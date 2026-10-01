using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class LockRowModel : PageModel
    {
        public Dictionary<string, object> Dict { get; set; }
        public List<object> DropData { get; set; }
        public List<int> DropValue { get; set; }

        public void OnGet()
        {
            Dict = new Dictionary<string, object>();
            Dict.Add("number", true);
            Dict.Add("min", 0);
            DropData = new List<Object>();
            for (var i = 1; i <= 36; i++)
            { 
                DropData.Add(new { text = i.ToString(), value = i });
            }
            DropValue = new List<int>() { 2, 6 };
        }
        
    }
}