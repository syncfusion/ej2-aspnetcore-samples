using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class LoadingAnimationModel : PageModel
    {
        public string[] TypeDropData { get; set; }
        public void OnGet ()
        {
            TypeDropData = new string[] { "Shimmer", "Spinner" };
        }
    }
}