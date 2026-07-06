using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class FilteringModel : PageModel
    {
        public List<object> DropData { get; set; }
        
        public void OnGet()
        {
            DropData = new List<object>() {
                new { id= "Parent", mode= "Parent" },
                new { id= "Child", mode= "Child" },
                new { id= "Both", mode= "Both" },
                new { id= "None", mode= "None" },
            };
        }
        
    }
}