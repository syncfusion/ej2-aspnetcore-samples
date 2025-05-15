#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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