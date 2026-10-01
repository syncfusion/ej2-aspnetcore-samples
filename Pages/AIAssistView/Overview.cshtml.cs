using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.AIAssistView
{
    public class OverviewModel : PageModel
    {
        public List<ToolbarItemModel> ToolbarItems { get; set; } = new List<ToolbarItemModel>();
        public List<ToolbarItemModel> FooterToolbarItems { get; set; } = new List<ToolbarItemModel>();
        public List<ResponseToolbarItemModel> ResponseToolbarItems { get; set; } = new List<ResponseToolbarItemModel>();
        public List<PromptResponseData> PromptResponseData { get; set; }
        public string[] PromptSuggestionData { get; set; }

        public void OnGet()
        {
            PromptResponseData = new PromptResponseData().GetOverviewPromptResponseData();
            PromptSuggestionData = new string[] { "How do I plan my day for maximum focus?", "Generate content ideas for my website" };
            
            ToolbarItems.Add(new ToolbarItemModel { align = "Right", iconCss = "e-icons e-refresh", tooltip = "Start new chat" });
            
            FooterToolbarItems.Add(new ToolbarItemModel { iconCss = "e-icons e-assist-send", align = "Right" });
            FooterToolbarItems.Add(new ToolbarItemModel { iconCss = "e-icons e-assist-attachment-icon", align = "Left", tooltip = "Attach File" });
            FooterToolbarItems.Add(new ToolbarItemModel { iconCss = "e-icons e-assist-speech-to-text", align = "Left" });
            
            ResponseToolbarItems.Add(new ResponseToolbarItemModel { type = "Button", iconCss = "e-icons e-assist-copy", tooltip = "Copy" });
            ResponseToolbarItems.Add(new ResponseToolbarItemModel { type = "Button", iconCss = "e-icons e-assist-like", tooltip = "Like" });
            ResponseToolbarItems.Add(new ResponseToolbarItemModel { type = "Button", iconCss = "e-icons e-assist-dislike", tooltip = "Need Improvement" });
            ResponseToolbarItems.Add(new ResponseToolbarItemModel { type = "Button", iconCss = "e-icons e-assist-audio", tooltip = "Read Aloud" });
            ResponseToolbarItems.Add(new ResponseToolbarItemModel { type = "Button", iconCss = "e-icons e-assist-regenerate", tooltip = "Regenerate" });
        }
    }

    public class ResponseToolbarItemModel
    {
        public string type { get; set; }
        public string iconCss { get; set; }
        public string tooltip { get; set; }
    }
}
