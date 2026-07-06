using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class LoadingAnimationModel : PageModel
    {
        public new string[] Data { get; set; }

        public void OnGet()
        {
            Data = new string[] { "Shimmer", "Spinner" };
        }
        
    }
}