using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.AIAssistView
{
    public class DefaultFunctionalitiesModel : PageModel
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

    public class ToolbarItemModel
    {
        public string align { get; set; }

        public string iconCss { get; set; }

        public string tooltip { get; set; }
    }
}