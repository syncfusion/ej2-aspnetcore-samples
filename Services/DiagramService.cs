using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Services
{
    public class DiagramService : IDiagramService
    {
        private readonly IRedisService _redis;
        private readonly ILogger<DiagramService> _logger;

        private const string DIAGRAM_KEY_PREFIX = "diagramData:";

        public DiagramService(IRedisService redis, ILogger<DiagramService> logger)
        {
            _redis = redis;
            _logger = logger;
        }

        public async Task<DiagramData?> GetDiagramAsync(string diagramId, string roomName)
        {
            try
            {
                string key = $"{DIAGRAM_KEY_PREFIX}_{roomName}_{diagramId}";
                DiagramData? diagramData = await _redis.GetAsync<DiagramData>(key);

                if (diagramData != null)
                {
                    _logger.LogDebug("Retrieved diagram {DiagramId}", diagramId);
                }

                return diagramData;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving diagram {DiagramId}", diagramId);
                return null;
            }
        }
        public async Task<bool> SaveDiagramDataAsync(string diagramId, string roomName, string data, string userId)
        {
            try
            {
                DiagramData diagramData = new DiagramData
                {
                    DiagramId = diagramId,
                    Data = data,
                };

                string key = $"{DIAGRAM_KEY_PREFIX}_{roomName}_{diagramId}";
                bool success = await _redis.SetAsync(key, diagramData);

                if (success)
                {
                    _logger.LogInformation($"Saved diagram by user {userId} with provided data");
                }

                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving diagram {DiagramId}", diagramId);
                return false;
            }
        }
    }
}