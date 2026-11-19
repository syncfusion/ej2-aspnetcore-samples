using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
using System.Text.Json;

namespace EJ2CoreSampleBrowser.Pages.AIAssistView
{
    public class GenerativeUIModel : PageModel
    {
        public List<ToolbarItemModel> ToolbarItems { get; set; } = new List<ToolbarItemModel>();
        public List<ResponseToolbarItemModel> ResponseToolbarItems { get; set; } = new List<ResponseToolbarItemModel>();
        public string[] PromptSuggestionData { get; set; }
        public BlockDataContainer BlockData { get; set; }

        public void OnGet()
        {
            PromptSuggestionData = new string[] { "What is the weather in New York?", "Can you show smartphone sales by region in a table?" };
            
            var promptResponseData = new PromptResponseData();
            BlockData = promptResponseData.GetGenerativeUIBlockData();

            ToolbarItems.Add(new ToolbarItemModel { align = "Right", iconCss = "e-icons e-refresh", tooltip = "Start new chat" });

            ResponseToolbarItems.Add(new ResponseToolbarItemModel { type = "Button", iconCss = "e-icons e-assist-copy", tooltip = "Copy" });
            ResponseToolbarItems.Add(new ResponseToolbarItemModel { type = "Button", iconCss = "e-icons e-assist-like", tooltip = "Like" });
            ResponseToolbarItems.Add(new ResponseToolbarItemModel { type = "Button", iconCss = "e-icons e-assist-dislike", tooltip = "Need Improvement" });
        }
    }
}
