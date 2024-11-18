#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Gantt;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class DefaultSortingModel : PageModel
    {
        public List<GanttSortDescriptor> Columns { get; set; }
        public void OnGet()
        {
            Columns = new List<GanttSortDescriptor>();
            Columns.Add(new GanttSortDescriptor { Field = "TaskName", Direction = Syncfusion.EJ2.Gantt.SortDirection.Ascending });
            Columns.Add(new GanttSortDescriptor { Field = "TaskId", Direction = Syncfusion.EJ2.Gantt.SortDirection.Ascending });
        }
    }
}
