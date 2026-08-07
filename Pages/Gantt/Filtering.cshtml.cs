using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class FilteringModel : PageModel
    {
        public List<object> TypeDropData { get; set; }
        public List<object> ModeDropData { get; set; }

        public void OnGet ()
        {
            TypeDropData = new List<object>() {
               new { id= "Menu", type= "Menu" },
               new { id= "Excel", type= "Excel" },
            };
            ModeDropData = new List<object>() {
                new { id= "Parent", type= "Parent" },
                new { id= "Child", type= "Child" },
                new { id= "Both", type= "Both" },
                new { id= "None", type= "None" }
            };
        }
    }
}