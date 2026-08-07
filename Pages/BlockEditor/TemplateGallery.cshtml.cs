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
