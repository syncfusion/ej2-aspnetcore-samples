using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class ColumnFormattingModel : PageModel
    {
        public List<object> Columns { get; set; }
        public List<object> NumberFormats { get; set; }
        public List<object> DateFormats { get; set; }

        public void OnGet()
        {
            Columns = new List<Object>() {
                new { id= "price", name= "Price" },
                new { id= "orderDate", name= "Order Date" }
            };
            NumberFormats = new List<Object>() {
                new { id= "n2", format= "n2" },
                new { id= "n3", format= "n3" },
                new { id= "c2", format= "c2" },
                new { id= "c3", format= "c3" },
                new { id= "p2", format= "p2" },
                new { id= "p3", format= "p3" }
            };
            DateFormats = new List<Object>() {
                new { id= "M/d/yyyy", format= "Short Date" },
                new { id= "dddd, MMMM dd, yyyy", format= "Long Date" },
                new { id= "MMMM, yyyy", format= "Month/Year" },
                new { id= "MMMM, dd", format= "Month/Day" }
            };

        }
        
    }
}