using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser.Pages.AIAssistView
{
    public class NotionAICloneModel : PageModel
    {
        public List<string> NotionSuggestions { get; set; }
        public Dictionary<string, string> ModelIcons { get; set; }
        public Dictionary<int, string> IconMapByIndex { get; set; }

        public void OnGet()
        {
            // Reuse data from PromptResponseData
            NotionSuggestions = PromptResponseData.GetNotionSuggestions();
            ModelIcons = PromptResponseData.GetModelIcons();
            IconMapByIndex = PromptResponseData.GetIconMapByIndex();
        }
    }
}
