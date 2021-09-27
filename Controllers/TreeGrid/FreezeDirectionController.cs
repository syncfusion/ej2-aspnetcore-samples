using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Popups;

namespace EJ2CoreSampleBrowser.Controllers.TreeGrid
{
    public partial class TreeGridController : Controller
    {
        public IActionResult FreezeDirection()
        {
            var order = FreezeDataSource.GetTreeData();
            ViewBag.datasource = order;
            List<object> dd = new List<object>();
            dd.Add(new { name = "Task ID", id = "TaskId" });
            dd.Add(new { name = "Task Name", id = "TaskName" });
            dd.Add(new { name = "Start Date", id = "StartDate" });
            dd.Add(new { name = "End Date", id = "EndDate" });
            dd.Add(new { name = "Duration", id = "Duration" });
            dd.Add(new { name = "Progress", id = "Progress" });
            dd.Add(new { name = "Priority", id = "Priority" });
            dd.Add(new { name = "Designation", id = "Designation" });
            dd.Add(new { name = "Employee ID", id = "EmployeeID" });
            dd.Add(new { name = "Approved", id = "Approved" });
            ViewBag.columns = dd;
            List<object> direction = new List<object>();
            direction.Add(new { name = "Left", id = "Left" });
            direction.Add(new { name = "Right", id = "Right" });
            direction.Add(new { name = "Center", id = "Center" });
            ViewBag.direction = direction;
            ViewBag.DefaultButtons = new
            {
                content = "OK",
                isPrimary = true
            };
            return View();
        }
        public class DefaultButtonModel
        {
            public string content { get; set; }
            public bool isPrimary { get; set; }
        }

        public class FreezeDataSource
        {
            public int TaskId { get; set; }

            public string TaskName { get; set; }

            public DateTime StartDate { get; set; }

            public DateTime EndDate { get; set; }

            public int Duration { get; set; }

            public int EmployeeID { get; set; }

            public string Designation { get; set; }

            public int Progress { get; set; }
            public string Priority { get; set; }
            public bool Approved { get; set; }

            public DateTime FilterStartDate { get; set; }
            public DateTime FilterEndDate { get; set; }

            public List<FreezeDataSource> Children { get; set; }

            public int? ParentId { get; set; }

