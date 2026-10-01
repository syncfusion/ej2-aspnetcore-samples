using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.AIAssistView
{
    public class AITelemetryModel : PageModel
    {
        public List<ToolbarItemModel> Items { get; set; } = new List<ToolbarItemModel>();
        public List<PromptResponseData> PromptResponseData { get; set; }
        public string[] PromptSuggestionData { get; set; }

        public void OnGet()
        {
            PromptResponseData = new PromptResponseData().GetAllPromptResponseData();
            PromptSuggestionData = new PromptResponseData().GetAllSuggestionData();
            Items.Add(new ToolbarItemModel { align = "Right", iconCss = "e-icons e-refresh" });
        }
    }
}
