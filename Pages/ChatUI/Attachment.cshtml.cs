using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
using Syncfusion.EJ2.InteractiveChat;

namespace EJ2CoreSampleBrowser.Pages.ChatUI
{
    public class AttachmentModel : PageModel
    {
        public List<ToolbarItemModel> HeaderToolbar { get; set; } = new List<ToolbarItemModel>();
        public void OnGet()
        {
            HeaderToolbar.Add(new ToolbarItemModel { iconCss = "e-icons e-refresh", align = "Right", tooltip = "Clear Chat" });
        }

        public class ToolbarItemModel
        {
            public string iconCss { get; set; }
            public string tooltip { get; set; }
            public string align { get; set; }
        }
    }
}
