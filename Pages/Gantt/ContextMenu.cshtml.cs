using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class ContextMenuModel : PageModel
    {
        public List<object> ContextItems { get; set; }
        public void OnGet()
        {
            ContextItems = new List<object> { "AutoFitAll", "AutoFit", "TaskInformation", "DeleteTask", "Save", "Cancel",
            "SortAscending", "SortDescending", "Add", "DeleteDependency", "Convert", "Indent", "Outdent"};
            ContextItems.Add(new { text = "Collapse the Row", target = ".e-content", id = "collapserow" });
            ContextItems.Add(new { text = "Expand the Row", target = ".e-content", id = "expandrow" });
        }
    }
}