#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class TimezoneModel : PageModel
    {
        public List<object> ToolbarItems { get; set; }
        public List<GanttDataSource> DataSource { get; set; }

        public void OnGet()
        {
            ToolbarItems = new List<object>
            {
                new { align = "Left", template = "<div class=\"timezone-label\"><label class=\"showhide\" style=\"margin-right: 10px;\">Time Zone:</label></div>" },
                new { align = "Left", template = "<div class=\"timezone-dropdown\"><div id=\"timezonelist\"></div></div>" },
                new { align = "Right", template = "<div class=\"timeline-section\"><button id=\"previous-timespan\" class=\"previous-timespan\"><span class=\"e-icons e-chevron-left-fill\"></span></button></div>" },
                new { type = "Separator", align = "Right" },
                new { align = "Right", template = "<div class=\"timeline-dropdown\"><div id=\"timeline\"></div></div>" },
                new { type = "Separator", align = "Right" },
                new { align = "Right", template = "<div class=\"timeline-section\"><button id=\"next-timespan\" class=\"next-timespan\"><span class=\"e-icons e-chevron-right-fill\"></span></button></div>" }
            };

            DataSource = TimezoneData();
        }

        public static List<GanttDataSource> TimezoneData()
        {
            List<GanttDataSource> GanttDataSourceCollection = new List<GanttDataSource>
            {
                new GanttDataSource { TaskId = 1, TaskName = "Project Schedule", StartDate = new DateTime(2025, 02, 04, 08, 00, 00), EndDate = new DateTime(2025, 03, 10) },
                new GanttDataSource { TaskId = 2, TaskName = "Planning", StartDate = new DateTime(2025, 02, 04, 08, 00, 00), EndDate = new DateTime(2025, 02, 10), ParentID = 1 },
                new GanttDataSource { TaskId = 3, TaskName = "Plan timeline", StartDate = new DateTime(2025, 02, 04, 08, 00, 00), EndDate = new DateTime(2025, 02, 10), Duration = 6, Progress = 60, ParentID = 2 },
                new GanttDataSource { TaskId = 4, TaskName = "Plan budget", StartDate = new DateTime(2025, 02, 04, 08, 00, 00), EndDate = new DateTime(2025, 02, 10), Duration = 6, Progress = 90, ParentID = 2 },
                new GanttDataSource { TaskId = 5, TaskName = "Allocate resources", StartDate = new DateTime(2025, 02, 04, 08, 00, 00), EndDate = new DateTime(2025, 02, 10), Duration = 6, Progress = 75, ParentID = 2 },
                new GanttDataSource { TaskId = 6, TaskName = "Planning complete", StartDate = new DateTime(2025, 02, 06, 08, 00, 00), EndDate = new DateTime(2025, 02, 10), Duration = 0, Predecessor = "3FS,4FS,5FS", ParentID = 2 },
                new GanttDataSource { TaskId = 7, TaskName = "Design", StartDate = new DateTime(2025, 02, 13, 08, 00, 00), EndDate = new DateTime(2025, 02, 17), ParentID = 1 },
                new GanttDataSource { TaskId = 8, TaskName = "Software specification", StartDate = new DateTime(2025, 02, 13, 08, 00, 00), EndDate = new DateTime(2025, 02, 15), Duration = 3, Progress = 60, Predecessor = "6FS", ParentID = 7 },
                new GanttDataSource { TaskId = 9, TaskName = "Develop prototype", StartDate = new DateTime(2025, 02, 13, 08, 00, 00), EndDate = new DateTime(2025, 02, 15), Duration = 3, Progress = 100, Predecessor = "6FS", ParentID = 7 },
                new GanttDataSource { TaskId = 10, TaskName = "Get approval from customer", StartDate = new DateTime(2025, 02, 16, 08, 00, 00), EndDate = new DateTime(2025, 02, 17), Duration = 2, Progress = 100, Predecessor = "9FS", ParentID = 7 },
                new GanttDataSource { TaskId = 11, TaskName = "Design complete", StartDate = new DateTime(2025, 02, 17, 08, 00, 00), EndDate = new DateTime(2025, 02, 17), Duration = 0, Predecessor = "10FS", ParentID = 7 },
                new GanttDataSource { TaskId = 12, TaskName = "Implementation", StartDate = new DateTime(2025, 02, 18, 08, 00, 00), EndDate = new DateTime(2025, 02, 25), ParentID = 1 },
                new GanttDataSource { TaskId = 13, TaskName = "Develop core modules", StartDate = new DateTime(2025, 02, 18, 08, 00, 00), EndDate = new DateTime(2025, 02, 22), Duration = 5, Progress = 80, Predecessor = "11FS", ParentID = 12 },
                new GanttDataSource { TaskId = 14, TaskName = "Integrate modules", StartDate = new DateTime(2025, 02, 19, 08, 00, 00), EndDate = new DateTime(2025, 02, 23), Duration = 5, Progress = 70, Predecessor = "13FS", ParentID = 12 },
                new GanttDataSource { TaskId = 15, TaskName = "Implementation complete", StartDate = new DateTime(2025, 02, 25, 08, 00, 00), EndDate = new DateTime(2025, 02, 25), Duration = 0, Predecessor = "14FS", ParentID = 12 },
                new GanttDataSource { TaskId = 16, TaskName = "Testing", StartDate = new DateTime(2025, 02, 26, 08, 00, 00), EndDate = new DateTime(2025, 03, 02), ParentID = 1 },
                new GanttDataSource { TaskId = 17, TaskName = "Unit testing", StartDate = new DateTime(2025, 02, 26, 08, 00, 00), EndDate = new DateTime(2025, 02, 28), Duration = 3, Progress = 50, Predecessor = "15FS", ParentID = 16 },
                new GanttDataSource { TaskId = 18, TaskName = "Integration testing", StartDate = new DateTime(2025, 02, 27, 08, 00, 00), EndDate = new DateTime(2025, 03, 01), Duration = 4, Progress = 40, Predecessor = "17FS", ParentID = 16 },
                new GanttDataSource { TaskId = 19, TaskName = "Test report", StartDate = new DateTime(2025, 03, 02, 08, 00, 00), EndDate = new DateTime(2025, 03, 02), Duration = 0, Predecessor = "18FS", ParentID = 16 },
                new GanttDataSource { TaskId = 20, TaskName = "Deployment", StartDate = new DateTime(2025, 03, 03, 08, 00, 00), EndDate = new DateTime(2025, 03, 06), ParentID = 1 },
                new GanttDataSource { TaskId = 21, TaskName = "Configure environment", StartDate = new DateTime(2025, 03, 03, 08, 00, 00), EndDate = new DateTime(2025, 03, 04), Duration = 2, Progress = 30, Predecessor = "19FS", ParentID = 20 },
                new GanttDataSource { TaskId = 22, TaskName = "Deploy application", StartDate = new DateTime(2025, 03, 04, 08, 00, 00), EndDate = new DateTime(2025, 03, 05), Duration = 2, Progress = 20, Predecessor = "21FS", ParentID = 20 },
                new GanttDataSource { TaskId = 23, TaskName = "Deployment verification", StartDate = new DateTime(2025, 03, 06, 08, 00, 00), EndDate = new DateTime(2025, 03, 06), Duration = 0, Predecessor = "22FS", ParentID = 20 },
                new GanttDataSource { TaskId = 24, TaskName = "Training", StartDate = new DateTime(2025, 03, 07, 08, 00, 00), EndDate = new DateTime(2025, 03, 08), ParentID = 1 },
                new GanttDataSource { TaskId = 25, TaskName = "User training", StartDate = new DateTime(2025, 03, 07, 08, 00, 00), EndDate = new DateTime(2025, 03, 07), Duration = 1, Progress = 10, Predecessor = "23FS", ParentID = 24 },
                new GanttDataSource { TaskId = 26, TaskName = "Admin training", StartDate = new DateTime(2025, 03, 07, 08, 00, 00), EndDate = new DateTime(2025, 03, 08), Duration = 2, Progress = 10, Predecessor = "23FS", ParentID = 24 },
                new GanttDataSource { TaskId = 27, TaskName = "Training complete", StartDate = new DateTime(2025, 03, 08, 08, 00, 00), EndDate = new DateTime(2025, 03, 08), Duration = 0, Predecessor = "25FS,26FS", ParentID = 24 },
                new GanttDataSource { TaskId = 28, TaskName = "Client Review", StartDate = new DateTime(2025, 03, 09, 08, 00, 00), EndDate = new DateTime(2025, 03, 09), Duration = 1, Progress = 0, Predecessor = "27FS", ParentID = 1 },
                new GanttDataSource { TaskId = 29, TaskName = "Project Handover", StartDate = new DateTime(2025, 03, 10, 08, 00, 00), EndDate = new DateTime(2025, 03, 10), Duration = 0, Predecessor = "28FS", ParentID = 1 },
                new GanttDataSource { TaskId = 30, TaskName = "Post-Project Review", StartDate = new DateTime(2025, 03, 10, 08, 00, 00), EndDate = new DateTime(2025, 03, 10), Duration = 0, Progress = 0, Predecessor = "29FS", ParentID = 1 }
            };

            return GanttDataSourceCollection;
        }

        public class GanttDataSource
        {
            public int TaskId { get; set; }
            public string TaskName { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public int? Duration { get; set; }
            public int Progress { get; set; }
            public string Predecessor { get; set; }
            public int? ParentID { get; set; }
        }
    }
}