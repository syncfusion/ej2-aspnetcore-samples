#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.EJ2.Gantt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class GanttData
    {
        public class GanttDataSource
        {
            public int TaskId { get; set; }
            public string TaskName { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public DateTime BaselineStartDate { get; set; }
            public DateTime BaselineEndDate { get; set; }
            public DateTime? DueDate { get; set; }
            public double? TimeLog { get; set; }
            public string Component { get; set; }
            public string Priority { get; set; }
            public string Status { get; set; }
            public double StoryPoints { get; set; }
            public string Manager { get; set; }
            public List<ResourceModel> Assignee { get; set; }
            public int? Duration { get; set; }
            public int Progress { get; set; }
            public bool IsManual { get; set; }
            public double? Work { get; set; }
            public string Predecessor { get; set; }
            public List<GanttDataSource> SubTasks { get; set; }
            public int[] ResourceId { get; set; }
            public List<ResourceModel> Resources { get; set; }
            public string Notes { get; set; }
            public int? ParentID { get; set; }
            public string TaskType { get; set; }
            public List<GanttIndicators> Indicators { get; set; }
            public List<GanttSegment> Segments { get; set; }

        }

        public class ResourceModel
        {
            public int ResourceId { get; set; }
            public Nullable<int> ResourceUnit { get; set; }
        }
        public class GanttResources
        {
            public int ResourceId { get; set; }
            public string ResourceName { get; set; }
            public Nullable<int> Unit { get; set; }
        }

        public class ResourceGroupCollection
        {
            public int ResourceId { get; set; }
            public string ResourceName { get; set; }
            public string ResourceGroup { get; set; }
            public string IsExpand { get; set; }
        }
        public class GanttIndicators
        {
            public DateTime date { get; set; }
            public string name { get; set; }
            public string tooltip { get; set; }
            public string iconClass { get; set; }
        }
        public class TaskbarData : GanttDataSource
        {
            public string Performance { get; set; }
            public string Winner { get; set; }
            public string Movie { get; set; }

        }
        public class GanttSegment
        {
            public int? Duration { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
        }

        public static List<GanttDataSource> ProjectNewData()
        {
            List<GanttDataSource> GanttDataSourceCollection = new List<GanttDataSource>();

            GanttDataSource Record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Product concept",
                StartDate = new DateTime(2019, 04, 02),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };

            GanttDataSource Child11 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Defining the product and its usage",
                StartDate = new DateTime(2019, 04, 02),
                Progress = 30,
                Duration = 3,
            };

            GanttDataSource Child12 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Defining target audience",
                StartDate = new DateTime(2019, 04, 02),
                Duration = 3,
            };

            GanttDataSource Child13 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Prepare product sketch and notes",
                StartDate = new DateTime(2019, 04, 02),
                Progress = 30,
                Duration = 2,
                Predecessor = "2"
            };
            Record1.SubTasks.Add(Child11);
            Record1.SubTasks.Add(Child12);
            Record1.SubTasks.Add(Child13);

            GanttDataSource Record2 = new GanttDataSource()
            {
                TaskId = 5,
                TaskName = "Concept approval",
                StartDate = new DateTime(2019, 04, 02),
                Duration = 0,
                Predecessor = "3, 4",
                Indicators = new List<GanttIndicators>(),
            };
            GanttIndicators indicator1 = new GanttIndicators()
            {
                date = new DateTime(2019, 04, 10),
                name = "Design Phase",
                tooltip = "Design phase completed",
                iconClass = "designPhase e-icons"
            };
            Record2.Indicators.Add(indicator1);
            GanttDataSource Record3 = new GanttDataSource()
            {
                TaskId = 6,
                TaskName = "Market research",
                StartDate = new DateTime(2019, 04, 02),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };

            GanttDataSource Record6Child1 = new GanttDataSource()
            {
                TaskId = 7,
                TaskName = "Demand analysis",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };

            GanttDataSource Record7Child1 = new GanttDataSource()
            {
                TaskId = 8,
                TaskName = "Customer strength",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Predecessor = "5",
                Progress = 30
            };

            GanttDataSource Record7Child2 = new GanttDataSource()
            {
                TaskId = 9,
                TaskName = "Market opportunity analysis",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Predecessor = "5",
            };
            Record6Child1.SubTasks.Add(Record7Child1);
            Record6Child1.SubTasks.Add(Record7Child2);

            GanttDataSource Record6Child2 = new GanttDataSource()
            {
                TaskId = 10,
                TaskName = "Competitor analysis",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Predecessor = "7, 8",
                Progress = 30,
            };
            GanttDataSource Record6Child3 = new GanttDataSource()
            {
                TaskId = 11,
                TaskName = "Product strength analsysis",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Predecessor = "9",
            };
            GanttDataSource Record6Child4 = new GanttDataSource()
            {
                TaskId = 12,
                TaskName = "Research complete",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 0,
                Predecessor = "10",
                Indicators = new List<GanttIndicators>(),
            };

            GanttIndicators indicator2 = new GanttIndicators()
            {
                date = new DateTime(2019, 04, 28),
                name = "Research completed",
                tooltip = "Research completed",
                iconClass = "researchPhase e-icons"
            };
            Record6Child4.Indicators.Add(indicator2);

            Record3.SubTasks.Add(Record6Child1);
            Record3.SubTasks.Add(Record6Child2);
            Record3.SubTasks.Add(Record6Child3);
            Record3.SubTasks.Add(Record6Child4);

            GanttDataSource Record4 = new GanttDataSource()
            {
                TaskId = 13,
                TaskName = "Product design and development",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record13Child1 = new GanttDataSource()
            {
                TaskId = 14,
                TaskName = "Functionality design",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "12"
            };
            GanttDataSource Record13Child2 = new GanttDataSource()
            {
                TaskId = 15,
                TaskName = "Quality design",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Predecessor = "12"
            };
            GanttDataSource Record13Child3 = new GanttDataSource()
            {
                TaskId = 16,
                TaskName = "Define reliability",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 2,
                Progress = 30,
                Predecessor = "15"
            };
            GanttDataSource Record13Child4 = new GanttDataSource()
            {
                TaskId = 17,
                TaskName = "Identifying raw materials",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 2,
                Predecessor = "15"
            };
            GanttDataSource Record13Child5 = new GanttDataSource()
            {
                TaskId = 18,
                TaskName = "Define cost plan",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record18Child1 = new GanttDataSource()
            {
                TaskId = 19,
                TaskName = "Manufacturing cost",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 2,
                Predecessor = "17",
                Progress = 30
            };
            GanttDataSource Record18Child2 = new GanttDataSource()
            {
                TaskId = 20,
                TaskName = "Selling cost",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 2,
                Predecessor = "17",
            };
            Record13Child5.SubTasks.Add(Record18Child1);
            Record13Child5.SubTasks.Add(Record18Child2);

            GanttDataSource Record13Child6 = new GanttDataSource()
            {
                TaskId = 21,
                TaskName = "Development of the final design",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record21Child1 = new GanttDataSource()
            {
                TaskId = 22,
                TaskName = "Defining dimensions and package volume",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 2,
                Predecessor = "19, 20",
                Progress = 30
            };
            GanttDataSource Record21Child2 = new GanttDataSource()
            {
                TaskId = 23,
                TaskName = "Develop design to meet industry standards",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 2,
                Predecessor = "22",
            };
            GanttDataSource Record21Child3 = new GanttDataSource()
            {
                TaskId = 24,
                TaskName = "Include all the details",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Predecessor = "23",
            };
            Record13Child6.SubTasks.Add(Record21Child1);
            Record13Child6.SubTasks.Add(Record21Child2);
            Record13Child6.SubTasks.Add(Record21Child3);
            GanttDataSource Record13Child7 = new GanttDataSource()
            {
                TaskId = 25,
                TaskName = "CAD computer-aided design",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "24"
            };
            GanttDataSource Record13Child8 = new GanttDataSource()
            {
                TaskId = 26,
                TaskName = "CAM computer-aided manufacturing",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Predecessor = "25"
            };
            GanttDataSource Record13Child9 = new GanttDataSource()
            {
                TaskId = 27,
                TaskName = "Design complete",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 0,
                Predecessor = "26",
            };
            GanttDataSource Record5 = new GanttDataSource()
            {
                TaskId = 28,
                TaskName = "Prototype testing",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Progress = 30,
                Predecessor = "27"
            };
            GanttDataSource Record6 = new GanttDataSource()
            {
                TaskId = 29,
                TaskName = "Include feedback",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Predecessor = "28ss",
                Indicators = new List<GanttIndicators>(),
            };

            GanttIndicators indicator3 = new GanttIndicators()
            {
                date = new DateTime(2019, 05, 24),
                name = "Production phase",
                tooltip = "Production phase completed",
                iconClass = "productionPhase e-icons"
            };
            Record6.Indicators.Add(indicator3);

            GanttDataSource Record7 = new GanttDataSource()
            {
                TaskId = 30,
                TaskName = "Manufacturing",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 5,
                Progress = 30,
                Predecessor = "28, 29"
            };
            GanttDataSource Record8 = new GanttDataSource()
            {
                TaskId = 31,
                TaskName = "Assembling materials to finsihed goods",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 5,
                Predecessor = "30"
            };
            Record4.SubTasks.Add(Record13Child1);
            Record4.SubTasks.Add(Record13Child2);
            Record4.SubTasks.Add(Record13Child3);
            Record4.SubTasks.Add(Record13Child4);
            Record4.SubTasks.Add(Record13Child5);
            Record4.SubTasks.Add(Record13Child6);
            Record4.SubTasks.Add(Record13Child7);
            Record4.SubTasks.Add(Record13Child8);
            Record4.SubTasks.Add(Record13Child9);

            GanttDataSource Record9 = new GanttDataSource()
            {
                TaskId = 32,
                TaskName = "Feedback and testing",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record9Child1 = new GanttDataSource()
            {
                TaskId = 33,
                TaskName = "Internal testing and feedback",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 45,
                Predecessor = "31",
            };
            GanttDataSource Record9Child2 = new GanttDataSource()
            {
                TaskId = 34,
                TaskName = "Customer testing and feedback",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 50,
                Predecessor = "33",
            };
            Record9.SubTasks.Add(Record9Child1);
            Record9.SubTasks.Add(Record9Child2);
            GanttDataSource Record10 = new GanttDataSource()
            {
                TaskId = 35,
                TaskName = "Final product development",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record10Child1 = new GanttDataSource()
            {
                TaskId = 36,
                TaskName = "Important improvements",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Progress = 30,
                Predecessor = "34",
            };
            GanttDataSource Record10Child2 = new GanttDataSource()
            {
                TaskId = 37,
                TaskName = "Address any unforeseen issues",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Progress = 30,
                Predecessor = "36ss",
                Indicators = new List<GanttIndicators>()
            };

            GanttIndicators indicator4 = new GanttIndicators()
            {
                date = new DateTime(2019, 06, 21),
                name = "Sales and marketing",
                tooltip = "Sales and marketing",
                iconClass = "salesPhase e-icons"
            };
            Record10Child2.Indicators.Add(indicator4);

            Record10.SubTasks.Add(Record10Child1);
            Record10.SubTasks.Add(Record10Child2);
            GanttDataSource Record11 = new GanttDataSource()
            {
                TaskId = 38,
                TaskName = "Final product",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record11Child1 = new GanttDataSource()
            {
                TaskId = 39,
                TaskName = "Branding product",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Predecessor = "37",
            };
            GanttDataSource Record11Child2 = new GanttDataSource()
            {
                TaskId = 40,
                TaskName = "Marketing and presales",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Progress = 30,
                Predecessor = "39",
            };
            Record11.SubTasks.Add(Record11Child1);
            Record11.SubTasks.Add(Record11Child2);
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
        public static List<GanttDataSource> TemplateData()
        {
            List<GanttDataSource> GanttDataSourceCollection = new List<GanttDataSource>();

            GanttDataSource Record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Product concept",
                StartDate = new DateTime(2019, 04, 02),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };

            GanttDataSource Child11 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Defining the product and its usage",
                StartDate = new DateTime(2019, 04, 02),
                Progress = 30,
                Duration = 3,
                ResourceId = new int[] { 2 }
            };

            GanttDataSource Child12 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Defining target audience",
                StartDate = new DateTime(2019, 04, 02),
                Duration = 3,
                ResourceId = new int[] { 3 }
            };

            GanttDataSource Child13 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Prepare product sketch and notes",
                StartDate = new DateTime(2019, 04, 02),
                Progress = 30,
                Duration = 2,
                Predecessor = "2",
                ResourceId = new int[] { 4 }
            };
            Record1.SubTasks.Add(Child11);
            Record1.SubTasks.Add(Child12);
            Record1.SubTasks.Add(Child13);

            GanttDataSource Record2 = new GanttDataSource()
            {
                TaskId = 5,
                TaskName = "Concept approval",
                StartDate = new DateTime(2019, 04, 02),
                Duration = 0,
                Predecessor = "3, 4",
                ResourceId = new int[] { 1 }
            };

            GanttDataSource Record3 = new GanttDataSource()
            {
                TaskId = 6,
                TaskName = "Market research",
                StartDate = new DateTime(2019, 04, 02),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };

            GanttDataSource Record6Child1 = new GanttDataSource()
            {
                TaskId = 7,
                TaskName = "Demand analysis",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };

            GanttDataSource Record7Child1 = new GanttDataSource()
            {
                TaskId = 8,
                TaskName = "Customer strength",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Predecessor = "5",
                Progress = 30,
                ResourceId = new int[] { 5 }
            };

            GanttDataSource Record7Child2 = new GanttDataSource()
            {
                TaskId = 9,
                TaskName = "Market opportunity analysis",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Predecessor = "5",
                ResourceId = new int[] { 6 }
            };
            Record6Child1.SubTasks.Add(Record7Child1);
            Record6Child1.SubTasks.Add(Record7Child2);

            GanttDataSource Record6Child2 = new GanttDataSource()
            {
                TaskId = 10,
                TaskName = "Competitor analysis",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Predecessor = "7, 8",
                Progress = 30,
                ResourceId = new int[] { 4 }
            };
            GanttDataSource Record6Child3 = new GanttDataSource()
            {
                TaskId = 11,
                TaskName = "Product strength analsysis",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Predecessor = "9",
                ResourceId = new int[] { 8 }
            };
            Record3.SubTasks.Add(Record6Child1);
            Record3.SubTasks.Add(Record6Child2);
            Record3.SubTasks.Add(Record6Child3);

            GanttDataSourceCollection.Add(Record1);
            GanttDataSourceCollection.Add(Record2);
            GanttDataSourceCollection.Add(Record3);
            return GanttDataSourceCollection;
        }
        public static List<GanttDataSource> ZoomingData()
        {
            List<GanttDataSource> GanttDataSourceCollection = new List<GanttDataSource>();

            GanttDataSource Record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Product concept",
                StartDate = new DateTime(2019, 04, 02),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };

            GanttDataSource Child11 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Defining the product and its usage",
                StartDate = new DateTime(2019, 04, 02),
                Progress = 30,
                Duration = 3,
            };

            GanttDataSource Child12 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Defining target audience",
                StartDate = new DateTime(2019, 04, 02),
                Duration = 3,
            };

            GanttDataSource Child13 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Prepare product sketch and notes",
                StartDate = new DateTime(2019, 04, 02),
                Progress = 30,
                Duration = 2,
                Predecessor = "2"
            };
            Record1.SubTasks.Add(Child11);
            Record1.SubTasks.Add(Child12);
            Record1.SubTasks.Add(Child13);

            GanttDataSource Record2 = new GanttDataSource()
            {
                TaskId = 5,
                TaskName = "Concept approval",
                StartDate = new DateTime(2019, 04, 02),
                Duration = 0,
                Predecessor = "3, 4",
            };

            GanttDataSource Record3 = new GanttDataSource()
            {
                TaskId = 6,
                TaskName = "Market research",
                StartDate = new DateTime(2019, 04, 02),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };

            GanttDataSource Record6Child1 = new GanttDataSource()
            {
                TaskId = 7,
                TaskName = "Demand analysis",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };

            GanttDataSource Record7Child1 = new GanttDataSource()
            {
                TaskId = 8,
                TaskName = "Customer strength",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Predecessor = "5",
                Progress = 30
            };

            GanttDataSource Record7Child2 = new GanttDataSource()
            {
                TaskId = 9,
                TaskName = "Market opportunity analysis",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Predecessor = "5",
            };
            Record6Child1.SubTasks.Add(Record7Child1);
            Record6Child1.SubTasks.Add(Record7Child2);

            GanttDataSource Record6Child2 = new GanttDataSource()
            {
                TaskId = 10,
                TaskName = "Competitor analysis",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Predecessor = "7, 8",
                Progress = 30,
            };
            GanttDataSource Record6Child3 = new GanttDataSource()
            {
                TaskId = 11,
                TaskName = "Product strength analsysis",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Predecessor = "9",
            };
            GanttDataSource Record6Child4 = new GanttDataSource()
            {
                TaskId = 12,
                TaskName = "Research complete",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 1,
                Predecessor = "10",
            };
            Record3.SubTasks.Add(Record6Child1);
            Record3.SubTasks.Add(Record6Child2);
            Record3.SubTasks.Add(Record6Child3);
            Record3.SubTasks.Add(Record6Child4);

            GanttDataSourceCollection.Add(Record1);
            GanttDataSourceCollection.Add(Record2);
            GanttDataSourceCollection.Add(Record3);
            return GanttDataSourceCollection;
        }
        public static List<GanttResources> EditingResources()
        {
            List<GanttResources> GanttResourcesCollection = new List<GanttResources>();

            GanttResources Record1 = new GanttResources()
            {
                ResourceId = 1,
                ResourceName = "Martin Tamer"
            };
            GanttResources Record2 = new GanttResources()
            {
                ResourceId = 2,
                ResourceName = "Rose Fuller"
            };
            GanttResources Record3 = new GanttResources()
            {
                ResourceId = 3,
                ResourceName = "Margaret Buchanan"
            };
            GanttResources Record4 = new GanttResources()
            {
                ResourceId = 4,
                ResourceName = "Fuller King"
            };
            GanttResources Record5 = new GanttResources()
            {
                ResourceId = 5,
                ResourceName = "Davolio Fuller"
            };
            GanttResources Record6 = new GanttResources()
            {
                ResourceId = 6,
                ResourceName = "Van Jack"
            };
            GanttResources Record7 = new GanttResources()
            {
                ResourceId = 7,
                ResourceName = "Fuller Buchanan"
            };
            GanttResources Record8 = new GanttResources()
            {
                ResourceId = 8,
                ResourceName = "Jack Davolio"
            };
            GanttResources Record9 = new GanttResources()
            {
                ResourceId = 9,
                ResourceName = "Tamer Vinet"
            };
            GanttResources Record10 = new GanttResources()
            {
                ResourceId = 10,
                ResourceName = "Vinet Fuller"
            };
            GanttResources Record11 = new GanttResources()
            {
                ResourceId = 11,
                ResourceName = "Bergs Anton"
            };
            GanttResources Record12 = new GanttResources()
            {
                ResourceId = 12,
                ResourceName = "Construction Supervisor"
            };
            GanttResourcesCollection.Add(Record1);
            GanttResourcesCollection.Add(Record2);
            GanttResourcesCollection.Add(Record3);
            GanttResourcesCollection.Add(Record4);
            GanttResourcesCollection.Add(Record5);
            GanttResourcesCollection.Add(Record6);
            GanttResourcesCollection.Add(Record7);
            GanttResourcesCollection.Add(Record8);
            GanttResourcesCollection.Add(Record9);
            GanttResourcesCollection.Add(Record10);
            GanttResourcesCollection.Add(Record11);
            GanttResourcesCollection.Add(Record12);
            return GanttResourcesCollection;
        }
        public static List<GanttDataSource> EditingData()
        {
            List<GanttDataSource> GanttDataSourceCollection = new List<GanttDataSource>();

            GanttDataSource Record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Project initiation",
                StartDate = new DateTime(2019, 04, 02),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record1Child1 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Identify site location",
                StartDate = new DateTime(2019, 04, 02),
                Duration = 0,
                Progress = 30,
                ResourceId = new int[] { 1 },
                Notes = "Measure the total property area alloted for construction"
            };
            GanttDataSource Record1Child2 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Perform soil test",
                StartDate = new DateTime(2019, 04, 02),
                Duration = 4,
                Predecessor = "2",
                ResourceId = new int[] { 2, 3, 5 },
                Notes = "Obtain an engineered soil test of lot where construction is planned.From an engineer or company specializing in soil testing"
            };
            GanttDataSource Record1Child3 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Soil test approval",
                StartDate = new DateTime(2019, 04, 02),
                Duration = 0,
                Progress = 30,
                Predecessor = "3"
            };
            Record1.SubTasks.Add(Record1Child1);
            Record1.SubTasks.Add(Record1Child2);
            Record1.SubTasks.Add(Record1Child3);

            GanttDataSource Record2 = new GanttDataSource()
            {
                TaskId = 5,
                TaskName = "Project estimation",
                StartDate = new DateTime(2019, 04, 02),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record2Child1 = new GanttDataSource()
            {
                TaskId = 6,
                TaskName = "Develop floor plan for estimation",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "4",
                ResourceId = new int[] { 4 },
                Notes = "Develop floor plans and obtain a materials list for estimations"
            };
            GanttDataSource Record2Child2 = new GanttDataSource()
            {
                TaskId = 7,
                TaskName = "List materials",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Predecessor = "6",
                ResourceId = new int[] { 4, 8 },
                Notes = ""
            };
            GanttDataSource Record2Child3 = new GanttDataSource()
            {
                TaskId = 8,
                TaskName = "Estimation approval",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 0,
                Predecessor = "7",
                ResourceId = new int[] { 12, 5 },
                Notes = ""
            };
            Record2.SubTasks.Add(Record2Child1);
            Record2.SubTasks.Add(Record2Child2);
            Record2.SubTasks.Add(Record2Child3);

            GanttDataSource Record3 = new GanttDataSource()
            {
                TaskId = 9,
                TaskName = "Sign contract",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 1,
                Predecessor = "8",
                Progress = 30,
                ResourceId = new int[] { 12 },
                Notes = "If required obtain approval from HOA (homeowners association) or ARC (architectural review committee)"
            };

            GanttDataSource Record4 = new GanttDataSource()
            {
                TaskId = 10,
                TaskName = "Project approval and kick off",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                Duration = 0,
                Predecessor = "9",
            };

            GanttDataSource Record5 = new GanttDataSource()
            {
                TaskId = 11,
                TaskName = "Site work",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record5Child1 = new GanttDataSource()
            {
                TaskId = 12,
                TaskName = "Clear the building site",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 2,
                Progress = 30,
                Predecessor = "9",
                ResourceId = new int[] { 6, 7 },
                Notes = "Clear the building site (demolition of existing home if necessary)"
            };
            GanttDataSource Record5Child2 = new GanttDataSource()
            {
                TaskId = 13,
                TaskName = "Install temporary power service",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 2,
                Predecessor = "12",
                ResourceId = new int[] { 6, 7 },
                Notes = ""
            };
            Record5.SubTasks.Add(Record5Child1);
            Record5.SubTasks.Add(Record5Child2);

            GanttDataSource Record6 = new GanttDataSource()
            {
                TaskId = 14,
                TaskName = "Foundation",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record6Child1 = new GanttDataSource()
            {
                TaskId = 15,
                TaskName = "Excavate for foundations",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "13",
                ResourceId = new int[] { 2, 8 },
                Notes = "Excavate the foundation and dig footers (Scope of work is dependent of foundation designed by engineer)"
            };
            GanttDataSource Record6Child2 = new GanttDataSource()
            {
                TaskId = 16,
                TaskName = "Dig footer",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 2,
                Predecessor = "15FF",
                ResourceId = new int[] { 8 },
                Notes = ""
            };
            GanttDataSource Record6Child3 = new GanttDataSource()
            {
                TaskId = 17,
                TaskName = "Install plumbing grounds",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Progress = 30,
                Predecessor = "15",
                ResourceId = new int[] { 9 },
                Notes = ""
            };
            GanttDataSource Record6Child4 = new GanttDataSource()
            {
                TaskId = 18,
                TaskName = "Pour a foundation and footer with concrete",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 1,
                Predecessor = "17",
                ResourceId = new int[] { 8, 9, 10 },
                Notes = ""
            };
            GanttDataSource Record6Child5 = new GanttDataSource()
            {
                TaskId = 19,
                TaskName = "Cure basement walls",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Progress = 30,
                Predecessor = "18",
                ResourceId = new int[] { 10 },
                Notes = ""
            };
            Record6.SubTasks.Add(Record6Child1);
            Record6.SubTasks.Add(Record6Child2);
            Record6.SubTasks.Add(Record6Child3);
            Record6.SubTasks.Add(Record6Child4);
            Record6.SubTasks.Add(Record6Child5);


            GanttDataSource Record7 = new GanttDataSource()
            {
                TaskId = 20,
                TaskName = "Framing",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record7Child1 = new GanttDataSource()
            {
                TaskId = 21,
                TaskName = "Add load-bearing structure",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "19",
                ResourceId = new int[] { 4, 5 },
                Notes = "Build the main load-bearing structure out of thick pieces of wood and possibly metal I-beams for large spans with few supports"
            };
            GanttDataSource Record7Child2 = new GanttDataSource()
            {
                TaskId = 22,
                TaskName = "Install floor joists",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Predecessor = "21",
                ResourceId = new int[] { 2, 3 },
                Notes = "Add floor and ceiling joists and install subfloor panels"
            };
            GanttDataSource Record7Child3 = new GanttDataSource()
            {
                TaskId = 23,
                TaskName = "Add ceiling joists",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "22SS",
                ResourceId = new int[] { 5 },
                Notes = ""
            };
            GanttDataSource Record7Child4 = new GanttDataSource()
            {
                TaskId = 24,
                TaskName = "Install subfloor panels",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Predecessor = "23",
                ResourceId = new int[] { 8, 9 },
                Notes = ""
            };
            GanttDataSource Record7Child5 = new GanttDataSource()
            {
                TaskId = 25,
                TaskName = "Frame floor walls",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "24",
                ResourceId = new int[] { 10 },
                Notes = ""
            };
            GanttDataSource Record7Child6 = new GanttDataSource()
            {
                TaskId = 26,
                TaskName = "Frame floor decking",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "25SS",
                ResourceId = new int[] { 4, 8 },
                Notes = ""
            };
            Record7.SubTasks.Add(Record7Child1);
            Record7.SubTasks.Add(Record7Child2);
            Record7.SubTasks.Add(Record7Child3);
            Record7.SubTasks.Add(Record7Child4);
            Record7.SubTasks.Add(Record7Child5);
            Record7.SubTasks.Add(Record7Child6);

            GanttDataSource Record8 = new GanttDataSource()
            {
                TaskId = 27,
                TaskName = "Exterior finishing",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record8Child1 = new GanttDataSource()
            {
                TaskId = 28,
                TaskName = "Cover outer walls and roof in OSB",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "26",
                ResourceId = new int[] { 2, 8 },
                Notes = "Cover outer walls and roof in OSB or plywood and a water-resistive barrier"
            };
            GanttDataSource Record8Child2 = new GanttDataSource()
            {
                TaskId = 29,
                TaskName = "Add water resistive barrier",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Predecessor = "28",
                ResourceId = new int[] { 1, 10 },
                Notes = "Cover the walls with siding, typically vinyl, wood, or brick veneer but possibly stone or other materials"
            };
            GanttDataSource Record8Child3 = new GanttDataSource()
            {
                TaskId = 30,
                TaskName = "Install roof shingles",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "29",
                ResourceId = new int[] { 8, 9 },
                Notes = "Install roof shingles or other covering for flat roof"
            };
            GanttDataSource Record8Child4 = new GanttDataSource()
            {
                TaskId = 31,
                TaskName = "Install windows",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Predecessor = "29",
                ResourceId = new int[] { 7 },
                Notes = ""
            };
            Record8.SubTasks.Add(Record8Child1);
            Record8.SubTasks.Add(Record8Child2);
            Record8.SubTasks.Add(Record8Child3);
            Record8.SubTasks.Add(Record8Child4);

            GanttDataSource Record9 = new GanttDataSource()
            {
                TaskId = 32,
                TaskName = "Utilities",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record9Child1 = new GanttDataSource()
            {
                TaskId = 33,
                TaskName = "Install internal plumbing",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "26",
                ResourceId = new int[] { 1, 10 },
            };
            GanttDataSource Record9Child2 = new GanttDataSource()
            {
                TaskId = 34,
                TaskName = "Install HVAC",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Predecessor = "33",
                ResourceId = new int[] { 4, 9 },
                Notes = "Add internal plumbing, HVAC, electrical, and natural gas utilities"
            };
            GanttDataSource Record9Child3 = new GanttDataSource()
            {
                TaskId = 35,
                TaskName = "Electrical utilities",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "34",
            };
            GanttDataSource Record9Child4 = new GanttDataSource()
            {
                TaskId = 36,
                TaskName = "Natural gas utilities",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Predecessor = "35",
                ResourceId = new int[] { 11 },
            };
            GanttDataSource Record9Child5 = new GanttDataSource()
            {
                TaskId = 37,
                TaskName = "Install bathroom fixtures",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "35",
                ResourceId = new int[] { 3, 7 },
            };
            Record9.SubTasks.Add(Record9Child1);
            Record9.SubTasks.Add(Record9Child2);
            Record9.SubTasks.Add(Record9Child3);
            Record9.SubTasks.Add(Record9Child4);
            Record9.SubTasks.Add(Record9Child5);

            GanttDataSource Record10 = new GanttDataSource()
            {
                TaskId = 38,
                TaskName = "Interior finsihing",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record10Child1 = new GanttDataSource()
            {
                TaskId = 39,
                TaskName = "Install insulation",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "37",
                ResourceId = new int[] { 1, 8 },
                Notes = "Frame interior walls with wooden 2×4s"
            };
            GanttDataSource Record10Child2 = new GanttDataSource()
            {
                TaskId = 40,
                TaskName = "Install  drywall panels",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Predecessor = "39",
                ResourceId = new int[] { 5 },
                Notes = "Install insulation and interior drywall panels (cementboard for wet areas) and to complete walls and ceilings"
            };
            GanttDataSource Record10Child3 = new GanttDataSource()
            {
                TaskId = 41,
                TaskName = "Spackle",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "40",
                ResourceId = new int[] { 10 },
            };
            GanttDataSource Record10Child4 = new GanttDataSource()
            {
                TaskId = 42,
                TaskName = "Apply primer",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Predecessor = "41",
                ResourceId = new int[] { 10, 11 },
            };
            GanttDataSource Record10Child5 = new GanttDataSource()
            {
                TaskId = 43,
                TaskName = "Paint wall and ceilings",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "42",
                ResourceId = new int[] { 2, 9 },
            };
            GanttDataSource Record10Child6 = new GanttDataSource()
            {
                TaskId = 44,
                TaskName = "Install modular kitchen",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "43",
                ResourceId = new int[] { 5, 7 },
            };
            Record10.SubTasks.Add(Record10Child1);
            Record10.SubTasks.Add(Record10Child2);
            Record10.SubTasks.Add(Record10Child3);
            Record10.SubTasks.Add(Record10Child4);
            Record10.SubTasks.Add(Record10Child5);
            Record10.SubTasks.Add(Record10Child6);


            GanttDataSource Record11 = new GanttDataSource()
            {
                TaskId = 45,
                TaskName = "Flooring",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record11Child1 = new GanttDataSource()
            {
                TaskId = 46,
                TaskName = "Tile kitchen, bathroom and entry walls",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "44",
                ResourceId = new int[] { 4, 9, 3 },
                Notes = "Additional tiling on top of cementboard for wet areas, such as the bathroom and kitchen backsplash"
            };
            GanttDataSource Record11Child2 = new GanttDataSource()
            {
                TaskId = 47,
                TaskName = "Tile floor",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Predecessor = "46SS",
                ResourceId = new int[] { 2, 8 },
                Notes = "Installation of final floor covering, such as floor tile, carpet, or wood flooring"
            };
            Record11.SubTasks.Add(Record11Child1);
            Record11.SubTasks.Add(Record11Child2);

            GanttDataSource Record12 = new GanttDataSource()
            {
                TaskId = 48,
                TaskName = "Final acceptance",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record12Child1 = new GanttDataSource()
            {
                TaskId = 49,
                TaskName = "Final inspection",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 2,
                Progress = 30,
                Predecessor = "47",
                ResourceId = new int[] { 12 },
                Notes = "Ensure the contracted items"
            };
            GanttDataSource Record12Child2 = new GanttDataSource()
            {
                TaskId = 50,
                TaskName = "Cleanup for occupancy",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 2,
                Predecessor = "49",
                ResourceId = new int[] { 1, 5 },
                Notes = "Installation of major appliances"
            };
            GanttDataSource Record12Child3 = new GanttDataSource()
            {
                TaskId = 51,
                TaskName = "Property handover",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 0,
                Predecessor = "50",
                Notes = "Ending the contract"
            };
            Record12.SubTasks.Add(Record12Child1);
            Record12.SubTasks.Add(Record12Child2);
            Record12.SubTasks.Add(Record12Child3);

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
            GanttDataSourceCollection.Add(Record12);
            return GanttDataSourceCollection;
        }
        public static List<GanttDataSource> RemoteData()
        {
            List<GanttDataSource> GanttDataSourceCollection = new List<GanttDataSource>();

            GanttDataSource Record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Germination",
                StartDate = new DateTime(2019, 03, 01),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record1Child1 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Dry seed (caryopsis)",
                StartDate = new DateTime(2019, 03, 01),
                Duration = 0,
            };
            GanttDataSource Record1Child2 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Seed imbibition complete",
                StartDate = new DateTime(2019, 03, 01),
                Duration = 3,
                Predecessor = "2"
            };
            GanttDataSource Record1Child3 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Radicle emerged from caryopsis",
                StartDate = new DateTime(2019, 03, 04),
                Duration = 2,
                Predecessor = "3"
            };
            GanttDataSource Record1Child4 = new GanttDataSource()
            {
                TaskId = 5,
                TaskName = "Coleoptile emerged from caryopsis",
                StartDate = new DateTime(2019, 03, 06),
                Duration = 2,
                Predecessor = "4"
            };
            GanttDataSource Record1Child5 = new GanttDataSource()
            {
                TaskId = 6,
                TaskName = "Emergence: coleoptile penetrates soil surface (cracking stage)",
                StartDate = new DateTime(2019, 03, 08),
                Duration = 2,
                Predecessor = "5"
            };
            Record1.SubTasks.Add(Record1Child1);
            Record1.SubTasks.Add(Record1Child2);
            Record1.SubTasks.Add(Record1Child3);
            Record1.SubTasks.Add(Record1Child4);
            Record1.SubTasks.Add(Record1Child5);


            GanttDataSource Record2 = new GanttDataSource()
            {
                TaskId = 7,
                TaskName = "Leaf development",
                StartDate = new DateTime(2019, 03, 10),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record2Child1 = new GanttDataSource()
            {
                TaskId = 8,
                TaskName = "First leaf through coleoptile",
                StartDate = new DateTime(2019, 03, 10),
                Duration = 1,
                Predecessor = "6"
            };
            GanttDataSource Record2Child2 = new GanttDataSource()
            {
                TaskId = 9,
                TaskName = "First leaf unfolded",
                StartDate = new DateTime(2019, 03, 11),
                Duration = 1,
                Predecessor = "8"
            };
            GanttDataSource Record2Child3 = new GanttDataSource()
            {
                TaskId = 10,
                TaskName = "3 leaves unfolded",
                StartDate = new DateTime(2019, 03, 12),
                Duration = 2,
                Predecessor = "9"
            };
            GanttDataSource Record2Child4 = new GanttDataSource()
            {
                TaskId = 11,
                TaskName = "9 or more leaves unfolded",
                StartDate = new DateTime(2019, 03, 14),
                Duration = 5,
                Predecessor = "10"
            };
            Record2.SubTasks.Add(Record2Child1);
            Record2.SubTasks.Add(Record2Child2);
            Record2.SubTasks.Add(Record2Child3);
            Record2.SubTasks.Add(Record2Child4);

            GanttDataSource Record3 = new GanttDataSource()
            {
                TaskId = 12,
                TaskName = "Tillering",
                StartDate = new DateTime(2019, 03, 18),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record3Child1 = new GanttDataSource()
            {
                TaskId = 13,
                TaskName = "Beginning of tillering: first tiller detectable",
                StartDate = new DateTime(2019, 03, 18),
                Duration = 0,
                Predecessor = "11"
            };
            GanttDataSource Record3Child2 = new GanttDataSource()
            {
                TaskId = 14,
                TaskName = "2 tillers detectable",
                StartDate = new DateTime(2019, 03, 19),
                Duration = 3,
                Predecessor = "13"
            };
            GanttDataSource Record3Child3 = new GanttDataSource()
            {
                TaskId = 15,
                TaskName = "3 tillers detectable",
                StartDate = new DateTime(2019, 03, 22),
                Duration = 3,
                Predecessor = "14"
            };
            GanttDataSource Record3Child4 = new GanttDataSource()
            {
                TaskId = 16,
                TaskName = "Maximum no. of tillers detectable",
                StartDate = new DateTime(2019, 03, 25),
                Duration = 6,
                Predecessor = "15"
            };
            GanttDataSource Record3Child5 = new GanttDataSource()
            {
                TaskId = 17,
                TaskName = "End of tillering",
                StartDate = new DateTime(2019, 03, 30),
                Duration = 0,
                Predecessor = "16"
            };
            Record3.SubTasks.Add(Record3Child1);
            Record3.SubTasks.Add(Record3Child2);
            Record3.SubTasks.Add(Record3Child3);
            Record3.SubTasks.Add(Record3Child4);
            Record3.SubTasks.Add(Record3Child5);

            GanttDataSource Record4 = new GanttDataSource()
            {
                TaskId = 18,
                TaskName = "Stem elongation",
                StartDate = new DateTime(2019, 03, 30),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record4Child1 = new GanttDataSource()
            {
                TaskId = 19,
                TaskName = "Beginning of stem elongation: pseudostem and tillers erect, first internode begins to elongate, top of inflorescence at least 1 cm above tillering node",
                StartDate = new DateTime(2019, 03, 30),
                Duration = 0,
                Predecessor = "17"
            };
            GanttDataSource Record4Child2 = new GanttDataSource()
            {
                TaskId = 20,
                TaskName = "First node at least 1 cm above tillering node",
                StartDate = new DateTime(2019, 03, 31),
                Duration = 1,
                Predecessor = "19"
            };
            GanttDataSource Record4Child3 = new GanttDataSource()
            {
                TaskId = 21,
                TaskName = "Node 3 at least 2 cm above node 2",
                StartDate = new DateTime(2019, 04, 01),
                Duration = 2,
                Predecessor = "20"
            };
            GanttDataSource Record4Child4 = new GanttDataSource()
            {
                TaskId = 22,
                TaskName = "Flag leaf just visible, still rolled",
                StartDate = new DateTime(2019, 04, 03),
                Duration = 4,
                Predecessor = "21"
            };
            GanttDataSource Record4Child5 = new GanttDataSource()
            {
                TaskId = 23,
                TaskName = "Flag leaf stage: flag leaf fully unrolled, ligule just visible",
                StartDate = new DateTime(2019, 04, 07),
                Duration = 2,
                Predecessor = "22"
            };
            Record4.SubTasks.Add(Record4Child1);
            Record4.SubTasks.Add(Record4Child2);
            Record4.SubTasks.Add(Record4Child3);
            Record4.SubTasks.Add(Record4Child4);
            Record4.SubTasks.Add(Record4Child5);

            GanttDataSource Record5 = new GanttDataSource()
            {
                TaskId = 24,
                TaskName = "Booting",
                StartDate = new DateTime(2019, 04, 09),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record5Child1 = new GanttDataSource()
            {
                TaskId = 25,
                TaskName = "Early boot stage: flag leaf sheath extending",
                StartDate = new DateTime(2019, 04, 09),
                Duration = 2,
                Predecessor = "23"
            };
            GanttDataSource Record5Child2 = new GanttDataSource()
            {
                TaskId = 26,
                TaskName = "Mid boot stage: flag leaf sheath just visibly swollen",
                StartDate = new DateTime(2019, 04, 11),
                Duration = 2,
                Predecessor = "25"
            };
            GanttDataSource Record5Child3 = new GanttDataSource()
            {
                TaskId = 27,
                TaskName = "Late boot stage: flag leaf sheath swollen",
                StartDate = new DateTime(2019, 04, 13),
                Duration = 2,
                Predecessor = "26"
            };
            GanttDataSource Record5Child4 = new GanttDataSource()
            {
                TaskId = 28,
                TaskName = "Flag leaf sheath opening",
                StartDate = new DateTime(2019, 04, 15),
                Duration = 2,
                Predecessor = "27"
            };
            GanttDataSource Record5Child5 = new GanttDataSource()
            {
                TaskId = 29,
                TaskName = "First awns visible (in awned forms only)",
                StartDate = new DateTime(2019, 04, 17),
                Duration = 2,
                Predecessor = "28"
            };
            Record5.SubTasks.Add(Record5Child1);
            Record5.SubTasks.Add(Record5Child2);
            Record5.SubTasks.Add(Record5Child3);
            Record5.SubTasks.Add(Record5Child4);
            Record5.SubTasks.Add(Record5Child5);


            GanttDataSource Record6 = new GanttDataSource()
            {
                TaskId = 30,
                TaskName = "Inflorescence emergence, heading",
                StartDate = new DateTime(2019, 04, 18),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record6Child1 = new GanttDataSource()
            {
                TaskId = 31,
                TaskName = "Beginning of heading: tip of inflorescence emerged from sheath, first spikelet just visible",
                StartDate = new DateTime(2019, 04, 18),
                Duration = 0,
                Predecessor = "29"
            };
            GanttDataSource Record6Child2 = new GanttDataSource()
            {
                TaskId = 32,
                TaskName = "20% of inflorescence emerged",
                StartDate = new DateTime(2019, 04, 19),
                Duration = 3,
                Predecessor = "31"
            };
            GanttDataSource Record6Child3 = new GanttDataSource()
            {
                TaskId = 33,
                TaskName = "40% of inflorescence emerged",
                StartDate = new DateTime(2019, 04, 22),
                Duration = 2,
                Predecessor = "32"
            };
            GanttDataSource Record6Child4 = new GanttDataSource()
            {
                TaskId = 34,
                TaskName = "Middle of heading: half of inflorescence emerged",
                StartDate = new DateTime(2019, 04, 23),
                Duration = 0,
                Predecessor = "33"
            };
            GanttDataSource Record6Child5 = new GanttDataSource()
            {
                TaskId = 35,
                TaskName = "60% of inflorescence emerged",
                StartDate = new DateTime(2019, 04, 24),
                Duration = 2,
                Predecessor = "34"
            };
            GanttDataSource Record6Child6 = new GanttDataSource()
            {
                TaskId = 36,
                TaskName = "80% of inflorescence emerged",
                StartDate = new DateTime(2018, 04, 26),
                Duration = 3,
                Predecessor = "35"
            };
            GanttDataSource Record6Child7 = new GanttDataSource()
            {
                TaskId = 37,
                TaskName = "End of heading: inflorescence fully emerged",
                StartDate = new DateTime(2018, 04, 28),
                Duration = 0,
                Predecessor = "36"
            };
            Record6.SubTasks.Add(Record6Child1);
            Record6.SubTasks.Add(Record6Child2);
            Record6.SubTasks.Add(Record6Child3);
            Record6.SubTasks.Add(Record6Child4);
            Record6.SubTasks.Add(Record6Child5);
            Record6.SubTasks.Add(Record6Child6);
            Record6.SubTasks.Add(Record6Child7);

            GanttDataSource Record7 = new GanttDataSource()
            {
                TaskId = 38,
                TaskName = "Flowering, anthesis",
                StartDate = new DateTime(2019, 04, 28),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record7Child1 = new GanttDataSource()
            {
                TaskId = 39,
                TaskName = "Beginning of flowering: first anthers visible",
                StartDate = new DateTime(2019, 04, 28),
                Duration = 0,
                Predecessor = "37"
            };
            GanttDataSource Record7Child2 = new GanttDataSource()
            {
                TaskId = 40,
                TaskName = "Full flowering: 50% of anthers mature",
                StartDate = new DateTime(2019, 04, 29),
                Duration = 5,
                Predecessor = "39"
            };
            GanttDataSource Record7Child3 = new GanttDataSource()
            {
                TaskId = 41,
                TaskName = "Spikelet have completed flowering",
                StartDate = new DateTime(2019, 05, 04),
                Duration = 5,
                Predecessor = "40"
            };
            GanttDataSource Record7Child4 = new GanttDataSource()
            {
                TaskId = 42,
                TaskName = "End of flowering",
                StartDate = new DateTime(2019, 05, 08),
                Duration = 0,
                Predecessor = "41"
            };
            Record7.SubTasks.Add(Record7Child1);
            Record7.SubTasks.Add(Record7Child2);
            Record7.SubTasks.Add(Record7Child3);
            Record7.SubTasks.Add(Record7Child4);

            GanttDataSource Record8 = new GanttDataSource()
            {
                TaskId = 43,
                TaskName = "Development of fruit",
                StartDate = new DateTime(2019, 05, 08),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record8Child1 = new GanttDataSource()
            {
                TaskId = 44,
                TaskName = "Watery ripe: first grains have reached half their final size",
                StartDate = new DateTime(2019, 05, 08),
                Duration = 0,
                Predecessor = "42"
            };
            GanttDataSource Record8Child2 = new GanttDataSource()
            {
                TaskId = 45,
                TaskName = "Early milk",
                StartDate = new DateTime(2019, 05, 09),
                Duration = 3,
                Predecessor = "44"
            };
            GanttDataSource Record8Child3 = new GanttDataSource()
            {
                TaskId = 46,
                TaskName = "Medium milk: grain content milky, grains reached final size,still green",
                StartDate = new DateTime(2019, 05, 12),
                Duration = 3,
                Predecessor = "45"
            };
            GanttDataSource Record8Child4 = new GanttDataSource()
            {
                TaskId = 47,
                TaskName = "Late milk",
                StartDate = new DateTime(2019, 05, 15),
                Duration = 2,
                Predecessor = "46"
            };
            Record8.SubTasks.Add(Record8Child1);
            Record8.SubTasks.Add(Record8Child2);
            Record8.SubTasks.Add(Record8Child3);
            Record8.SubTasks.Add(Record8Child4);

            GanttDataSource Record9 = new GanttDataSource()
            {
                TaskId = 48,
                TaskName = "Ripening",
                StartDate = new DateTime(2019, 05, 17),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record9Child1 = new GanttDataSource()
            {
                TaskId = 49,
                TaskName = "Early dough",
                StartDate = new DateTime(2019, 05, 17),
                Duration = 6,
                Predecessor = "47"
            };
            GanttDataSource Record9Child2 = new GanttDataSource()
            {
                TaskId = 50,
                TaskName = "Soft dough: grain content soft but dry. Fingernail impression not held",
                StartDate = new DateTime(2019, 05, 23),
                Duration = 2,
                Predecessor = "49"
            };
            GanttDataSource Record9Child3 = new GanttDataSource()
            {
                TaskId = 51,
                TaskName = "Hard dough: grain content solid. Fingernail impression held",
                StartDate = new DateTime(2019, 05, 25),
                Duration = 2,
                Predecessor = "50"
            };
            GanttDataSource Record9Child4 = new GanttDataSource()
            {
                TaskId = 52,
                TaskName = "Fully ripe: grain hard, difficult to divide with thumbnail",
                StartDate = new DateTime(2019, 05, 27),
                Duration = 2,
                Predecessor = "51"
            };
            Record9.SubTasks.Add(Record9Child1);
            Record9.SubTasks.Add(Record9Child2);
            Record9.SubTasks.Add(Record9Child3);
            Record9.SubTasks.Add(Record9Child4);
            GanttDataSource Record10 = new GanttDataSource()
            {
                TaskId = 53,
                TaskName = "Senescence",
                StartDate = new DateTime(2019, 05, 29),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record10Child1 = new GanttDataSource()
            {
                TaskId = 54,
                TaskName = "Over-ripe: grain very hard, cannot be dented by thumbnail",
                StartDate = new DateTime(2019, 05, 29),
                Duration = 3,
                Predecessor = "52"
            };
            GanttDataSource Record10Child2 = new GanttDataSource()
            {
                TaskId = 55,
                TaskName = "Grains loosening in day-time",
                StartDate = new DateTime(2019, 06, 01),
                Duration = 1,
                Predecessor = "54"
            };
            GanttDataSource Record10Child3 = new GanttDataSource()
            {
                TaskId = 56,
                TaskName = "Plant dead and collapsing",
                StartDate = new DateTime(2019, 06, 02),
                Duration = 4,
                Predecessor = "55"
            };
            GanttDataSource Record10Child4 = new GanttDataSource()
            {
                TaskId = 57,
                TaskName = "Harvested product",
                StartDate = new DateTime(2019, 06, 06),
                Duration = 2,
                Predecessor = "56"
            };
            Record10.SubTasks.Add(Record10Child1);
            Record10.SubTasks.Add(Record10Child2);
            Record10.SubTasks.Add(Record10Child3);
            Record10.SubTasks.Add(Record10Child4);

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
            //GanttDataSourceCollection.Add(Record11);
            return GanttDataSourceCollection;
        }
        public static List<GanttResources> TimelineResources()
        {
            List<GanttResources> GanttResourcesCollection = new List<GanttResources>();

            GanttResources Record1 = new GanttResources()
            {
                ResourceId = 1,
                ResourceName = "Project Manager"
            };
            GanttResources Record2 = new GanttResources()
            {
                ResourceId = 2,
                ResourceName = "Software Analyst"
            };
            GanttResources Record3 = new GanttResources()
            {
                ResourceId = 3,
                ResourceName = "Developer"
            };
            GanttResources Record4 = new GanttResources()
            {
                ResourceId = 4,
                ResourceName = "Testing Engineer"
            };
            GanttResourcesCollection.Add(Record1);
            GanttResourcesCollection.Add(Record2);
            GanttResourcesCollection.Add(Record3);
            GanttResourcesCollection.Add(Record4);
            return GanttResourcesCollection;
        }
        public static List<GanttDataSource> TimelineData()
        {
            List<GanttDataSource> GanttDataSourceCollection = new List<GanttDataSource>();

            GanttDataSource Record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Project schedule",
                StartDate = new DateTime(2019, 02, 08),
                EndDate = new DateTime(2019, 03, 15),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record1Child1 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Planning",
                StartDate = new DateTime(2019, 02, 08),
                EndDate = new DateTime(2019, 02, 12),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record2Child1 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Plan timeline",
                StartDate = new DateTime(2019, 02, 08),
                EndDate = new DateTime(2019, 02, 12),
                Duration = 5,
                Progress = 100,
                ResourceId = new int[] { 1 }
            };
            GanttDataSource Record2Child2 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Plan budget",
                StartDate = new DateTime(2019, 02, 08),
                EndDate = new DateTime(2019, 02, 12),
                Duration = 5,
                Progress = 100,
                ResourceId = new int[] { 1 }
            };
            GanttDataSource Record2Child3 = new GanttDataSource()
            {
                TaskId = 5,
                TaskName = "Allocate resources",
                StartDate = new DateTime(2019, 02, 08),
                EndDate = new DateTime(2019, 02, 12),
                Duration = 5,
                Progress = 100,
                ResourceId = new int[] { 1 }
            };
            GanttDataSource Record2Child4 = new GanttDataSource()
            {
                TaskId = 6,
                TaskName = "Planning complete",
                StartDate = new DateTime(2019, 02, 10),
                EndDate = new DateTime(2019, 02, 10),
                Duration = 0,
                Progress = 100,
                Predecessor = "3, 4, 5"
            };

            Record1Child1.SubTasks.Add(Record2Child1);
            Record1Child1.SubTasks.Add(Record2Child2);
            Record1Child1.SubTasks.Add(Record2Child3);
            Record1Child1.SubTasks.Add(Record2Child4);

            GanttDataSource Record1Child2 = new GanttDataSource()
            {
                TaskId = 7,
                TaskName = "Design",
                StartDate = new DateTime(2019, 02, 15),
                EndDate = new DateTime(2019, 02, 19),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record7Child1 = new GanttDataSource()
            {
                TaskId = 8,
                TaskName = "Software specification",
                StartDate = new DateTime(2019, 02, 15),
                EndDate = new DateTime(2019, 02, 17),
                Duration = 3,
                Progress = 60,
                Predecessor = "6",
                ResourceId = new int[] { 2 }
            };
            GanttDataSource Record7Child2 = new GanttDataSource()
            {
                TaskId = 9,
                TaskName = "Develop prototype",
                StartDate = new DateTime(2019, 02, 15),
                EndDate = new DateTime(2019, 02, 17),
                Duration = 3,
                Progress = 100,
                Predecessor = "6",
                ResourceId = new int[] { 3 }
            };
            GanttDataSource Record7Child3 = new GanttDataSource()
            {
                TaskId = 10,
                TaskName = "Get approval from customer",
                StartDate = new DateTime(2019, 02, 18),
                EndDate = new DateTime(2019, 02, 19),
                Duration = 2,
                Progress = 100,
                Predecessor = "9",
                ResourceId = new int[] { 1 }
            };
            GanttDataSource Record7Child4 = new GanttDataSource()
            {
                TaskId = 11,
                TaskName = "Design complete",
                StartDate = new DateTime(2019, 02, 17),
                EndDate = new DateTime(2019, 02, 17),
                Duration = 0,
                Predecessor = "10"
            };
            Record1Child2.SubTasks.Add(Record7Child1);
            Record1Child2.SubTasks.Add(Record7Child2);
            Record1Child2.SubTasks.Add(Record7Child3);
            Record1Child2.SubTasks.Add(Record7Child4);

            GanttDataSource Record1Child3 = new GanttDataSource()
            {
                TaskId = 12,
                TaskName = "Implementation phase",
                StartDate = new DateTime(2019, 02, 25),
                EndDate = new DateTime(2019, 03, 05),
                SubTasks = new List<GanttDataSource>(),
            };

            GanttDataSource Record12Child1 = new GanttDataSource()
            {
                TaskId = 13,
                TaskName = "Phase 1",
                StartDate = new DateTime(2019, 02, 25),
                EndDate = new DateTime(2019, 03, 07),
                SubTasks = new List<GanttDataSource>(),
            };

            GanttDataSource Record13Child1 = new GanttDataSource()
            {
                TaskId = 14,
                TaskName = "Implementation module 1",
                StartDate = new DateTime(2019, 02, 25),
                EndDate = new DateTime(2019, 03, 07),
                SubTasks = new List<GanttDataSource>(),
            };
            Record12Child1.SubTasks.Add(Record13Child1);
            GanttDataSource Record14Child1 = new GanttDataSource()
            {
                TaskId = 15,
                TaskName = "Development task 1",
                StartDate = new DateTime(2019, 02, 22),
                EndDate = new DateTime(2019, 02, 24),
                Duration = 3,
                Progress = 50,
                Predecessor = "11",
                ResourceId = new int[] { 3 }
            };
            GanttDataSource Record14Child6 = new GanttDataSource()
            {
                TaskId = 16,
                TaskName = "Development task 2",
                StartDate = new DateTime(2019, 02, 22),
                EndDate = new DateTime(2019, 02, 24),
                Duration = 3,
                Progress = 50,
                Predecessor = "11",
                ResourceId = new int[] { 3 }
            };
            GanttDataSource Record14Child2 = new GanttDataSource()
            {
                TaskId = 17,
                TaskName = "Testing",
                StartDate = new DateTime(2019, 02, 25),
                EndDate = new DateTime(2019, 02, 26),
                Duration = 2,
                Progress = 0,
                Predecessor = "15, 16",
                ResourceId = new int[] { 4 }
            };
            GanttDataSource Record14Child3 = new GanttDataSource()
            {
                TaskId = 18,
                TaskName = "Bug fix",
                StartDate = new DateTime(2019, 03, 01),
                EndDate = new DateTime(2019, 03, 02),
                Duration = 2,
                Progress = 0,
                Predecessor = "17",
                ResourceId = new int[] { 3 }
            };
            GanttDataSource Record14Child4 = new GanttDataSource()
            {
                TaskId = 19,
                TaskName = "Customer review meeting",
                StartDate = new DateTime(2019, 03, 03),
                EndDate = new DateTime(2019, 03, 07),
                Duration = 2,
                Progress = 0,
                Predecessor = "18",
                ResourceId = new int[] { 1 }
            };
            GanttDataSource Record14Child5 = new GanttDataSource()
            {
                TaskId = 20,
                TaskName = "Phase 1 complete",
                StartDate = new DateTime(2019, 03, 05),
                EndDate = new DateTime(2019, 03, 05),
                Duration = 0,
                Predecessor = "19"
            };
            Record13Child1.SubTasks.Add(Record14Child1);
            Record13Child1.SubTasks.Add(Record14Child2);
            Record13Child1.SubTasks.Add(Record14Child3);
            Record13Child1.SubTasks.Add(Record14Child4);
            Record13Child1.SubTasks.Add(Record14Child5);

            GanttDataSource Record12Child2 = new GanttDataSource()
            {
                TaskId = 21,
                TaskName = "Phase 2",
                StartDate = new DateTime(2019, 02, 25),
                EndDate = new DateTime(2019, 03, 05),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record21 = new GanttDataSource()
            {
                TaskId = 22,
                TaskName = "Implementation module 2",
                StartDate = new DateTime(2019, 02, 25),
                EndDate = new DateTime(2019, 03, 05),
                SubTasks = new List<GanttDataSource>(),
            };
            Record12Child2.SubTasks.Add(Record21);

            GanttDataSource Record22 = new GanttDataSource()
            {
                TaskId = 23,
                TaskName = "Development task 1",
                StartDate = new DateTime(2019, 02, 22),
                EndDate = new DateTime(2019, 02, 25),
                Duration = 4,
                Progress = 50,
                ResourceId = new int[] { 3 }
            };
            GanttDataSource Record22Child1 = new GanttDataSource()
            {
                TaskId = 24,
                TaskName = "Development task 2",
                StartDate = new DateTime(2019, 02, 22),
                EndDate = new DateTime(2019, 02, 25),
                Duration = 4,
                Progress = 50,
                ResourceId = new int[] { 3 }
            };
            GanttDataSource Record22Child2 = new GanttDataSource()
            {
                TaskId = 25,
                TaskName = "Testing",
                StartDate = new DateTime(2019, 02, 26),
                EndDate = new DateTime(2019, 03, 01),
                Duration = 2,
                Progress = 0,
                Predecessor = "23, 24",
                ResourceId = new int[] { 4 }
            };
            GanttDataSource Record22Child3 = new GanttDataSource()
            {
                TaskId = 26,
                TaskName = "Bug fix",
                StartDate = new DateTime(2019, 03, 02),
                EndDate = new DateTime(2019, 03, 03),
                Duration = 2,
                Progress = 0,
                Predecessor = "25",
                ResourceId = new int[] { 4 }
            };
            GanttDataSource Record22Child4 = new GanttDataSource()
            {
                TaskId = 27,
                TaskName = "Customer review meeting",
                StartDate = new DateTime(2019, 03, 07),
                EndDate = new DateTime(2019, 03, 09),
                Duration = 2,
                Progress = 0,
                Predecessor = "26",
                ResourceId = new int[] { 1 }
            };
            GanttDataSource Record22Child5 = new GanttDataSource()
            {
                TaskId = 28,
                TaskName = "Phase 2 complete",
                StartDate = new DateTime(2019, 03, 03),
                EndDate = new DateTime(2019, 03, 03),
                Duration = 0,
                Predecessor = "27"
            };
            Record21.SubTasks.Add(Record22Child1);
            Record21.SubTasks.Add(Record22Child2);
            Record21.SubTasks.Add(Record22Child3);
            Record21.SubTasks.Add(Record22Child4);
            Record21.SubTasks.Add(Record22Child5);

            GanttDataSource Record12Child3 = new GanttDataSource()
            {
                TaskId = 29,
                TaskName = "Phase 3",
                StartDate = new DateTime(2019, 02, 25),
                EndDate = new DateTime(2019, 03, 07),
                SubTasks = new List<GanttDataSource>(),
            };
            Record1Child3.SubTasks.Add(Record12Child1);
            Record1Child3.SubTasks.Add(Record12Child2);
            Record1Child3.SubTasks.Add(Record12Child3);

            GanttDataSource Record30 = new GanttDataSource()
            {
                TaskId = 30,
                TaskName = "Implementation module 3",
                StartDate = new DateTime(2019, 02, 25),
                EndDate = new DateTime(2019, 03, 07),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record30Child1 = new GanttDataSource()
            {
                TaskId = 31,
                TaskName = "Development task 1",
                StartDate = new DateTime(2019, 02, 22),
                EndDate = new DateTime(2019, 02, 24),
                Duration = 3,
                Progress = 50,
                ResourceId = new int[] { 3 }
            };
            GanttDataSource Record30Child2 = new GanttDataSource()
            {
                TaskId = 32,
                TaskName = "Development task 2",
                StartDate = new DateTime(2019, 02, 22),
                EndDate = new DateTime(2019, 02, 24),
                Duration = 3,
                Progress = 50,
                ResourceId = new int[] { 3 }
            };
            GanttDataSource Record30Child3 = new GanttDataSource()
            {
                TaskId = 33,
                TaskName = "Testing",
                StartDate = new DateTime(2019, 02, 25),
                EndDate = new DateTime(2019, 02, 26),
                Duration = 2,
                Progress = 0,
                Predecessor = "31, 32",
                ResourceId = new int[] { 4 }
            };
            GanttDataSource Record30Child4 = new GanttDataSource()
            {
                TaskId = 34,
                TaskName = "Bug fix",
                StartDate = new DateTime(2019, 03, 01),
                EndDate = new DateTime(2019, 03, 05),
                Duration = 2,
                Progress = 0,
                Predecessor = "33",
                ResourceId = new int[] { 3 }
            };
            GanttDataSource Record30Child5 = new GanttDataSource()
            {
                TaskId = 35,
                TaskName = "Customer review meeting",
                StartDate = new DateTime(2019, 03, 03),
                EndDate = new DateTime(2019, 03, 04),
                Duration = 2,
                Progress = 0,
                Predecessor = "34",
                ResourceId = new int[] { 1 }
            };
            GanttDataSource Record30Child6 = new GanttDataSource()
            {
                TaskId = 36,
                TaskName = "Phase 3 complete",
                StartDate = new DateTime(2019, 03, 02),
                EndDate = new DateTime(2019, 03, 02),
                Duration = 0,
                Predecessor = "35"
            };

            Record30.SubTasks.Add(Record30Child1);
            Record30.SubTasks.Add(Record30Child2);
            Record30.SubTasks.Add(Record30Child3);
            Record30.SubTasks.Add(Record30Child4);
            Record30.SubTasks.Add(Record30Child5);
            Record30.SubTasks.Add(Record30Child6);

            GanttDataSource Record1Child4 = new GanttDataSource()
            {
                TaskId = 37,
                TaskName = "Integration",
                StartDate = new DateTime(2019, 03, 08),
                EndDate = new DateTime(2019, 03, 10),
                Duration = 3,
                Progress = 0,
                Predecessor = "20, 28, 36",
                ResourceId = new int[] { 3 }
            };
            GanttDataSource Record1Child5 = new GanttDataSource()
            {
                TaskId = 38,
                TaskName = "Final testing",
                StartDate = new DateTime(2019, 03, 11),
                EndDate = new DateTime(2019, 03, 12),
                Duration = 2,
                Progress = 0,
                Predecessor = "37",
                ResourceId = new int[] { 4 }
            };
            GanttDataSource Record1Child6 = new GanttDataSource()
            {
                TaskId = 39,
                TaskName = "Final delivery",
                StartDate = new DateTime(2019, 03, 10),
                EndDate = new DateTime(2019, 03, 10),
                Duration = 0,
                Predecessor = "38",
            };
            Record1.SubTasks.Add(Record1Child1);
            Record1.SubTasks.Add(Record1Child2);
            Record1.SubTasks.Add(Record1Child3);
            GanttDataSourceCollection.Add(Record1);
            GanttDataSourceCollection.Add(Record13Child1);
            GanttDataSourceCollection.Add(Record1Child4);
            GanttDataSourceCollection.Add(Record1Child5);
            GanttDataSourceCollection.Add(Record1Child6);
            return GanttDataSourceCollection;
        }
        public static List<GanttDataSource> BaselineData()
        {
            List<GanttDataSource> GanttDataSourceCollection = new List<GanttDataSource>();

            GanttDataSource Record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Receive vehicle and create job card",
                BaselineStartDate = new DateTime(2018, 03, 05, 10, 0, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 10, 0, 0),
                StartDate = new DateTime(2018, 03, 05, 10, 0, 0),
                EndDate = new DateTime(2018, 03, 05, 10, 0, 0),
            };
            GanttDataSource Record2 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Allot mechanic and send vehicle to service bay",
                BaselineStartDate = new DateTime(2018, 03, 05, 10, 0, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 10, 15, 0),
                StartDate = new DateTime(2018, 03, 05, 10, 15, 0),
                EndDate = new DateTime(2018, 03, 05, 10, 20, 0),
            };
            GanttDataSource Record3 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Change the receive vehicle and create job cardengine oil",
                BaselineStartDate = new DateTime(2018, 03, 05, 10, 15, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 10, 45, 0),
                StartDate = new DateTime(2018, 03, 05, 10, 20, 0),
                EndDate = new DateTime(2018, 03, 05, 10, 35, 0),
            };
            GanttDataSource Record4 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Replace the oil filter",
                BaselineStartDate = new DateTime(2018, 03, 05, 10, 45, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 11, 15, 0),
                StartDate = new DateTime(2018, 03, 05, 10, 35, 0),
                EndDate = new DateTime(2018, 03, 05, 11, 0, 0),
            };
            GanttDataSource Record5 = new GanttDataSource()
            {
                TaskId = 5,
                TaskName = "Replace the air filter",
                BaselineStartDate = new DateTime(2018, 03, 05, 10, 45, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 11, 15, 0),
                StartDate = new DateTime(2018, 03, 05, 10, 35, 0),
                EndDate = new DateTime(2018, 03, 05, 11, 0, 0),
            };
            GanttDataSource Record6 = new GanttDataSource()
            {
                TaskId = 6,
                TaskName = "Replace the fuel filter",
                BaselineStartDate = new DateTime(2018, 03, 05, 11, 15, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 11, 25, 0),
                StartDate = new DateTime(2018, 03, 05, 11, 0, 0),
                EndDate = new DateTime(2018, 03, 05, 11, 20, 0),
            };
            GanttDataSource Record7 = new GanttDataSource()
            {
                TaskId = 7,
                TaskName = "Replace the cabin filter",
                BaselineStartDate = new DateTime(2018, 03, 05, 11, 0, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 11, 30, 0),
                StartDate = new DateTime(2018, 03, 05, 11, 0, 0),
                EndDate = new DateTime(2018, 03, 05, 11, 25, 0),
            };
            GanttDataSource Record8 = new GanttDataSource()
            {
                TaskId = 8,
                TaskName = "Replace the spark plugs",
                BaselineStartDate = new DateTime(2018, 03, 05, 11, 0, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 11, 30, 0),
                StartDate = new DateTime(2018, 03, 05, 11, 25, 0),
                EndDate = new DateTime(2018, 03, 05, 11, 45, 0),
            };
            GanttDataSource Record9 = new GanttDataSource()
            {
                TaskId = 9,
                TaskName = "Check level and refill brake fluid/clutch fluid",
                BaselineStartDate = new DateTime(2018, 03, 05, 11, 20, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 11, 40, 0),
                StartDate = new DateTime(2018, 03, 05, 11, 30, 0),
                EndDate = new DateTime(2018, 03, 05, 11, 50, 0),
            };
            GanttDataSource Record10 = new GanttDataSource()
            {
                TaskId = 10,
                TaskName = "Check Brake Pads/Liners, Brake Discs/Drums, and replace if worn out",
                BaselineStartDate = new DateTime(2018, 03, 05, 11, 40, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 12, 0, 0),
                StartDate = new DateTime(2018, 03, 05, 11, 50, 0),
                EndDate = new DateTime(2018, 03, 05, 12, 20, 0),
            };
            GanttDataSource Record11 = new GanttDataSource()
            {
                TaskId = 11,
                TaskName = "Check level and refill power steering fluid",
                BaselineStartDate = new DateTime(2018, 03, 05, 11, 40, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 12, 0, 0),
                StartDate = new DateTime(2018, 03, 05, 12, 0, 0),
                EndDate = new DateTime(2018, 03, 05, 12, 15, 0),
            };
            GanttDataSource Record12 = new GanttDataSource()
            {
                TaskId = 12,
                TaskName = "Check level and refill Automatic/Manual Transmission Fluid",
                BaselineStartDate = new DateTime(2018, 03, 05, 12, 0, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 12, 35, 0),
                StartDate = new DateTime(2018, 03, 05, 11, 50, 0),
                EndDate = new DateTime(2018, 03, 05, 12, 20, 0),
            };
            GanttDataSource Record13 = new GanttDataSource()
            {
                TaskId = 13,
                TaskName = "Grease and lubricate components",
                BaselineStartDate = new DateTime(2018, 03, 05, 12, 20, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 12, 35, 0),
                StartDate = new DateTime(2018, 03, 05, 12, 20, 0),
                EndDate = new DateTime(2018, 03, 05, 12, 45, 0),
            };
            GanttDataSource Record14 = new GanttDataSource()
            {
                TaskId = 14,
                TaskName = "Inspect and replace the timing belt or timing chain if needed",
                BaselineStartDate = new DateTime(2018, 03, 05, 12, 35, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 13, 0, 0),
                StartDate = new DateTime(2018, 03, 05, 12, 45, 0),
                EndDate = new DateTime(2018, 03, 05, 13, 0, 0),
            };
            GanttDataSource Record15 = new GanttDataSource()
            {
                TaskId = 15,
                TaskName = "Wheel balancing",
                BaselineStartDate = new DateTime(2018, 03, 05, 13, 0, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 13, 20, 0),
                StartDate = new DateTime(2018, 03, 05, 13, 0, 0),
                EndDate = new DateTime(2018, 03, 05, 13, 45, 0),
            };
            GanttDataSource Record16 = new GanttDataSource()
            {
                TaskId = 16,
                TaskName = "Wheel alignment",
                BaselineStartDate = new DateTime(2018, 03, 05, 13, 20, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 13, 45, 0),
                StartDate = new DateTime(2018, 03, 05, 13, 45, 0),
                EndDate = new DateTime(2018, 03, 05, 14, 45, 0),
            };
            GanttDataSource Record17 = new GanttDataSource()
            {
                TaskId = 17,
                TaskName = "Check for proper operation of all lights, wipers etc",
                BaselineStartDate = new DateTime(2018, 03, 05, 13, 50, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 14, 30, 0),
                StartDate = new DateTime(2018, 03, 05, 14, 45, 0),
                EndDate = new DateTime(2018, 03, 05, 15, 30, 0),
            };
            GanttDataSource Record18 = new GanttDataSource()
            {
                TaskId = 18,
                TaskName = "Check for any Error codes in the ECU and take corrective action",
                BaselineStartDate = new DateTime(2018, 03, 05, 14, 30, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 15, 30, 0),
                StartDate = new DateTime(2018, 03, 05, 15, 30, 0),
                EndDate = new DateTime(2018, 03, 05, 16, 15, 0),
            };
            GanttDataSource Record19 = new GanttDataSource()
            {
                TaskId = 19,
                TaskName = "Use scan tool read trouble code",
                BaselineStartDate = new DateTime(2018, 03, 05, 15, 30, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 16, 45, 0),
                StartDate = new DateTime(2018, 03, 05, 16, 15, 0),
                EndDate = new DateTime(2018, 03, 05, 16, 45, 0),
            };
            GanttDataSource Record20 = new GanttDataSource()
            {
                TaskId = 20,
                TaskName = "Exterior washing",
                BaselineStartDate = new DateTime(2018, 03, 05, 16, 45, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 17, 15, 0),
                StartDate = new DateTime(2018, 03, 05, 16, 45, 0),
                EndDate = new DateTime(2018, 03, 05, 17, 30, 0),
            };
            GanttDataSource Record21 = new GanttDataSource()
            {
                TaskId = 21,
                TaskName = "Interior vacuuming",
                BaselineStartDate = new DateTime(2018, 03, 05, 17, 15, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 17, 45, 0),
                StartDate = new DateTime(2018, 03, 05, 17, 30, 0),
                EndDate = new DateTime(2018, 03, 05, 18, 0, 0),
            };
            GanttDataSource Record22 = new GanttDataSource()
            {
                TaskId = 21,
                TaskName = "Final service inspection",
                BaselineStartDate = new DateTime(2018, 03, 05, 17, 45, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 18, 0, 0),
                StartDate = new DateTime(2018, 03, 05, 18, 0, 0),
                EndDate = new DateTime(2018, 03, 05, 18, 30, 0),
            };
            GanttDataSource Record23 = new GanttDataSource()
            {
                TaskId = 23,
                TaskName = "Vehicle handover",
                BaselineStartDate = new DateTime(2018, 03, 05, 18, 0, 0),
                BaselineEndDate = new DateTime(2018, 03, 05, 18, 0, 0),
                StartDate = new DateTime(2018, 03, 05, 18, 30, 0),
                EndDate = new DateTime(2018, 03, 05, 18, 30, 0),
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
            GanttDataSourceCollection.Add(Record13);
            GanttDataSourceCollection.Add(Record14);
            GanttDataSourceCollection.Add(Record15);
            GanttDataSourceCollection.Add(Record16);
            GanttDataSourceCollection.Add(Record17);
            GanttDataSourceCollection.Add(Record18);
            GanttDataSourceCollection.Add(Record19);
            GanttDataSourceCollection.Add(Record20);
            GanttDataSourceCollection.Add(Record21);
            GanttDataSourceCollection.Add(Record22);
            GanttDataSourceCollection.Add(Record23);
            return GanttDataSourceCollection;
        }
        public static List<TaskbarData> TaskbarTemplateData()
        {
            List<TaskbarData> GanttDataSourceCollection = new List<TaskbarData>();

            TaskbarData Record2 = new TaskbarData()
            {
                TaskId = 1,
                TaskName = "Oscar moments",
                StartDate = new DateTime(2018, 03, 05, 18, 0, 0),
                EndDate = new DateTime(2018, 03, 05, 18, 15, 0),
                Winner = "",
                Performance = "90th Academy awards kicks-off and Jimmy kimmel hosts the show"
            };
            TaskbarData Record3 = new TaskbarData()
            {
                TaskId = 2,
                TaskName = "Actor in a supporting role",
                StartDate = new DateTime(2018, 03, 05, 18, 16, 0),
                EndDate = new DateTime(2018, 03, 05, 18, 25, 0),
                Predecessor = "1",
                Winner = "Sam Rockwell",
                Movie = "Three Billboards Outside Ebbing, Missouri."
            };
            TaskbarData Record4 = new TaskbarData()
            {
                TaskId = 3,
                TaskName = "Hair and makeup",
                StartDate = new DateTime(2018, 03, 05, 18, 26, 0),
                EndDate = new DateTime(2018, 03, 05, 18, 32, 0),
                Predecessor = "2",
                Movie = "Darkest Hour"
            };
            TaskbarData Record5 = new TaskbarData()
            {
                TaskId = 4,
                TaskName = "Costume design",
                StartDate = new DateTime(2018, 03, 05, 18, 33, 0),
                EndDate = new DateTime(2018, 03, 05, 18, 40, 0),
                Predecessor = "3",
                Winner = "Mark Bridges",
                Movie = "Phantom Thread"
            };
            TaskbarData Record6 = new TaskbarData()
            {
                TaskId = 5,
                TaskName = "Documentary feature",
                StartDate = new DateTime(2018, 03, 05, 18, 41, 0),
                EndDate = new DateTime(2018, 03, 05, 18, 58, 0),
                Predecessor = "4",
                Winner = "Bryan Fogel",
                Movie = "Icarus"
            };
            TaskbarData Record7 = new TaskbarData()
            {
                TaskId = 6,
                TaskName = "Best sound editing and sound mixing",
                StartDate = new DateTime(2018, 03, 05, 18, 59, 0),
                EndDate = new DateTime(2018, 03, 05, 19, 10, 0),
                Predecessor = "5",
                Winner = "Richard King and Alex Gibson",
                Movie = "Dunkirk"
            };
            TaskbarData Record8 = new TaskbarData()
            {
                TaskId = 7,
                TaskName = "Production design",
                StartDate = new DateTime(2018, 03, 05, 19, 11, 0),
                EndDate = new DateTime(2018, 03, 05, 19, 15, 0),
                Predecessor = "6",
                Movie = "The Shape of Water"
            };
            TaskbarData Record9 = new TaskbarData()
            {
                TaskId = 8,
                TaskName = "Oscar performance",
                StartDate = new DateTime(2018, 03, 05, 19, 16, 0),
                EndDate = new DateTime(2018, 03, 05, 19, 23, 0),
                Predecessor = "7",
                Performance = "Second performance of the night is 'Remember Me' from Coco",
            };
            TaskbarData Record10 = new TaskbarData()
            {
                TaskId = 9,
                TaskName = "Best foreign language film goes",
                StartDate = new DateTime(2018, 03, 05, 19, 24, 0),
                EndDate = new DateTime(2018, 03, 05, 19, 29, 0),
                Predecessor = "8",
                Movie = "A Fantastic Woman"
            };
            TaskbarData Record11 = new TaskbarData()
            {
                TaskId = 10,
                TaskName = "Best supporting actress",
                StartDate = new DateTime(2018, 03, 05, 19, 30, 0),
                EndDate = new DateTime(2018, 03, 05, 19, 35, 0),
                Predecessor = "9",
                Winner = "Allison Janney",
                Movie = "I, Tonya"
            };
            TaskbarData Record12 = new TaskbarData()
            {
                TaskId = 11,
                TaskName = "Best animated short",
                StartDate = new DateTime(2018, 03, 05, 19, 36, 0),
                EndDate = new DateTime(2018, 03, 05, 19, 45, 0),
                Predecessor = "10",
                Winner = "Kobe Bryant",
                Movie = "Dear Basketball"
            };
            TaskbarData Record13 = new TaskbarData()
            {
                TaskId = 12,
                TaskName = "Award for best animated feature.",
                StartDate = new DateTime(2018, 03, 05, 19, 46, 0),
                EndDate = new DateTime(2018, 03, 05, 19, 52, 0),
                Predecessor = "11",
                Movie = "Coco"
            };
            TaskbarData Record14 = new TaskbarData()
            {
                TaskId = 13,
                TaskName = "Best visual effects.",
                StartDate = new DateTime(2018, 03, 05, 19, 53, 0),
                EndDate = new DateTime(2018, 03, 05, 19, 56, 0),
                Predecessor = "12",
                Movie = "Blade Runner 2049"
            };
            TaskbarData Record15 = new TaskbarData()
            {
                TaskId = 14,
                TaskName = "Achievement in film editing",
                StartDate = new DateTime(2018, 03, 05, 19, 57, 0),
                EndDate = new DateTime(2018, 03, 05, 19, 59, 0),
                Predecessor = "13",
                Movie = "Dunkirk",
            };
            TaskbarData Record16 = new TaskbarData()
            {
                TaskId = 15,
                TaskName = "Oscar moments",
                StartDate = new DateTime(2018, 03, 05, 20, 0, 0),
                EndDate = new DateTime(2018, 03, 05, 20, 09, 0),
                Predecessor = "14",
                Performance = "Jimmy Kimmel surprises moviegoers along with celebrities"
            };
            TaskbarData Record17 = new TaskbarData()
            {
                TaskId = 16,
                TaskName = "Best documentary short",
                StartDate = new DateTime(2018, 03, 05, 20, 10, 0),
                EndDate = new DateTime(2018, 03, 05, 20, 12, 0),
                Predecessor = "15",
                Movie = "Heaven is a traffic jam on the 405"
            };
            TaskbarData Record18 = new TaskbarData()
            {
                TaskId = 17,
                TaskName = "Best live action short film",
                StartDate = new DateTime(2018, 03, 05, 20, 13, 0),
                EndDate = new DateTime(2018, 03, 05, 20, 15, 0),
                Predecessor = "16",
                Movie = "The Silent Child"
            };
            TaskbarData Record19 = new TaskbarData()
            {
                TaskId = 18,
                TaskName = "Oscar performance",
                StartDate = new DateTime(2018, 03, 05, 20, 0, 0),
                EndDate = new DateTime(2018, 03, 05, 20, 09, 0),
                Predecessor = "17",
                Performance = "Jimmy Kimmel surprCommon and Andra Day performs 'Stand Up for Something' by 'Marshall'"
            };
            TaskbarData Record20 = new TaskbarData()
            {
                TaskId = 19,
                TaskName = "Oscar moments",
                StartDate = new DateTime(2018, 03, 05, 20, 26, 0),
                EndDate = new DateTime(2018, 03, 05, 20, 29, 0),
                Predecessor = "18",
                Performance = "The oscars are showcasing the #MeToo and #TimesUp movements with a montage and interviews with actors and filmmakers"
            };
            TaskbarData Record21 = new TaskbarData()
            {
                TaskId = 20,
                TaskName = "Oscar for best adapted screenplay",
                StartDate = new DateTime(2018, 03, 05, 20, 30, 0),
                EndDate = new DateTime(2018, 03, 05, 20, 35, 0),
                Predecessor = "19",
                Winner = "James Ivory",
                Movie = "Call Me By Your Name"
            };
            TaskbarData Record22 = new TaskbarData()
            {
                TaskId = 21,
                TaskName = "Oscar for best original screenplay",
                StartDate = new DateTime(2018, 03, 05, 20, 36, 0),
                EndDate = new DateTime(2018, 03, 05, 20, 44, 0),
                Predecessor = "20",
                Winner = "Jordan Peele",
                Movie = "Get Out"
            };
            TaskbarData Record23 = new TaskbarData()
            {
                TaskId = 22,
                TaskName = "Oscar moments",
                StartDate = new DateTime(2018, 03, 05, 20, 40, 0),
                EndDate = new DateTime(2018, 03, 05, 20, 45, 0),
                Predecessor = "21",
                Performance = "Who’s trending on Twitter at the Oscars? Actors Timothée Chalamet, Chadwick Boseman,Tom Holland, Lupita Nyong’o and Adam Rippon."
            };
            TaskbarData Record24 = new TaskbarData()
            {
                TaskId = 23,
                TaskName = "Best cinematography",
                StartDate = new DateTime(2018, 03, 05, 20, 46, 0),
                EndDate = new DateTime(2018, 03, 05, 20, 48, 0),
                Predecessor = "22",
                Winner = "Roger A. Deakins",
                Movie = "Blade Runner 2049"
            };

            TaskbarData Record25 = new TaskbarData()
            {
                TaskId = 24,
                TaskName = "Oscar performance",
                StartDate = new DateTime(2018, 03, 05, 20, 49, 0),
                EndDate = new DateTime(2018, 03, 05, 20, 54, 0),
                Predecessor = "23",
                Performance = "Keala Settle performs the nominated song 'This is Me' from 'The Greatest Showman'."
            };
            TaskbarData Record26 = new TaskbarData()
            {
                TaskId = 25,
                TaskName = "Best original score",
                StartDate = new DateTime(2018, 03, 05, 20, 55, 0),
                EndDate = new DateTime(2018, 03, 05, 20, 59, 0),
                Predecessor = "24",
                Movie = "The Shape of Water"
            };
            TaskbarData Record27 = new TaskbarData()
            {
                TaskId = 26,
                TaskName = "Award for original song",
                StartDate = new DateTime(2018, 03, 05, 21, 0, 0),
                EndDate = new DateTime(2018, 03, 05, 21, 07, 0),
                Predecessor = "25",
                Winner = "Remember Me",
                Movie = "Coco"
            };
            TaskbarData Record28 = new TaskbarData()
            {
                TaskId = 27,
                TaskName = "Oscar moments",
                StartDate = new DateTime(2018, 03, 05, 21, 05, 0),
                EndDate = new DateTime(2018, 03, 05, 21, 11, 0),
                Predecessor = "26",
                Performance = "Time to pay tribute to those in the cinema world we lost last year"
            };
            TaskbarData Record29 = new TaskbarData()
            {
                TaskId = 28,
                TaskName = "Oscar for best director",
                StartDate = new DateTime(2018, 03, 05, 21, 12, 0),
                EndDate = new DateTime(2018, 03, 05, 21, 19, 0),
                Predecessor = "27",
                Winner = "Guillermo del Toro",
                Movie = "The Shape of Water"
            };
            TaskbarData Record30 = new TaskbarData()
            {
                TaskId = 29,
                TaskName = "Best actor in a leading role",
                StartDate = new DateTime(2018, 03, 05, 21, 20, 0),
                EndDate = new DateTime(2018, 03, 05, 21, 29, 0),
                Predecessor = "28",
                Winner = "Gary Oldman",
                Movie = "The Shape of Water"
            };
            TaskbarData Record31 = new TaskbarData()
            {
                TaskId = 30,
                TaskName = "Best leading actress",
                StartDate = new DateTime(2018, 03, 05, 21, 30, 0),
                EndDate = new DateTime(2018, 03, 05, 21, 44, 0),
                Predecessor = "29",
                Winner = "Frances McDormand",
                Movie = "Three Billboards Outside Ebbing, Missouri"
            };
            TaskbarData Record32 = new TaskbarData()
            {
                TaskId = 31,
                TaskName = "Oscar for best picture.",
                StartDate = new DateTime(2018, 03, 05, 21, 20, 0),
                EndDate = new DateTime(2018, 03, 05, 21, 29, 0),
                Predecessor = "30",
                Movie = "The Shape of Water"
            };
            TaskbarData Record33 = new TaskbarData()
            {
                TaskId = 32,
                TaskName = "90th Academy awards wind-up",
                StartDate = new DateTime(2018, 03, 05, 21, 30, 0),
                EndDate = new DateTime(2018, 03, 05, 21, 30, 0),
                Predecessor = "31",
                Duration = 0,
                Performance = "90th Academy awards wind-up"
            };


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
            GanttDataSourceCollection.Add(Record12);
            GanttDataSourceCollection.Add(Record13);
            GanttDataSourceCollection.Add(Record14);
            GanttDataSourceCollection.Add(Record15);
            GanttDataSourceCollection.Add(Record16);
            GanttDataSourceCollection.Add(Record17);
            GanttDataSourceCollection.Add(Record18);
            GanttDataSourceCollection.Add(Record19);
            GanttDataSourceCollection.Add(Record20);
            GanttDataSourceCollection.Add(Record21);
            GanttDataSourceCollection.Add(Record22);
            GanttDataSourceCollection.Add(Record23);
            GanttDataSourceCollection.Add(Record24);
            GanttDataSourceCollection.Add(Record25);
            GanttDataSourceCollection.Add(Record26);
            GanttDataSourceCollection.Add(Record27);
            GanttDataSourceCollection.Add(Record28);
            GanttDataSourceCollection.Add(Record29);
            GanttDataSourceCollection.Add(Record30);
            GanttDataSourceCollection.Add(Record31);
            GanttDataSourceCollection.Add(Record32);
            GanttDataSourceCollection.Add(Record33);
            return GanttDataSourceCollection;
        }
        public static List<GanttDataSource> FilteredData()
        {
            List<GanttDataSource> GanttDataSourceCollection = new List<GanttDataSource>();
            GanttDataSource Record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Launch and flight to lunar orbit",
                StartDate = new DateTime(1969, 07, 16),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record1Child1 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Apollo 11 blasts off from launch pad",
                StartDate = new DateTime(1969, 07, 16, 3, 32, 0),
                EndDate = new DateTime(1969, 07, 16, 3, 32, 0),
                Duration = 0
            };
            GanttDataSource Record1Child2 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Entry to earth’s orbit",
                StartDate = new DateTime(1969, 07, 16, 3, 32, 0),
                EndDate = new DateTime(1969, 07, 16, 3, 44, 0),
                Predecessor = "2"
            };
            GanttDataSource Record1Child3 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Travelling in earth’s orbit",
                StartDate = new DateTime(1969, 07, 16, 3, 44, 0),
                EndDate = new DateTime(1969, 07, 16, 4, 22, 13),
                Predecessor = "3"
            };
            GanttDataSource Record1Child4 = new GanttDataSource()
            {
                TaskId = 5,
                TaskName = "Trajectory change toward the Moon",
                StartDate = new DateTime(1969, 07, 16, 4, 22, 13),
                EndDate = new DateTime(1969, 07, 16, 4, 52, 0),
                Predecessor = "4"
            };
            GanttDataSource Record1Child5 = new GanttDataSource()
            {
                TaskId = 6,
                TaskName = "extraction maneuver performed",
                StartDate = new DateTime(1969, 07, 16, 4, 52, 0),
                EndDate = new DateTime(1969, 07, 16, 4, 52, 0),
                Predecessor = "5"
            };
            GanttDataSource Record1Child6 = new GanttDataSource()
            {
                TaskId = 7,
                TaskName = "Travelling toward moon and entering into lunar orbit",
                StartDate = new DateTime(1969, 07, 16, 4, 52, 0),
                EndDate = new DateTime(1969, 07, 16, 16, 21, 50),
                Predecessor = "6"
            };
            GanttDataSource Record1Child7 = new GanttDataSource()
            {
                TaskId = 8,
                TaskName = "Midcourse correction, sharpening the course and testing the engine",
                StartDate = new DateTime(1969, 07, 16, 23, 22, 0),
                EndDate = new DateTime(1969, 07, 17, 5, 21, 50)
            };
            GanttDataSource Record1Child8 = new GanttDataSource()
            {
                TaskId = 9,
                TaskName = "Reached half the distance spanning between earth and moon",
                StartDate = new DateTime(1969, 07, 17, 5, 22, 0),
                EndDate = new DateTime(1969, 07, 17, 08, 0, 50)
            };
            GanttDataSource Record1Child9 = new GanttDataSource()
            {
                TaskId = 10,
                TaskName = "Reached 3/4th distance spanning between earth and moon",
                StartDate = new DateTime(1969, 07, 17, 20, 02, 0),
                EndDate = new DateTime(1969, 07, 18, 16, 21, 50)
            };
            GanttDataSource Record1Child10 = new GanttDataSource()
            {
                TaskId = 11,
                TaskName = "Reached distance 45000 miles from moon",
                StartDate = new DateTime(1969, 07, 18, 23, 20, 0),
                EndDate = new DateTime(1969, 07, 19, 17, 21, 0)
            };

            Record1.SubTasks.Add(Record1Child1);
            Record1.SubTasks.Add(Record1Child2);
            Record1.SubTasks.Add(Record1Child3);
            Record1.SubTasks.Add(Record1Child4);
            Record1.SubTasks.Add(Record1Child5);
            Record1.SubTasks.Add(Record1Child6);
            Record1.SubTasks.Add(Record1Child7);
            Record1.SubTasks.Add(Record1Child8);
            Record1.SubTasks.Add(Record1Child9);
            Record1.SubTasks.Add(Record1Child10);

            GanttDataSource Record2 = new GanttDataSource()
            {
                TaskId = 12,
                TaskName = "Lunar descent",
                StartDate = new DateTime(1969, 07, 19, 17, 21, 50),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record2Child1 = new GanttDataSource()
            {
                TaskId = 13,
                TaskName = "Lunar orbiting (30 orbits)",
                StartDate = new DateTime(1969, 07, 19, 17, 21, 50),
                EndDate = new DateTime(1969, 07, 20, 12, 52, 0),
                Predecessor = "11"
            };
            GanttDataSource Record2Child2 = new GanttDataSource()
            {
                TaskId = 14,
                TaskName = "Landing site identified",
                StartDate = new DateTime(1969, 07, 20, 12, 52, 0),
                EndDate = new DateTime(1969, 07, 20, 12, 52, 0),
                Predecessor = "13"
            };
            GanttDataSource Record2Child3 = new GanttDataSource()
            {
                TaskId = 15,
                TaskName = "Eagle separated from Columbia",
                StartDate = new DateTime(1969, 07, 20, 17, 44, 0),
                EndDate = new DateTime(1969, 07, 20, 17, 44, 0)
            };
            GanttDataSource Record2Child4 = new GanttDataSource()
            {
                TaskId = 16,
                TaskName = "Eagle’s decent to Moon",
                StartDate = new DateTime(1969, 07, 20, 17, 44, 0),
                EndDate = new DateTime(1969, 07, 20, 20, 16, 40)
            };

            Record2.SubTasks.Add(Record2Child1);
            Record2.SubTasks.Add(Record2Child2);
            Record2.SubTasks.Add(Record2Child3);
            Record2.SubTasks.Add(Record2Child4);

            GanttDataSource Record3 = new GanttDataSource()
            {
                TaskId = 17,
                TaskName = "Landing",
                StartDate = new DateTime(1969, 07, 20, 20, 17, 40),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record3Child1 = new GanttDataSource()
            {
                TaskId = 18,
                TaskName = "Eagle’s touch down",
                StartDate = new DateTime(1969, 07, 20, 20, 17, 40),
                EndDate = new DateTime(1969, 07, 20, 20, 17, 40)
            };
            GanttDataSource Record3Child2 = new GanttDataSource()
            {
                TaskId = 19,
                TaskName = "Radio communication and Performing post landing checklist",
                StartDate = new DateTime(1969, 07, 20, 20, 17, 40),
                EndDate = new DateTime(1969, 07, 20, 23, 43, 0)
            };
            GanttDataSource Record3Child3 = new GanttDataSource()
            {
                TaskId = 20,
                TaskName = "Preparations for EVA (Extra Vehicular Activity)",
                StartDate = new DateTime(1969, 07, 20, 23, 43, 0),
                EndDate = new DateTime(1969, 07, 21, 2, 39, 33)
            };
            GanttDataSource Record3Child4 = new GanttDataSource()
            {
                TaskId = 21,
                TaskName = "Hatch open and climbing down the moon",
                StartDate = new DateTime(1969, 07, 21, 2, 39, 33),
                EndDate = new DateTime(1969, 07, 21, 2, 56, 15)
            };
            GanttDataSource Record3Child5 = new GanttDataSource()
            {
                TaskId = 22,
                TaskName = "Armstrong stepped down on the moon",
                StartDate = new DateTime(1969, 07, 21, 2, 56, 15),
                EndDate = new DateTime(1969, 07, 21, 3, 11, 0)
            };
            Record3.SubTasks.Add(Record3Child1);
            Record3.SubTasks.Add(Record3Child2);
            Record3.SubTasks.Add(Record3Child3);
            Record3.SubTasks.Add(Record3Child4);
            Record3.SubTasks.Add(Record3Child5);

            GanttDataSource Record4 = new GanttDataSource()
            {
                TaskId = 23,
                TaskName = "Lunar surface operations",
                StartDate = new DateTime(1969, 07, 21, 2, 56, 15),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record4Child1 = new GanttDataSource()
            {
                TaskId = 24,
                TaskName = "Soil sample collections",
                StartDate = new DateTime(1969, 07, 21, 2, 56, 15),
                EndDate = new DateTime(1969, 07, 21, 3, 11, 0)
            };
            GanttDataSource Record4Child2 = new GanttDataSource()
            {
                TaskId = 25,
                TaskName = "Aldrin joined Armstrong",
                StartDate = new DateTime(1969, 07, 21, 3, 11, 0),
                EndDate = new DateTime(1969, 07, 21, 3, 41, 0)
            };
            GanttDataSource Record4Child3 = new GanttDataSource()
            {
                TaskId = 26,
                TaskName = "planted the Lunar Flag Assembly",
                StartDate = new DateTime(1969, 07, 21, 3, 41, 0),
                EndDate = new DateTime(1969, 07, 21, 3, 46, 0)
            };
            GanttDataSource Record4Child4 = new GanttDataSource()
            {
                TaskId = 27,
                TaskName = "President Richard Nixon’s telephone-radio transmission",
                StartDate = new DateTime(1969, 07, 21, 3, 48, 0),
                EndDate = new DateTime(1969, 07, 21, 3, 51, 0)
            };
            GanttDataSource Record4Child5 = new GanttDataSource()
            {
                TaskId = 28,
                TaskName = "Collect rock samples, photos and other mission controls",
                StartDate = new DateTime(1969, 07, 21, 3, 52, 0),
                EndDate = new DateTime(1969, 07, 21, 4, 50, 0)
            };
            Record4.SubTasks.Add(Record4Child1);
            Record4.SubTasks.Add(Record4Child2);
            Record4.SubTasks.Add(Record4Child3);
            Record4.SubTasks.Add(Record4Child4);
            Record4.SubTasks.Add(Record4Child5);
            GanttDataSource Record5 = new GanttDataSource()
            {
                TaskId = 29,
                TaskName = "Lunar ascent",
                StartDate = new DateTime(1969, 07, 21, 4, 51, 0),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record5Child1 = new GanttDataSource()
            {
                TaskId = 30,
                TaskName = "Climbing the eagle to ascent",
                StartDate = new DateTime(1969, 07, 21, 4, 51, 0),
                EndDate = new DateTime(1969, 07, 21, 5, 0, 0)
            };
            GanttDataSource Record5Child2 = new GanttDataSource()
            {
                TaskId = 31,
                TaskName = "Hatch closing",
                StartDate = new DateTime(1969, 07, 21, 5, 1, 0),
                EndDate = new DateTime(1969, 07, 21, 5, 1, 0)
            };
            GanttDataSource Record5Child3 = new GanttDataSource()
            {
                TaskId = 32,
                TaskName = "Final housekeeping",
                StartDate = new DateTime(1969, 07, 21, 5, 2, 0),
                EndDate = new DateTime(1969, 07, 21, 8, 0, 0)
            };
            GanttDataSource Record5Child4 = new GanttDataSource()
            {
                TaskId = 33,
                TaskName = "Resting of astronauts",
                StartDate = new DateTime(1969, 07, 21, 8, 0, 0),
                EndDate = new DateTime(1969, 07, 21, 15, 0, 0)
            };
            GanttDataSource Record5Child5 = new GanttDataSource()
            {
                TaskId = 34,
                TaskName = "Preparation for lift off and Ascent engine started",
                StartDate = new DateTime(1969, 07, 21, 15, 0, 0),
                EndDate = new DateTime(1969, 07, 21, 17, 54, 0)
            };
            GanttDataSource Record5Child6 = new GanttDataSource()
            {
                TaskId = 35,
                TaskName = "Eagle lifted off",
                StartDate = new DateTime(1969, 07, 21, 17, 54, 0),
                EndDate = new DateTime(1969, 07, 21, 21, 23, 0)
            };
            GanttDataSource Record5Child7 = new GanttDataSource()
            {
                TaskId = 36,
                TaskName = "Eagle’s travel toward Columbia",
                StartDate = new DateTime(1969, 07, 21, 21, 24, 0),
                EndDate = new DateTime(1969, 07, 21, 21, 35, 0)
            };
            Record5.SubTasks.Add(Record5Child1);
            Record5.SubTasks.Add(Record5Child2);
            Record5.SubTasks.Add(Record5Child3);
            Record5.SubTasks.Add(Record5Child4);
            Record5.SubTasks.Add(Record5Child5);
            Record5.SubTasks.Add(Record5Child6);
            Record5.SubTasks.Add(Record5Child7);

            GanttDataSource Record6 = new GanttDataSource()
            {
                TaskId = 37,
                TaskName = "Return",
                StartDate = new DateTime(1969, 07, 21, 21, 24, 0),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record6Child1 = new GanttDataSource()
            {
                TaskId = 38,
                TaskName = "Eagle docked with Columbia",
                StartDate = new DateTime(1969, 07, 16, 21, 24, 0),
                EndDate = new DateTime(1969, 07, 16, 21, 35, 0)
            };
            GanttDataSource Record6Child2 = new GanttDataSource()
            {
                TaskId = 39,
                TaskName = "Eagle’s ascent stage jettisoned into lunar orbit",
                StartDate = new DateTime(1969, 07, 21, 21, 35, 0),
                EndDate = new DateTime(1969, 07, 21, 23, 41, 0)
            };
            Record6.SubTasks.Add(Record6Child1);
            Record6.SubTasks.Add(Record6Child2);
            GanttDataSource Record7 = new GanttDataSource()
            {
                TaskId = 40,
                TaskName = "Decent toward earth  and splashdown",
                StartDate = new DateTime(1969, 07, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record7Child1 = new GanttDataSource()
            {
                TaskId = 41,
                TaskName = "Spacecraft reaches 1/4th distance spanning between moon and earth",
                StartDate = new DateTime(1969, 07, 21, 23, 50, 0),
                EndDate = new DateTime(1969, 07, 22, 16, 40, 0)
            };
            GanttDataSource Record7Child2 = new GanttDataSource()
            {
                TaskId = 42,
                TaskName = "Spacecraft travels to midway point of journey",
                StartDate = new DateTime(1969, 07, 22, 16, 0, 0),
                EndDate = new DateTime(1969, 07, 23, 16, 0, 0)
            };
            GanttDataSource Record7Child3 = new GanttDataSource()
            {
                TaskId = 43,
                TaskName = "Spacecraft travels to 3/4th point of journey",
                StartDate = new DateTime(1969, 07, 23, 16, 40, 0),
                EndDate = new DateTime(1969, 07, 24, 10, 0, 0)
            };
            GanttDataSource Record7Child4 = new GanttDataSource()
            {
                TaskId = 44,
                TaskName = "Crew prepares for splashdown",
                StartDate = new DateTime(1969, 07, 24, 11, 47, 0),
                EndDate = new DateTime(1969, 07, 24, 16, 20, 0)
            };
            GanttDataSource Record7Child5 = new GanttDataSource()
            {
                TaskId = 45,
                TaskName = "Command and service modules separates",
                StartDate = new DateTime(1969, 07, 24, 16, 20, 0),
                EndDate = new DateTime(1969, 07, 24, 16, 35, 0)
            };
            GanttDataSource Record7Child6 = new GanttDataSource()
            {
                TaskId = 46,
                TaskName = "Command module re-enters the Earth’s atmosphere",
                StartDate = new DateTime(1969, 07, 24, 16, 35, 0),
                EndDate = new DateTime(1969, 07, 24, 16, 50, 0)
            };
            GanttDataSource Record7Child7 = new GanttDataSource()
            {
                TaskId = 47,
                TaskName = "Spacecraft splashes near USS hornet",
                StartDate = new DateTime(1969, 07, 24, 16, 51, 0),
                EndDate = new DateTime(1969, 07, 24, 16, 51, 0)
            };

            Record7.SubTasks.Add(Record7Child1);
            Record7.SubTasks.Add(Record7Child2);
            Record7.SubTasks.Add(Record7Child3);
            Record7.SubTasks.Add(Record7Child4);
            Record7.SubTasks.Add(Record7Child5);
            Record7.SubTasks.Add(Record7Child6);
            Record7.SubTasks.Add(Record7Child7);

            GanttDataSourceCollection.Add(Record1);
            GanttDataSourceCollection.Add(Record2);
            GanttDataSourceCollection.Add(Record3);
            GanttDataSourceCollection.Add(Record4);
            GanttDataSourceCollection.Add(Record5);
            GanttDataSourceCollection.Add(Record6);
            GanttDataSourceCollection.Add(Record7);
            return GanttDataSourceCollection;
        }

        public static List<GanttDataSource> UnscheduledData()
        {
            List<GanttDataSource> ganttData = new List<GanttDataSource>();
            GanttDataSource record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Task 1",
                StartDate = new DateTime(2019, 01, 03),
                EndDate = new DateTime(2019, 01, 08),
                Duration = 5,
                TaskType = "",
            };
            GanttDataSource record2 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Task 2",
                Duration = 5,
                TaskType = "Task with duration only",
            };
            GanttDataSource record3 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Task 3",
                StartDate = new DateTime(2019, 01, 03),
                TaskType = "Task with start date only",

            };
            GanttDataSource record4 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Task 4",
                EndDate = new DateTime(2019, 01, 08),
                TaskType = "Task with end date only",
            };
            ganttData.Add(record1);
            ganttData.Add(record2);
            ganttData.Add(record3);
            ganttData.Add(record4);
            return ganttData;
        }

        public static List<GanttDataSource> SelfData()
        {
            List<GanttDataSource> GanttDataSourceCollection = new List<GanttDataSource>();

            GanttDataSource Record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Project schedule",
                StartDate = new DateTime(2019, 02, 04),
                EndDate = new DateTime(2019, 03, 10)
            };
            GanttDataSource Record2 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Planning",
                StartDate = new DateTime(2019, 02, 04),
                EndDate = new DateTime(2019, 02, 10),
                ParentID = 1
            };
            GanttDataSource Record3 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Plan timeline",
                StartDate = new DateTime(2019, 02, 04),
                EndDate = new DateTime(2019, 02, 10),
                Duration = 6,
                Progress = 60,
                ParentID = 2
            };
            GanttDataSource Record4 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Plan budget",
                StartDate = new DateTime(2019, 02, 04),
                EndDate = new DateTime(2019, 02, 10),
                Duration = 6,
                Progress = 90,
                ParentID = 2
            };
            GanttDataSource Record5 = new GanttDataSource()
            {
                TaskId = 5,
                TaskName = "Allocate resources",
                StartDate = new DateTime(2019, 02, 04),
                EndDate = new DateTime(2019, 02, 10),
                Duration = 6,
                Progress = 75,
                ParentID = 2
            };
            GanttDataSource Record6 = new GanttDataSource()
            {
                TaskId = 6,
                TaskName = "Planning complete",
                StartDate = new DateTime(2019, 02, 06),
                EndDate = new DateTime(2019, 02, 10),
                Duration = 0,
                Predecessor = "3, 4, 5",
                ParentID = 2
            };
            GanttDataSource Record7 = new GanttDataSource()
            {
                TaskId = 7,
                TaskName = "Design",
                StartDate = new DateTime(2019, 02, 13),
                EndDate = new DateTime(2019, 02, 17),
                ParentID = 1
            };
            GanttDataSource Record8 = new GanttDataSource()
            {
                TaskId = 8,
                TaskName = "Software specification",
                StartDate = new DateTime(2019, 02, 13),
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
                StartDate = new DateTime(2019, 02, 13),
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
                StartDate = new DateTime(2019, 02, 16),
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
                StartDate = new DateTime(2019, 02, 17),
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

        public static List<GanttDataSource> TempData()
        {
            List<GanttDataSource> GanttDataSourceCollection = new List<GanttDataSource>();

            GanttDataSource Record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Product concept",
                StartDate = new DateTime(2019, 04, 02),
                EndDate = new DateTime(2019, 04, 29),
                ParentID = 0
            };
            GanttDataSource Record2 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Defining the product and its usage",
                StartDate = new DateTime(2019, 04, 02),
                Duration = 3,
                Progress = 30,
                ParentID = 1,
            };
            GanttDataSource Record3 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Defining target audience",
                StartDate = new DateTime(2019, 04, 02),
                ParentID = 1,
                Duration = 3
            };
            GanttDataSource Record4 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Prepare product sketch and notes",
                StartDate = new DateTime(2019, 04, 05),
                Duration = 2,
                ParentID = 1,
                Predecessor = "2",
                Progress = 30
            };
            GanttDataSource Record5 = new GanttDataSource()
            {
                TaskId = 5,
                TaskName = "Concept approval",
                StartDate = new DateTime(2019, 04, 08),
                ParentID = 0,
                Duration = 0,
                Predecessor = "3,4"
            };
            GanttDataSource Record6 = new GanttDataSource()
            {
                TaskId = 6,
                TaskName = "Market research",
                StartDate = new DateTime(2019, 04, 02),
                ParentID = 0,
                EndDate = new DateTime(2019, 04, 21),
            };
            GanttDataSource Record7 = new GanttDataSource()
            {
                TaskId = 7,
                TaskName = "Demand analysis",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                ParentID = 6,
            };
            GanttDataSource Record8 = new GanttDataSource()
            {
                TaskId = 8,
                TaskName = "Customer strength",
                StartDate = new DateTime(2019, 04, 09),
                Duration = 4,
                Predecessor = "5",
                ParentID = 7,
                Progress = 30
            };
            GanttDataSource Record9 = new GanttDataSource()
            {
                TaskId = 9,
                TaskName = "Market opportunity analysis",
                StartDate = new DateTime(2019, 04, 9),
                Duration = 4,
                ParentID = 7,
                Predecessor = "5"
            };
            GanttDataSource Record10 = new GanttDataSource()
            {
                TaskId = 10,
                TaskName = "Competitor analysis",
                StartDate = new DateTime(2019, 04, 15),
                Duration = 4,
                Predecessor = "7, 8",
                ParentID = 6,
                Progress = 30
            };
            GanttDataSource Record11 = new GanttDataSource()
            {
                TaskId = 11,
                TaskName = "Product strength analsysis",
                StartDate = new DateTime(2019, 04, 15),
                Duration = 4,
                ParentID = 6,
                Predecessor = "9"
            };
            GanttDataSource Record12 = new GanttDataSource()
            {
                TaskId = 12,
                TaskName = "Research complete",
                StartDate = new DateTime(2019, 04, 18),
                Duration = 0,
                ParentID = 6,
                Predecessor = "10"
            };
            GanttDataSource Record13 = new GanttDataSource()
            {
                TaskId = 13,
                TaskName = "Product design and development",
                StartDate = new DateTime(2019, 04, 04),
                ParentID = 0,
                EndDate = new DateTime(2019, 04, 21),
            };
            GanttDataSource Record14 = new GanttDataSource()
            {
                TaskId = 14,
                TaskName = "Functionality design",
                StartDate = new DateTime(2019, 04, 19),
                Duration = 3,
                ParentID = 13,
                Progress = 30,
                Predecessor = "12"
            };
            GanttDataSource Record15 = new GanttDataSource()
            {
                TaskId = 15,
                TaskName = "Quality design",
                StartDate = new DateTime(2019, 04, 19),
                Duration = 3,
                ParentID = 13,
                Predecessor = "12"
            };
            GanttDataSource Record16 = new GanttDataSource()
            {
                TaskId = 16,
                TaskName = "Define reliability",
                StartDate = new DateTime(2019, 04, 24),
                Duration = 2,
                Progress = 30,
                ParentID = 13,
                Predecessor = "15"
            };
            GanttDataSource Record17 = new GanttDataSource()
            {
                TaskId = 17,
                TaskName = "Identifying raw materials",
                StartDate = new DateTime(2019, 04, 24),
                Duration = 2,
                ParentID = 13,
                Predecessor = "15"
            };
            GanttDataSource Record18 = new GanttDataSource()
            {
                TaskId = 18,
                TaskName = "Define cost plan",
                StartDate = new DateTime(2019, 04, 04),
                ParentID = 13,
                EndDate = new DateTime(2019, 04, 21),
            };
            GanttDataSource Record19 = new GanttDataSource()
            {
                TaskId = 19,
                TaskName = "Manufacturing cost",
                StartDate = new DateTime(2019, 04, 26),
                Duration = 2,
                Progress = 30,
                ParentID = 18,
                Predecessor = "17"
            };
            GanttDataSource Record20 = new GanttDataSource()
            {
                TaskId = 20,
                TaskName = "Selling cost",
                StartDate = new DateTime(2019, 04, 26),
                Duration = 2,
                ParentID = 18,
                Predecessor = "17"
            };
            GanttDataSource Record21 = new GanttDataSource()
            {
                TaskId = 21,
                TaskName = "Development of the final design",
                StartDate = new DateTime(2019, 04, 30),
                ParentID = 13,
                EndDate = new DateTime(2019, 04, 21),
            };
            GanttDataSource Record22 = new GanttDataSource()
            {
                TaskId = 22,
                TaskName = "Defining dimensions and package volume",
                StartDate = new DateTime(2019, 04, 30),
                Duration = 2,
                ParentID = 21,
                Progress = 30,
                Predecessor = "19,20"
            };
            GanttDataSource Record23 = new GanttDataSource()
            {
                TaskId = 23,
                TaskName = "Develop design to meet industry standards",
                StartDate = new DateTime(2019, 05, 02),
                Duration = 2,
                ParentID = 21,
                Predecessor = "22"
            };
            GanttDataSource Record24 = new GanttDataSource()
            {
                TaskId = 24,
                TaskName = "Include all the details",
                StartDate = new DateTime(2019, 05, 06),
                Duration = 3,
                ParentID = 21,
                Predecessor = "23"
            };
            GanttDataSource Record25 = new GanttDataSource()
            {
                TaskId = 25,
                TaskName = "CAD computer-aided design",
                StartDate = new DateTime(2019, 05, 09),
                Duration = 3,
                ParentID = 13,
                Progress = 30,
                Predecessor = "24"
            };
            GanttDataSource Record26 = new GanttDataSource()
            {
                TaskId = 26,
                TaskName = "CAM computer-aided manufacturing",
                StartDate = new DateTime(2019, 05, 14),
                Duration = 3,
                ParentID = 13,
                Predecessor = "25"
            };
            GanttDataSource Record27 = new GanttDataSource()
            {
                TaskId = 27,
                TaskName = "Design complete",
                StartDate = new DateTime(2019, 05, 16),
                Duration = 0,
                ParentID = 13,
                Predecessor = "26"
            };
            GanttDataSource Record28 = new GanttDataSource()
            {
                TaskId = 28,
                TaskName = "Prototype testing",
                StartDate = new DateTime(2019, 05, 17),
                Duration = 4,
                Progress = 30,
                ParentID = 0,
                Predecessor = "27"
            };
            GanttDataSource Record29 = new GanttDataSource()
            {
                TaskId = 29,
                TaskName = "Include feedback",
                StartDate = new DateTime(2019, 05, 17),
                Duration = 4,
                ParentID = 0,
                Predecessor = "28ss"
            };
            GanttDataSource Record30 = new GanttDataSource()
            {
                TaskId = 30,
                TaskName = "Manufacturing",
                StartDate = new DateTime(2019, 05, 23),
                Duration = 5,
                Progress = 30,
                ParentID = 0,
                Predecessor = "28,29"
            };
            GanttDataSource Record31 = new GanttDataSource()
            {
                TaskId = 31,
                TaskName = "Assembling materials to finsihed goods",
                StartDate = new DateTime(2019, 05, 30),
                Duration = 5,
                ParentID = 0,
                Predecessor = "30"
            };
            GanttDataSource Record32 = new GanttDataSource()
            {
                TaskId = 32,
                TaskName = "Feedback and testing",
                StartDate = new DateTime(2019, 05, 04),
                ParentID = 0,
                EndDate = new DateTime(2019, 05, 21),
            };
            GanttDataSource Record33 = new GanttDataSource()
            {
                TaskId = 33,
                TaskName = "Internal testing and feedback",
                StartDate = new DateTime(2019, 06, 06),
                Duration = 3,
                ParentID = 32,
                Progress = 45,
                Predecessor = "31"
            };
            GanttDataSource Record34 = new GanttDataSource()
            {
                TaskId = 34,
                TaskName = "Customer testing and feedback",
                StartDate = new DateTime(2019, 06, 11),
                Duration = 3,
                ParentID = 32,
                Progress = 50,
                Predecessor = "33"
            };
            GanttDataSource Record35 = new GanttDataSource()
            {
                TaskId = 35,
                TaskName = "Final product development",
                StartDate = new DateTime(2019, 06, 06),
                ParentID = 0,
                EndDate = new DateTime(2019, 06, 06),
            };
            GanttDataSource Record36 = new GanttDataSource()
            {
                TaskId = 36,
                TaskName = "Important improvements",
                StartDate = new DateTime(2019, 06, 14),
                Duration = 4,
                Progress = 30,
                ParentID = 35,
                Predecessor = "34"
            };
            GanttDataSource Record37 = new GanttDataSource()
            {
                TaskId = 37,
                TaskName = "Address any unforeseen issues",
                StartDate = new DateTime(2019, 06, 14),
                Duration = 4,
                Progress = 30,
                ParentID = 35,
                Predecessor = "36ss"
            };
            GanttDataSource Record38 = new GanttDataSource()
            {
                TaskId = 38,
                TaskName = "Final product",
                StartDate = new DateTime(2019, 06, 06),
                ParentID = 0,
                EndDate = new DateTime(2019, 06, 06),
            };
            GanttDataSource Record39 = new GanttDataSource()
            {
                TaskId = 39,
                TaskName = "Branding product",
                StartDate = new DateTime(2019, 06, 20),
                Duration = 4,
                ParentID = 38,
                Predecessor = "37"
            };
            GanttDataSource Record40 = new GanttDataSource()
            {
                TaskId = 40,
                TaskName = "Marketing and presales",
                StartDate = new DateTime(2019, 06, 26),
                Duration = 4,
                Progress = 30,
                ParentID = 38,
                Predecessor = "39"
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
            GanttDataSourceCollection.Add(Record12);
            GanttDataSourceCollection.Add(Record13);
            GanttDataSourceCollection.Add(Record14);
            GanttDataSourceCollection.Add(Record15);
            GanttDataSourceCollection.Add(Record16);
            GanttDataSourceCollection.Add(Record17);
            GanttDataSourceCollection.Add(Record18);
            GanttDataSourceCollection.Add(Record19);
            GanttDataSourceCollection.Add(Record20);
            GanttDataSourceCollection.Add(Record21);
            GanttDataSourceCollection.Add(Record22);
            GanttDataSourceCollection.Add(Record23);
            GanttDataSourceCollection.Add(Record24);
            GanttDataSourceCollection.Add(Record25);
            GanttDataSourceCollection.Add(Record26);
            GanttDataSourceCollection.Add(Record27);
            GanttDataSourceCollection.Add(Record28);
            GanttDataSourceCollection.Add(Record29);
            GanttDataSourceCollection.Add(Record30);
            GanttDataSourceCollection.Add(Record31);
            GanttDataSourceCollection.Add(Record32);
            GanttDataSourceCollection.Add(Record33);
            GanttDataSourceCollection.Add(Record34);
            GanttDataSourceCollection.Add(Record35);
            GanttDataSourceCollection.Add(Record36);
            GanttDataSourceCollection.Add(Record37);
            GanttDataSourceCollection.Add(Record38);
            GanttDataSourceCollection.Add(Record39);
            GanttDataSourceCollection.Add(Record40);
            return GanttDataSourceCollection;
        }

        public static List<GanttDataSource> VirtualData()
        {
            List<GanttDataSource> list = new List<GanttDataSource>();
            for (var i = 0; i < 50; i++)
            {
                var x = list.Count + 1;
                list.Add(new GanttDataSource()
                {
                    TaskId = x,
                    TaskName = "Project " + (i + 1)
                });
                for (var j = 0; j < TempData().ToList().Count; j++)
                {
                    list.Add(new GanttDataSource()
                    {
                        TaskId = TempData()[j].TaskId + x,
                        TaskName = TempData()[j].TaskName,
                        StartDate = TempData()[j].StartDate,
                        Duration = TempData()[j].Duration,
                        Progress = TempData()[j].Progress,
                        ParentID = TempData()[j].ParentID + x
                    });
                }
            }
            return list;
        }
        public static List<GanttDataSource> LabelData()
        {
            List<GanttDataSource> GanttDataSourceCollection = new List<GanttDataSource>();

            GanttDataSource Record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Project initiation",
                StartDate = new DateTime(2019, 04, 02),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record1Child1 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Identify Site location",
                StartDate = new DateTime(2019, 04, 02),
                Duration = 0,
                Progress = 30,
                ResourceId = new int[] { 1 },
                Notes = "Measure the total property area alloted for construction",
                BaselineStartDate = new DateTime(2019, 04, 02),
                BaselineEndDate = new DateTime(2019, 04, 02)
            };
            GanttDataSource Record1Child2 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Perform soil test",
                StartDate = new DateTime(2019, 04, 02),
                Duration = 4,
                Predecessor = "2",
                ResourceId = new int[] { 2, 3, 5 },
                Notes = "Obtain an engineered soil test of lot where construction is planned.From an engineer or company specializing in soil testing",
                BaselineStartDate = new DateTime(2019, 04, 01),
                BaselineEndDate = new DateTime(2019, 04, 04)
            };
            GanttDataSource Record1Child3 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Soil test approval",
                StartDate = new DateTime(2019, 04, 02),
                Duration = 0,
                Progress = 30,
                Predecessor = "3",
                BaselineStartDate = new DateTime(2019, 04, 06),
                BaselineEndDate = new DateTime(2019, 04, 06)
            };
            Record1.SubTasks.Add(Record1Child1);
            Record1.SubTasks.Add(Record1Child2);
            Record1.SubTasks.Add(Record1Child3);

            GanttDataSource Record2 = new GanttDataSource()
            {
                TaskId = 5,
                TaskName = "Project estimation",
                StartDate = new DateTime(2019, 04, 02),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record2Child1 = new GanttDataSource()
            {
                TaskId = 6,
                TaskName = "Develop floor plan for estimation",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "4",
                ResourceId = new int[] { 4 },
                Notes = "Develop floor plans and obtain a materials list for estimations",
                BaselineStartDate = new DateTime(2019, 04, 05),
                BaselineEndDate = new DateTime(2019, 04, 07)
            };
            GanttDataSource Record2Child2 = new GanttDataSource()
            {
                TaskId = 7,
                TaskName = "List materials",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Predecessor = "6",
                ResourceId = new int[] { 4, 8 },
                Notes = "",
                BaselineStartDate = new DateTime(2019, 04, 09),
                BaselineEndDate = new DateTime(2019, 04, 12)
            };
            GanttDataSource Record2Child3 = new GanttDataSource()
            {
                TaskId = 8,
                TaskName = "Estimation approval",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 0,
                Predecessor = "7",
                ResourceId = new int[] { 12, 5 },
                Notes = "",
                BaselineStartDate = new DateTime(2019, 04, 16),
                BaselineEndDate = new DateTime(2019, 04, 16)
            };
            Record2.SubTasks.Add(Record2Child1);
            Record2.SubTasks.Add(Record2Child2);
            Record2.SubTasks.Add(Record2Child3);

            GanttDataSource Record3 = new GanttDataSource()
            {
                TaskId = 9,
                TaskName = "Sign contract",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 1,
                Predecessor = "8",
                Progress = 30,
                ResourceId = new int[] { 12 },
                Notes = "If required obtain approval from HOA (homeowners association) or ARC (architectural review committee)",
                BaselineStartDate = new DateTime(2019, 04, 16),
                BaselineEndDate = new DateTime(2019, 04, 17)
            };

            GanttDataSource Record4 = new GanttDataSource()
            {
                TaskId = 10,
                TaskName = "Project approval and kick off",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                Duration = 0,
                Predecessor = "9",
                BaselineStartDate = new DateTime(2019, 04, 17),
                BaselineEndDate = new DateTime(2019, 04, 17)
            };

            GanttDataSource Record5 = new GanttDataSource()
            {
                TaskId = 11,
                TaskName = "Site wwork",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record5Child1 = new GanttDataSource()
            {
                TaskId = 12,
                TaskName = "Clear the building site",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 2,
                Progress = 30,
                Predecessor = "9",
                Notes = "Clear the building site (demolition of existing home if necessary)",
                BaselineStartDate = new DateTime(2019, 04, 16),
                BaselineEndDate = new DateTime(2019, 04, 18)
            };
            GanttDataSource Record5Child2 = new GanttDataSource()
            {
                TaskId = 13,
                TaskName = "Install temporary power service",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 2,
                Predecessor = "12",
                Notes = "",
                BaselineStartDate = new DateTime(2019, 04, 17),
                BaselineEndDate = new DateTime(2019, 04, 19)
            };
            Record5.SubTasks.Add(Record5Child1);
            Record5.SubTasks.Add(Record5Child2);

            GanttDataSourceCollection.Add(Record1);
            GanttDataSourceCollection.Add(Record2);
            GanttDataSourceCollection.Add(Record3);
            GanttDataSourceCollection.Add(Record4);
            GanttDataSourceCollection.Add(Record5);

            return GanttDataSourceCollection;
        }

        public static List<GanttDataSource> TooltipData()
        {
            List<GanttDataSource> GanttDataSourceCollection = new List<GanttDataSource>();

            GanttDataSource Record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Project initiation",
                StartDate = new DateTime(2019, 04, 02),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record1Child1 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Identify Site location",
                StartDate = new DateTime(2019, 04, 02),
                Duration = 0,
                Progress = 30,
                ResourceId = new int[] { 1 },
                Notes = "Measure the total property area alloted for construction",
                BaselineStartDate = new DateTime(2019, 04, 02),
                BaselineEndDate = new DateTime(2019, 04, 02)
            };
            GanttDataSource Record1Child2 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Perform soil test",
                StartDate = new DateTime(2019, 04, 02),
                Duration = 4,
                Predecessor = "2",
                ResourceId = new int[] { 2 },
                Notes = "Obtain an engineered soil test of lot where construction is planned.From an engineer or company specializing in soil testing",
                BaselineStartDate = new DateTime(2019, 04, 01),
                BaselineEndDate = new DateTime(2019, 04, 04)
            };
            GanttDataSource Record1Child3 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Soil test approval",
                StartDate = new DateTime(2019, 04, 02),
                Duration = 0,
                Progress = 30,
                Predecessor = "3",
                BaselineStartDate = new DateTime(2019, 04, 06),
                BaselineEndDate = new DateTime(2019, 04, 06)
            };
            Record1.SubTasks.Add(Record1Child1);
            Record1.SubTasks.Add(Record1Child2);
            Record1.SubTasks.Add(Record1Child3);

            GanttDataSource Record2 = new GanttDataSource()
            {
                TaskId = 5,
                TaskName = "Project estimation",
                StartDate = new DateTime(2019, 04, 02),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record2Child1 = new GanttDataSource()
            {
                TaskId = 6,
                TaskName = "Develop floor plan for estimation",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Progress = 30,
                Predecessor = "4",
                ResourceId = new int[] { 4 },
                Notes = "Develop floor plans and obtain a materials list for estimations",
                BaselineStartDate = new DateTime(2019, 04, 05),
                BaselineEndDate = new DateTime(2019, 04, 07)
            };
            GanttDataSource Record2Child2 = new GanttDataSource()
            {
                TaskId = 7,
                TaskName = "List materials",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 3,
                Predecessor = "6",
                ResourceId = new int[] { 4 },
                Notes = "",
                BaselineStartDate = new DateTime(2019, 04, 09),
                BaselineEndDate = new DateTime(2019, 04, 12)
            };
            GanttDataSource Record2Child3 = new GanttDataSource()
            {
                TaskId = 8,
                TaskName = "Estimation approval",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 0,
                Predecessor = "7",
                ResourceId = new int[] { 12 },
                Notes = "",
                BaselineStartDate = new DateTime(2019, 04, 16),
                BaselineEndDate = new DateTime(2019, 04, 16)
            };
            Record2.SubTasks.Add(Record2Child1);
            Record2.SubTasks.Add(Record2Child2);
            Record2.SubTasks.Add(Record2Child3);

            GanttDataSource Record3 = new GanttDataSource()
            {
                TaskId = 9,
                TaskName = "Sign contract",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 1,
                Predecessor = "8",
                Progress = 30,
                ResourceId = new int[] { 12 },
                Notes = "If required obtain approval from HOA (homeowners association) or ARC (architectural review committee)",
                BaselineStartDate = new DateTime(2019, 04, 16),
                BaselineEndDate = new DateTime(2019, 04, 17)
            };

            GanttDataSource Record4 = new GanttDataSource()
            {
                TaskId = 10,
                TaskName = "Project approval and kick off",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                Duration = 0,
                Predecessor = "9",
                BaselineStartDate = new DateTime(2019, 04, 17),
                BaselineEndDate = new DateTime(2019, 04, 17)
            };

            GanttDataSource Record5 = new GanttDataSource()
            {
                TaskId = 11,
                TaskName = "Site wwork",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record5Child1 = new GanttDataSource()
            {
                TaskId = 12,
                TaskName = "Clear the building site",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 2,
                Progress = 30,
                Predecessor = "9",
                Notes = "Clear the building site (demolition of existing home if necessary)",
                BaselineStartDate = new DateTime(2019, 04, 16),
                BaselineEndDate = new DateTime(2019, 04, 18)
            };
            GanttDataSource Record5Child2 = new GanttDataSource()
            {
                TaskId = 13,
                TaskName = "Install temporary power service",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 2,
                Predecessor = "12",
                Notes = "",
                BaselineStartDate = new DateTime(2019, 04, 17),
                BaselineEndDate = new DateTime(2019, 04, 19)
            };
            Record5.SubTasks.Add(Record5Child1);
            Record5.SubTasks.Add(Record5Child2);

            GanttDataSourceCollection.Add(Record1);
            GanttDataSourceCollection.Add(Record2);
            GanttDataSourceCollection.Add(Record3);
            GanttDataSourceCollection.Add(Record4);
            GanttDataSourceCollection.Add(Record5);

            return GanttDataSourceCollection;
        }

        public static List<ResourceGroupCollection> GetResourceGroup()
        {
            List<ResourceGroupCollection> GanttResourcesCollection = new List<ResourceGroupCollection>();

            ResourceGroupCollection Record1 = new ResourceGroupCollection()
            {
                ResourceId = 1,
                ResourceName = "Martin Tamer",
                ResourceGroup = "Planning Team",
                IsExpand = "false"
            };
            ResourceGroupCollection Record2 = new ResourceGroupCollection()
            {
                ResourceId = 2,
                ResourceName = "Rose Fuller",
                ResourceGroup = "Testing Team",
                IsExpand = "true"
            };
            ResourceGroupCollection Record3 = new ResourceGroupCollection()
            {
                ResourceId = 3,
                ResourceName = "Margaret Buchanan",
                ResourceGroup = "Approval Team",
                IsExpand = "false"
            };
            ResourceGroupCollection Record4 = new ResourceGroupCollection()
            {
                ResourceId = 4,
                ResourceName = "Fuller King",
                ResourceGroup = "Development Team",
                IsExpand = "true"
            };
            ResourceGroupCollection Record5 = new ResourceGroupCollection()
            {
                ResourceId = 5,
                ResourceName = "Davolio Fuller",
                ResourceGroup = "Approval Team",
                IsExpand = "false"
            };
            ResourceGroupCollection Record6 = new ResourceGroupCollection()
            {
                ResourceId = 6,
                ResourceName = "Van Jack",
                ResourceGroup = "Development Team"
            };
            GanttResourcesCollection.Add(Record1);
            GanttResourcesCollection.Add(Record2);
            GanttResourcesCollection.Add(Record3);
            GanttResourcesCollection.Add(Record4);
            GanttResourcesCollection.Add(Record5);
            GanttResourcesCollection.Add(Record6);
            return GanttResourcesCollection;
        }
        public static List<GanttResources> GetResources()
        {
            List<GanttResources> GanttResourcesCollection = new List<GanttResources>();

            GanttResources Record1 = new GanttResources()
            {
                ResourceId = 1,
                ResourceName = "Martin Tamer"
            };
            GanttResources Record2 = new GanttResources()
            {
                ResourceId = 2,
                ResourceName = "Rose Fuller"
            };
            GanttResources Record3 = new GanttResources()
            {
                ResourceId = 3,
                ResourceName = "Margaret Buchanan"
            };
            GanttResources Record4 = new GanttResources()
            {
                ResourceId = 4,
                ResourceName = "Fuller King"
            };
            GanttResources Record5 = new GanttResources()
            {
                ResourceId = 5,
                ResourceName = "Davolio Fuller"
            };
            GanttResources Record6 = new GanttResources()
            {
                ResourceId = 6,
                ResourceName = "Van Jack"
            };
            GanttResources Record7 = new GanttResources()
            {
                ResourceId = 7,
                ResourceName = "Fuller Buchanan"
            };
            GanttResources Record8 = new GanttResources()
            {
                ResourceId = 8,
                ResourceName = "Jack Davolio"
            };
            GanttResources Record9 = new GanttResources()
            {
                ResourceId = 9,
                ResourceName = "Tamer Vinet"
            };
            GanttResources Record10 = new GanttResources()
            {
                ResourceId = 10,
                ResourceName = "Vinet Fuller"
            };
            GanttResources Record11 = new GanttResources()
            {
                ResourceId = 11,
                ResourceName = "Bergs Anton"
            };
            GanttResources Record12 = new GanttResources()
            {
                ResourceId = 12,
                ResourceName = "Construction Supervisor"
            };
            GanttResourcesCollection.Add(Record1);
            GanttResourcesCollection.Add(Record2);
            GanttResourcesCollection.Add(Record3);
            GanttResourcesCollection.Add(Record4);
            GanttResourcesCollection.Add(Record5);
            GanttResourcesCollection.Add(Record6);
            GanttResourcesCollection.Add(Record7);
            GanttResourcesCollection.Add(Record8);
            GanttResourcesCollection.Add(Record9);
            GanttResourcesCollection.Add(Record10);
            GanttResourcesCollection.Add(Record11);
            GanttResourcesCollection.Add(Record12);
            return GanttResourcesCollection;
        }
        public static List<GanttDataSource> ResourceData()
        {
            List<GanttDataSource> GanttResourceSampleCollection = new List<GanttDataSource>();

            GanttDataSource Record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Project initiation",
                StartDate = new DateTime(2019, 03, 29),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record1Child1 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Identify Site location",
                StartDate = new DateTime(2019, 03, 29),
                Duration = 2,
                Progress = 30,
                Work = 16,
                Resources = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 1, ResourceUnit = 70 },
                   new ResourceModel { ResourceId = 6 }
                }
            };
            GanttDataSource Record1Child2 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Perform soil test",
                StartDate = new DateTime(2019, 03, 29),
                Duration = 4,
                Work = 96,
                Resources = new List<ResourceModel>
                {
                    new ResourceModel { ResourceId = 2 },
                    new ResourceModel{ ResourceId = 3 },
                    new ResourceModel{ ResourceId = 5 }
                }
            };
            GanttDataSource Record1Child3 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Soil test approval",
                StartDate = new DateTime(2019, 03, 29),
                Duration = 1,
                Progress = 30,
                Work = 16,
                Resources = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 8 },
                new ResourceModel { ResourceId = 9, ResourceUnit = 50 }
                }
            };
            Record1.SubTasks.Add(Record1Child1);
            Record1.SubTasks.Add(Record1Child2);
            Record1.SubTasks.Add(Record1Child3);

            GanttDataSource Record2 = new GanttDataSource()
            {
                TaskId = 5,
                TaskName = "Project estimation",
                StartDate = new DateTime(2019, 03, 29),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record2Child1 = new GanttDataSource()
            {
                TaskId = 6,
                TaskName = "Develop floor plan for estimation",
                StartDate = new DateTime(2019, 03, 29),
                Duration = 3,
                Progress = 30,
                Work = 30,
                Resources = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 4, ResourceUnit = 60 }
                }
            };
            GanttDataSource Record2Child2 = new GanttDataSource()
            {
                TaskId = 7,
                TaskName = "List materials",
                StartDate = new DateTime(2019, 04, 01),
                Duration = 3,
                Work = 48,
                Resources = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 8 },
                 new ResourceModel{ ResourceId = 4 }
                }
            };
            GanttDataSource Record2Child3 = new GanttDataSource()
            {
                TaskId = 8,
                TaskName = "Estimation approval",
                StartDate = new DateTime(2019, 04, 01),
                Duration = 2,
                Work = 60,
                Resources = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 12 },
                 new ResourceModel{ ResourceId = 5, ResourceUnit = 70 }
                }
            };
            Record2.SubTasks.Add(Record2Child1);
            Record2.SubTasks.Add(Record2Child2);
            Record2.SubTasks.Add(Record2Child3);

            GanttDataSource Record3 = new GanttDataSource()
            {
                TaskId = 9,
                TaskName = "Sign contract",
                StartDate = new DateTime(2019, 04, 01),
                Duration = 1,
                Predecessor = "8",
                Progress = 30,
                Resources = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 12 }
            }
            };
            GanttResourceSampleCollection.Add(Record1);
            GanttResourceSampleCollection.Add(Record2);
            GanttResourceSampleCollection.Add(Record3);
            return GanttResourceSampleCollection;
        }

        public static List<GanttDataSource> ResourceViewData()
        {
            List<GanttDataSource> GanttResourceSampleCollection = new List<GanttDataSource>();

            GanttDataSource Record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Project initiation",
                StartDate = new DateTime(2019, 03, 29),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record1Child1 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Identify Site location",
                StartDate = new DateTime(2019, 03, 29),
                Duration = 3,
                Progress = 30,
                Work = 10,
                Resources = new List<ResourceModel>
                {
                   new ResourceModel{  ResourceId = 1, ResourceUnit = 50 }
                }
            };
            GanttDataSource Record1Child2 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Perform soil test",
                StartDate = new DateTime(2019, 03, 29),
                Duration = 4,
                Progress = 30,
                Work = 20,
                Resources = new List<ResourceModel>
                {
                   new ResourceModel {  ResourceId = 2, ResourceUnit = 70 }
                }
            };
            GanttDataSource Record1Child3 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Soil test approval",
                StartDate = new DateTime(2019, 03, 29),
                Duration = 4,
                Progress = 30,
                Work = 10,
                Resources = new List<ResourceModel> {
                   new ResourceModel { ResourceId = 1, ResourceUnit = 75 },
                },
                Predecessor = "2"

            };
            Record1.SubTasks.Add(Record1Child1);
            Record1.SubTasks.Add(Record1Child2);
            Record1.SubTasks.Add(Record1Child3);

            GanttDataSource Record2 = new GanttDataSource()
            {
                TaskId = 5,
                TaskName = "Project estimation",
                StartDate = new DateTime(2019, 03, 29),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record2Child1 = new GanttDataSource()
            {
                TaskId = 6,
                TaskName = "Develop floor plan for estimation",
                StartDate = new DateTime(2019, 03, 29),
                Duration = 3,
                Progress = 30,
                Work = 30,
                Resources = new List<ResourceModel>
                {
                   new ResourceModel{ ResourceId = 2, ResourceUnit = 70 }
                },
                Predecessor = "3FS+2"
            };
            GanttDataSource Record2Child2 = new GanttDataSource()
            {
                TaskId = 7,
                TaskName = "List materials",
                StartDate = new DateTime(2019, 04, 08),
                Duration = 12,
                Progress = 30,
                Work = 40,
                Resources = new List<ResourceModel>
                {
                   new ResourceModel{ ResourceId = 6, ResourceUnit = 40 }
                }
            };
            GanttDataSource Record2Child3 = new GanttDataSource()
            {
                TaskId = 8,
                TaskName = "Estimation approval",
                StartDate = new DateTime(2019, 04, 03),
                Duration = 10,
                Progress = 30,
                Work = 60,
                Resources = new List<ResourceModel>
                {
                   new ResourceModel{ ResourceId = 5, ResourceUnit = 75 }
                }
            };
            GanttDataSource Record2Child4 = new GanttDataSource()
            {
                TaskId = 9,
                TaskName = "Excavate for foundations",
                StartDate = new DateTime(2019, 04, 01),
                Duration = 4,
                Progress = 30,
                Resources = new List<ResourceModel>
                {
                    new ResourceModel { ResourceId = 4 }
                }
            };
            GanttDataSource Record2Child5 = new GanttDataSource()
            {
                TaskId = 10,
                TaskName = "Install Plumbing grounds",
                StartDate = new DateTime(2019, 04, 01),
                Duration = 4,
                Progress = 30,
                Predecessor = "9SS",
                Resources = new List<ResourceModel>
                {
                    new ResourceModel { ResourceId = 3 }
                }
            };
            GanttDataSource Record2Child6 = new GanttDataSource()
            {
                TaskId = 11,
                TaskName = "Dig Footer",
                StartDate = new DateTime(2019, 04, 08),
                Duration = 3,
                Resources = new List<ResourceModel>
                {
                    new ResourceModel { ResourceId = 2 }
                }
            };
            GanttDataSource Record2Child7 = new GanttDataSource()
            {
                TaskId = 12,
                TaskName = "Electrical Utilites",
                StartDate = new DateTime(2019, 04, 03),
                Duration = 4,
                Progress = 30,
                Resources = new List<ResourceModel>
                {
                    new ResourceModel { ResourceId = 3 }
                }
            };
            Record2.SubTasks.Add(Record2Child1);
            Record2.SubTasks.Add(Record2Child2);
            Record2.SubTasks.Add(Record2Child3);
            Record2.SubTasks.Add(Record2Child4);
            Record2.SubTasks.Add(Record2Child5);
            Record2.SubTasks.Add(Record2Child6);
            Record2.SubTasks.Add(Record2Child7);

            GanttDataSource Record3 = new GanttDataSource()
            {
                TaskId = 13,
                TaskName = "Sign contract",
                StartDate = new DateTime(2019, 04, 01),
                Duration = 1,
                Progress = 30,
            };
            GanttResourceSampleCollection.Add(Record1);
            GanttResourceSampleCollection.Add(Record2);
            GanttResourceSampleCollection.Add(Record3);
            return GanttResourceSampleCollection;
        }
        public static List<GanttDataSource> TaskModeData()
        {
            List<GanttDataSource> GanttDataSourceCollection = new List<GanttDataSource>();

            GanttDataSource Record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Parent Task 1",
                StartDate = new DateTime(2017, 02, 27),
                EndDate = new DateTime(2017, 03, 03),
                Progress = 40,
                IsManual = true,
                ResourceId = new int[] { 1 },
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record1Child1 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Child Task 1",
                StartDate = new DateTime(2017, 02, 27),
                EndDate = new DateTime(2017, 03, 03),
                Progress = 40,
                ResourceId = new int[] { 2, 3 },
            };
            GanttDataSource Record1Child2 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Child Task 2",
                StartDate = new DateTime(2017, 02, 26),
                EndDate = new DateTime(2017, 03, 03),
                Progress = 40,
                IsManual = true
            };
            GanttDataSource Record1Child3 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Child Task 3",
                StartDate = new DateTime(2017, 02, 27),
                Duration = 5,
                Progress = 40,
                EndDate = new DateTime(2017, 03, 03)
            };
            Record1.SubTasks.Add(Record1Child1);
            Record1.SubTasks.Add(Record1Child2);
            Record1.SubTasks.Add(Record1Child3);

            GanttDataSource Record2 = new GanttDataSource()
            {
                TaskId = 5,
                TaskName = "Parent Task 2",
                StartDate = new DateTime(2017, 03, 05),
                EndDate = new DateTime(2017, 03, 09),
                Progress = 40,
                IsManual = true,
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record2Child1 = new GanttDataSource()
            {
                TaskId = 6,
                TaskName = "Child Task 1",
                StartDate = new DateTime(2017, 03, 06),
                EndDate = new DateTime(2017, 03, 09),
                Progress = 40,
            };
            GanttDataSource Record2Child2 = new GanttDataSource()
            {
                TaskId = 7,
                TaskName = "Child Task 2",
                StartDate = new DateTime(2017, 03, 06),
                EndDate = new DateTime(2017, 03, 09),
                Progress = 40
            };
            GanttDataSource Record2Child3 = new GanttDataSource()
            {
                TaskId = 8,
                TaskName = "Child Task 3",
                StartDate = new DateTime(2017, 02, 28),
                EndDate = new DateTime(2017, 03, 05),
                Progress = 40,
                IsManual = true
            };
            GanttDataSource Record2Child4 = new GanttDataSource()
            {
                TaskId = 9,
                TaskName = "Child Task 4",
                StartDate = new DateTime(2017, 03, 04),
                EndDate = new DateTime(2017, 03, 09),
                Progress = 40,
                IsManual = true
            };
            Record2.SubTasks.Add(Record2Child1);
            Record2.SubTasks.Add(Record2Child2);
            Record2.SubTasks.Add(Record2Child3);
            Record2.SubTasks.Add(Record2Child4);

            GanttDataSource Record3 = new GanttDataSource()
            {
                TaskId = 10,
                TaskName = "Parent Task 3",
                StartDate = new DateTime(2017, 03, 13),
                EndDate = new DateTime(2017, 03, 17),
                Progress = 40,
                IsManual = true,
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record3Child1 = new GanttDataSource()
            {
                TaskId = 11,
                TaskName = "Child Task 1",
                StartDate = new DateTime(2017, 03, 13),
                EndDate = new DateTime(2017, 03, 17),
                Progress = 40
            };
            GanttDataSource Record3Child2 = new GanttDataSource()
            {
                TaskId = 12,
                TaskName = "Child Task 2",
                StartDate = new DateTime(2017, 03, 13),
                EndDate = new DateTime(2017, 03, 17),
                Progress = 40
            };
            GanttDataSource Record3Child3 = new GanttDataSource()
            {
                TaskId = 13,
                TaskName = "Child Task 3",
                StartDate = new DateTime(2017, 03, 13),
                EndDate = new DateTime(2017, 03, 17),
                Progress = 40
            };
            GanttDataSource Record3Child4 = new GanttDataSource()
            {
                TaskId = 14,
                TaskName = "Child Task 4",
                StartDate = new DateTime(2017, 03, 12),
                EndDate = new DateTime(2017, 03, 17),
                Progress = 40,
                IsManual = true
            };
            GanttDataSource Record3Child5 = new GanttDataSource()
            {
                TaskId = 15,
                TaskName = "Child Task 5",
                StartDate = new DateTime(2017, 03, 13),
                EndDate = new DateTime(2017, 03, 17),
                Progress = 40,
            };
            Record3.SubTasks.Add(Record3Child1);
            Record3.SubTasks.Add(Record3Child2);
            Record3.SubTasks.Add(Record3Child3);
            Record3.SubTasks.Add(Record3Child4);
            Record3.SubTasks.Add(Record3Child5);

            GanttDataSourceCollection.Add(Record1);
            GanttDataSourceCollection.Add(Record2);
            GanttDataSourceCollection.Add(Record3);
            return GanttDataSourceCollection;
        }
        public static List<GanttDataSource> MultiTaskbarData()
        {
            List<GanttDataSource> GanttDataSourceCollection = new List<GanttDataSource>();

            GanttDataSource Record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Project Initiation",
                StartDate = new DateTime(2019, 03, 29),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record1Child1 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Identify Site Location",
                StartDate = new DateTime(2019, 03, 29),
                Duration = 3,
                Progress = 30,
                Work = 10,
                Resources = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 1, ResourceUnit = 50 }
                }
            };
            GanttDataSource Record1Child2 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Perform Soil Test",
                StartDate = new DateTime(2019, 04, 03),
                Duration = 4,
                Resources = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 1, ResourceUnit = 70 }
                },
                Predecessor = "2",
                Progress = 30,
                Work = 20
            };
            GanttDataSource Record1Child3 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Soil Test Approval",
                StartDate = new DateTime(2019, 04, 09),
                Duration = 4,
                Resources = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 1, ResourceUnit = 25 }
                },
                Predecessor = "3",
                Progress = 30,
                Work = 10
            };
            Record1.SubTasks.Add(Record1Child1);
            Record1.SubTasks.Add(Record1Child2);
            Record1.SubTasks.Add(Record1Child3);

            GanttDataSource Record2 = new GanttDataSource()
            {
                TaskId = 5,
                TaskName = "Project Estimation",
                StartDate = new DateTime(2019, 03, 29),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>()
            };
            GanttDataSource Record2Child1 = new GanttDataSource()
            {
                TaskId = 6,
                TaskName = "Develop Floor Plan for Estimation",
                StartDate = new DateTime(2019, 04, 01),
                Duration = 5,
                Progress = 30,
                Resources = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 2, ResourceUnit = 50 }
                },
                Work = 50
            };
            GanttDataSource Record2Child2 = new GanttDataSource()
            {
                TaskId = 7,
                TaskName = "List Materials",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 4,
                Resources = new List<ResourceModel>
                {
                    new ResourceModel { ResourceId = 2, ResourceUnit = 40}
                },
                Predecessor = "6FS-2",
                Progress = 30,
                Work = 40
            };
            GanttDataSource Record2Child3 = new GanttDataSource()
            {
                TaskId = 8,
                TaskName = "Estimation Approval",
                StartDate = new DateTime(2019, 04, 09),
                Duration = 4,
                Resources = new List<ResourceModel>
                {
                    new ResourceModel { ResourceId = 2, ResourceUnit = 75}
                },
                Predecessor = "7FS-1",
                Progress = 30,
                Work = 60
            };
            Record2.SubTasks.Add(Record2Child1);
            Record2.SubTasks.Add(Record2Child2);
            Record2.SubTasks.Add(Record2Child3);

            GanttDataSource Record3 = new GanttDataSource()
            {
                TaskId = 9,
                TaskName = "Site Work",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>()
            };
            GanttDataSource Record3Child1 = new GanttDataSource()
            {
                TaskId = 10,
                TaskName = "Install Temporary Power Service",
                StartDate = new DateTime(2019, 04, 01),
                Duration = 14,
                Progress = 30,
                Resources = new List<ResourceModel>
                {
                    new ResourceModel { ResourceId = 3, ResourceUnit = 75}
                },
            };
            GanttDataSource Record3Child2 = new GanttDataSource()
            {
                TaskId = 11,
                TaskName = "Clear the building site",
                StartDate = new DateTime(2019, 04, 08),
                Duration = 9,
                Progress = 30,
                Predecessor = "10FS-9",
                Resources = new List<ResourceModel>
                {
                    new ResourceModel { ResourceId = 3 }
                },
            };

            GanttDataSource Record3Child3 = new GanttDataSource()
            {
                TaskId = 12,
                TaskName = "Sign Contract",
                StartDate = new DateTime(2019, 04, 12),
                Duration = 5,
                Resources = new List<ResourceModel>
                {
                    new ResourceModel { ResourceId = 3 }
                },
                Predecessor = "11FS-5"
            };
            Record3.SubTasks.Add(Record3Child1);
            Record3.SubTasks.Add(Record3Child2);
            Record3.SubTasks.Add(Record3Child3);

            GanttDataSource Record4 = new GanttDataSource()
            {
                TaskId = 13,
                TaskName = "Foundation",
                StartDate = new DateTime(2019, 04, 01),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>()
            };
            GanttDataSource Record4Child1 = new GanttDataSource()
            {
                TaskId = 14,
                TaskName = "Excavate for Foundations",
                StartDate = new DateTime(2019, 04, 01),
                Duration = 2,
                Progress = 30,
                Resources = new List<ResourceModel>
                {
                    new ResourceModel { ResourceId = 4 }
                }
            };
            GanttDataSource Record4Child2 = new GanttDataSource()
            {
                TaskId = 15,
                TaskName = "Dig Footer",
                StartDate = new DateTime(2019, 04, 04),
                Duration = 2,
                Predecessor = "14FS+1",
                Resources = new List<ResourceModel>
                {
                    new ResourceModel { ResourceId = 4}
                }
            };
            GanttDataSource Record4Child3 = new GanttDataSource()
            {
                TaskId = 16,
                TaskName = "Install plumbing grounds",
                StartDate = new DateTime(2019, 04, 08),
                Duration = 2,
                Progress = 30,
                Predecessor = "15",
                Resources = new List<ResourceModel>
                {
                    new ResourceModel { ResourceId = 4 }
                }
            };
            Record4.SubTasks.Add(Record4Child1);
            Record4.SubTasks.Add(Record4Child2);
            Record4.SubTasks.Add(Record4Child3);

            GanttDataSource Record5 = new GanttDataSource()
            {
                TaskId = 17,
                TaskName = "Framing",
                StartDate = new DateTime(2019, 04, 04),
                EndDate = new DateTime(2019, 04, 21),
                SubTasks = new List<GanttDataSource>()
            };
            GanttDataSource Record5Child1 = new GanttDataSource()
            {
                TaskId = 18,
                TaskName = "Add load-bearing structure",
                StartDate = new DateTime(2019, 04, 03),
                Duration = 2,
                Progress = 30,
                Resources = new List<ResourceModel>
                {
                    new ResourceModel { ResourceId = 5 }
                }
            };

            GanttDataSource Record5Child2 = new GanttDataSource()
            {
                TaskId = 19,
                TaskName = "Natural Gas Utilities",
                StartDate = new DateTime(2019, 04, 08),
                Duration = 4,
                Predecessor = "18",
                Resources = new List<ResourceModel>
                {
                    new ResourceModel { ResourceId = 5 }
                }
            };
            GanttDataSource Record5Child3 = new GanttDataSource()
            {
                TaskId = 20,
                TaskName = "Electrical utilitites",
                StartDate = new DateTime(2019, 04, 11),
                Duration = 2,
                Progress = 30,
                Predecessor = "19FS+1",
                Resources = new List<ResourceModel>
                {
                    new ResourceModel { ResourceId = 5 }
                }
            };
            Record5.SubTasks.Add(Record5Child1);
            Record5.SubTasks.Add(Record5Child2);
            Record5.SubTasks.Add(Record5Child3);


            GanttDataSourceCollection.Add(Record1);
            GanttDataSourceCollection.Add(Record2);
            GanttDataSourceCollection.Add(Record3);
            GanttDataSourceCollection.Add(Record4);
            GanttDataSourceCollection.Add(Record5);
            return GanttDataSourceCollection;
        }
        public static List<ResourceGroupCollection> MultitaskbarResource()
        {
            List<ResourceGroupCollection> GanttResourcesCollection = new List<ResourceGroupCollection>();

            ResourceGroupCollection Record1 = new ResourceGroupCollection()
            {
                ResourceId = 1,
                ResourceName = "Martin Tamer",
                ResourceGroup = "Planning Team",
                IsExpand = "false"
            };
            ResourceGroupCollection Record2 = new ResourceGroupCollection()
            {
                ResourceId = 2,
                ResourceName = "Rose Fuller",
                ResourceGroup = "Testing Team",
                IsExpand = "true"
            };
            ResourceGroupCollection Record3 = new ResourceGroupCollection()
            {
                ResourceId = 3,
                ResourceName = "Margaret Buchanan",
                ResourceGroup = "Approval Team",
                IsExpand = "false"
            };
            ResourceGroupCollection Record4 = new ResourceGroupCollection()
            {
                ResourceId = 4,
                ResourceName = "Fuller King",
                ResourceGroup = "Development Team",
                IsExpand = "false"
            };
            ResourceGroupCollection Record5 = new ResourceGroupCollection()
            {
                ResourceId = 5,
                ResourceName = "Davolio Fuller",
                ResourceGroup = "Approval Team",
                IsExpand = "true"
            };
            GanttResourcesCollection.Add(Record1);
            GanttResourcesCollection.Add(Record2);
            GanttResourcesCollection.Add(Record3);
            GanttResourcesCollection.Add(Record4);
            GanttResourcesCollection.Add(Record5);
            return GanttResourcesCollection;
        }
        public static List<GanttDataSource> SplitTasksData()
        {
            List<GanttDataSource> GanttDataSourceCollection = new List<GanttDataSource>();

            GanttDataSource Record1 = new GanttDataSource()
            {
                TaskId = 1,
                TaskName = "Project Schedule",
                StartDate = new DateTime(2019, 02, 04),
                EndDate = new DateTime(2019, 03, 10),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record2 = new GanttDataSource()
            {
                TaskId = 2,
                TaskName = "Planning",
                StartDate = new DateTime(2019, 02, 04),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record2Child1 = new GanttDataSource()
            {
                TaskId = 3,
                TaskName = "Plan timeline",
                StartDate = new DateTime(2019, 02, 04),
                EndDate = new DateTime(2019, 02, 10),
                Duration = 10,
                Progress = 60,
                Segments = new List<GanttSegment>
                {
                    new GanttSegment {StartDate = new DateTime(2019,02,04), Duration = 2},
                    new GanttSegment {StartDate = new DateTime(2019,02,05), Duration = 5},
                    new GanttSegment {StartDate = new DateTime(2019,02,08), Duration = 3}
                }
            };
            GanttDataSource Record2Child2 = new GanttDataSource()
            {
                TaskId = 4,
                TaskName = "Plan budget",
                StartDate = new DateTime(2019, 02, 04),
                EndDate = new DateTime(2019, 02, 10),
                Duration = 10,
                Progress = 90
            };
            GanttDataSource Record2Child3 = new GanttDataSource()
            {
                TaskId = 5,
                TaskName = "Allocate resources",
                StartDate = new DateTime(2019, 02, 04),
                EndDate = new DateTime(2019, 02, 10),
                Duration = 10,
                Progress = 75,
                Segments = new List<GanttSegment>
                {
                    new GanttSegment {StartDate = new DateTime(2019,02,04), Duration = 4},
                    new GanttSegment {StartDate = new DateTime(2019,02,09), Duration = 5},
                }
            };
            GanttDataSource Record2Child4 = new GanttDataSource()
            {
                TaskId = 6,
                TaskName = "Planning complete",
                StartDate = new DateTime(2019, 02, 21),
                EndDate = new DateTime(2019, 02, 21),
                Duration = 0,
                Predecessor = "3FS, 5FS"
            };
            Record2.SubTasks.Add(Record2Child1);
            Record2.SubTasks.Add(Record2Child2);
            Record2.SubTasks.Add(Record2Child3);
            Record2.SubTasks.Add(Record2Child4);

            GanttDataSource Record3 = new GanttDataSource()
            {
                TaskId = 7,
                TaskName = "Design",
                StartDate = new DateTime(2019, 02, 25),
                SubTasks = new List<GanttDataSource>(),
            };
            GanttDataSource Record3Child1 = new GanttDataSource()
            {
                TaskId = 8,
                TaskName = "Software Specification",
                StartDate = new DateTime(2019, 02, 25),
                EndDate = new DateTime(2019, 03, 02),
                Duration = 5,
                Progress = 60,
                Predecessor = "6FS"
            };
            GanttDataSource Record3Child2 = new GanttDataSource()
            {
                TaskId = 9,
                TaskName = "Develop prototype",
                StartDate = new DateTime(2019, 02, 25),
                EndDate = new DateTime(2019, 03, 02),
                Duration = 10,
                Progress = 100,
                Predecessor = "6FS",
                Segments = new List<GanttSegment>
                {
                    new GanttSegment {StartDate = new DateTime(2019,02,25), Duration = 2},
                    new GanttSegment {StartDate = new DateTime(2019,02,28), Duration = 3},
                }
            };
            GanttDataSource Record3Child3 = new GanttDataSource()
            {
                TaskId = 10,
                TaskName = "Get approval from customer",
                StartDate = new DateTime(2019, 02, 25),
                EndDate = new DateTime(2019, 03, 01),
                Duration = 4,
                Progress = 100,
                Predecessor = "9FS"
            };
            GanttDataSource Record3Child4 = new GanttDataSource()
            {
                TaskId = 11,
                TaskName = "Design complete",
                StartDate = new DateTime(2019, 02, 25),
                EndDate = new DateTime(2019, 02, 25),
                Duration = 0,
                Predecessor = "10FS"
            };

            Record3.SubTasks.Add(Record3Child1);
            Record3.SubTasks.Add(Record3Child2);
            Record3.SubTasks.Add(Record3Child3);
            Record3.SubTasks.Add(Record3Child4);

            Record1.SubTasks.Add(Record2);
            Record1.SubTasks.Add(Record3);

            GanttDataSourceCollection.Add(Record1);
            return GanttDataSourceCollection;
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
        public static List<GanttDataSource> OverviewData()
        {
            List<GanttDataSource> Tasks = new List<GanttDataSource>()
            {
                new GanttDataSource(){
                    TaskId = 1,
                    TaskName="Q-1 Release",
                    StartDate=new DateTime(2021,12,20),
                    EndDate=new DateTime(2022,04,4),
                    Manager="",
                    DueDate= new DateTime(2022,04,4),
                    TimeLog=2,
                    Work=2,
                    Progress=80,
                    Status="In Progress"
                },
                new GanttDataSource(){
                    TaskId= 2,
                    TaskName="Roadmap",
                    ParentID=1
                },
                new GanttDataSource(){
                    TaskId= 3,
                    TaskName="Implementation",
                    ParentID=2
                },
                new GanttDataSource(){
                    TaskId = 4,
                    TaskName="Grid",
                    StartDate=new DateTime(2021,12,20),
                    EndDate=new DateTime(2022,2,20),
                    DueDate=new DateTime(2022,04,4),
                    TimeLog=44,
                    Work=45,
                    Progress=70,
                    ParentID=3
                },
                new GanttDataSource(){
                    TaskId = 5,
                    TaskName="Batch Editing",
                    StartDate=new DateTime(2021,12,24),
                    EndDate=new DateTime(2022,2,21),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 1 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,17),
                    TimeLog=42,
                    Work=43,
                    Progress=100,
                    Status="Completed",
                    ParentID=4,
                    Priority="High",
                    Component="Grid"
                },
                new GanttDataSource(){
                    TaskId = 6,
                    TaskName="PDF Export",
                    StartDate=new DateTime(2021,12,28),
                    EndDate=new DateTime(2022,2,25),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 4 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,17),
                    TimeLog=42,
                    Work=45,
                    Progress=10,
                    Status="On Hold",
                    ParentID=4,
                    Priority="Normal",
                    Component="Grid"
                },
                new GanttDataSource(){
                    TaskId = 7,
                    TaskName="Tree Grid",
                    StartDate=new DateTime(2022,1,2),
                    EndDate=new DateTime(2022,2,20),
                    DueDate=new DateTime(2022,2,20),
                    TimeLog=33,
                    Work=30,
                    Progress=80,
                    ParentID=3
                },
                new GanttDataSource(){
                    TaskId = 8,
                    TaskName="Drag Multi-selection",
                    StartDate=new DateTime(2022,1,2),
                    EndDate=new DateTime(2022,2,20),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 2 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,20),
                    TimeLog=33,
                    Work=32,
                    Progress=100,
                    Status="Completed",
                    ParentID=7,
                    Priority="Critical",
                    Component="Tree Grid"
                },
                new GanttDataSource(){
                    TaskId = 9,
                    TaskName="Gantt Chart",
                    StartDate=new DateTime(2022,2,20),
                    EndDate=new DateTime(2022,4,28),
                    DueDate=DateTime.Now,
                    TimeLog=2,
                    Work=2,
                    Progress=100,
                    ParentID=3
                },
                new GanttDataSource(){
                    TaskId = 10,
                    TaskName="Initial loading performance",
                    StartDate=new DateTime(2022,2,24),
                    EndDate=new DateTime(2022,3,14),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 5 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=13,
                    Work=15,
                    Progress=35,
                    Status="In Progress",
                    ParentID=9,
                    Priority="Low",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 11,
                    TaskName="Drag Multi-selection",
                    StartDate=new DateTime(2022,2,22),
                    EndDate=new DateTime(2022,3,14),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 3 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=13,
                    Work=14,
                    Progress=100,
                    Predecessor="8FS",
                    Status="Completed",
                    ParentID=9,
                    Priority="Normal",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 12,
                    TaskName="ScrollToViewAsync Method",
                    StartDate=new DateTime(2022,2,20),
                    EndDate=new DateTime(2022,3,10),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 2 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=13,
                    Work=10,
                    Progress=100,
                    Status="Completed",
                    ParentID=9,
                    Priority="High",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 13,
                    TaskName="ScrollToTimelineAsync Method",
                    StartDate=new DateTime(2022,2,20),
                    EndDate=new DateTime(2022,3,10),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 6 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=13,
                    Work=10,
                    Progress=40,
                    Status="On Hold",
                    ParentID=9,
                    Priority="Normal",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 14,
                    TaskName="ScrollToTaskbarAsync Method",
                    StartDate=new DateTime(2022,3,10),
                    EndDate=new DateTime(2022,3,25),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 4 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=11,
                    Work=15,
                    Progress=100,
                    Status="Completed",
                    ParentID=9,
                    Priority="Critical",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 15,
                    TaskName="Web Accessibility",
                    StartDate=new DateTime(2022,3,10),
                    EndDate=new DateTime(2022,3,25),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 6 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=11,
                    Work=12,
                    Progress=35,
                    Status="On Hold",
                    ParentID=9,
                    Priority="Normal",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskName="Feature Completion",
                    StartDate=new DateTime(2022,3,25),
                    TimeLog=0,
                    ParentID=3,
                },
                new GanttDataSource(){
                    TaskId=16,
                    TaskName="Testing",
                    Work=8,
                    ParentID=3,
                },
                new GanttDataSource(){
                    TaskId=17,
                    TaskName="Phase-1",
                    StartDate=new DateTime(2022,3,20),
                    EndDate=new DateTime(2022,3,24),
                    Work=2,
                    Progress=0,
                    ParentID=16,
                },
                new GanttDataSource(){
                    TaskId=18,
                    TaskName="Phase-2",
                    StartDate=new DateTime(2022,3,22),
                    EndDate=new DateTime(2022,3,26),
                    Work=1,
                    Progress=0,
                    Predecessor="17FS",
                    ParentID=16,
                },
                new GanttDataSource(){
                    TaskId=19,
                    TaskName="Testing Completion",
                    StartDate=new DateTime(2022,3,27),
                    TimeLog=0,
                    ParentID=3,
                },
                new GanttDataSource(){
                    TaskId=20,
                    TaskName="Release Roll-out",
                    StartDate=new DateTime(2022,04,4),
                    TimeLog=0,
                    ParentID=2,
                },
                new GanttDataSource(){
                    TaskId = 21,
                    TaskName="Q-2 Release",
                    StartDate=new DateTime(2022,04,5),
                    EndDate=new DateTime(2022,06,30),
                    Manager="",
                    DueDate=new DateTime(2022,06,30),
                    TimeLog=2,
                    Work=2,
                    Progress=90,
                    Status="Completed",
                },
                new GanttDataSource(){
                    TaskId= 22,
                    TaskName="Roadmap",
                    ParentID=21
                },
                new GanttDataSource(){
                    TaskId= 23,
                    TaskName="Implementation",
                    ParentID=22
                },
                new GanttDataSource(){
                    TaskId = 24,
                    TaskName="Grid",
                    StartDate=new DateTime(2022,04,5),
                    EndDate=new DateTime(2022,05,30),
                    DueDate=DateTime.Now,
                    TimeLog=2,
                    Work=2,
                    Progress=100,
                    ParentID=23
                },
                new GanttDataSource(){
                    TaskId = 25,
                    TaskName="Web Accessibility",
                    StartDate=new DateTime(2022,04,5),
                    EndDate=new DateTime(2022,04,30),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 3 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=19,
                    Work=15,
                    Progress=100,
                    Status="Completed",
                    ParentID=24,
                    Priority="High",
                    Component="Grid"
                },
                new GanttDataSource(){
                    TaskId = 26,
                    TaskName="Sticky Header",
                    StartDate=new DateTime(2022,04,15),
                    EndDate=new DateTime(2022,05,10),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 6 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=19,
                    Work=20,
                    Progress=100,
                    Status="Completed",
                    ParentID=24,
                    Priority="Normal",
                    Component="Grid"
                },
                new GanttDataSource(){
                    TaskId = 27,
                    TaskName="Adapative UI Mode",
                    StartDate=new DateTime(2022,04,20),
                    EndDate=new DateTime(2022,05,20),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 5 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=19,
                    Work=25,
                    Progress=100,
                    Status="Completed",
                    ParentID=24,
                    Priority="Normal",
                    Component="Grid"
                },
                new GanttDataSource(){
                    TaskId = 28,
                    TaskName="Tree Grid",
                    StartDate=new DateTime(2022,04,25),
                    EndDate=new DateTime(2022,5,30),
                    DueDate=DateTime.Now,
                    TimeLog=2,
                    Work=2,
                    Progress=50,
                    ParentID=23
                },
                new GanttDataSource(){
                    TaskId = 29,
                    TaskName="CRUD Opreation for virtualization",
                    StartDate=new DateTime(2022,04,25),
                    EndDate=new DateTime(2022,05,30),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 2 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=26,
                    Work=28,
                    Progress=72,
                    Status="In Progress",
                    ParentID=28,
                    Priority="Normal",
                    Component="Tree Grid"
                },
                new GanttDataSource(){
                    TaskId = 30,
                    TaskName="Frozen Column",
                    StartDate=new DateTime(2022,04,28),
                    EndDate=new DateTime(2022,05,30),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 4 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=26,
                    Work=28,
                    Progress=100,
                    Status="Completed",
                    ParentID=28,
                    Priority="High",
                    Component="Tree Grid"
                },
                new GanttDataSource(){
                    TaskId = 31,
                    TaskName="Gantt Chart",
                    StartDate=new DateTime(2022,05,5),
                    EndDate=new DateTime(2022,6,20),
                    DueDate=DateTime.Now,
                    TimeLog=2,
                    Work=2,
                    Progress=50,
                    ParentID=23
                },
                new GanttDataSource(){
                    TaskId = 32,
                    TaskName="Observable Collection",
                    StartDate=new DateTime(2022,05,15),
                    EndDate=new DateTime(2022,06,10),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 3 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=19,
                    Work=15,
                    Progress=70,
                    Status="On Hold",
                    ParentID=31,
                    Priority="Critical",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 33,
                    TaskName="INotifyPropertyChanged",
                    StartDate=new DateTime(2022,05,18),
                    EndDate=new DateTime(2022,05,30),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 1 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=19,
                    Work=18,
                    Progress=20,
                    Status="On Hold",
                    ParentID=31,
                    Priority="Normal",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 34,
                    TaskName="INotifyPropertyChanged",
                    StartDate=new DateTime(2022,05,25),
                    EndDate=new DateTime(2022,06,15),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 5 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=19,
                    Work=25,
                    Progress=50,
                    Status="In Progress",
                    ParentID=31,
                    Priority="Normal",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 35,
                    TaskName="Customized Taskbar Editing",
                    StartDate=new DateTime(2022,05,25),
                    EndDate=new DateTime(2022,06,30),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 3},
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=15,
                    Work=20,
                    Progress=10,
                    Status="On Hold",
                    ParentID=31,
                    Priority="High",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 36,
                    TaskName="Column Virtualization ",
                    StartDate=new DateTime(2022,05,5),
                    EndDate=new DateTime(2022,05,30),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 5 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=18,
                    Work=22,
                    Progress=100,
                    Status="Completed",
                    ParentID=31,
                    Priority="Critical",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 37,
                    TaskName="Touch Interaction ",
                    StartDate=new DateTime(2022,05,27),
                    EndDate=new DateTime(2022,6,17),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 8 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=18,
                    Work=14,
                    Progress=100,
                    Status="Completed",
                    ParentID=31,
                    Priority="Normal",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 38,
                    TaskName="Editing Tooltip Template",
                    StartDate=new DateTime(2022,05,29),
                    EndDate=new DateTime(2022,6,19),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 6 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=18,
                    Work=20,
                    Progress=100,
                    Status="Completed",
                    ParentID=31,
                    Priority="Low",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 39,
                    TaskName="Predecessor Drag Vertical Auto Scroll",
                    StartDate=new DateTime(2022,05,25),
                    EndDate=new DateTime(2022,6,15),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 8 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=18,
                    Work=15,
                    Progress=100,
                    Status="Completed",
                    ParentID=31,
                    Priority="Normal",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 40,
                    TaskName="Taskbar Drag Horizontal Auto Scroll",
                    StartDate=new DateTime(2022,05,27),
                    EndDate=new DateTime(2022,6,17),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 1 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=18,
                    Work=14,
                    Progress=100,
                    Status="Completed",
                    ParentID=31,
                    Priority="Normal",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 41,
                    TaskName="Predecessor Types Configure",
                    StartDate=new DateTime(2022,05,28),
                    EndDate=new DateTime(2022,6,18),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 3 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=18,
                    Work=15,
                    Progress=70,
                    Status="On Hold",
                    ParentID=31,
                    Priority="Low",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 42,
                    TaskName="Based on content height holiday, event markers, and weekend container rendering",
                    StartDate=new DateTime(2022,05,28),
                    EndDate=new DateTime(2022,6,15),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 2 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=18,
                    Work=17,
                    Progress=60,
                    Status="In Progress",
                    ParentID=31,
                    Priority="Normal",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 43,
                    TaskName="Feature Completion",
                    StartDate=new DateTime(2022,6,15),
                    TimeLog=0,
                    ParentID=23,
                },
                new GanttDataSource(){
                    TaskId=44,
                    TaskName="Testing",
                    Work=8,
                    ParentID=23,
                },
                new GanttDataSource(){
                    TaskId=45,
                    TaskName="Phase-1",
                    StartDate=new DateTime(2022,6,15),
                    EndDate=new DateTime(2022,6,20),
                    Work=3,
                    Progress=0,
                    ParentID=44,
                },
                new GanttDataSource(){
                    TaskId=46,
                    TaskName="Phase-2",
                    StartDate=new DateTime(2022,6,18),
                    EndDate=new DateTime(2022,6,23),
                    Work=2,
                    Predecessor="45FS",
                    Progress=0,
                    ParentID=44,
                },
                new GanttDataSource(){
                    TaskId=47,
                    TaskName="Testing Completion",
                    StartDate=new DateTime(2022,6,24),
                    TimeLog=0,
                    ParentID=24,
                },
                new GanttDataSource(){
                    TaskId=48,
                    TaskName="Release Roll-out",
                    StartDate=new DateTime(2022,06,30),
                    TimeLog=0,
                    ParentID=22,
                },
                new GanttDataSource(){
                    TaskId = 49,
                    TaskName="Q-3 Release",
                    StartDate=new DateTime(2022,07,01),
                    EndDate=new DateTime(2022,09,29),
                    Manager="",
                    DueDate=DateTime.Now,
                    TimeLog=2,
                    Work=2,
                    Progress=100,
                    StoryPoints=100,
                    Status="In Progress"
                },
                new GanttDataSource(){
                    TaskId= 50,
                    TaskName="Roadmap",
                    ParentID=49
                },
                new GanttDataSource(){
                    TaskId= 51,
                    TaskName="Implementation",
                    ParentID=50
                },
                new GanttDataSource(){
                    TaskId = 52,
                    TaskName="Grid",
                    StartDate=new DateTime(2022,07,01),
                    EndDate=new DateTime(2022,7,20),
                    DueDate=new DateTime(2022,04,4),
                    TimeLog=15,
                    Work=120,
                    Progress=100,
                    ParentID=51
                },
                new GanttDataSource(){
                    TaskId = 53,
                    TaskName="Lazy-Loading Grouping with Virtualization",
                    StartDate=new DateTime(2022,07,01),
                    EndDate=new DateTime(2022,07,15),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 5 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=11,
                    Work=12,
                    Progress=50,
                    Status="In Progress",
                    ParentID=52,
                    Priority="Normal",
                    Component="Grid"
                },
                new GanttDataSource(){
                    TaskId = 54,
                    TaskName="Filter Bar Keyboard Navigation",
                    StartDate=new DateTime(2022,07,04),
                    EndDate=new DateTime(2022,07,18),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 8 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=11,
                    Work=15,
                    Progress=20,
                    Status="On Hold",
                    ParentID=52,
                    Priority="Low",
                    Component="Grid"
                },
                new GanttDataSource(){
                    TaskId = 55,
                    TaskName="Keyboard Navigation Enhanced",
                    StartDate=new DateTime(2022,07,07),
                    EndDate=new DateTime(2022,07,20),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 6 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=11,
                    Work=12,
                    Progress=33,
                    Status="In Progress",
                    ParentID=52,
                    Priority="High",
                    Component="Grid"
                },
                new GanttDataSource(){
                    TaskId = 56,
                    TaskName="Tree Grid",
                    StartDate=new DateTime(2022,07,01),
                    EndDate=new DateTime(2022,7,20),
                    DueDate=new DateTime(2022,04,4),
                    TimeLog=15,
                    Work=12,
                    Progress=100,
                    ParentID=51
                },
                new GanttDataSource(){
                    TaskId = 57,
                    TaskName="Persistence State",
                    StartDate=new DateTime(2022,07,15),
                    EndDate=new DateTime(2022,08,15),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 2 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=24,
                    Work=20,
                    Progress=20,
                    Status="In Progress",
                    ParentID=56,
                    Priority="Normal",
                    Component="Tree Grid"
                },
                new GanttDataSource(){
                    TaskId = 58,
                    TaskName="Add or Remove Frozen Columns",
                    StartDate=new DateTime(2022,07,18),
                    EndDate=new DateTime(2022,08,15),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 5 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=24,
                    Work=20,
                    Progress=40,
                    Status="In Progress",
                    ParentID=56,
                    Priority="Critical",
                    Component="Tree Grid"
                },
                new GanttDataSource(){
                    TaskId = 59,
                    TaskName="Gantt Chart",
                    StartDate=new DateTime(2022,07,01),
                    EndDate=new DateTime(2022,7,20),
                    DueDate=new DateTime(2022,04,4),
                    TimeLog=15,
                    Work=120,
                    Progress=100,
                    ParentID=51
                },
                new GanttDataSource(){
                    TaskId = 60,
                    TaskName="Timeline Virtualization",
                    StartDate=new DateTime(2022,07,18),
                    EndDate=new DateTime(2022,08,15),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 8 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=24,
                    Work=21,
                    Progress=80,
                    Status="In Progress",
                    ParentID=59,
                    Priority="Normal",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 61,
                    TaskName="String and GUID Task Id type",
                    StartDate=new DateTime(2022,07,25),
                    EndDate=new DateTime(2022,08,20),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 3 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=24,
                    Work=19,
                    Progress=10,
                    Status="In Progress",
                    ParentID=59,
                    Priority="Normal",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 62,
                    TaskName="Rendering spinner for every Gantt action",
                    StartDate=new DateTime(2022,07,27),
                    EndDate=new DateTime(2022,08,20),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 6 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=24,
                    Work=20,
                    Progress=35,
                    Status="In Progress",
                    ParentID=59,
                    Priority="Normal",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 63,
                    TaskName="External Key Events",
                    StartDate=new DateTime(2022,07,27),
                    EndDate=new DateTime(2022,08,15),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 1 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=24,
                    Work=18,
                    Progress=100,
                    Status="Completed",
                    ParentID=59,
                    Priority="High",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 64,
                    TaskName="Dependency and CRUD operation in row virtualization",
                    StartDate=new DateTime(2022,07,25),
                    EndDate=new DateTime(2022,08,15),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 5 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=24,
                    Work=17,
                    Progress=78,
                    Status="In Progress",
                    ParentID=59,
                    Predecessor="30FS+40Days",
                    Priority="Normal",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 65,
                    TaskName="AutoCalculateDateScheduling API",
                    StartDate=new DateTime(2022,07,27),
                    EndDate=new DateTime(2022,08,20),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 6 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=24,
                    Work=19,
                    Progress=25,
                    Status="On Hold",
                    ParentID=59,
                    Priority="Low",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 66,
                    TaskName="Persistence State",
                    StartDate=new DateTime(2022,08,15),
                    EndDate=new DateTime(2022,09,15),
                    Assignee = new List<ResourceModel>
                {
                   new ResourceModel { ResourceId = 3 },
                },
                    Manager="",
                    DueDate=new DateTime(2022,2,01),
                    TimeLog=24,
                    Work=18,
                    Progress=70,
                    Status="In Progress",
                    ParentID=59,
                    Predecessor="58FS",
                    Priority="Normal",
                    Component="Gantt Chart"
                },
                new GanttDataSource(){
                    TaskId = 67,
                    TaskName="Feature Completion",
                    StartDate=new DateTime(2022,9,15),
                    TimeLog=0,
                    ParentID=51,
                },
                new GanttDataSource(){
                    TaskId=68,
                    TaskName="Testing",
                    Work=8,
                    ParentID=51,
                },
                new GanttDataSource(){
                    TaskId=69,
                    TaskName="Phase-1",
                    StartDate=new DateTime(2022,09,15),
                    EndDate=new DateTime(2022,09,19),
                    Work=3,
                    Progress=0,
                    ParentID=68,
                },
                new GanttDataSource(){
                    TaskId=70,
                    TaskName="Phase-2",
                    StartDate=new DateTime(2022,09,18),
                    EndDate=new DateTime(2022,09,23),
                    Work=4,
                    Predecessor="69FS",
                    Progress=0,
                    ParentID=68,
                },
                new GanttDataSource(){
                    TaskId=71,
                    TaskName="Testing Completion",
                    StartDate=new DateTime(2022,9,24),
                    TimeLog=0,
                    ParentID=51,
                },
                new GanttDataSource(){
                    TaskId=72,
                    TaskName="Release Roll-out",
                    StartDate=new DateTime(2022,09,29),
                    TimeLog=0,
                    ParentID=50,
                },

            };
            return Tasks;
        }
    }
}
