#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class RemoteDataModel : PageModel
    {
        public List<GanttDropDownList> DropdownData { get; set; }
        public string RecordCount { get; set; } = "1000";
        public void OnGet()
        {
            DropdownData = DLData();
        }
        public static List<GanttDropDownList> DLData()
        {
            return new List<GanttDropDownList>
                {
                new GanttDropDownList { Text = "1,000 Rows", Value = "1000" },
                new GanttDropDownList { Text = "2,500 Rows", Value = "2500" },
                new GanttDropDownList { Text = "5,000 Rows", Value = "5000" }
                };
        }
    }
    public class GanttDropDownList
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}