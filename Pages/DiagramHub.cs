#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.SignalR;
using EJ2CoreSampleBrowser.Services;
using EJ2CoreSampleBrowser.Models;
using System.Collections.Concurrent;
using Newtonsoft.Json;

namespace EJ2SDiagramSample.Pages
{
    public class DiagramHub : Hub
    {
        private readonly IDiagramService _diagramService;
        private readonly IRedisService _redisService;
        private readonly ILogger<DiagramHub> _logger;
        private readonly IHubContext<DiagramHub> _diagramHubContext;
        private static readonly ConcurrentDictionary<string, DiagramUser> _diagramUsers = new();

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
        private static string SelectionKey(string connectionId) => $"diagram:selections_{connectionId}";

        public async Task UpdateSameElementHighlighterBounds(List<string> elementIds, SelectorBounds newBounds)
        {
            foreach (string connectionId in _diagramUsers.Keys)
            {
                if (connectionId == Context.ConnectionId) continue;
                // Get current user's selection event from Redis
                var currentEvent = await _redisService.GetAsync<SelectionEvent>(SelectionKey(connectionId));
                if (currentEvent == null)
                    return;
                if (currentEvent.ElementIds != null && currentEvent.ElementIds.ToHashSet().SetEquals(elementIds))
                {
                    if (!IsEqual(currentEvent.SelectorBounds?.Bounds, newBounds.Bounds) || currentEvent.SelectorBounds.RotationAngle != newBounds.RotationAngle)
                    {
                        var updatedEvent = new SelectionEvent
                        {
                            ConnectionId = currentEvent.ConnectionId,
                            UserId = currentEvent.UserId,
                            UserName = currentEvent.UserName,
                            ElementIds = currentEvent.ElementIds,
                            TimestampUnixMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                            SelectorBounds = newBounds
                        };
                        await _redisService.SetAsync(SelectionKey(Context.ConnectionId), updatedEvent);
                    }
                }
            }
        }
        private bool IsEqual(EJ2CoreSampleBrowser.Models.DiagramRect bounds1, EJ2CoreSampleBrowser.Models.DiagramRect bounds2)
        {
            return bounds1.X == bounds2.X && bounds1.Y == bounds2.Y && bounds1.Width == bounds2.Width && bounds1.Height == bounds2.Height;
        }
        public async Task SelectElements(List<string> elementIds, SelectorBounds selectorBounds)
        {
            SelectionEvent evt = BuildSelectedElementEvent(elementIds, selectorBounds);
            await Clients.OthersInGroup("diagram_group").SendAsync("PeerSelectionChanged", evt);

            await _redisService.SetAsync(SelectionKey(Context.ConnectionId), evt);
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
            SelectionEvent evt = BuildClearSelectionEvent();
            await Clients.OthersInGroup("diagram_group").SendAsync("PeerSelectionCleared", evt);
            await _redisService.DeleteAsync(SelectionKey(Context.ConnectionId));
        }
        public async Task SendCurrentSelectionsToCaller()
        {
            var map = await _redisService.GetByPatternAsync<SelectionEvent>("diagram:selections_*");
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
            var connId = Context.ConnectionId;
            var gate = GetConnectionLock(connId);
            await gate.WaitAsync();
            try
            {
                var versionKey = "diagram:version";

                var (acceptedSingle, serverVersionSingle) = await _redisService.CompareAndIncrementAsync(versionKey, clientVersion);
                long serverVersionFinal = serverVersionSingle;

                if (!acceptedSingle)
                {
                    var recentUpdates = await GetUpdatesSinceVersionAsync(clientVersion, maxScan: 200);
                    var recentlyTouched = new HashSet<string>(StringComparer.Ordinal);
                    foreach (var upd in recentUpdates)
                    {
                        if (upd.ModifiedElementIds == null) continue;
                        foreach (var id in upd.ModifiedElementIds)
                            recentlyTouched.Add(id);
                    }

                    var overlaps = elementIds?.Where(id => recentlyTouched.Contains(id)).Distinct().ToList();
                    if (overlaps?.Count > 0)
                    {
                        await Clients.Caller.SendAsync("RevertCurrentChanges", elementIds);
                        await Clients.Caller.SendAsync("ShowConflict");
                        return;
                    }

                    var (_, newServerVersion) = await _redisService.CompareAndIncrementAsync(versionKey, serverVersionSingle);
                    serverVersionFinal = newServerVersion;
                }

                var update = new DiagramUpdateMessage
                {
                    SourceConnectionId = connId,
                    Version = serverVersionFinal,
                    ModifiedElementIds = elementIds
                };

                await StoreUpdateInRedis(update, connId);
                SelectionEvent selectionEvent = BuildSelectedElementEvent(currentSelection.ElementIds, currentSelection.SelectorBounds);
                await UpdateSelectionBoundsInRedis(selectionEvent, currentSelection.ElementIds, currentSelection.SelectorBounds);
                await Clients.OthersInGroup(roomName).SendAsync("ReceiveData", payloads, serverVersionFinal, selectionEvent);
                await RemoveOldUpdates(serverVersionFinal);
            }
            finally
            {
                gate.Release();
            }
        }
        private async Task RemoveOldUpdates(long currentServerVersion)
        {
            // Keep only versions > (finalVersion - window)
            int historyKeepWindow = 2;
            var minVersionToKeep = Math.Max(0, currentServerVersion - historyKeepWindow);
            await TrimHistoryFullScanAsync(minVersionToKeep);
        }
        private async Task TrimHistoryFullScanAsync(long minVersionToKeep)
        {
            string HISTORY_KEY = "diagram_updates_history";
            var length = await _redisService.ListLengthAsync(HISTORY_KEY);
            if (length <= 0) return;

            var all = await _redisService.ListRangeAsync(HISTORY_KEY, 0, -1);
            if (all == null || all.Length == 0)
            {
                await _redisService.DeleteAsync(HISTORY_KEY);
                return;
            }

            int cutIndex = -1;
            for (int i = 0; i < all.Length; i++)
            {
                var item = all[i];
                if (item.IsNullOrEmpty) continue;

                try
                {
                    var update = JsonConvert.DeserializeObject<DiagramUpdateMessage>(item.ToString());
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
        private async Task<IReadOnlyList<DiagramUpdateMessage>> GetUpdatesSinceVersionAsync(long sinceVersion, int maxScan = 200)
        {
            var historyKey = "diagram_updates_history";
            var length = await _redisService.ListLengthAsync(historyKey);
            if (length == 0) return Array.Empty<DiagramUpdateMessage>();

            long start = Math.Max(0, length - maxScan);
            long end = length - 1;

            var range = await _redisService.ListRangeAsync(historyKey, start, end);

            var results = new List<DiagramUpdateMessage>(range.Length);
            foreach (var item in range)
            {
                if (item.IsNullOrEmpty) continue;
                try
                {
                    var update = JsonConvert.DeserializeObject<DiagramUpdateMessage>(item.ToString());
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
        private async Task StoreUpdateInRedis(DiagramUpdateMessage updateMessage, string userId)
        {
            try
            {
                // Store in updates history list
                var historyKey = "diagram_updates_history";
                await _redisService.ListPushAsync(historyKey, updateMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error storing update in Redis for diagram");
            }
        }
        private async Task UpdateSelectionBoundsInRedis(SelectionEvent evt, List<string> elementIds, SelectorBounds selectorBounds)
        {
            await _redisService.SetAsync(SelectionKey(Context.ConnectionId), evt);
            await UpdateSameElementHighlighterBounds(elementIds, selectorBounds);
        }
        private static readonly ConcurrentDictionary<string, TaskCompletionSource<string>> _pendingStateRequests = new(StringComparer.Ordinal);

        public Task ProvideDiagramState(string requestId, string jsonData)
        {
            if (_pendingStateRequests.TryRemove(requestId, out var tcs))
            {
                tcs.TrySetResult(jsonData);
            }
            return Task.CompletedTask;
        }
        private async Task RequestAndLoadStateAsync(string roomName, string diagramId, string replyToConnectionId, CancellationToken connectionAborted)
        {
            var requestId = Guid.NewGuid().ToString("N");
            var tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
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
                var responseTask = tcs.Task;
                var completed = await Task.WhenAny(responseTask, Task.Delay(timeoutMs, connectionAborted));
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
                var savedBy = replyToConnectionId;
                await _diagramService.SaveDiagramDataAsync(diagramId, json, savedBy);

                await _diagramHubContext.Clients.Client(replyToConnectionId).SendAsync("LoadDiagramData", new DiagramData
                {
                    DiagramId = diagramId,
                    Data = json,
                    Version = await GetDiagramVersion()
                }, cancellationToken: connectionAborted);
                return;
            }
            var data = await _diagramService.GetDiagramAsync(diagramId);
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
        public async Task JoinDiagram(string roomName, string diagramId, string userName)
        {
            try
            {
                string userId = Context.ConnectionId;
                if (_diagramUsers.TryGetValue(userId, out var existingUser))
                {
                    if (existingUser != null)
                    {
                        _diagramUsers.TryRemove(userId, out _);
                        await Groups.RemoveFromGroupAsync(userId, roomName);
                        _logger.LogInformation("Removed existing connection for user {UserId} before adding new one", userId);
                    }
                }

                // Add to SignalR group
                await Groups.AddToGroupAsync(userId, roomName);

                // Store connection context
                Context.Items["DiagramId"] = diagramId;
                Context.Items["UserId"] = userId;
                Context.Items["UserName"] = userName;
                Context.Items["RoomName"] = roomName;

                // Track user in diagram
                var diagramUser = new DiagramUser
                {
                    ConnectionId = Context.ConnectionId,
                    UserName = userName,
                };
                bool userExists = _diagramUsers?.Count > 0;
                if (!userExists)
                    await ClearConnectionsFromRedis();
                _diagramUsers.AddOrUpdate(userId, diagramUser,
                    (key, existingValue) => diagramUser
                );
                await RequestAndLoadStateAsync(roomName,diagramId,Context.ConnectionId,Context.ConnectionAborted);

                long currentServerVersion = await GetDiagramVersion();
                await Clients.Caller.SendAsync("UpdateVersion", currentServerVersion);
                await Clients.OthersInGroup(roomName).SendAsync("UserJoined", userName);
                await SendCurrentSelectionsToCaller();
                List<string> activeUsers = GetCurrentUsers();
                await Clients.Group(roomName).SendAsync("CurrentUsers", activeUsers);
                _logger.LogInformation("User {UserId} ({UserName}) joined diagram {DiagramId}. Total users: {UserCount}", userId, userName, diagramId, _diagramUsers.Count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error joining diagram {DiagramId} for user {UserId}", diagramId, Context.ConnectionId);
                await Clients.Caller.SendAsync("JoinError", "Failed to join diagram");
            }
        }
        private List<string> GetCurrentUsers()
        {
            List<string> users = new();
            foreach (DiagramUser userData in _diagramUsers.Values)
            {
                users.Add(userData.UserName);
            }
            return users;
        }
        public async Task<long> GetDiagramVersion()
        {
            var versionKey = "diagram:version";
            // Use CAS with expected = -1 to read current version without incrementing
            var (_, currentVersion) = await _redisService.CompareAndIncrementAsync(versionKey, -1);
            return currentVersion; // 0 if not set
        }
        public async Task ClearConnectionsFromRedis()
        {
            try
            {
                string diagramId = Context.Items["DiagramId"].ToString();
                string diagramUpdateHistoryKey = "diagram_updates_history";
                string diagramVersionKey = "diagram:version";
                var userId = Context.Items["UserId"]?.ToString();

                await _diagramService.SaveDiagramDataAsync(diagramId, string.Empty, userId);
                await _redisService.DeleteAsync(diagramUpdateHistoryKey);
                await _redisService.DeleteAsync(diagramVersionKey);

                var availableSelections = await _redisService.GetByPatternAsync<SelectionEvent>("diagram:selections_*");
                foreach (var selection in availableSelections)
                {
                    await _redisService.DeleteAsync(SelectionKey(selection.ConnectionId));
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
                await _redisService.DeleteAsync(SelectionKey(Context.ConnectionId));

                // Remove from diagram users tracking
                if (_diagramUsers.TryGetValue(Context.ConnectionId, out var user))
                {
                    if (user != null)
                        _diagramUsers.TryRemove(Context.ConnectionId, out _);
                }
                List<string> activeUsers = GetCurrentUsers();
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