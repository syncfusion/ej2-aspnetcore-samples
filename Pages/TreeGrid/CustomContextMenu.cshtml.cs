using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class CustomContextMenuModel : PageModel
    {
        public List<object> ContextItems { get; set; }

        public void OnGet()
        {
            ContextItems = new List<Object>();
            ContextItems.Add(new { text = "Collapse the Row", target = ".e-content", id = "collapserow" });
            ContextItems.Add(new { text = "Expand the Row", target = ".e-content", id = "expandrow" });

        }
        
    }
}