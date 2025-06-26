#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
