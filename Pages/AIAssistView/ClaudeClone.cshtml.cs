using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.AIAssistView
{
    public class ClaudeCloneModel : PageModel
    {
        public List<PromptResponseData> PromptResponseData { get; set; } = new();
        public object[] FooterToolbarItems { get; set; } = [];

        public void OnGet()
        {
            PromptResponseData = new PromptResponseData().GetAllPromptResponseData();
            FooterToolbarItems =
            [
                new
                {
                    iconCss = "e-icons e-assist-attachment-icon",
                    align = "Left"
                },
                new
                {
                    align = "Right",
                    template = "<button id=\"custombtn\">Opus 4.6</button>"
                }
            ];
        }
    }
}
