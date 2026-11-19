using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.AIAssistView
{
    public class ViewsModel : PageModel
    {
        public List<PromptResponseData> PromptResponseData { get; set; }
        public void OnGet()
        {
            PromptResponseData = new PromptResponseData().GetAllPromptResponseData();
        }
    }
}
