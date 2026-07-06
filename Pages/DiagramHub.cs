using Microsoft.AspNetCore.SignalR;
using EJ2CoreSampleBrowser.Services;
using EJ2CoreSampleBrowser.Models;
using System.Collections.Concurrent;
using System.Text.Json;

namespace EJ2SDiagramSample.Pages
{
    public class DiagramHub : Hub
    {
        private readonly IDiagramService _diagramService;
        private readonly IRedisService _redisService;
        private readonly ILogger<DiagramHub> _logger;
        private readonly IHubContext<DiagramHub> _diagramHubContext;
        private static long _userCount = 1;
        private static readonly ConcurrentDictionary<string, ConcurrentDictionary<string, DiagramUser>> _roomUsers = new(StringComparer.Ordinal);
        // per-room sequential user number generator (last issued)
        private static readonly ConcurrentDictionary<string, long> _roomNextUserNumber = new(StringComparer.Ordinal);

        public DiagramHub(
            IDiagramService diagramService, IRedisService redis,
            ILogger<DiagramHub> logger, IHubContext<DiagramHub> diagramHubContext)
        {
            _diagramService = diagramService;
            _redisService = redis;
            _logger = logger;
            _diagramHubContext = diagramHubContext;
        }

        public override Task OnConnectedAsync()
        {
            // Send session id to client.
            Clients.Caller.SendAsync("OnConnectedAsync", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        #region Cursor update
        private static string SelectionKey(string connectionId, string roomName) => $"diagram_{roomName}:selections_{connectionId}";

        public async Task UpdateSameElementHighlighterBounds(List<string> elementIds, SelectorBounds newBounds, string roomName)
        {
            // Get all users in the room from Redis
            var roomUsers = await GetCurrentUsersInRoomAsync(roomName);
            if (roomUsers.Count == 0)
                return;

            foreach (var user in roomUsers)
            {
                if (user.ConnectionId == Context.ConnectionId) continue;
                // Get current user's selection event from Redis
                SelectionEvent currentEvent = await _redisService.GetAsync<SelectionEvent>(SelectionKey(user.ConnectionId, roomName));
                if (currentEvent == null)
                    continue;
                if (currentEvent.ElementIds != null && currentEvent.ElementIds.ToHashSet().SetEquals(elementIds))
                {
                    if (!IsEqual(currentEvent.SelectorBounds?.Bounds, newBounds?.Bounds) || currentEvent.SelectorBounds?.RotationAngle != newBounds?.RotationAngle)
                    {
                        SelectionEvent updatedEvent = new SelectionEvent
                        {
                            ConnectionId = currentEvent.ConnectionId,
                            UserId = currentEvent.UserId,
                            UserName = currentEvent.UserName,
                            ElementIds = currentEvent.ElementIds,
                            TimestampUnixMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                            SelectorBounds = newBounds
                        };
                        await _redisService.SetAsync(SelectionKey(currentEvent.ConnectionId, roomName), updatedEvent);
                    }
                }
            }
        }
        private bool IsEqual(DiagramRect bounds1, DiagramRect bounds2)
        {
            return bounds1.X == bounds2.X && bounds1.Y == bounds2.Y && bounds1.Width == bounds2.Width && bounds1.Height == bounds2.Height;
        }
        public async Task SelectElements(List<string> elementIds, SelectorBounds selectorBounds)
        {
            string roomName = this.Context.Items["RoomName"].ToString();
            SelectionEvent evt = BuildSelectedElementEvent(elementIds, selectorBounds);
            await Clients.OthersInGroup(roomName).SendAsync("PeerSelectionChanged", evt);

            await _redisService.SetAsync(SelectionKey(Context.ConnectionId, roomName), evt);
        }
        private SelectionEvent BuildSelectedElementEvent(List<string> elementIds, SelectorBounds selectorBounds)
        {
            return new SelectionEvent
            {
                ConnectionId = Context.ConnectionId,
                UserId = Context.Items["UserId"]?.ToString(),
                UserName = Context.Items["UserName"]?.ToString(),
                ElementIds = elementIds ?? new(),
                TimestampUnixMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                SelectorBounds = selectorBounds
            };
        }
        private SelectionEvent BuildClearSelectionEvent()
        {
            SelectionEvent evt = new SelectionEvent
            {
                ConnectionId = Context.ConnectionId,
                UserId = Context.Items["UserId"]?.ToString(),
                UserName = Context.Items["UserName"]?.ToString(),
                ElementIds = new(),
                SelectorBounds = new()
            };
            return evt;
        }
        public async Task ClearSelection()
        {
            string roomName = this.Context.Items["RoomName"].ToString();
            SelectionEvent evt = BuildClearSelectionEvent();
            await Clients.OthersInGroup(roomName).SendAsync("PeerSelectionCleared", evt);
            await _redisService.DeleteAsync(SelectionKey(Context.ConnectionId, roomName));
        }
        public async Task ClearSelectionForAll()
        {
            string roomName = this.Context.Items["RoomName"].ToString();
            await Clients.Group(roomName).SendAsync("ClearAllSelection");
            List<SelectionEvent> availableSelections = await _redisService.GetByPatternAsync<SelectionEvent>($"diagram_{roomName}:selections_*");
            foreach (SelectionEvent selection in availableSelections)
            {
                await _redisService.DeleteAsync(SelectionKey(selection.ConnectionId, roomName));
            }
        }
        public async Task SendCurrentSelectionsToCaller(string roomName)
        {
            List<SelectionEvent> map = await _redisService.GetByPatternAsync<SelectionEvent>($"diagram_{roomName}:selections_*");
            if (map.Count > 0)
                await Clients.Caller.SendAsync("PeerSelectionsBootstrap", map);
        }
        #endregion

        private static readonly ConcurrentDictionary<string, SemaphoreSlim> _connLocks = new();

        private static SemaphoreSlim GetConnectionLock(string connectionId)
        {
            return _connLocks.GetOrAdd(connectionId, _ => new SemaphoreSlim(1, 1));
        }
        public async Task BroadcastToOtherClients(List<string> payloads, long clientVersion, List<string>? elementIds, SelectionEvent currentSelection, string roomName)
        {
            string connId = Context.ConnectionId;
            SemaphoreSlim gate = GetConnectionLock(connId);
            await gate.WaitAsync();
            try
            {
                string versionKey = $"diagram_{roomName}:version";

                (bool acceptedSingle, long serverVersionSingle) = await _redisService.CompareAndIncrementAsync(versionKey, clientVersion);
                long serverVersionFinal = serverVersionSingle;

                if (!acceptedSingle)
                {
                    IReadOnlyList<DiagramUpdateMessage> recentUpdates = await GetUpdatesSinceVersionAsync(clientVersion, roomName, maxScan: 200);
                    HashSet<string> recentlyTouched = new HashSet<string>(StringComparer.Ordinal);
                    foreach (DiagramUpdateMessage upd in recentUpdates)
                    {
                        if (upd.ModifiedElementIds == null) continue;
                        foreach (string id in upd.ModifiedElementIds)
                            recentlyTouched.Add(id);
                    }

                    List<string> overlaps = elementIds?.Where(id => recentlyTouched.Contains(id)).Distinct().ToList();
                    if (overlaps?.Count > 0)
                    {
                        await Clients.Caller.SendAsync("RevertCurrentChanges", elementIds);
                        await Clients.Caller.SendAsync("ShowConflict");
                        return;
                    }

                    (bool _, long newServerVersion) = await _redisService.CompareAndIncrementAsync(versionKey, serverVersionSingle);
                    serverVersionFinal = newServerVersion;
                }

                DiagramUpdateMessage update = new DiagramUpdateMessage
                {
                    SourceConnectionId = connId,
                    Version = serverVersionFinal,
                    ModifiedElementIds = elementIds
                };

                await StoreUpdateInRedis(update, connId, roomName);
                SelectionEvent selectionEvent = BuildSelectedElementEvent(currentSelection.ElementIds, currentSelection.SelectorBounds);
                await UpdateSelectionBoundsInRedis(selectionEvent, currentSelection.ElementIds, currentSelection.SelectorBounds, roomName);
                await Clients.Caller.SendAsync("UpdateVersion", serverVersionFinal);
                await Clients.OthersInGroup(roomName).SendAsync("ReceiveData", payloads, serverVersionFinal, selectionEvent);
                await RemoveOldUpdates(serverVersionFinal, roomName);
            }
            finally
            {
                gate.Release();
            }
        }
        private async Task RemoveOldUpdates(long currentServerVersion, string roomName)
        {
            // Keep only versions > (finalVersion - window)
            int historyKeepWindow = 2;
            long minVersionToKeep = Math.Max(0, currentServerVersion - historyKeepWindow);
            await TrimHistoryFullScanAsync(minVersionToKeep, roomName);
        }
        private async Task TrimHistoryFullScanAsync(long minVersionToKeep, string roomName)
        {
            string HISTORY_KEY = $"diagram_{roomName}_updates_history";
            long length = await _redisService.ListLengthAsync(HISTORY_KEY);
            if (length <= 0) return;

            StackExchange.Redis.RedisValue[] all = await _redisService.ListRangeAsync(HISTORY_KEY, 0, -1);
            if (all == null || all.Length == 0)
            {
                await _redisService.DeleteAsync(HISTORY_KEY);
                return;
            }

            int cutIndex = -1;
            for (int i = 0; i < all.Length; i++)
            {
                StackExchange.Redis.RedisValue item = all[i];
                if (item.IsNullOrEmpty) continue;

                try
                {
                    DiagramUpdateMessage? update = JsonSerializer.Deserialize<DiagramUpdateMessage>(item.ToString());
                    if (update != null && update.Version <= minVersionToKeep)
                    {
                        cutIndex = i;
                        break;
                    }
                }
                catch
                {
                }
            }

            if (cutIndex == -1)
            {
                return;
            }
            if (cutIndex == 0)
            {
                await _redisService.DeleteAsync(HISTORY_KEY);
                return;
            }
            await _redisService.ListTrimAsync(HISTORY_KEY, 0, cutIndex - 1);

        }
        private async Task<IReadOnlyList<DiagramUpdateMessage>> GetUpdatesSinceVersionAsync(long sinceVersion, string roomName, int maxScan = 200)
        {
            string historyKey = $"diagram_{roomName}_updates_history";
            long length = await _redisService.ListLengthAsync(historyKey);
            if (length == 0) return Array.Empty<DiagramUpdateMessage>();

            long start = Math.Max(0, length - maxScan);
            long end = length - 1;

            StackExchange.Redis.RedisValue[] range = await _redisService.ListRangeAsync(historyKey, start, end);

            List<DiagramUpdateMessage> results = new List<DiagramUpdateMessage>(range.Length);
            foreach (StackExchange.Redis.RedisValue item in range)
            {
                if (item.IsNullOrEmpty) continue;
                try
                {
                    DiagramUpdateMessage? update = JsonSerializer.Deserialize<DiagramUpdateMessage>(item.ToString());
                    if (update is not null && update.Version > sinceVersion && update.SourceConnectionId != Context.ConnectionId)
                        results.Add(update);
                }
                catch
                {
                    // ignore malformed entries
                }
            }
            results.Sort((a, b) => a.Version.CompareTo(b.Version));
            return results;
        }
        private async Task StoreUpdateInRedis(DiagramUpdateMessage updateMessage, string userId, string roomName)
        {
            try
            {
                // Store in updates history list
                string historyKey = $"diagram_{roomName}_updates_history";
                await _redisService.ListPushAsync(historyKey, updateMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error storing update in Redis for diagram");
            }
        }
        private async Task UpdateSelectionBoundsInRedis(SelectionEvent evt, List<string> elementIds, SelectorBounds selectorBounds, string roomName)
        {
            await _redisService.SetAsync(SelectionKey(Context.ConnectionId, roomName), evt);
            await UpdateSameElementHighlighterBounds(elementIds, selectorBounds, roomName);
        }
        private static readonly ConcurrentDictionary<string, TaskCompletionSource<string>> _pendingStateRequests = new(StringComparer.Ordinal);

        public Task ProvideDiagramState(string requestId, string jsonData)
        {
            if (_pendingStateRequests.TryRemove(requestId, out TaskCompletionSource<string>? tcs))
            {
                tcs.TrySetResult(jsonData);
            }
            return Task.CompletedTask;
        }
        private async Task RequestAndLoadStateAsync(string roomName, string diagramId, string replyToConnectionId, CancellationToken connectionAborted)
        {
            string requestId = Guid.NewGuid().ToString("N");
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
            _pendingStateRequests[requestId] = tcs;

            try
            {
                await Clients.OthersInGroup(roomName)
                    .SendAsync("OnSaveDiagramState", requestId, cancellationToken: connectionAborted);
            }
            catch (OperationCanceledException)
            {
                _pendingStateRequests.TryRemove(requestId, out _);
                return; // caller disconnected
            }

            const int timeoutMs = 3000;
            string? json = null;
            try
            {
                Task<string> responseTask = tcs.Task;
                Task completed = await Task.WhenAny(responseTask, Task.Delay(timeoutMs, connectionAborted));
                if (completed == responseTask)
                {
                    json = await responseTask;
                }
                // else: timed out or caller disconnected
            }
            finally
            {
                _pendingStateRequests.TryRemove(requestId, out _);
            }

            if (!string.IsNullOrEmpty(json))
            {
                string savedBy = replyToConnectionId;
                await _diagramService.SaveDiagramDataAsync(diagramId, roomName, json, savedBy);

                await _diagramHubContext.Clients.Client(replyToConnectionId).SendAsync("LoadDiagramData", new DiagramData
                {
                    DiagramId = diagramId,
                    Data = json,
                    Version = await GetDiagramVersion(roomName)
                }, cancellationToken: connectionAborted);
                return;
            }
            DiagramData? data = await _diagramService.GetDiagramAsync(diagramId, roomName);
            if (data != null && !string.IsNullOrEmpty(data.Data))
            {
                await _diagramHubContext.Clients.Client(replyToConnectionId).SendAsync("LoadDiagramData", new DiagramData
                {
                    DiagramId = data.DiagramId,
                    Data = data.Data,
                    Version = data.Version
                }, cancellationToken: connectionAborted);
            }
        }
        public async Task JoinDiagram(string roomName, string diagramId, string? userName)
        {
            try
            {
                string userId = Context.ConnectionId;
                // Remove any previous presence of this connection from other rooms
                foreach (var roomData in _roomUsers)
                {
                    var room = roomData.Key;
                    var clients = roomData.Value;
                    if (clients.TryRemove(userId, out var _))
                    {
                        await Groups.RemoveFromGroupAsync(userId, room);
                        _logger.LogInformation("Removed existing connection for user {UserId} from room {Room} before adding new one", userId, room);
                    }
                }

                // Add to SignalR group
                await Groups.AddToGroupAsync(userId, roomName);

                // Store connection context
                Context.Items["DiagramId"] = diagramId;
                Context.Items["UserId"] = userId;
                Context.Items["RoomName"] = roomName;

                // Check existing users in Redis (cross-server consistent)
                var existingRoomUsersCount = await GetRoomUserCountAsync(roomName);
                if (existingRoomUsersCount == 0)
                {
                    await ClearConnectionsFromRedis(roomName);
                    await ResetRoomCountersAsync(roomName);
                }

                // Track user in diagram - use Redis counter for cross-server consistency
                if (string.IsNullOrEmpty(userName))
                {
                    long next = await GetNextUserNumberAsync(roomName);
                    userName = next.ToString();
                }
                Context.Items["UserName"] = userName;
                DiagramUser diagramUser = new DiagramUser
                {
                    ConnectionId = Context.ConnectionId,
                    UserName = userName,
                };

                // Store in Redis and local cache
                await AddUserToRoomAsync(roomName, userId, diagramUser);

                await RequestAndLoadStateAsync(roomName, diagramId, Context.ConnectionId, Context.ConnectionAborted);

                long currentServerVersion = await GetDiagramVersion(roomName);
                await Clients.Caller.SendAsync("UpdateVersion", currentServerVersion);
                await Clients.OthersInGroup(roomName).SendAsync("UserJoined", userName);
                await SendCurrentSelectionsToCaller(roomName);
                List<string> activeUsers = await GetCurrentUsersAsync(roomName);
                await Clients.Group(roomName).SendAsync("CurrentUsers", activeUsers);
                var totalUsers = await GetRoomUserCountAsync(roomName);
                _logger.LogInformation("User {UserId} ({UserName}) joined diagram {DiagramId}. Room users: {UserCount}", userId, userName, diagramId, totalUsers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error joining diagram {DiagramId} for user {UserId}", diagramId, Context.ConnectionId);
                await Clients.Caller.SendAsync("JoinError", "Failed to join diagram");
            }
        }
        private async Task<List<string>> GetCurrentUsersAsync(string roomName)
        {
            var usersKey = $"diagram_{roomName}:users";
            var users = await _redisService.GetByPatternAsync<DiagramUser>($"{usersKey}:*");
            return users.Select(u => u.UserName).ToList();
        }

        private async Task<List<DiagramUser>> GetCurrentUsersInRoomAsync(string roomName)
        {
            var usersKey = $"diagram_{roomName}:users";
            return await _redisService.GetByPatternAsync<DiagramUser>($"{usersKey}:*");
        }
        public async Task LoadDiagram(string data)
        {
            string roomName = Context.Items["RoomName"]?.ToString();
            DiagramData dataToSend = new DiagramData
            {
                Data = data,
                Version = await GetDiagramVersion(roomName)
            };
            await Clients.OthersInGroup(roomName).SendAsync("LoadDiagramData", dataToSend);
        }
        private async Task<long> GetNextUserNumberAsync(string roomName)
        {
            string counterKey = $"diagram_{roomName}:user_counter";
            return await _redisService.IncrementAsync(counterKey);
        }

        private async Task AddUserToRoomAsync(string roomName, string connectionId, DiagramUser user)
        {
            string userKey = $"diagram_{roomName}:users:{connectionId}";
            await _redisService.SetAsync(userKey, user);

            var roomDict = _roomUsers.GetOrAdd(roomName, _ => new ConcurrentDictionary<string, DiagramUser>(StringComparer.Ordinal));
            roomDict[connectionId] = user;
        }

        private async Task<bool> RemoveUserFromRoomAsync(string roomName, string connectionId)
        {
            var userKey = $"diagram_{roomName}:users:{connectionId}";
            await _redisService.DeleteAsync(userKey);

            // Remove from local cache
            if (_roomUsers.TryGetValue(roomName, out var roomDict))
            {
                return roomDict.TryRemove(connectionId, out _);
            }
            return false;
        }

        private async Task<int> GetRoomUserCountAsync(string roomName)
        {
            List<DiagramUser> users = await _redisService.GetByPatternAsync<DiagramUser>($"diagram_{roomName}:users:*");
            return users.Count;
        }

        private async Task ResetRoomCountersAsync(string roomName)
        {
            string counterKey = $"diagram_{roomName}:user_counter";
            await _redisService.DeleteAsync(counterKey);
            _roomNextUserNumber.TryRemove(roomName, out _);
        }
        public async Task<long> GetDiagramVersion(string roomName)
        {
            string versionKey = $"diagram_{roomName}:version";
            // Use CAS with expected = -1 to read current version without incrementing
            (bool _, long currentVersion) = await _redisService.CompareAndIncrementAsync(versionKey, -1);
            return currentVersion; // 0 if not set
        }
        public async Task ClearConnectionsFromRedis(string roomName)
        {
            try
            {
                string diagramId = Context.Items["DiagramId"].ToString();
                string diagramUpdateHistoryKey = $"diagram_{roomName}_updates_history";
                string diagramVersionKey = $"diagram_{roomName}:version";
                string? userId = Context.Items["UserId"]?.ToString();

                await _diagramService.SaveDiagramDataAsync(diagramId, roomName, string.Empty, userId);
                await _redisService.DeleteAsync(diagramUpdateHistoryKey);
                await _redisService.DeleteAsync(diagramVersionKey);

                List<SelectionEvent> availableSelections = await _redisService.GetByPatternAsync<SelectionEvent>($"diagram_{roomName}:selections_*");
                foreach (SelectionEvent selection in availableSelections)
                {
                    await _redisService.DeleteAsync(SelectionKey(selection.ConnectionId, roomName));
                }

                _logger.LogInformation("Clients removed from redis.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error clearing diagram-related Redis data");
                throw;
            }
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            try
            {
                string roomName = Context.Items["RoomName"]?.ToString();
                string userName = Context.Items["UserName"]?.ToString();

                await Clients.OthersInGroup(roomName)
                                        .SendAsync("PeerSelectionCleared", new SelectionEvent
                                        {
                                            ConnectionId = Context.ConnectionId,
                                            ElementIds = new()
                                        });
                await Clients.OthersInGroup(roomName).SendAsync("UserLeft", userName);

                // Remove from SignalR group
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
                await _redisService.DeleteAsync(SelectionKey(Context.ConnectionId, roomName));

                if (!string.IsNullOrEmpty(roomName))
                {
                    await RemoveUserFromRoomAsync(roomName, Context.ConnectionId);

                    // Check if room is now empty and reset counters
                    var remainingUsers = await GetRoomUserCountAsync(roomName);
                    if (remainingUsers == 0)
                    {
                        await ResetRoomCountersAsync(roomName);
                        _roomUsers.TryRemove(roomName, out _);
                    }
                }
                List<string> activeUsers = await GetCurrentUsersAsync(roomName);
                await Clients.Group(roomName).SendAsync("CurrentUsers", activeUsers);
                // Clear context
                Context.Items.Remove("DiagramId");
                Context.Items.Remove("UserId");
                Context.Items.Remove("UserName");
                await base.OnDisconnectedAsync(exception);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during disconnect cleanup for connection {ConnectionId}", Context.ConnectionId);
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}