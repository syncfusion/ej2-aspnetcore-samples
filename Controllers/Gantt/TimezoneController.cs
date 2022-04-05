#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Gantt
{
    public partial class GanttController : Controller
    {
        public IActionResult Timezone()
        {
            ViewBag.DataSource = TimezoneData();
            return View();
        }

        public static List<GanttDataSource> TimezoneData()
        {
            List<GanttDataSource> GanttDataSourceCollection = new List<GanttDataSource>();

            GanttDataSource Record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Project schedule",
                StartDate = new DateTime(2019, 02, 04, 08, 00, 00),
                EndDate = new DateTime(2019, 03, 10)
            };
            GanttDataSource Record2 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Planning",
                StartDate = new DateTime(2019, 02, 04, 08, 00, 00),
                EndDate = new DateTime(2019, 02, 10),
                ParentID = 1
            };
            GanttDataSource Record3 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Plan timeline",
                StartDate = new DateTime(2019, 02, 04, 08, 00, 00),
                EndDate = new DateTime(2019, 02, 10),
                Duration = 6,
                Progress = 60,
                ParentID = 2
            };
            GanttDataSource Record4 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Plan budget",
                StartDate = new DateTime(2019, 02, 04, 08, 00, 00),
                EndDate = new DateTime(2019, 02, 10),
                Duration = 6,
                Progress = 90,
                ParentID = 2
            };
            GanttDataSource Record5 = new GanttDataSource()
            {
                TaskId = 5,
                TaskName = "Allocate resources",
                StartDate = new DateTime(2019, 02, 04, 08, 00, 00),
                EndDate = new DateTime(2019, 02, 10),
                Duration = 6,
                Progress = 75,
                ParentID = 2
            };
            GanttDataSource Record6 = new GanttDataSource()
            {
                TaskId = 6,
                TaskName = "Planning complete",
                StartDate = new DateTime(2019, 02, 06, 08, 00, 00),
                EndDate = new DateTime(2019, 02, 10),
                Duration = 0,
                Predecessor = "3, 4, 5",
                ParentID = 2
            };
            GanttDataSource Record7 = new GanttDataSource()
            {
                TaskId = 7,
                TaskName = "Design",
                StartDate = new DateTime(2019, 02, 13, 08, 00, 00),
                EndDate = new DateTime(2019, 02, 17),
                ParentID = 1
            };
            GanttDataSource Record8 = new GanttDataSource()
            {
                TaskId = 8,
                TaskName = "Software specification",
                StartDate = new DateTime(2019, 02, 13, 08, 00, 00),
                EndDate = new DateTime(2019, 02, 15),
                Duration = 3,
                Progress = 60,
                Predecessor = "6",
                ParentID = 7
            };
            GanttDataSource Record9 = new GanttDataSource()
            {
                TaskId = 9,
                TaskName = "Develop prototype",
                StartDate = new DateTime(2019, 02, 13, 08, 00, 00),
                EndDate = new DateTime(2019, 02, 15),
                Duration = 3,
                Progress = 100,
                Predecessor = "6",
                ParentID = 7
            };
            GanttDataSource Record10 = new GanttDataSource()
            {
                TaskId = 10,
                TaskName = "Get approval from customer",
                StartDate = new DateTime(2019, 02, 16, 08, 00, 00),
                EndDate = new DateTime(2019, 02, 17),
                Duration = 2,
                Progress = 100,
                Predecessor = "9",
                ParentID = 7
            };
            GanttDataSource Record11 = new GanttDataSource()
            {
                TaskId = 11,
                TaskName = "Design complete",
                StartDate = new DateTime(2019, 02, 17, 08, 00, 00),
                EndDate = new DateTime(2019, 02, 17),
                Duration = 0,
                Predecessor = "10",
                ParentID = 7
            };
            GanttDataSourceCollection.Add(Record1);
            GanttDataSourceCollection.Add(Record2);
            GanttDataSourceCollection.Add(Record3);
            GanttDataSourceCollection.Add(Record4);
            GanttDataSourceCollection.Add(Record5);
            GanttDataSourceCollection.Add(Record6);
            GanttDataSourceCollection.Add(Record7);
            GanttDataSourceCollection.Add(Record8);
            GanttDataSourceCollection.Add(Record9);
            GanttDataSourceCollection.Add(Record10);
            GanttDataSourceCollection.Add(Record11);

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
            public int ParentID { get; set; }

        }
    }
}