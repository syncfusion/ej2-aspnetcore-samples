using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.AIAssistView
{
    public class ThinkingModel : PageModel
    {
        public string[] PromptSuggestionData { get; set; }

        public void OnGet()
        {
            PromptSuggestionData = new string[] 
            { 
                "Suggest ways to improve decision making",
                "Explain how climate change affects everyday life"
            };
        }
    }
}
