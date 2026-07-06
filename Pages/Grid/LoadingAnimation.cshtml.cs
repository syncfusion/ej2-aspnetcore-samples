using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class LoadingAnimationModel : PageModel
{
    public string[] data { get; set; }
    public void OnGet()
    {
        data = new string[] { "Shimmer", "Spinner" };
    }
}