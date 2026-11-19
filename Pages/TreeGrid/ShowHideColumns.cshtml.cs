using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class ShowHideColumnsModel : PageModel
    {
        public List<object> Columns { get; set; }

        public void OnGet()
        {
            Columns = new List<Object>() {
                new { value= "TaskId", text= "Task ID" },
                new { value= "StartDate", text= "Start Date" },
                new { value= "Duration", text= "Duration" },
                new { value= "Progress", text= "Progress" }
            };
        }
        
    }
}