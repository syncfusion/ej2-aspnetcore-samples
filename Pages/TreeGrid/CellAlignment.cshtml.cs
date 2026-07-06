using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class CellAlignmentModel : PageModel
    {
        public List<Object> Columns { get; set; }
        public List<Object> Indexes { get; set; }

        public void OnGet()
        {
            Columns = new List<Object>() {
                new { id= "TaskId", name= "Task ID" },
                new { id= "StartDate", name= "Start Date" },
                new { id= "Duration", name= "Duration" },
                new { id= "Progress", name= "Progress" }
            };
            Indexes = new List<Object>() {
                new { id= "Right", name= "Right" },
                new { id= "Left", name= "Left" },
                new { id= "Center", name= "Center" },
                new { id= "Justify", name= "Justify" }
            };
        }
        
    }
}