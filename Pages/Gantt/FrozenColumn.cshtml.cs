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
    public class FrozenColumnModel : PageModel
    {
        public List<GanttDataSource> DataSource { get; set; }

        public void OnGet()
        {
            DataSource = FrozenColumnsData();
        }

        public static List<GanttDataSource> FrozenColumnsData()
        {
            List<GanttDataSource> GanttDataSourceCollection = new List<GanttDataSource>
            {
                new GanttDataSource { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2025, 03, 01), EndDate = new DateTime(2025, 03, 10), Duration = 10, Progress = 100, ResourceId = new int[] { 1 }, Designation = "Project Manager", Status = "Completed" },
                new GanttDataSource { TaskId = 2, TaskName = "Identify requirements", StartDate = new DateTime(2025, 03, 01), EndDate = new DateTime(2025, 03, 04), Duration = 2, Progress = 100, ResourceId = new int[] { 5 }, Designation = "Project Manager", Status = "Completed", ParentID = 1 },
                new GanttDataSource { TaskId = 3, TaskName = "Feasibility study", StartDate = new DateTime(2025, 03, 02), EndDate = new DateTime(2025, 03, 06), Duration = 3, Predecessor = "2", Progress = 100, ResourceId = new int[] { 2 }, Designation = "Project Manager", Status = "Completed", ParentID = 1 },
                new GanttDataSource { TaskId = 4, TaskName = "Stakeholder approval", StartDate = new DateTime(2025, 03, 06), EndDate = new DateTime(2025, 03, 06), Duration = 0, Predecessor = "3", Progress = 100, ResourceId = new int[] { 3 }, Designation = "Executive", Status = "Completed", ParentID = 1 },
                new GanttDataSource { TaskId = 5, TaskName = "Planning phase", StartDate = new DateTime(2025, 03, 07), EndDate = new DateTime(2025, 03, 20), Duration = 14, Predecessor = "4", Progress = 85, ResourceId = new int[] { 2, 5 }, Designation = "Project Manager", Status = "In Progress" },
                new GanttDataSource { TaskId = 6, TaskName = "Create project plan", StartDate = new DateTime(2025, 03, 07), EndDate = new DateTime(2025, 03, 12), Duration = 5, Predecessor = "4", Progress = 100, ResourceId = new int[] { 6, 4 }, Designation = "Project Manager", Status = "Completed", ParentID = 5 },
                new GanttDataSource { TaskId = 7, TaskName = "Resource allocation", StartDate = new DateTime(2025, 03, 10), EndDate = new DateTime(2025, 03, 14), Duration = 4, Predecessor = "6", Progress = 90, ResourceId = new int[] { 1, 2 }, Designation = "Project Manager", Status = "In Progress", ParentID = 5 },
                new GanttDataSource { TaskId = 8, TaskName = "Assign developers", StartDate = new DateTime(2025, 03, 10), EndDate = new DateTime(2025, 03, 12), Duration = 2, Progress = 100, ResourceId = new int[] { 2 }, Designation = "Software Engineer", Status = "Completed", ParentID = 7 },
                new GanttDataSource { TaskId = 9, TaskName = "Assign designers", StartDate = new DateTime(2025, 03, 11), EndDate = new DateTime(2025, 03, 13), Duration = 2, Progress = 80, ResourceId = new int[] { 3 }, Designation = "Designer", Status = "In Progress", ParentID = 7 },
                new GanttDataSource { TaskId = 10, TaskName = "Risk assessment", StartDate = new DateTime(2025, 03, 12), EndDate = new DateTime(2025, 03, 15), Duration = 3, Predecessor = "6", Progress = 70, ResourceId = new int[] { 1 }, Designation = "Project Manager", Status = "In Progress", ParentID = 5 },
                new GanttDataSource { TaskId = 11, TaskName = "Design and development", StartDate = new DateTime(2025, 03, 15), EndDate = new DateTime(2025, 04, 25), Duration = 41, Predecessor = "6", Progress = 60, ResourceId = new int[] { 2, 3 }, Designation = "Software Engineer", Status = "In Progress" },
                new GanttDataSource { TaskId = 12, TaskName = "UI/UX design", StartDate = new DateTime(2025, 03, 15), EndDate = new DateTime(2025, 03, 23), Duration = 8, Predecessor = "6", Progress = 90, ResourceId = new int[] { 3 }, Designation = "Designer", Status = "In Progress", ParentID = 11 },
                new GanttDataSource { TaskId = 13, TaskName = "Wireframes", StartDate = new DateTime(2025, 03, 15), EndDate = new DateTime(2025, 03, 18), Duration = 3, Progress = 100, ResourceId = new int[] { 5 }, Designation = "Designer", Status = "Completed", ParentID = 12 },
                new GanttDataSource { TaskId = 14, TaskName = "Prototypes", StartDate = new DateTime(2025, 03, 18), EndDate = new DateTime(2025, 03, 23), Duration = 5, Progress = 80, ResourceId = new int[] { 4 }, Designation = "Designer", Status = "In Progress", ParentID = 12 },
                new GanttDataSource { TaskId = 15, TaskName = "Back-end development", StartDate = new DateTime(2025, 03, 20), EndDate = new DateTime(2025, 04, 04), Duration = 15, Predecessor = "13", Progress = 55, ResourceId = new int[] { 2 }, Designation = "Software Engineer", Status = "In Progress", ParentID = 11 },
                new GanttDataSource { TaskId = 16, TaskName = "API design", StartDate = new DateTime(2025, 03, 20), EndDate = new DateTime(2025, 03, 24), Duration = 4, Progress = 100, ResourceId = new int[] { 2 }, Designation = "Software Engineer", Status = "Completed", ParentID = 15 },
                new GanttDataSource { TaskId = 17, TaskName = "Database schema", StartDate = new DateTime(2025, 03, 22), EndDate = new DateTime(2025, 03, 27), Duration = 5, Progress = 60, ResourceId = new int[] { 3 }, Designation = "Software Engineer", Status = "In Progress", ParentID = 15 },
                new GanttDataSource { TaskId = 18, TaskName = "Server setup", StartDate = new DateTime(2025, 03, 25), EndDate = new DateTime(2025, 03, 31), Duration = 6, Progress = 30, ResourceId = new int[] { 5 }, Designation = "Operations", Status = "In Progress", ParentID = 15 },
                new GanttDataSource { TaskId = 19, TaskName = "Front-end development", StartDate = new DateTime(2025, 03, 22), EndDate = new DateTime(2025, 04, 03), Duration = 12, Predecessor = "14", Progress = 50, ResourceId = new int[] { 2, 3 }, Designation = "Software Engineer", Status = "In Progress", ParentID = 11 },
                new GanttDataSource { TaskId = 20, TaskName = "Testing phase", StartDate = new DateTime(2025, 04, 10), EndDate = new DateTime(2025, 04, 25), Duration = 16, Predecessor = "19", Progress = 30, ResourceId = new int[] { 4 }, Designation = "Quality Assurance", Status = "In Progress" },
                new GanttDataSource { TaskId = 21, TaskName = "Unit testing", StartDate = new DateTime(2025, 04, 10), EndDate = new DateTime(2025, 04, 15), Duration = 5, Predecessor = "19", Progress = 40, ResourceId = new int[] { 6 }, Designation = "Quality Assurance", Status = "In Progress", ParentID = 20 },
                new GanttDataSource { TaskId = 22, TaskName = "Integration testing", StartDate = new DateTime(2025, 04, 15), EndDate = new DateTime(2025, 04, 20), Duration = 5, Predecessor = "21", Progress = 20, ResourceId = new int[] { 4, 2 }, Designation = "Quality Assurance", Status = "In Progress", ParentID = 20 },
                new GanttDataSource { TaskId = 23, TaskName = "User acceptance testing", StartDate = new DateTime(2025, 04, 20), EndDate = new DateTime(2025, 04, 23), Duration = 3, Predecessor = "22", Progress = 0, ResourceId = new int[] { 5, 1 }, Designation = "Product Manager", Status = "Not Started", ParentID = 20 },
                new GanttDataSource { TaskId = 24, TaskName = "Deployment", StartDate = new DateTime(2025, 04, 25), EndDate = new DateTime(2025, 04, 25), Duration = 0, Predecessor = "23", Progress = 0, ResourceId = new int[] { 5 }, Designation = "Operations", Status = "Not Started" },
                new GanttDataSource { TaskId = 25, TaskName = "Project closure", StartDate = new DateTime(2025, 04, 27), EndDate = new DateTime(2025, 04, 29), Duration = 3, Predecessor = "24", Progress = 0, ResourceId = new int[] { 1 }, Designation = "Project Manager", Status = "Not Started" },
                new GanttDataSource { TaskId = 26, TaskName = "Documentation", StartDate = new DateTime(2025, 04, 27), EndDate = new DateTime(2025, 04, 29), Duration = 2, Progress = 0, ResourceId = new int[] { 1, 3 }, Designation = "Project Manager", Status = "Not Started", ParentID = 25 },
                new GanttDataSource { TaskId = 27, TaskName = "Final review", StartDate = new DateTime(2025, 04, 28), EndDate = new DateTime(2025, 04, 28), Duration = 0, Progress = 0, ResourceId = new int[] { 1 }, Designation = "Executive", Status = "Not Started", ParentID = 25 },
                new GanttDataSource { TaskId = 28, TaskName = "Test plan review", StartDate = new DateTime(2025, 04, 10), EndDate = new DateTime(2025, 04, 11), Duration = 1, Predecessor = "19", Progress = 30, ResourceId = new int[] { 4 }, Designation = "Quality Assurance", Status = "In Progress", ParentID = 20 },
                new GanttDataSource { TaskId = 29, TaskName = "Performance testing", StartDate = new DateTime(2025, 04, 20), EndDate = new DateTime(2025, 04, 25), Duration = 5, Predecessor = "22", Progress = 10, ResourceId = new int[] { 4 }, Designation = "Quality Assurance", Status = "In Progress", ParentID = 20 },
                new GanttDataSource { TaskId = 30, TaskName = "Security testing", StartDate = new DateTime(2025, 04, 20), EndDate = new DateTime(2025, 04, 25), Duration = 5, Predecessor = "22", Progress = 10, ResourceId = new int[] { 4, 6 }, Designation = "Quality Assurance", Status = "In Progress", ParentID = 20 },
                new GanttDataSource { TaskId = 31, TaskName = "Regression testing", StartDate = new DateTime(2025, 04, 25), EndDate = new DateTime(2025, 04, 25), Duration = 1, Predecessor = "29", Progress = 0, ResourceId = new int[] { 4 }, Designation = "Quality Assurance", Status = "Not Started", ParentID = 20 },
                new GanttDataSource { TaskId = 32, TaskName = "Training materials", StartDate = new DateTime(2025, 04, 27), EndDate = new DateTime(2025, 04, 28), Duration = 1, Predecessor = "26", Progress = 0, ResourceId = new int[] { 1, 3 }, Designation = "Project Manager", Status = "Not Started", ParentID = 25 },
                new GanttDataSource { TaskId = 33, TaskName = "Team training", StartDate = new DateTime(2025, 04, 28), EndDate = new DateTime(2025, 04, 29), Duration = 1, Predecessor = "32", Progress = 0, ResourceId = new int[] { 1 }, Designation = "Product Manager", Status = "Not Started", ParentID = 25 },
                new GanttDataSource { TaskId = 34, TaskName = "Post-deployment support", StartDate = new DateTime(2025, 04, 29), EndDate = new DateTime(2025, 05, 10), Duration = 12, Predecessor = "24", Progress = 0, ResourceId = new int[] { 5 }, Designation = "Operations", Status = "Not Started" },
                new GanttDataSource { TaskId = 35, TaskName = "Monitoring configuration", StartDate = new DateTime(2025, 04, 29), EndDate = new DateTime(2025, 05, 01), Duration = 2, Predecessor = "34", Progress = 0, ResourceId = new int[] { 6 }, Designation = "Operations", Status = "Not Started", ParentID = 34 },
                new GanttDataSource { TaskId = 36, TaskName = "Create incident runbook", StartDate = new DateTime(2025, 04, 29), EndDate = new DateTime(2025, 05, 02), Duration = 3, Predecessor = "35", Progress = 0, ResourceId = new int[] { 4 }, Designation = "Operations", Status = "Not Started", ParentID = 34 },
                new GanttDataSource { TaskId = 37, TaskName = "Support handover milestone", StartDate = new DateTime(2025, 05, 03), EndDate = new DateTime(2025, 05, 03), Duration = 0, Predecessor = "36", Progress = 0, ResourceId = new int[] { 5 }, Designation = "Operations", Status = "Not Started", ParentID = 34 },
                new GanttDataSource { TaskId = 38, TaskName = "Implement analytics and telemetry", StartDate = new DateTime(2025, 05, 01), EndDate = new DateTime(2025, 05, 10), Duration = 9, Predecessor = "24", Progress = 0, ResourceId = new int[] { 2 }, Designation = "Software Engineer", Status = "Not Started" },
                new GanttDataSource { TaskId = 39, TaskName = "Build dashboards", StartDate = new DateTime(2025, 05, 01), EndDate = new DateTime(2025, 05, 04), Duration = 3, Predecessor = "38", Progress = 0, ResourceId = new int[] { 2, 3 }, Designation = "Software Engineer", Status = "Not Started", ParentID = 38 },
                new GanttDataSource { TaskId = 40, TaskName = "Configure alerting and notifications", StartDate = new DateTime(2025, 05, 05), EndDate = new DateTime(2025, 05, 10), Duration = 5, Predecessor = "39", Progress = 0, ResourceId = new int[] { 2 }, Designation = "Software Engineer", Status = "Not Started", ParentID = 38 }
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
            public int[] ResourceId {get; set;}
            public string Status{get; set;}
            public string Designation{get; set;}
        }
    }
}