            public static List<FreezeDataSource> GetTreeData()
            {
                List<FreezeDataSource> BusinessObjectCollection = new List<FreezeDataSource>();

                FreezeDataSource Record1 = null;

                Record1 = new FreezeDataSource()
                {
                    TaskId = 1,
                    TaskName = "Planning",
                    StartDate = new DateTime(2016, 06, 07),
                    EndDate = new DateTime(2021, 08, 25),
                    Progress = 100,
                    Duration = 5,
                    Priority = "Normal",
                    Approved = false,
                    FilterStartDate = new DateTime(2017, 02, 03),
                    FilterEndDate = new DateTime(2017, 02, 07),
                    Children = new List<FreezeDataSource>(),
                    EmployeeID = 1,
                    Designation = "Vice President"
                };

                FreezeDataSource Child1 = new FreezeDataSource()
                {
                    TaskId = 2,
                    TaskName = "Plan timeline",
                    StartDate = new DateTime(2016, 06, 07),
                    EndDate = new DateTime(2021, 08, 25),
                    Progress = 100,
                    Duration = 5,
                    Priority = "Normal",
                    Approved = false,
                    FilterStartDate = new DateTime(2017, 02, 03),
                    FilterEndDate = new DateTime(2017, 02, 07),
                    EmployeeID = 2,
                    Designation = "Chief Executive Officer"
                };

                FreezeDataSource Child2 = new FreezeDataSource()
                {
                    TaskId = 3,
                    TaskName = "Plan budget",
                    StartDate = new DateTime(2016, 06, 07),
                    EndDate = new DateTime(2021, 08, 25),
                    Duration = 5,
                    Priority = "Critical",
                    Progress = 100,
                    Approved = true,
                    FilterStartDate = new DateTime(2017, 02, 03),
                    FilterEndDate = new DateTime(2017, 02, 07),
                    EmployeeID = 3,
                    Designation = "Chief Executive Officer"
                };

                FreezeDataSource Child3 = new FreezeDataSource()
                {
                    TaskId = 4,
                    TaskName = "Allocate resources",
                    StartDate = new DateTime(2016, 06, 07),
                    EndDate = new DateTime(2021, 08, 25),
                    Duration = 5,
                    Progress = 100,
                    Priority = "Critical",
                    FilterStartDate = new DateTime(2017, 02, 03),
                    FilterEndDate = new DateTime(2017, 02, 07),
                    Approved = false,
                    EmployeeID = 4,
                    Designation = "Chief Executive Officer"
                };

                FreezeDataSource Child4 = new FreezeDataSource()
                {
                    TaskId = 5,
                    TaskName = "Planning complete",
                    StartDate = new DateTime(2021, 08, 25),
                    EndDate = new DateTime(2021, 08, 25),
                    Duration = 3,
                    Progress = 25,
                    Priority = "Low",
                    FilterStartDate = new DateTime(2017, 02, 07),
                    FilterEndDate = new DateTime(2017, 02, 07),
                    Approved = true,
                    EmployeeID = 5,
                    Designation = "Chief Executive Officer"
                };

                Record1.Children.Add(Child1);
                Record1.Children.Add(Child2);
                Record1.Children.Add(Child3);
                Record1.Children.Add(Child4);

                FreezeDataSource Record2 = new FreezeDataSource()
                {
                    TaskId = 6,
                    TaskName = "Design",
                    StartDate = new DateTime(2021, 08, 25),
                    EndDate = new DateTime(2024, 06, 27),
                    Progress = 86,
                    Duration = 3,
                    Priority = "High",
                    FilterStartDate = new DateTime(2017, 02, 10),
                    FilterEndDate = new DateTime(2017, 02, 14),
                    Approved = false,
                    Children = new List<FreezeDataSource>(),
                    EmployeeID = 6,
                    Designation = "Vice President"
                };

                FreezeDataSource Child5 = new FreezeDataSource()
                {
                    TaskId = 7,
                    TaskName = "Software Specification",
                    StartDate = new DateTime(2021, 08, 25),
                    EndDate = new DateTime(2024, 06, 27),
                    Duration = 3,
                    Progress = 60,
                    Priority = "Normal",
                    FilterStartDate = new DateTime(2017, 02, 10),
                    FilterEndDate = new DateTime(2017, 02, 12),
                    Approved = false,
                    EmployeeID = 7,
                    Designation = "Sales Representative"
                };

                FreezeDataSource Child6 = new FreezeDataSource()
                {
                    TaskId = 8,
                    TaskName = "Develop prototype",
                    StartDate = new DateTime(2021, 08, 25),
                    EndDate = new DateTime(2024, 06, 27),
                    Duration = 3,
                    Progress = 100,
                    Priority = "Critical",
                    FilterStartDate = new DateTime(2017, 02, 10),
                    FilterEndDate = new DateTime(2017, 02, 12),
                    Approved = false,
                    EmployeeID = 8,
                    Designation = "Sales Representative"
                };

                FreezeDataSource Child7 = new FreezeDataSource()
                {
                    TaskId = 9,
                    TaskName = "Get approval from customer",
                    StartDate = new DateTime(2024, 06, 27),
                    EndDate = new DateTime(2024, 06, 27),
                    Duration = 2,
                    Progress = 100,
                    Approved = true,
                    Priority = "Critical",
                    FilterStartDate = new DateTime(2017, 02, 13),
                    FilterEndDate = new DateTime(2017, 02, 14),
                    EmployeeID = 9,
                    Designation = "Sales Representative"
                };

                FreezeDataSource Child8 = new FreezeDataSource()
                {
                    TaskId = 10,
                    TaskName = "Design complete",
                    StartDate = new DateTime(2024, 06, 27),
                    EndDate = new DateTime(2024, 06, 27),
                    Duration = 3,
                    Progress = 25,
                    Priority = "Normal",
                    FilterStartDate = new DateTime(2017, 02, 14),
                    FilterEndDate = new DateTime(2017, 02, 14),
                    Approved = true,
                    EmployeeID = 10,
                    Designation = "Sales Representative"
                };

                Record2.Children.Add(Child5);
                Record2.Children.Add(Child6);
                Record2.Children.Add(Child7);
                Record2.Children.Add(Child8);
                FreezeDataSource Record3 = new FreezeDataSource()
                {
                    TaskId = 11,
                    TaskName = "Implementation Phase",
                    StartDate = new DateTime(2017, 02, 17),
                    EndDate = new DateTime(2017, 02, 17),
                    Priority = "Normal",
                    Approved = false,
                    Duration = 11,
                    Progress = 25,
                    FilterStartDate = new DateTime(2017, 02, 17),
                    FilterEndDate = new DateTime(2017, 02, 17),
                    Children = new List<FreezeDataSource>(),
                    EmployeeID = 11,
                    Designation = "Vice President"
                };

                FreezeDataSource Record4 = new FreezeDataSource()
                {
                    TaskId = 12,
                    TaskName = "Phase 1",
                    StartDate = new DateTime(2017, 02, 17),
                    EndDate = new DateTime(2017, 02, 27),
                    Priority = "High",
                    Approved = false,
                    Duration = 11,
                    Progress = 25,
                    FilterStartDate = new DateTime(2017, 02, 17),
                    FilterEndDate = new DateTime(2017, 02, 27),
                    Children = new List<FreezeDataSource>(),
                    EmployeeID = 12,
                    Designation = "Vice President"
                };
                FreezeDataSource Record7 = new FreezeDataSource()
                {
                    TaskId = 13,
                    TaskName = "Implementation Module 1",
                    StartDate = new DateTime(2017, 02, 17),
                    EndDate = new DateTime(2017, 02, 27),
                    Priority = "Normal",
                    Duration = 11,
                    Approved = false,
                    Progress = 25,
                    FilterStartDate = new DateTime(2017, 02, 17),
                    FilterEndDate = new DateTime(2017, 02, 27),
                    Children = new List<FreezeDataSource>(),
                    EmployeeID = 13,
                    Designation = "Vice President"
                };
                FreezeDataSource Child9 = new FreezeDataSource()
                {
                    TaskId = 14,
                    TaskName = "Development Task 1",
                    StartDate = new DateTime(2017, 02, 17),
                    EndDate = new DateTime(2017, 02, 19),
                    Duration = 3,
                    Progress = 50,
                    Priority = "High",
                    FilterStartDate = new DateTime(2017, 02, 17),
                    FilterEndDate = new DateTime(2017, 02, 19),
                    Approved = false,
                    EmployeeID = 14,
                    Designation = "Sales Representative"
                };
                FreezeDataSource Child10 = new FreezeDataSource()
                {
                    TaskId = 15,
                    TaskName = "Development Task 2",
                    StartDate = new DateTime(2017, 02, 17),
                    EndDate = new DateTime(2017, 02, 19),
                    Duration = 3,
                    Progress = 50,
                    Priority = "Low",
                    FilterStartDate = new DateTime(2017, 02, 17),
                    FilterEndDate = new DateTime(2017, 02, 19),
                    Approved = true,
                    EmployeeID = 15,
                    Designation = "Sales Representative"
                };
                FreezeDataSource Child11 = new FreezeDataSource()
                {
                    TaskId = 16,
                    TaskName = "Testing",
                    StartDate = new DateTime(2017, 02, 20),
                    EndDate = new DateTime(2017, 02, 21),
                    Duration = 2,
                    Progress = 25,
                    Priority = "Normal",
                    FilterStartDate = new DateTime(2017, 02, 20),
                    FilterEndDate = new DateTime(2017, 02, 21),
                    Approved = true,
                    EmployeeID = 16,
                    Designation = "Sales Representative"
                };
                FreezeDataSource Child12 = new FreezeDataSource()
                {
                    TaskId = 17,
                    TaskName = "Bug fix",
                    StartDate = new DateTime(2017, 02, 24),
                    EndDate = new DateTime(2017, 02, 25),
                    Duration = 2,
                    Progress = 25,
                    Priority = "Critical",
                    FilterStartDate = new DateTime(2017, 02, 24),
                    FilterEndDate = new DateTime(2017, 02, 25),
                    Approved = false,
                    EmployeeID = 17,
                    Designation = "Sales Representative"
                };
                FreezeDataSource Child13 = new FreezeDataSource()
                {
                    TaskId = 18,
                    TaskName = "Customer review meeting",
                    StartDate = new DateTime(2017, 02, 26),
                    EndDate = new DateTime(2017, 02, 27),
                    Duration = 2,
                    Progress = 25,
                    Priority = "High",
                    FilterStartDate = new DateTime(2017, 02, 26),
                    FilterEndDate = new DateTime(2017, 02, 27),
                    Approved = false,
                    EmployeeID = 18,
                    Designation = "Sales Representative"
                };
                FreezeDataSource Child14 = new FreezeDataSource()
                {
                    TaskId = 19,
                    TaskName = "Phase 1 complete",
                    StartDate = new DateTime(2017, 02, 27),
                    EndDate = new DateTime(2017, 02, 27),
                    Duration = 2,
                    Progress = 25,
                    Priority = "Low",
                    FilterStartDate = new DateTime(2017, 02, 27),
                    FilterEndDate = new DateTime(2017, 02, 27),
                    Approved = true,
                    EmployeeID = 19,
                    Designation = "Sales Representative"
                };
                Record7.Children.Add(Child9);
                Record7.Children.Add(Child10);
                Record7.Children.Add(Child11);
                Record7.Children.Add(Child12);
                Record7.Children.Add(Child13);
                Record7.Children.Add(Child14);
                Record4.Children.Add(Record7);
                Record3.Children.Add(Record4);
                FreezeDataSource Record5 = new FreezeDataSource()
                {
                    TaskId = 20,
                    TaskName = "Phase 2",
                    StartDate = new DateTime(2017, 02, 17),
                    EndDate = new DateTime(2017, 02, 28),
                    Children = new List<FreezeDataSource>(),
                    Priority = "High",
                    Approved = false,
                    Progress = 25,
                    FilterStartDate = new DateTime(2017, 02, 17),
                    FilterEndDate = new DateTime(2017, 02, 28),
                    Duration = 12,
                    EmployeeID = 20,
                    Designation = "Vice President"
                };
                FreezeDataSource Record8 = new FreezeDataSource()
                {
                    TaskId = 21,
                    TaskName = "Implementation Module 2",
                    StartDate = new DateTime(2017, 02, 17),
                    EndDate = new DateTime(2017, 02, 28),
                    Priority = "Critical",
                    Approved = false,
                    Progress = 25,
                    FilterStartDate = new DateTime(2017, 02, 17),
                    FilterEndDate = new DateTime(2017, 02, 28),
                    Duration = 12,
                    Children = new List<FreezeDataSource>(),
                    EmployeeID = 21,
                    Designation = "Sales Representative"
                };
                FreezeDataSource Child15 = new FreezeDataSource()
                {
                    TaskId = 22,
                    TaskName = "Development Task 1",
                    StartDate = new DateTime(2017, 02, 17),
                    EndDate = new DateTime(2017, 02, 20),
                    Duration = 4,
                    Progress = 50,
                    Priority = "Normal",
                    FilterStartDate = new DateTime(2017, 02, 17),
                    FilterEndDate = new DateTime(2017, 02, 20),
                    Approved = true,
                    EmployeeID = 22,
                    Designation = "Sales Representative"
                };
                FreezeDataSource Child16 = new FreezeDataSource()
                {
                    TaskId = 23,
                    TaskName = "Development Task 2",
                    StartDate = new DateTime(2017, 02, 17),
                    EndDate = new DateTime(2017, 02, 20),
                    Duration = 4,
                    Progress = 50,
                    Priority = "Critical",
                    FilterStartDate = new DateTime(2017, 02, 17),
                    FilterEndDate = new DateTime(2017, 02, 20),
                    Approved = true,
                    EmployeeID = 23,
                    Designation = "Sales Representative"
                };
                FreezeDataSource Child17 = new FreezeDataSource()
                {
                    TaskId = 24,
                    TaskName = "Testing",
                    StartDate = new DateTime(2017, 02, 21),
                    EndDate = new DateTime(2017, 02, 24),
                    Duration = 2,
                    Progress = 25,
                    Priority = "High",
                    FilterStartDate = new DateTime(2017, 02, 21),
                    FilterEndDate = new DateTime(2017, 02, 24),
                    Approved = false,
                    EmployeeID = 24,
                    Designation = "Sales Representative"
                };
                FreezeDataSource Child18 = new FreezeDataSource()
                {
                    TaskId = 25,
                    TaskName = "Bug fix",
                    StartDate = new DateTime(2017, 02, 25),
                    EndDate = new DateTime(2017, 02, 26),
                    Duration = 2,
                    Progress = 25,
                    Priority = "Low",
                    Approved = false,
                    FilterStartDate = new DateTime(2017, 02, 25),
                    FilterEndDate = new DateTime(2017, 02, 26),
                    EmployeeID = 25,
                    Designation = "Sales Representative"
                };
                FreezeDataSource Child19 = new FreezeDataSource()
                {
                    TaskId = 26,
                    TaskName = "Customer review meeting",
                    StartDate = new DateTime(2017, 02, 27),
                    EndDate = new DateTime(2017, 02, 28),
                    Duration = 2,
                    Progress = 25,
                    Priority = "Critical",
                    FilterStartDate = new DateTime(2017, 02, 27),
                    FilterEndDate = new DateTime(2017, 02, 28),
                    Approved = true,
                    EmployeeID = 26,
                    Designation = "Sales Representative"
                };
                FreezeDataSource Child20 = new FreezeDataSource()
                {
                    TaskId = 27,
                    TaskName = "Phase 2 complete",
                    StartDate = new DateTime(2017, 02, 28),
                    EndDate = new DateTime(2017, 02, 28),
                    Duration = 2,
                    Progress = 25,
                    Priority = "Normal",
                    FilterStartDate = new DateTime(2017, 02, 28),
                    FilterEndDate = new DateTime(2017, 02, 28),
                    Approved = false,
                    EmployeeID = 27,
                    Designation = "Sales Representative"
                };
                Record8.Children.Add(Child15);
                Record8.Children.Add(Child16);
                Record8.Children.Add(Child17);
                Record8.Children.Add(Child18);
                Record8.Children.Add(Child19);
                Record8.Children.Add(Child20);
                Record5.Children.Add(Record8);
                Record3.Children.Add(Record5);
                FreezeDataSource Record6 = new FreezeDataSource()
                {
                    TaskId = 28,
                    TaskName = "Phase 3",
                    StartDate = new DateTime(2017, 02, 17),
                    EndDate = new DateTime(2017, 02, 27),
                    Priority = "Normal",
                    Approved = false,
                    Progress = 25,
                    FilterStartDate = new DateTime(2017, 02, 17),
                    FilterEndDate = new DateTime(2017, 02, 27),
                    Duration = 11,
                    Children = new List<FreezeDataSource>(),
                    EmployeeID = 28,
                    Designation = "Vice President"
                };
                FreezeDataSource Record9 = new FreezeDataSource()
                {
                    TaskId = 29,
                    TaskName = "Implementation Module 3",
                    StartDate = new DateTime(2017, 02, 17),
                    EndDate = new DateTime(2017, 02, 27),
                    Priority = "High",
                    Progress = 25,
                    Approved = false,
                    Duration = 11,
                    FilterStartDate = new DateTime(2017, 02, 17),
                    FilterEndDate = new DateTime(2017, 02, 27),
                    Children = new List<FreezeDataSource>(),
                    EmployeeID = 29,
                    Designation = "Vice President"
                };
                FreezeDataSource Child21 = new FreezeDataSource()
                {
                    TaskId = 30,
                    TaskName = "Development Task 1",
                    StartDate = new DateTime(2017, 02, 17),
                    EndDate = new DateTime(2017, 02, 19),
                    Duration = 3,
                    Progress = 50,
                    Priority = "Low",
                    Approved = true,
                    FilterStartDate = new DateTime(2017, 02, 17),
                    FilterEndDate = new DateTime(2017, 02, 19),
                    EmployeeID = 30,
                    Designation = "Sales Representative"
                };
                FreezeDataSource Child22 = new FreezeDataSource()
                {
                    TaskId = 31,
                    TaskName = "Development Task 2",
                    StartDate = new DateTime(2017, 02, 17),
                    EndDate = new DateTime(2017, 02, 19),
                    Duration = 3,
                    Progress = 50,
                    Priority = "Normal",
                    Approved = false,
                    FilterStartDate = new DateTime(2017, 02, 17),
                    FilterEndDate = new DateTime(2017, 02, 19),
                    EmployeeID = 31,
                    Designation = "Sales Representative"
                };
                FreezeDataSource Child23 = new FreezeDataSource()
                {
                    TaskId = 32,
                    TaskName = "Testing",
                    StartDate = new DateTime(2017, 02, 20),
                    EndDate = new DateTime(2017, 02, 21),
                    Duration = 2,
                    Progress = 25,
                    Priority = "Critical",
                    FilterStartDate = new DateTime(2017, 02, 20),
                    FilterEndDate = new DateTime(2017, 02, 21),
                    Approved = true,
                    EmployeeID = 32,
                    Designation = "Sales Representative"
                };
                FreezeDataSource Child24 = new FreezeDataSource()
                {
                    TaskId = 33,
                    TaskName = "Bug fix",
                    StartDate = new DateTime(2017, 02, 24),
                    EndDate = new DateTime(2017, 02, 25),
                    Duration = 2,
                    Progress = 25,
                    Priority = "High",
                    Approved = false,
                    FilterStartDate = new DateTime(2017, 02, 24),
                    FilterEndDate = new DateTime(2017, 02, 25),
                    EmployeeID = 33,
                    Designation = "Sales Representative"
                };
                FreezeDataSource Child25 = new FreezeDataSource()
                {
                    TaskId = 34,
                    TaskName = "Customer review meeting",
                    StartDate = new DateTime(2017, 02, 26),
                    EndDate = new DateTime(2017, 02, 27),
                    Duration = 2,
                    Progress = 25,
                    Priority = "Normal",
                    FilterStartDate = new DateTime(2017, 02, 26),
                    FilterEndDate = new DateTime(2017, 02, 27),
                    Approved = true,
                    EmployeeID = 34,
                    Designation = "Sales Representative"
                };
                FreezeDataSource Child26 = new FreezeDataSource()
                {
                    TaskId = 35,
                    TaskName = "Phase 3 complete",
                    StartDate = new DateTime(2017, 02, 27),
                    EndDate = new DateTime(2017, 02, 27),
                    Duration = 2,
                    Progress = 25,
                    Priority = "Critical",
                    FilterStartDate = new DateTime(2017, 02, 27),
                    FilterEndDate = new DateTime(2017, 02, 27),
                    Approved = false,
                    EmployeeID = 35,
                    Designation = "Sales Representative"
                };
                Record9.Children.Add(Child21);
                Record9.Children.Add(Child22);
                Record9.Children.Add(Child23);
                Record9.Children.Add(Child24);
                Record9.Children.Add(Child25);
                Record9.Children.Add(Child26);
                Record6.Children.Add(Record9);
                Record3.Children.Add(Record6);
                BusinessObjectCollection.Add(Record1);
                BusinessObjectCollection.Add(Record2);
                BusinessObjectCollection.Add(Record3);

                return BusinessObjectCollection;
            }

        }

    }
}