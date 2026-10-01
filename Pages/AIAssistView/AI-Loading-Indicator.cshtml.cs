using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Pages.AIAssistView
{
    public class LoadingIndicatorModel : PageModel
    {
        public List<ToolbarItemModel> Items = new List<ToolbarItemModel>();
        public List<PromptResponseData> PromptResponseData { get; set; } = new List<PromptResponseData>();
        public string[] PromptSuggestionData { get; set; } = Array.Empty<string>();
        public List<object> LoadingTypes { get; set; } = new List<object>();
        public string LoadingTypeValue { get; set; } = "dot";

        public void OnGet()
        {
            Items.Add(new ToolbarItemModel { align = "Right", iconCss = "e-icons e-refresh", tooltip = "Start new chat" });
            PromptResponseData = new PromptResponseData().GetTemplatePromptResponseData();
            PromptSuggestionData = new PromptResponseData().GetAllSuggestionData();
            LoadingTypes = new List<object>
            {
                new { Text = "Dot", Value = "dot" },
                new { Text = "Spinner", Value = "spinner" },
                new { Text = "Text", Value = "text" },
                new { Text = "Text with indicator", Value = "textIndicator" }
            };
        }
    }
}