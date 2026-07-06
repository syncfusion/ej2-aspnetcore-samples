using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class UnscheduledTaskeModel : PageModel
    {
        public List<object> ToolbarItems { get; set; }
        public void OnGet ()
        {
            ToolbarItems = new List<object>();
            ToolbarItems.Add(new { text = "Insert task", tooltipText = "Insert task at top", id = "toolbarAdd", prefixIcon = "e-add-icon tb-icons" });
        }
    }
}