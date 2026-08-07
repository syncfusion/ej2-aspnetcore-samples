using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class ContextMenuModel : PageModel
    {
        public string[] ContextItems { get; set; }

        public void OnGet()
        {
            ContextItems = new string[] {"SortAscending", "SortDescending",
                "Edit", "Delete", "Save", "Cancel",
                "PdfExport", "ExcelExport", "CsvExport", "FirstPage", "PrevPage",
                "LastPage", "NextPage", "Indent", "Outdent" };

        }
        
    }
}