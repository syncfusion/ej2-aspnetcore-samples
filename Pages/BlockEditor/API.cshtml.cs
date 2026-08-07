using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.BlockEditor;
using static EJ2CoreSampleBrowser.Models.BlockData;

namespace EJ2CoreSampleBrowser_NET9.Pages.BlockEditor
{
    public class APIModel : PageModel
    {
        public List<BlockModel> BlockDataAPI { get; set; }
        public void OnGet()
        {
            BlockDataAPI = new BlockData().GetBlockDataAPI();
        }
    }
}
