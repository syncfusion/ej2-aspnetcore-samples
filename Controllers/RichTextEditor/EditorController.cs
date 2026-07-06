using System;
using System.Collections.Generic;
using System.Linq;
using EJ2CoreSampleBrowser.Helpers;
using EJ2CoreSampleBrowser.Services;
using EJ2CoreSampleBrowser_NET8.Pages.RichTextEditor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser_NET8.Controllers.RichTextEditor {
    [ApiController]
    [Route("api/[controller]")]
    public class EditorController: ControllerBase {
        private readonly EditorService _editorService;
        public EditorController(EditorService editorService)
        {
            _editorService=editorService;
        }

        [HttpPost("Stream")]
        public async Task Stream()
        {
            await _editorService.StreamResponseAsync(Request, Response);
        }
    }
}
