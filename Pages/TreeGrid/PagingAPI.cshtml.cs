using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class PagingAPIModel : PageModel
    {
        public List<object> DropData { get; set; }
        
        public void OnGet()
        {
            DropData = new List<object>() {
                new { id= "All", mode= "All" },
                new { id= "Root", mode= "Root" }
            };
        }
        
    }
}