using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class ToolbarTemplateModel : PageModel
    {
        public List<object> ToolbarItems { get; set; }

        public void OnGet()
        {
            ToolbarItems = new List<object>();
            ToolbarItems.Add("ExpandAll");
            ToolbarItems.Add("CollapseAll");
            ToolbarItems.Add(new { text = "Quick Filter", tooltipText = "Quick Filter", id = "toolbarfilter" });
        }
        
    }
}