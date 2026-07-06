using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class ToolbarTemplateModel : PageModel
    {
        public List<object> ToolbarItems { get; set; }
        public void OnGet ()
        {
            ToolbarItems = new List<object> { "ExpandAll", "CollapseAll" };
            ToolbarItems.Add(new { text = "Quick Filter", tooltipText = "Quick Filter", id = "Quick Filter", prefixIcon = "e-quickfilter" });
            ToolbarItems.Add(new { text = "Clear Filter", tooltipText = "Clear Filter", id = "Quick Filter" });
        }
    }
}