#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser_NET8.Pages.Gantt
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
