using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.AIAssistView
{
    public class GeminiCloneModel : PageModel
    {
        public List<PromptResponseData> PromptResponseData { get; set; }

        public void OnGet()
        {
            PromptResponseData = new PromptResponseData().GetAllPromptResponseData();
        }
    }
}
