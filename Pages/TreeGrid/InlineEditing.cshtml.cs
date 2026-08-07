using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class InlineEditingModel : PageModel
    {
        public List<object> DropDownData { get; set; }
        public Dictionary<string, object> Dict { get; set; }

        public void OnGet()
        {
            DropDownData = new List<object>();
            DropDownData.Add(new { id = "CellEditing", name = "Cell Editing" });
            DropDownData.Add(new { id = "RowEditing", name = "Row Editing" });

            Dict = new Dictionary<string, object>();
            Dict.Add("number", true);
            Dict.Add("min", 0);
        }
        
    }
}