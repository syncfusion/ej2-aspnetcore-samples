using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class RowHeightModel : PageModel
    {
        public List<object> ToolbarItems { get; set; }

        public void OnGet()
        {
            ToolbarItems = new List<object>();
            ToolbarItems.Add(new { prefixIcon = "e-big-icon", id = "small", align = "Left", tooltipText = "Small" });
            ToolbarItems.Add(new { prefixIcon = "e-medium-icon", id = "medium", align = "Left", tooltipText = "Medium" });
            ToolbarItems.Add(new { prefixIcon = "e-small-icon", id = "big", align = "Left", tooltipText = "Large" });
        }
        
    }
}