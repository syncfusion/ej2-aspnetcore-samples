using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class SelectionModel : PageModel
    {
        public List<object> TypeData { get; set; }
        public List<object> ModeData { get; set; }
        public List<object> CellModeData { get; set; }

        public void OnGet()
        {
            TypeData = new List<object>() {
                new { id= "Single", type= "Single" },
                new { id= "Multiple", type= "Multiple" }
            };
            ModeData = new List<object>() {
                new { id= "Row", mode= "Row" },
                new { id= "Cell", mode= "Cell" }
            };
            CellModeData = new List<object>() {
                new { id= "Flow", cellmode= "Flow" },
                new { id= "Box", cellmode= "Box" }
            };
        }
        
    }
}