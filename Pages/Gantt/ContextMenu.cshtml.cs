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
