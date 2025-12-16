#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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

        public async Task<DiagramData?> GetDiagramAsync(string diagramId)
        {
            try
            {
                var key = $"{DIAGRAM_KEY_PREFIX}{diagramId}";
                var diagramData = await _redis.GetAsync<DiagramData>(key);

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
        public async Task<bool> SaveDiagramDataAsync(string diagramId, string data, string userId)
        {
            try
            {
                var diagramData = new DiagramData
                {
                    DiagramId = diagramId,
                    Data = data,
                };

                var key = $"{DIAGRAM_KEY_PREFIX}{diagramId}";
                var success = await _redis.SetAsync(key, diagramData);

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