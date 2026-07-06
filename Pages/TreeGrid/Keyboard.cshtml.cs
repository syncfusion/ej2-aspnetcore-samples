using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class KeyboardModel : PageModel
    {
        public Dictionary<string, object> Dict { get; set; }

        public void OnGet()
        {
            Dict = new Dictionary<string, object>();
            Dict.Add("number", true);
            Dict.Add("min", 0);
        }
        
    }
}