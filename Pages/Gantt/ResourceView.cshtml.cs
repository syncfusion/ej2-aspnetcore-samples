using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class ResourceViewModel : PageModel
    {
        public List<object> ToolbarItems { get; set; }
        public void OnGet ()
        {
            ToolbarItems = new List<object>();
            ToolbarItems.Add("Add");
            ToolbarItems.Add("Edit");
            ToolbarItems.Add("Update");
            ToolbarItems.Add("Delete");
            ToolbarItems.Add("Cancel");
            ToolbarItems.Add("ExpandAll");
            ToolbarItems.Add("CollapseAll");
            ToolbarItems.Add(new { text = "Show/Hide Overallocation", tooltipText = "Show/Hide Overallocation", id = "showhidebar" });
        }
    }
}