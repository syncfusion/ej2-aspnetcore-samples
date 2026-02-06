#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
