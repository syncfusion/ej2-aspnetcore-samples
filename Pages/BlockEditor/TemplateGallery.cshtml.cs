#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.BlockEditor;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using static EJ2CoreSampleBrowser.Models.BlockData;

namespace EJ2CoreSampleBrowser_NET9.Pages.BlockEditor
{
    public class TemplateGalleryModel : PageModel
    {
        public List<BlockModel> InitialBlocks { get; set; }
        public string TemplatePagesJson { get; set; }

        public void OnGet()
        {
            var data = new BlockData();
            InitialBlocks = data.GetInitialTemplateBlocks();
            TemplatePagesJson = data.GetTemplatePagesJson();
        }

    }
}
