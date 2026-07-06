using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class SortingModel : PageModel
    {
        public List<object> Columns = new List<object>();

        public void OnGet()
        {
            
            Columns.Add(new { field = "ShipmentCategory", direction = "Ascending" });
            Columns.Add(new { field = "Name", direction = "Descending" });
        }
        
    }
}