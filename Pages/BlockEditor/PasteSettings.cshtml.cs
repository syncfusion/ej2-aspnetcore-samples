using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.BlockEditor;
using static EJ2CoreSampleBrowser.Models.BlockData;

namespace EJ2CoreSampleBrowser_NET9.Pages.BlockEditor
{
    public class PasteSettingsModel : PageModel
    {
        public List<BlockModel> BlockDataPaste { get; set; }
        public void OnGet()
        {
            BlockDataPaste = new BlockData().GetBlockDataPaste();
        }
    }
}
