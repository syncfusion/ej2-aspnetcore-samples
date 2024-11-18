#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class OverViewModel : PageModel
    {
        public List<object> ToolbarItems { get; set; }
        public void OnGet ()
        {

            ToolbarItems = new List<object> { "ExpandAll", "CollapseAll" };
            ToolbarItems.Add(new
            {
                type = "Input",
                align = "Right",
                template = "#ToolbarTemplate"
            });

        }
        public static List<GanttDropDownLists> ViewData ()
        {
            List<GanttDropDownLists> Data = new List<GanttDropDownLists>();
            Data.Add(new GanttDropDownLists { Id = "Default", Type = "Default" });
            Data.Add(new GanttDropDownLists { Id = "Grid", Type = "Grid" });
            Data.Add(new GanttDropDownLists { Id = "Chart", Type = "Chart" });
            return Data;
        }
    }
    public class GanttDropDownLists
    {
        public string Id { get; set; }
        public string Type { get; set; }
        
    }
}
