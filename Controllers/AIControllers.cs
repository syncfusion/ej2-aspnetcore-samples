#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
