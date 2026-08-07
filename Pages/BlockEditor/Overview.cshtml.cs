using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.BlockEditor;
using static EJ2CoreSampleBrowser.Models.BlockData;

namespace EJ2CoreSampleBrowser_NET9.Pages.BlockEditor
{
    public class OverviewModel : PageModel
    {
        public List<BlockModel> BlockDataOverview { get; set; }
        public List<UserModel> MentionUsers { get; set; }
        public string[] InlineToolbarItems { get; set; }
        public void OnGet()
        {
            BlockDataOverview = new BlockData().GetBlockDataOverview();
            MentionUsers = new BlockData().GetUniqueMentionUsers();
            InlineToolbarItems = new string[] { "Transform", "Bold", "Italic", "Underline", "StrikeThrough", "Uppercase", "Lowercase", "Subscript", "Superscript", "InlineCode", "Link", "Color", "Backgroundcolor" };
        }
    }
}
