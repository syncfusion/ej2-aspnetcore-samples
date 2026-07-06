using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser_NET8.Pages.AIAssistView
{
    public class Ai_Text_To_SpeechModel : PageModel
    {
        public List<ToolbarItemModels> Items { get; set; } = new List<ToolbarItemModels>();
        public List<ResponseToolbarItemModel> ResponseToolbarItems { get; set; } = new List<ResponseToolbarItemModel>();
        public string[] Suggestions { get; set; }

        public void OnGet()
        {
            Items.Add(new ToolbarItemModels { align = "Right", iconCss = "e-icons e-refresh" });

            // Response toolbar items
            ResponseToolbarItems.Add(new ResponseToolbarItemModel { type = "Button", iconCss = "e-icons e-assist-copy", tooltip = "Copy" });
            ResponseToolbarItems.Add(new ResponseToolbarItemModel { type = "Button", iconCss = "e-icons e-assist-audio", tooltip = "Read Aloud" });
            ResponseToolbarItems.Add(new ResponseToolbarItemModel { type = "Button", iconCss = "e-icons e-assist-like", tooltip = "Like" });
            ResponseToolbarItems.Add(new ResponseToolbarItemModel { type = "Button", iconCss = "e-icons e-assist-dislike", tooltip = "Need Improvement" });

        }
    }

    public class ToolbarItemModels
    {
        public string align { get; set; }
        public string iconCss { get; set; }
    }

    public class ResponseToolbarItemModel
    {
        public string type { get; set; }
        public string iconCss { get; set; }
        public string tooltip { get; set; }
    }

}