using System;
using System.Collections.Generic;
using System.Linq;
using EJ2CoreSampleBrowser.Helpers;
using EJ2CoreSampleBrowser.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class AIController: ControllerBase {
        private readonly AIService _aiService;
        public AIController(AIService aiService)
        {
            _aiService=aiService;
        }

        [HttpPost("Stream")]
        public async Task Stream([FromBody] ChatRequest request)
        {
            await _aiService.StreamAsync(request, HttpContext);
        }
    }
}
