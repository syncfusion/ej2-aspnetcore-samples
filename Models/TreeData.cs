#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class TreeData
    {
        public class BusinessObject
        {
            public int TaskId
            {
                get;
                set;
            }

            public string TaskName
            {
                get;
                set;
            }

            public DateTime StartDate
            {
                get;
                set;
            }

            public DateTime EndDate
            {
                get;
                set;
            }

            public int Duration
            {
                get;
                set;
            }

            public int Progress
            {
                get;
                set;
            }
            public string Priority
            {
                get;
                set;
            }
            public bool Approved
            {
                get;
                set;
            }

            public DateTime FilterStartDate
            {
                get;
                set;
            }
            public DateTime FilterEndDate
            {
                get;
                set;
            }

            public List<BusinessObject> Children
            {
                get;
                set;
            }

            public int? ParentId
            {
                get;
                set;
            }

        }
        public static List<BusinessObject> GetDefaultData()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();

            BusinessObject Record1 = null;

            Record1 = new BusinessObject()
            {
                TaskId = 1,
                TaskName = "Planning",
                StartDate = new DateTime(2017, 03, 02),
                EndDate = new DateTime(2017, 07, 02),
                Progress = 100,
                Duration = 5,
                Priority = "Normal",
                Approved = false,
                FilterStartDate = new DateTime(2017, 02, 03),
                FilterEndDate = new DateTime(2017, 02, 07),
                Children = new List<BusinessObject>(),
            };

            BusinessObject Child1 = new BusinessObject()
            {
                TaskId = 2,
                TaskName = "Plan timeline",
                StartDate = new DateTime(2017, 03, 02),
                EndDate = new DateTime(2017, 07, 02),
                Progress = 100,
                Duration = 5,
                Priority = "Normal",
                Approved = false,
                FilterStartDate = new DateTime(2017, 02, 03),
                FilterEndDate = new DateTime(2017, 02, 07),
            };

            BusinessObject Child2 = new BusinessObject()
            {
                TaskId = 3,
                TaskName = "Plan budget",
                StartDate = new DateTime(2017, 03, 02),
                EndDate = new DateTime(2017, 07, 02),
                Duration = 5,
                Progress = 100,
                Approved = true,
                Priority = "Low",
                FilterStartDate = new DateTime(2017, 02, 03),
                FilterEndDate = new DateTime(2017, 02, 07),
            };

            BusinessObject Child3 = new BusinessObject()
            {
                TaskId = 4,
                TaskName = "Allocate resources",
                StartDate = new DateTime(2017, 03, 02),
                EndDate = new DateTime(2017, 07, 02),
                Duration = 5,
                Progress = 100,
                Priority = "Critical",
                FilterStartDate = new DateTime(2017, 02, 03),
                FilterEndDate = new DateTime(2017, 02, 07),
                Approved = false
            };

            BusinessObject Child4 = new BusinessObject()
            {
                TaskId = 5,
                TaskName = "Planning complete",
                StartDate = new DateTime(2017, 07, 02),
                EndDate = new DateTime(2017, 07, 02),
                Duration = 1,
                Progress = 1,
                Priority = "Low",
                FilterStartDate = new DateTime(2017, 02, 07),
                FilterEndDate = new DateTime(2017, 02, 07),
                Approved = true
            };

            Record1.Children.Add(Child1);
            Record1.Children.Add(Child2);
            Record1.Children.Add(Child3);
            Record1.Children.Add(Child4);

            BusinessObject Record2 = new BusinessObject()
            {
                TaskId = 6,
                TaskName = "Design",
                StartDate = new DateTime(2017, 10, 02),
                EndDate = new DateTime(2017, 02, 14),
                Progress = 86,
                Duration = 3,
                Priority = "High",
                FilterStartDate = new DateTime(2017, 02, 10),
                FilterEndDate = new DateTime(2017, 02, 14),
                Approved = false,
                Children = new List<BusinessObject>(),
            };

            BusinessObject Child5 = new BusinessObject()
            {
                TaskId = 7,
                TaskName = "Software Specification",
                StartDate = new DateTime(2017, 10, 02),
                EndDate = new DateTime(2017, 02, 12),
                Duration = 3,
                Progress = 60,
                Priority = "Normal",
                FilterStartDate = new DateTime(2017, 02, 10),
                FilterEndDate = new DateTime(2017, 02, 12),
                Approved = false
            };

            BusinessObject Child6 = new BusinessObject()
            {
                TaskId = 8,
                TaskName = "Develop prototype",
                StartDate = new DateTime(2017, 10, 02),
                EndDate = new DateTime(2017, 02, 12),
                Duration = 3,
                Progress = 100,
                Priority = "Critical",
                FilterStartDate = new DateTime(2017, 02, 10),
                FilterEndDate = new DateTime(2017, 02, 12),
                Approved = false
            };

            BusinessObject Child7 = new BusinessObject()
            {
                TaskId = 9,
                TaskName = "Get approval from customer",
                StartDate = new DateTime(2017, 02, 13),
                EndDate = new DateTime(2017, 02, 14),
                Duration = 2,
                Progress = 100,
                Priority = "Low",
                Approved = true,
                FilterStartDate = new DateTime(2017, 02, 13),
                FilterEndDate = new DateTime(2017, 02, 14),
            };

            BusinessObject Child8 = new BusinessObject()
            {
                TaskId = 10,
                TaskName = "Design complete",
                StartDate = new DateTime(2017, 02, 14),
                EndDate = new DateTime(2017, 02, 14),
                Duration = 1,
                Progress = 1,
                Priority = "Normal",
                FilterStartDate = new DateTime(2017, 02, 14),
                FilterEndDate = new DateTime(2017, 02, 14),
                Approved = true
            };

            Record2.Children.Add(Child5);
            Record2.Children.Add(Child6);
            Record2.Children.Add(Child7);
            Record2.Children.Add(Child8);
            BusinessObject Record3 = new BusinessObject()
            {
                TaskId = 11,
                TaskName = "Implementation Phase",
                StartDate = new DateTime(2017, 02, 17),
                EndDate = new DateTime(2017, 02, 17),
                Priority = "Normal",
                Approved = false,
                Duration = 11,
                Progress = 66,
                FilterStartDate = new DateTime(2017, 02, 17),
                FilterEndDate = new DateTime(2017, 02, 17),
                Children = new List<BusinessObject>(),
            };

            BusinessObject Record4 = new BusinessObject()
            {
                TaskId = 12,
                TaskName = "Phase 1",
                StartDate = new DateTime(2017, 02, 17),
                EndDate = new DateTime(2017, 02, 27),
                Priority = "High",
                Approved = false,
                Duration = 11,
                Progress = 50,
                FilterStartDate = new DateTime(2017, 02, 17),
                FilterEndDate = new DateTime(2017, 02, 27),
                Children = new List<BusinessObject>(),
            };
            BusinessObject Record7 = new BusinessObject()
            {
                TaskId = 13,
                TaskName = "Implementation Module 1",
                StartDate = new DateTime(2017, 02, 17),
                EndDate = new DateTime(2017, 02, 27),
                Priority = "Normal",
                Duration = 11,
                Progress = 10,
                Approved = false,
                FilterStartDate = new DateTime(2017, 02, 17),
                FilterEndDate = new DateTime(2017, 02, 27),
                Children = new List<BusinessObject>(),
            };
            BusinessObject Child9 = new BusinessObject()
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
                Approved = false
            };
            BusinessObject Child10 = new BusinessObject()
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
                Approved = true
            };
            BusinessObject Child11 = new BusinessObject()
            {
                TaskId = 16,
                TaskName = "Testing",
                StartDate = new DateTime(2017, 02, 20),
                EndDate = new DateTime(2017, 02, 21),
                Duration = 2,
                Progress = 1,
                Priority = "Normal",
                FilterStartDate = new DateTime(2017, 02, 20),
                FilterEndDate = new DateTime(2017, 02, 21),
                Approved = true
            };
            BusinessObject Child12 = new BusinessObject()
            {
                TaskId = 17,
                TaskName = "Bug fix",
                StartDate = new DateTime(2017, 02, 24),
                EndDate = new DateTime(2017, 02, 25),
                Duration = 2,
                Progress = 1,
                Priority = "Critical",
                FilterStartDate = new DateTime(2017, 02, 24),
                FilterEndDate = new DateTime(2017, 02, 25),
                Approved = false
            };
            BusinessObject Child13 = new BusinessObject()
            {
                TaskId = 18,
                TaskName = "Customer review meeting",
                StartDate = new DateTime(2017, 02, 26),
                EndDate = new DateTime(2017, 02, 27),
                Duration = 2,
                Progress = 1,
                Priority = "High",
                FilterStartDate = new DateTime(2017, 02, 26),
                FilterEndDate = new DateTime(2017, 02, 27),
                Approved = false
            };
            BusinessObject Child14 = new BusinessObject()
            {
                TaskId = 19,
                TaskName = "Phase 1 complete",
                StartDate = new DateTime(2017, 02, 27),
                EndDate = new DateTime(2017, 02, 27),
                Duration = 2,
                Progress = 50,
                Priority = "Low",
                FilterStartDate = new DateTime(2017, 02, 27),
                FilterEndDate = new DateTime(2017, 02, 27),
                Approved = true
            };
            Record7.Children.Add(Child9);
            Record7.Children.Add(Child10);
            Record7.Children.Add(Child11);
            Record7.Children.Add(Child12);
            Record7.Children.Add(Child13);
            Record7.Children.Add(Child14);
            Record4.Children.Add(Record7);
            Record3.Children.Add(Record4);
            BusinessObject Record5 = new BusinessObject()
            {
                TaskId = 20,
                TaskName = "Phase 2",
                StartDate = new DateTime(2017, 02, 17),
                EndDate = new DateTime(2017, 02, 28),
                Children = new List<BusinessObject>(),
                Priority = "High",
                Approved = false,
                Progress = 60,
                FilterStartDate = new DateTime(2017, 02, 17),
                FilterEndDate = new DateTime(2017, 02, 28),
                Duration = 12,
            };
            BusinessObject Record8 = new BusinessObject()
            {
                TaskId = 21,
                TaskName = "Implementation Module 2",
                StartDate = new DateTime(2017, 02, 17),
                EndDate = new DateTime(2017, 02, 28),
                Priority = "Critical",
                Approved = false,
                Progress = 90,
                FilterStartDate = new DateTime(2017, 02, 17),
                FilterEndDate = new DateTime(2017, 02, 28),
                Duration = 12,
                Children = new List<BusinessObject>(),
            };
            BusinessObject Child15 = new BusinessObject()
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
            };
            BusinessObject Child16 = new BusinessObject()
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
            };
            BusinessObject Child17 = new BusinessObject()
            {
                TaskId = 24,
                TaskName = "Testing",
                StartDate = new DateTime(2017, 02, 21),
                EndDate = new DateTime(2017, 02, 24),
                Duration = 2,
                Progress = 1,
                Priority = "High",
                FilterStartDate = new DateTime(2017, 02, 21),
                FilterEndDate = new DateTime(2017, 02, 24),
                Approved = false,
            };
            BusinessObject Child18 = new BusinessObject()
            {
                TaskId = 25,
                TaskName = "Bug fix",
                StartDate = new DateTime(2017, 02, 25),
                EndDate = new DateTime(2017, 02, 26),
                Duration = 2,
                Progress = 1,
                Priority = "Low",
                Approved = false,
                FilterStartDate = new DateTime(2017, 02, 25),
                FilterEndDate = new DateTime(2017, 02, 26),
            };
            BusinessObject Child19 = new BusinessObject()
            {
                TaskId = 26,
                TaskName = "Customer review meeting",
                StartDate = new DateTime(2017, 02, 27),
                EndDate = new DateTime(2017, 02, 28),
                Duration = 2,
                Progress = 1,
                Priority = "Critical",
                FilterStartDate = new DateTime(2017, 02, 27),
                FilterEndDate = new DateTime(2017, 02, 28),
                Approved = true,
            };
            BusinessObject Child20 = new BusinessObject()
            {
                TaskId = 27,
                TaskName = "Phase 2 complete",
                StartDate = new DateTime(2017, 02, 28),
                EndDate = new DateTime(2017, 02, 28),
                Duration = 2,
                Priority = "Normal",
                Progress = 50,
                FilterStartDate = new DateTime(2017, 02, 28),
                FilterEndDate = new DateTime(2017, 02, 28),
                Approved = false,
            };
            Record8.Children.Add(Child15);
            Record8.Children.Add(Child16);
            Record8.Children.Add(Child17);
            Record8.Children.Add(Child18);
            Record8.Children.Add(Child19);
            Record8.Children.Add(Child20);
            Record5.Children.Add(Record8);
            Record3.Children.Add(Record5);
            BusinessObject Record6 = new BusinessObject()
            {
                TaskId = 28,
                TaskName = "Phase 3",
                StartDate = new DateTime(2017, 02, 17),
                EndDate = new DateTime(2017, 02, 27),
                Priority = "Normal",
                Approved = false,
                FilterStartDate = new DateTime(2017, 02, 17),
                FilterEndDate = new DateTime(2017, 02, 27),
                Duration = 11,
                Progress = 30,
                Children = new List<BusinessObject>(),
            };
            BusinessObject Record9 = new BusinessObject()
            {
                TaskId = 29,
                TaskName = "Implementation Module 3",
                StartDate = new DateTime(2017, 02, 17),
                EndDate = new DateTime(2017, 02, 27),
                Priority = "High",
                Approved = false,
                Duration = 11,
                Progress = 60,
                FilterStartDate = new DateTime(2017, 02, 17),
                FilterEndDate = new DateTime(2017, 02, 27),
                Children = new List<BusinessObject>(),
            };
            BusinessObject Child21 = new BusinessObject()
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
            };
            BusinessObject Child22 = new BusinessObject()
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
            };
            BusinessObject Child23 = new BusinessObject()
            {
                TaskId = 32,
                TaskName = "Testing",
                StartDate = new DateTime(2017, 02, 20),
                EndDate = new DateTime(2017, 02, 21),
                Duration = 2,
                Progress = 1,
                Priority = "Critical",
                FilterStartDate = new DateTime(2017, 02, 20),
                FilterEndDate = new DateTime(2017, 02, 21),
                Approved = true,

            };
            BusinessObject Child24 = new BusinessObject()
            {
                TaskId = 33,
                TaskName = "Bug fix",
                StartDate = new DateTime(2017, 02, 24),
                EndDate = new DateTime(2017, 02, 25),
                Duration = 2,
                Progress = 1,
                Priority = "High",
                Approved = false,
                FilterStartDate = new DateTime(2017, 02, 24),
                FilterEndDate = new DateTime(2017, 02, 25),
            };
            BusinessObject Child25 = new BusinessObject()
            {
                TaskId = 34,
                TaskName = "Customer review meeting",
                StartDate = new DateTime(2017, 02, 26),
                EndDate = new DateTime(2017, 02, 27),
                Duration = 2,
                Progress = 1,
                Priority = "Normal",
                FilterStartDate = new DateTime(2017, 02, 26),
                FilterEndDate = new DateTime(2017, 02, 27),
                Approved = true,
            };
            BusinessObject Child26 = new BusinessObject()
            {
                TaskId = 35,
                TaskName = "Phase 3 complete",
                StartDate = new DateTime(2017, 02, 27),
                EndDate = new DateTime(2017, 02, 27),
                Duration = 2,
                Priority = "Critical",
                Progress = 50,
                FilterStartDate = new DateTime(2017, 02, 27),
                FilterEndDate = new DateTime(2017, 02, 27),
                Approved = false,
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
        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject()
            {
                TaskId = 1,
                TaskName = "Parent Task 1",
                StartDate = new DateTime(2017, 10, 23),
                Duration = 10,
                Progress = 70,
                ParentId = null
            });
            BusinessObjectCollection.Add(new BusinessObject()
            {
                TaskId = 2,
                TaskName = "Child task 1",
                StartDate = new DateTime(2017, 10, 23),
                Duration = 4,
                Progress = 80,
                ParentId = 1
            });
            BusinessObjectCollection.Add(new BusinessObject()
            {
                TaskId = 3,
                TaskName = "Child Task 2",
                StartDate = new DateTime(2017, 10, 24),
                Duration = 5,
                Progress = 65,
                ParentId = 1
            });
            BusinessObjectCollection.Add(new BusinessObject()
            {
                TaskId = 4,
                TaskName = "Child task 3",
                StartDate = new DateTime(2017, 10, 25),
                Duration = 6,
                Progress = 77,
                ParentId = 1
            });
            BusinessObjectCollection.Add(new BusinessObject()
            {
                TaskId = 5,
                TaskName = "Parent Task 2",
                StartDate = new DateTime(2017, 10, 23),
                Duration = 10,
                Progress = 70,
                ParentId = null
            });
            BusinessObjectCollection.Add(new BusinessObject()
            {
                TaskId = 6,
                TaskName = "Child task 1",
                StartDate = new DateTime(2017, 10, 23),
                Duration = 4,
                Progress = 80,
                ParentId = 5
            });
            BusinessObjectCollection.Add(new BusinessObject()
            {
                TaskId = 7,
                TaskName = "Child Task 2",
                StartDate = new DateTime(2017, 10, 24),
                Duration = 5,
                Progress = 65,
                ParentId = 5
            });
            BusinessObjectCollection.Add(new BusinessObject()
            {
                TaskId = 8,
                TaskName = "Child task 3",
                StartDate = new DateTime(2017, 10, 25),
                Duration = 6,
                Progress = 77,
                ParentId = 5
            });
            BusinessObjectCollection.Add(new BusinessObject()
            {
                TaskId = 9,
                TaskName = "Child task 4",
                StartDate = new DateTime(2017, 10, 25),
                Duration = 6,
                Progress = 77,
                ParentId = 5
            });
            BusinessObjectCollection.Add(new BusinessObject()
            {
                TaskId = 10,
                TaskName = "Parent Task 3",
                StartDate = new DateTime(2017, 10, 23),
                Duration = 10,
                Progress = 70,
                ParentId = null
            });
            BusinessObjectCollection.Add(new BusinessObject()
            {
                TaskId = 11,
                TaskName = "Child task 1",
                StartDate = new DateTime(2017, 10, 23),
                Duration = 4,
                Progress = 80,
                ParentId = 10
            });
            BusinessObjectCollection.Add(new BusinessObject()
            {
                TaskId = 12,
                TaskName = "Child Task 2",
                StartDate = new DateTime(2017, 10, 24),
                Duration = 5,
                Progress = 65,
                ParentId = 10
            });
            BusinessObjectCollection.Add(new BusinessObject()
            {
                TaskId = 13,
                TaskName = "Child task 3",
                StartDate = new DateTime(2017, 10, 25),
                Duration = 6,
                Progress = 77,
                ParentId = 10
            });
            BusinessObjectCollection.Add(new BusinessObject()
            {
                TaskId = 14,
                TaskName = "Child task 4",
                StartDate = new DateTime(2017, 10, 25),
                Duration = 6,
                Progress = 77,
                ParentId = 10
            });
            BusinessObjectCollection.Add(new BusinessObject()
            {
                TaskId = 15,
                TaskName = "Child task 5",
                StartDate = new DateTime(2017, 10, 25),
                Duration = 6,
                Progress = 77,
                ParentId = 10
            });

            return BusinessObjectCollection;
        }

        public static List<object> GetTemplateData()
        {
            List<Object> DataCollection = new List<object>();
            List<Object> Child111 = new List<object>();
            Child111.Add(new
            {
                Name = "Andrew Fuller",
                FullName = "AndrewFuller",
                Designation = "Sales Representative",
                EmployeeID = "4",
                EmpID = "EMP045",
                Address = "14 Garrett Hill, London",
                Contact = "(71) 555-4848",
                Country = "UK",
                DOB = new DateTime(1980, 9, 20)
            });
            Child111.Add(new
            {
                Name = "Anne Dodsworth",
                FullName = "AnneDodsworth",
                Designation = "Sales Representative",
                EmployeeID = "5",
                EmpID = "EMP091",
                Address = "4726 - 11th Ave. N.E., Seattle",
                Contact = "(206) 555-1189",
                Country = "USA",
                DOB = new DateTime(1989, 10, 19)
            });
            Child111.Add(new
            {
                Name = "Michael Suyama",
                FullName = "MichaelSuyama",
                Designation = "Sales Representative",
                EmployeeID = "6",
                EmpID = "EMP110",
                Address = "Coventry House Miner Rd., London",
                Contact = "(71) 555-3636",
                Country = "UK",
                DOB = new DateTime(1987, 11, 02)
            });
            Child111.Add(new
            {
                Name = "Janet Leverling",
                FullName = "JanetLeverling",
                Designation = "Sales Coordinator",
                EmployeeID = "7",
                EmpID = "EMP131",
                Address = "Edgeham Hollow Winchester Way, London",
                Contact = "(71) 555-3636",
                Country = "UK",
                DOB = new DateTime(1090, 11, 06)
            });
            List<Object> Child11 = new List<object>();
            Child11.Add(new
            {
                Name = "Nancy Davolio",
                FullName = "NancyDavolio",
                Designation = "Marketing Executive",
                EmployeeID = "3",
                EmpID = "EMP035",
                Address = "4110 Old Redmond Rd., Redmond",
                Contact = "(206) 555-8122",
                Country = "USA",
                DOB = new DateTime(1966, 3, 19),
                Children = Child111
            });
            List<Object> Child112 = new List<object>();
            Child112.Add(new
            {
                Name = "Margaret Peacock",
                FullName = "MargaretPeacock",
                Designation = "Sales Representative",
                EmployeeID = "9",
                EmpID = "EMP213",
                Address = "4726 - 11th Ave. N.E., California",
                Contact = "(206) 555-1989",
                Country = "USA",
                DOB = new DateTime(1986, 1, 21)
            });
            Child112.Add(new
            {
                Name = "Steven Buchanan",
                FullName = "StevenBuchanan",
                Designation = "Sales Representative",
                EmployeeID = "11",
                EmpID = "EMP197",
                Address = "200 Lincoln Ave, Salinas, CA 93901",
                Contact = "(831) 758-7408",
                Country = "USA",
                DOB = new DateTime(1987, 3, 23)
            });
            Child112.Add(new
            {
                Name = "Tedd Lawson",
                FullName = "TeddLawson",
                Designation = "Sales Representative",
                EmployeeID = "12",
                EmpID = "EMP167",
                Address = "200 Lincoln Ave, Salinas, CA 93901",
                Contact = "(831) 758-7368",
                Country = "USA",
                DOB = new DateTime(1989, 8, 9)
            });
            Child11.Add(new
            {
                Name = "Romey Wilson",
                FullName = "RomeyWilson",
                Designation = "Sales Executive",
                EmployeeID = "8",
                EmpID = "EMP039",
                Address = "7 Houndstooth Rd., London",
                Contact = "(71) 555-3690",
                Country = "UK",
                DOB = new DateTime(1980, 2, 2),
                Children = Child112
            });
            List<Object> Child1 = new List<object>();
            Child1.Add(new
            {
                Name = "David william",
                FullName = "DavidWilliam",
                Designation = "Vice President",
                EmployeeID = "2",
                EmpID = "EMP004",
                Address = "722 Moss Bay Blvd., Kirkland",
                Contact = "(206) 555-3412",
                Country = "USA",
                DOB = new DateTime(1971, 5, 20),
                Children = Child11
            });
            DataCollection.Add(new
            {
                Name = "Robert King",
                FullName = "RobertKing",
                Designation = "Chief Executive Officer",
                EmployeeID = "1",
                EmpID = "EMP001",
                Address = "507 - 20th Ave. E.Apt. 2A, Seattle",
                Contact = "(206) 555-9857",
                Country = "USA",
                DOB = new DateTime(1963, 2, 15),
                Children = Child1
            });
            return DataCollection;
        }
        public static List<ShipmentData> GetShipmentData()
        {

            List<ShipmentData> DataCollection = new List<ShipmentData>();

            ShipmentData Parent1 = new ShipmentData()
            {
                ID = "1",
                Name = "Order 1",
                Category = "Seafood",
                Units = 1395,
                UnitPrice = 47,
                Price = 65565,
                OrderDate = new DateTime(2017, 3, 2),
                ShippedDate = new DateTime(2017, 9, 2),
                ShipmentCategory = "Seafood",
                Children = new List<ShipmentData>()
            };

            ShipmentData Child1 = new ShipmentData()
            {
                ID = "1.1",
                Name = "Mackerel",
                Category = "Frozen Seafood",
                Units = 235,
                UnitPrice = 12,
                Price = 2820,
                OrderDate = new DateTime(2017, 3, 3),
                ShippedDate = new DateTime(2017, 10, 3),
                ShipmentCategory = "Frozen Seafood"
            };

            ShipmentData Child2 = new ShipmentData()
            {
                ID = "1.2",
                Name = "Yellowfin Tuna",
                Category = "Frozen Seafood",
                Units = 324,
                UnitPrice = 8,
                Price = 2592,
                OrderDate = new DateTime(2017, 3, 5),
                ShippedDate = new DateTime(2017, 10, 5),
                ShipmentCategory = "Frozen Seafood"
            };
            ShipmentData Child3 = new ShipmentData()
            {
                ID = "1.3",
                Name = "Herrings",
                Category = "Frozen Seafood",
                Units = 488,
                UnitPrice = 11,
                Price = 5368,
                OrderDate = new DateTime(2017, 8, 5),
                ShippedDate = new DateTime(2017, 5, 15),
                ShipmentCategory = "Frozen Seafood"
            };
            ShipmentData Child4 = new ShipmentData()
            {
                ID = "1.4",
                Name = "Preserved Olives",
                Category = "Edible",
                Units = 125,
                UnitPrice = 9,
                Price = 1125,
                OrderDate = new DateTime(2017, 6, 10),
                ShippedDate = new DateTime(2017, 6, 17),
                ShipmentCategory = "Edible"
            };
            ShipmentData Child5 = new ShipmentData()
            {
                ID = "1.5",
                Name = " Sweet corn Frozen ",
                Category = "Edible",
                Units = 223,
                UnitPrice = 7,
                Price = 1561,
                OrderDate = new DateTime(2017, 7, 12),
                ShippedDate = new DateTime(2017, 7, 19),
                ShipmentCategory = "Edible"
            };
            Parent1.Children.Add(Child1);
            Parent1.Children.Add(Child2);
            Parent1.Children.Add(Child3);
            Parent1.Children.Add(Child4);
            Parent1.Children.Add(Child5);

            ShipmentData Parent2 = new ShipmentData()
            {
                ID = "2",
                Name = "Order 2",
                Category = "Products",
                Units = 1944,
                UnitPrice = 58,
                Price = 21233,
                OrderDate = new DateTime(2017, 1, 10),
                ShippedDate = new DateTime(2017, 1, 16),
                ShipmentCategory = "Seafood",
                Children = new List<ShipmentData>()
            };

            ShipmentData Child6 = new ShipmentData()
            {
                ID = "2.1",
                Name = "Tilapias",
                Category = "Frozen Seafood",
                Units = 278,
                UnitPrice = 15,
                Price = 4170,
                OrderDate = new DateTime(2017, 2, 5),
                ShippedDate = new DateTime(2017, 2, 12),
                ShipmentCategory = "Frozen Seafood"
            };

            ShipmentData Child7 = new ShipmentData()
            {
                ID = "2.2",
                Name = "White Shrimp",
                Category = "Frozen Seafood",
                Units = 560,
                UnitPrice = 7,
                Price = 3920,
                OrderDate = new DateTime(2017, 5, 22),
                ShippedDate = new DateTime(2017, 5, 29),
                ShipmentCategory = "Frozen Seafood"
            };
            ShipmentData Child8 = new ShipmentData()
            {
                ID = "2.3",
                Name = "Fresh Cheese",
                Category = "Dairy",
                Units = 323,
                UnitPrice = 12,
                Price = 3876,
                OrderDate = new DateTime(2017, 6, 8),
                ShippedDate = new DateTime(2017, 6, 15),
                ShipmentCategory = "Dairy"
            };
            ShipmentData Child9 = new ShipmentData()
            {
                ID = "2.4",
                Name = "Blue Veined Cheese",
                Category = "Dairy",
                Units = 370,
                UnitPrice = 15,
                Price = 5550,
                OrderDate = new DateTime(2017, 7, 10),
                ShippedDate = new DateTime(2017, 7, 17),
                ShipmentCategory = "Dairy"
            };
            ShipmentData Child10 = new ShipmentData()
            {
                ID = "2.5",
                Name = "Butter",
                Category = "Dairy",
                Units = 413,
                UnitPrice = 9,
                Price = 3717,
                OrderDate = new DateTime(2017, 9, 18),
                ShippedDate = new DateTime(2017, 9, 25),
                ShipmentCategory = "Dairy"
            };

            Parent2.Children.Add(Child6);
            Parent2.Children.Add(Child7);
            Parent2.Children.Add(Child8);
            Parent2.Children.Add(Child9);
            Parent2.Children.Add(Child10);

            ShipmentData Parent3 = new ShipmentData()
            {
                ID = "3",
                Name = "Order 3",
                Category = "Crystals",
                Units = 1944,
                UnitPrice = 58,
                Price = 21233,
                OrderDate = new DateTime(2017, 9, 10),
                ShippedDate = new DateTime(2017, 9, 20),
                ShipmentCategory = "Seafood",
                Children = new List<ShipmentData>()
            };

            ShipmentData Child11 = new ShipmentData()
            {
                ID = "3.1",
                Name = "Lead glassware",
                Category = "Solid crystals",
                Units = 542,
                UnitPrice = 6,
                Price = 3252,
                OrderDate = new DateTime(2017, 2, 7),
                ShippedDate = new DateTime(2017, 2, 14),
                ShipmentCategory = "Solid crystals"
            };

            ShipmentData Child12 = new ShipmentData()
            {
                ID = "3.2",
                Name = "Pharmaceutical Glassware",
                Category = "Solid crystals",
                Units = 324,
                UnitPrice = 11,
                Price = 3564,
                OrderDate = new DateTime(2017, 4, 19),
                ShippedDate = new DateTime(2017, 4, 26),
                ShipmentCategory = "Solid crystals"
            };
            ShipmentData Child13 = new ShipmentData()
            {
                ID = "3.3",
                Name = "Glass beads",
                Category = "Solid crystals",
                Units = 254,
                UnitPrice = 16,
                Price = 4064,
                OrderDate = new DateTime(2017, 5, 22),
                ShippedDate = new DateTime(2017, 3, 22),
                ShipmentCategory = "Solid crystals"
            };

            Parent3.Children.Add(Child11);
            Parent3.Children.Add(Child12);
            Parent3.Children.Add(Child13);

            DataCollection.Add(Parent1);
            DataCollection.Add(Parent2);
            DataCollection.Add(Parent3);

            return DataCollection;

        }

        public class ShipmentData
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public int Units { get; set; }
            public string Category { get; set; }
            public int UnitPrice { get; set; }
            public int Price { get; set; }
            public string ShipmentCategory { get; set; }
            public DateTime ShippedDate { get; set; }
            public DateTime OrderDate { get; set; }
            public List<ShipmentData> Children { get; set; }

        }
    }

    
    public class VirtualDataFormat
    {
        public int TaskID { get; set; }
        public string FIELD1 { get; set; }
        public int FIELD2 { get; set; }
        public int FIELD3 { get; set; }
        public int FIELD4 { get; set; }
        public int FIELD5 { get; set; }
        public int FIELD6 { get; set; }
        public int FIELD7 { get; set; }

        public List<VirtualDataFormat> Children { get; set; }



        public static List<VirtualDataFormat> GetVirtualData()
        {

            string[] Names = new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "HANAR", "CHOPS", "RICSU", "WELLI", "HILAA", "ERNSH", "CENTC",
        "OTTIK", "QUEDE", "RATTC", "ERNSH", "FOLKO", "BLONP", "WARTH", "FRANK", "GROSR", "WHITC", "WARTH", "SPLIR", "RATTC", "QUICK", "VINET",
        "MAGAA", "TORTU", "MORGK", "BERGS", "LEHMS", "BERGS", "ROMEY", "ROMEY", "LILAS", "LEHMS", "QUICK", "QUICK", "RICAR", "REGGC", "BSBEV",
        "COMMI", "QUEDE", "TRADH", "TORTU", "RATTC", "VINET", "LILAS", "BLONP", "HUNGO", "RICAR", "MAGAA", "WANDK", "SUPRD", "GODOS", "TORTU",
        "OLDWO", "ROMEY", "LONEP", "ANATR", "HUNGO", "THEBI", "DUMON", "WANDK", "QUICK", "RATTC", "ISLAT", "RATTC", "LONEP", "ISLAT", "TORTU",
        "WARTH", "ISLAT", "PERIC", "KOENE", "SAVEA", "KOENE", "BOLID", "FOLKO", "FURIB", "SPLIR", "LILAS", "BONAP", "MEREP", "WARTH", "VICTE",
        "HUNGO", "PRINI", "FRANK", "OLDWO", "MEREP", "BONAP", "SIMOB", "FRANK", "LEHMS", "WHITC", "QUICK", "RATTC", "FAMIA" };

            List<VirtualDataFormat> DataCollection = new List<VirtualDataFormat>();
            var j = 1;

            for (var i = 0; i <= 1000; i = j)
            {
                var name = (i % 100);
                VirtualDataFormat Parent = new VirtualDataFormat()
                {
                    TaskID = i + 1,
                    FIELD1 = Names[name],
                    FIELD2 = (i % 2 == 0) ? 1967 + 2 : (i % 5 == 0) ? 1967 + 8 : 1967 + 12,
                    FIELD3 = (i % 2 == 0) ? 395 + 2 : (i % 5 == 0) ? 395 + 1 : 395 + 25,
                    FIELD4 = (i % 2 == 0) ? 87 + 2 : (i % 5 == 0) ? 87 + 1 : 87 + 15,
                    FIELD5 = (i % 2 == 0) ? 410 + 2 : (i % 5 == 0) ? 410 + 1 : 410 + 45,
                    FIELD6 = (i % 2 == 0) ? 67 + 2 : (i % 5 == 0) ? 67 + 1 : 67 + 6,
                    FIELD7 = (i % 2 == 0) ? 35 + 2 : (i % 5 == 0) ? 24 + 1 : 45 + 12,
                    Children = new List<VirtualDataFormat>()
                };

                for (j = i + 1; j < i + 6; j++)
                {
                    var childName = ((i + j) % 100);
                    Parent.Children.Add(new VirtualDataFormat()
                    {
                        TaskID = j + 1,
                        FIELD1 = Names[childName],
                        FIELD2 = (j % 3 == 0) ? 1967 + (j + 2) : (j % 4 == 0) ? 1967 + (j + 1) : 1967 + j,
                        FIELD3 = (j % 3 == 0) ? 395 + (j + 2) : (j % 4 == 0) ? 395 + (j + 4) : 395 + (j + 13),
                        FIELD4 = (j % 3 == 0) ? 87 + (j + 2) : (j % 4 == 0) ? 87 + (j + 1) : 87 + (j + 12),
                        FIELD5 = (j % 3 == 0) ? 410 + (j + 2) : (j % 4 == 0) ? 410 + (j + 1) : 410 + (j + 14),
                        FIELD6 = (j % 3 == 0) ? 67 + (j + 2) : (j % 4 == 0) ? 67 + (j + 1) : 67 + (j + 7),
                        FIELD7 = (j % 3 == 0) ? 89 + (j + 2) : (j % 4 == 0) ? 94 + (j + 1) : 23 + (j + 7),
                    });
                }
                DataCollection.Add(Parent);
            }
            return DataCollection;

        }

    }
    public class TreeDataFormat
    {
        public TreeDataFormat() { }
        public string orderID { get; set; }
        public string orderName { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime shippedDate { get; set; }
        public int units { get; set; }
        public double price { get; set; }
        public int unitPrice { get; set; }
        public string category { get; set; }
        public List<TreeDataFormat> subTasks { get; set; }
        public static List<TreeDataFormat> GetDataFormat()
        {
            List<TreeDataFormat> data = new List<TreeDataFormat>()
            {
                new TreeDataFormat()
                {
                    orderID= "1",
                    orderName= "Order 1",
                    orderDate= new DateTime(2017, 03, 02),
                    shippedDate= new DateTime(2019, 10, 09),
                    units= 1395,
                    unitPrice= 47,
                    price=133.66,
                    category= "Seafood",
                    subTasks= new List<TreeDataFormat>() {
                        new TreeDataFormat() { orderID= "1.1", orderName= "Mackerel", category= "Frozen seafood", units= 23,
                            orderDate= new DateTime(2017, 03, 02), shippedDate= new DateTime(2019, 05, 13), unitPrice= 12, price= 28.20 },
                        new TreeDataFormat() { orderID= "1.2", orderName= "Mackerel", category= "Frozen seafood", units= 23,
                            orderDate= new DateTime(2017, 03, 05), shippedDate= new DateTime(2019, 05, 22), unitPrice= 11, price= 25.92 },
                        new TreeDataFormat() { orderID= "1.3", orderName= "Mackerel", category= "Frozen seafood", units= 23,
                            orderDate= new DateTime(2017, 03, 10), shippedDate= new DateTime(2019, 10, 14), unitPrice= 8, price= 52.68 },
                        new TreeDataFormat() { orderID= "1.4", orderName= "Mackerel", category= "Edible", units= 23,
                            orderDate= new DateTime(2017, 03, 08), shippedDate= new DateTime(2019, 08, 03), unitPrice= 9, price= 11.25 },
                        new TreeDataFormat() { orderID= "1.5", orderName= "Mackerel", category= "Edible", units= 23,
                            orderDate= new DateTime(2017, 03, 09), shippedDate= new DateTime(2019, 03, 09), unitPrice= 7, price= 15.61 }
                    }
                },
                new TreeDataFormat()
                {
                    orderID= "2",
                    orderName= "Order 2",
                    orderDate= new DateTime(2017, 03, 05),
                    shippedDate= new DateTime(2019, 05, 03),
                    units= 1944,
                    unitPrice= 58,
                    price=212.33,
                    category= "Seafood",
                    subTasks= new List<TreeDataFormat>() {
                        new TreeDataFormat() { orderID= "2.1", orderName= "Tilapias", category= "Frozen seafood", units= 278,
                            orderDate= new DateTime(2017, 03, 05), shippedDate= new DateTime(2019, 03, 15), unitPrice= 15, price= 55.50 },
                        new TreeDataFormat() { orderID= "2.2", orderName= "White Shrimp", category= "Frozen seafood", units= 560,
                            orderDate= new DateTime(2017, 05, 07), shippedDate= new DateTime(2019, 09, 19), unitPrice= 7, price= 41.70 },
                        new TreeDataFormat() { orderID= "2.3", orderName= "Fresh Cheese", category= "Dairy", units= 323,
                            orderDate= new DateTime(2017, 03, 09), shippedDate= new DateTime(2019, 11, 13), unitPrice= 8, price= 39.20 },
                        new TreeDataFormat() { orderID= "2.4", orderName= "Blue Veined Cheese", category= "Dairy", units= 373,
                            orderDate= new DateTime(2017, 03, 11), shippedDate= new DateTime(2019, 11, 13), unitPrice= 9, price= 38.76 },
                        new TreeDataFormat() { orderID= "2.5", orderName= "Butter", category= "Dairy", units= 413,
                            orderDate= new DateTime(2017, 12, 23), shippedDate= new DateTime(2019, 12, 23), unitPrice= 7, price= 37.17 }
                    }
                },
                new TreeDataFormat()
                {
                    orderID= "3",
                    orderName= "Order 3",
                    orderDate= new DateTime(2017, 03, 10),
                    shippedDate= new DateTime(2019, 05, 20),
                    units = 1120,
                    unitPrice = 33,
                    price = 108.80,
                    category= "Seafood",
                    subTasks= new List<TreeDataFormat>() {
                        new TreeDataFormat() { orderID= "3.1", orderName= "Lead glassware", category= "Solid crystals", units= 542,
                            orderDate= new DateTime(2017, 03, 05), shippedDate= new DateTime(2019, 03, 15), unitPrice= 6, price= 32.52 },
                        new TreeDataFormat() { orderID= "3.2", orderName= "Glassware", category= "Solid crystals", units= 324,
                            orderDate= new DateTime(2017, 05, 07), shippedDate= new DateTime(2019, 09, 19), unitPrice= 11, price= 35.64 },
                        new TreeDataFormat() { orderID= "3.3", orderName= "Glass beads", category= "Solid crystals", units= 254,
                            orderDate= new DateTime(2017, 03, 09), shippedDate= new DateTime(2019, 11, 13), unitPrice= 16, price= 40.64 },
                        }
                }
            };
            return data;
        }
    }
    public class TreeGridHeader
    {
        public DateTime StartDate { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int PercentDone { get; set; }
        public List<TreeGridHeader> Children { get; set; }
        public string Resources { get; set; }

        public static List<TreeGridHeader> GetDataSource()
        {
            List<TreeGridHeader> BusinessObjectCollection = new List<TreeGridHeader>();
            BusinessObjectCollection.Add(new TreeGridHeader()
            {
                Id = 1,
                Name = "Task 1",
                StartDate = new DateTime(2017, 10, 23),
                Duration = 10,
                PercentDone = 70,
                Resources = "1",

                Children = (new List<TreeGridHeader>()
                    {
                        new TreeGridHeader()
                        {
                            Id = 2,
                            Name = "Child task 1",
                            StartDate = new DateTime(2017, 10, 23),
                            Duration = 4,
                            PercentDone = 80,
                            Resources ="4"
                        },
                        new TreeGridHeader()
                        {
                            Id = 3,
                            Name = "Child Task 2",
                            StartDate = new DateTime(2017, 10, 24),
                            Duration = 5,
                            PercentDone = 65,
                            Resources ="1"
                        },
                        new TreeGridHeader()
                        {
                            Id = 4,
                            Name = "Child task 3",
                            StartDate = new DateTime(2017, 10, 25),
                            Duration = 6,
                            PercentDone = 77,
                            Resources ="5",
                            Children = (new List<TreeGridHeader>()
                            {
                                new TreeGridHeader()
                                {
                                    Id = 5,
                                    Name = "Grand child task 1",
                                    StartDate = new DateTime(2017, 10, 28),
                                    Duration = 5,
                                    PercentDone = 60,
                                    Resources ="7",
                                },
                                new TreeGridHeader()
                                {
                                    Id = 6,
                                    Name = "Grand child task 2",
                                    StartDate = new DateTime(2017, 10, 29),
                                    Duration = 6,
                                    PercentDone = 77,
                                    Resources ="7",
                                },
                                new TreeGridHeader()
                                {
                                    Id = 7,
                                    Name = "Grand child task 3",
                                    StartDate = new DateTime(2017, 10, 29),
                                    Duration = 3,
                                    PercentDone = 77,
                                    Resources ="8"

                                }
                            })
                        }
                    })

            });
            BusinessObjectCollection.Add(new TreeGridHeader()
            {
                Id = 8,
                Name = "Task 2",
                StartDate = new DateTime(2017, 10, 23),
                Duration = 10,
                PercentDone = 70,
                Resources = "5",

                Children = (new List<TreeGridHeader>()
                    {
                        new TreeGridHeader()
                        {
                            Id = 9,
                            Name = "Child task 1",
                            StartDate = new DateTime(2017, 10, 23),
                            Duration = 4,
                            PercentDone = 80,
                            Resources ="4",
                        },
                        new TreeGridHeader()
                        {
                            Id = 10,
                            Name = "Child Task 2",
                            StartDate = new DateTime(2017, 10, 24),
                            Duration = 5,
                            PercentDone = 65,
                            Resources ="1",
                        },
                        new TreeGridHeader()
                        {
                            Id = 11,
                            Name = "Child task 3",
                            StartDate = new DateTime(2017, 10, 25),
                            Duration = 6,
                            PercentDone = 77,
                            Resources ="5",
                            Children = (new List<TreeGridHeader>()
                            {
                                new TreeGridHeader()
                                {
                                    Id = 12,
                                    Name = "Grand child task 1",
                                    StartDate = new DateTime(2017, 10, 28),
                                    Duration = 5,
                                    PercentDone = 60,
                                    Resources ="7",
                                },
                                new TreeGridHeader()
                                {
                                    Id = 13,
                                    Name = "Grand child task 2",
                                    StartDate = new DateTime(2017, 10, 29),
                                    Duration = 6,
                                    PercentDone = 77,
                                    Resources ="7",
                                },
                                new TreeGridHeader()
                                {
                                    Id = 14,
                                    Name = "Grand child task 3",
                                    StartDate = new DateTime(2017, 10, 29),
                                    Duration = 3,
                                    PercentDone = 88,
                                    Resources ="8"

                                }
                            })
                        }
                    })

            });
            return BusinessObjectCollection;
        }
    }
    public class OverviewData
    {
        public OverviewData() { }
        public string name
        {
            get;
            set;
        }

        public string capital
        {
            get;
            set;
        }

        public double area
        {
            get;
            set;
        }

        public double population
        {
            get;
            set;
        }

        public double gdp
        {
            get;
            set;
        }

        public string timezone
        {
            get;
            set;
        }
        public double rating
        {
            get;
            set;
        }
        public double unemployment
        {
            get;
            set;
        }

        public string coordinates
        {
            get;
            set;
        }
        public List<OverviewData> states { get; set; }
        public static List<OverviewData> GetCountriesData()
        {
            List<OverviewData> data = new List<OverviewData>()
            {
                new OverviewData()
                {
            name= "USA",
            capital = "Washington, D.C.",
            area = 9147590,
            population = 327892000,
            gdp = 2.2,
            timezone= "UTC -5 to -10",
            rating = 5,
            unemployment = 3.9,
            coordinates = "37.0902° N, 95.7129° W",
            states= new List<OverviewData>() {
                        new OverviewData() { name= "Washington, D.C.", area= 184827, population= 693972, gdp= 4.7,
            timezone= "UTC -5", unemployment= 4.3, coordinates= "38.9072° N, 77.0369° W" },
                        new OverviewData() { name= "New York", area= 783.8, capital= "Albany", population= 8175133, gdp= 1.9,
            timezone= "UTC -5", unemployment= 3.9, coordinates= "40.7128° N, 74.0060° W" },
                        new OverviewData() { name= "New Mexico", area= 315194, capital= "Santa Fe", population= 2088070, gdp= 0.1,
            timezone= "UTC -7", unemployment= 4.7, coordinates= "34.5199° N, 105.8701° W" },
                        new OverviewData() { name= "Alaska", area= 1717856, capital= "Juneau", population= 297832, gdp= -0.5,
            timezone= "UTC -9", unemployment= 6.3, coordinates= "64.2008° N, 149.4937° W" }
                    }
                },
                new OverviewData()
                {
                name= "Greece",
                capital = "Athens",
                area = 131957,
                population = 10783625,
                gdp = 1.5,
                timezone= "UTC +2.0",
                rating = 3,
                unemployment = 20.8,
                coordinates = "39.0742° N, 21.8243° E",
                states= new List<OverviewData>() {
                        new OverviewData() { name= "Athens", area= 2929, population= 664046, gdp= 1,
            timezone= "UTC +2.0", unemployment= 7.7, coordinates= "37.9838° N, 23.7275° E" },
                        new OverviewData() { name= "Arcadia", capital= "Tripoli", area= 28.83, population= 58799, gdp= 2.5,
            timezone= "UTC +2.0", unemployment= 3.0, coordinates= "34.1397° N, 118.0353° W" },
                        new OverviewData() { name= "Argolis", capital= "Nafplio", area= 2154, population= 97044, gdp= 2.1,
            timezone= "UTC +2.0", unemployment= 6.2, coordinates= "37.6525° N, 22.8582° E" },
                    }
                },
                new OverviewData()
                {
                name= "Germany",
                capital = "Berlin",
                area = 357386,
                population = 82293457,
                gdp = 2.2,
                timezone= "UTC +1.0",
                rating = 5,
                unemployment = 3.3,
                coordinates = "51.1657° N, 10.4515° E",
                states= new List<OverviewData>() {
                        new OverviewData() { name= "Berlin", area= 891.8, population= 3539234, gdp= 4.1,
            timezone= "UTC +1.0", unemployment= 7.7, coordinates= "52.5200° N, 13.4050° E" },
                        new OverviewData() { name= "Bavaria", capital= "Munich", area= 70550, population= 12997204, gdp= 3.1,
            timezone= "UTC +1.0", unemployment= 2.7, coordinates= "48.7904° N, 11.4979° E" },
                        new OverviewData() { name= "Saxony", capital= "Dresden", area= 18416, population= 4081308, gdp= 3.8,
            timezone= "UTC +1.0", unemployment= 6.2, coordinates= "51.1045° N, 13.2017° E" },
                        }
                },
                new OverviewData()
                {
                 name= "Bangladesh",
                 capital = "Dhaka",
                 area = 147570,
                 population = 185584811,
                 gdp = 7.3,
                 timezone = "UTC +6.0",
                 rating = 3,
                  unemployment = 4.3,
                 coordinates = "23.6850° N, 90.3563° E",
                 states= new List<OverviewData>() {
                        new OverviewData() { name= "Dhaka", area= 306.4, population= 10356500, gdp= 7.28,
            timezone= "UTC +6.0", unemployment= 7.4, coordinates= "23.8103° N, 90.4125° E" },
                        new OverviewData() { name= "Barisal", capital= "Barisal", area= 16.37, population= 202242, gdp= 6.3,
            timezone= "UTC +6.0", unemployment= 5, coordinates= "22.7010° N, 90.3535° E" },
                        new OverviewData() { name= "Chittagong", capital= "Chittagong", area= 168.1, population= 3920222, gdp= 6.3,
            timezone= "UTC +6.0", unemployment= 4.7, coordinates= "22.3569° N, 91.7832° E" },
                        }
                },
                new OverviewData()
                {
                name= "Egypt",
                capital = "Cairo",
                area = 1001449,
                population = 99375741,
                gdp = 4.2,
                timezone= "UTC +2.0",
                rating = 3,
                unemployment = 9.9,
                coordinates = "26.8206° N, 30.8025° E",
                states= new List<OverviewData>() {
                        new OverviewData() { name= "Cairo", area= 528, population= 7734614, gdp= 3.7,
            timezone= "UTC +2.0", unemployment= 11.3, coordinates= "30.0444° N, 31.2357° E" },
                        new OverviewData() { name= "Alexandria", capital= "Bacos", area= 46.42, population= 3811516, gdp= 4.2,
            timezone= "UTC +2.0", unemployment= 5.3, coordinates= "31.2001° N, 29.9187° E" },
                        new OverviewData() {  name= "Giza", capital= "Giza", area= 1580, population= 2443203, gdp= 4.1,
            timezone= "UTC +2.0", unemployment= 4.7, coordinates= "30.0131° N, 31.2089° E" },
                        }
                },
                new OverviewData()
                {
                 name= "Canada",
                 capital = "Ottawa",
                 area = 9984670,
                 population = 36953765,
                 gdp = 3.0,
                 timezone= "UTC -3.3 to -8",
                 rating = 5,
                 unemployment = 5.8,
                 coordinates = "56.1304° N, 106.3468° W",
                 states= new List<OverviewData>() {
                        new OverviewData() { name= "Ontario", capital= "Toronto", area= 908607, population= 14374084, gdp= 2.8,
            timezone= "UTC -5", unemployment= 5.9, coordinates= "51.2538° N, 85.3232° W" },
                        new OverviewData() { name= "Quebec", capital= "Quebec", area= 1542056, population= 8455402, gdp= 1.9,
            timezone= "UTC -4 to -5", unemployment= 5.6, coordinates= "46.8139° N, 71.2080° W" },
                        new OverviewData() {  name= "Alberta", capital= "Edmonton", area= 661848, population= 4334025, gdp= 1.6,
            timezone= "UTC -7", unemployment= 7.8, coordinates= "53.9333° N, 116.5765° W" },
                        new OverviewData() {  name= "Manitoba", capital= "Winnipeg", area= 647797, population= 1348809, gdp= 2.9,
            timezone= "UTC -6", unemployment= 6, coordinates= "53.7609° N, 98.8139° W" },
                        }
                },
            };
            return data;
        }
    }

    public class TreeLiveData
        {
            public TreeLiveData() { }
            public int Id { get; set; }
            public string IndexFunds { get; set; }
            public double Open { get; set; }
            public double High { get; set; }
            public double Low { get; set; }
            public double Ltp { get; set; }
            public double Change { get; set; }
            public double PercentageChange { get; set; }
            public double WeekHigh { get; set; }
            public double WeekLow { get; set; }
            public List<TreeLiveData> subTasks { get; set; }

        public static List<TreeLiveData> GetTreeLiveDatas()
        {
            List<TreeLiveData> tradeData = new List<TreeLiveData>()
                {
                    new TreeLiveData()
                {
                    Id = 1,
                    IndexFunds = "NIFTY 50",
                    Open = 19729.35,
                    High = 19729.35,
                    Low = 19615.95,
                    Ltp = 19672.35,
                    Change = 25.40,
                    PercentageChange = 0.13,
                    WeekHigh = 3064.68,
                    WeekLow = 2384.51,
                    subTasks = new List<TreeLiveData>(){
                        new TreeLiveData { Id = 2, IndexFunds = "HINDALCO", Open = 436.15, High = 448.45, Low = 435.00, Ltp = 432.95, Change = 15.20, PercentageChange = 3.51, WeekHigh = 6423.28, WeekLow = 28408.25 },
                        new TreeLiveData { Id = 3, IndexFunds = "JSWSTEEL", Open = 778.00, High = 805.50, Low = 777.00, Ltp = 775.65, Change = 26.45, PercentageChange = 3.41, WeekHigh = 4010.93, WeekLow = 31906.18 },
                        new TreeLiveData { Id = 4, IndexFunds = "TATASTEEL", Open = 115.00, High = 119.90, Low = 114.35, Ltp = 115.50, Change = 3.90, PercentageChange = 3.38, WeekHigh = 75256.60, WeekLow = 88878.05 },
                        new TreeLiveData { Id = 5, IndexFunds = "ULTRACEMCO", Open = 8244.70, High = 8415.00, Low = 8244.70, Ltp = 8219.85, Change = 178.40, PercentageChange = 2.17, WeekHigh = 486407.00, WeekLow = 40750.55 },
                        new TreeLiveData { Id = 4, IndexFunds = "NTPC", Open = 196.50, High = 201.35, Low = 195.90, Ltp = 195.90, Change = 4.25, PercentageChange = 2.17, WeekHigh = 15542809.00, WeekLow = 31048.32 },
                        new TreeLiveData { Id = 6, IndexFunds = "TATAMOTORS", Open = 636.00, High = 642.50, Low = 633.35, Ltp = 629.25, Change = 11.35, PercentageChange = 1.80, WeekHigh = 11915439.00, WeekLow = 76127.74 },
                        new TreeLiveData { Id = 7, IndexFunds = "TITAN", Open = 2980.00, High = 3021.00, Low = 2972.75, Ltp = 2979.20, Change = 39.85, PercentageChange = 1.34, WeekHigh = 677302.00, WeekLow = 20343.10 },
                        new TreeLiveData { Id = 8, IndexFunds = "ONGC", Open = 172.00, High = 173.10, Low = 171.30, Ltp = 171.00, Change = 2.05, PercentageChange = 1.20, WeekHigh = 7904458.00, WeekLow = 13628.08 },
                        new TreeLiveData { Id = 9, IndexFunds = "HDFCBANK", Open = 1684.65, High = 1697.95, Low = 1678.40, Ltp = 1678.40, Change = 19.45, PercentageChange = 1.16, WeekHigh = 22934289.00, WeekLow = 387869.28 },
                        new TreeLiveData { Id = 10, IndexFunds = "POWERGRID", Open = 248.95, High = 250.50, Low = 248.15, Ltp = 247.45, Change = 2.65, PercentageChange = 1.07, WeekHigh = 6011009.00, WeekLow = 15012.49 },
                        new TreeLiveData { Id = 11, IndexFunds = "POWERGRID", Open = 248.95, High = 250.50, Low = 248.15, Ltp = 247.45, Change = 2.65, PercentageChange = 1.07, WeekHigh = 6011009.00, WeekLow = 15012.49 },
                        new TreeLiveData { Id = 12, IndexFunds = "POWERGRID", Open = 248.95, High = 250.50, Low = 248.15, Ltp = 247.45, Change = 2.65, PercentageChange = 1.07, WeekHigh = 6011009.00, WeekLow = 15012.49 },
                        new TreeLiveData { Id = 13, IndexFunds = "POWERGRID", Open = 248.95, High = 250.50, Low = 248.15, Ltp = 247.45, Change = 2.65, PercentageChange = 1.07, WeekHigh = 6011009.00, WeekLow = 15012.49 },
                        new TreeLiveData { Id = 14, IndexFunds = "M&M", Open = 1551.45, High = 1569.50, Low = 1548.05, Ltp = 1546.85, Change = 12.80, PercentageChange = 0.83, WeekHigh = 1620100.00, WeekLow = 25246.34 },
                        new TreeLiveData { Id = 15, IndexFunds = "M&M", Open = 1551.45, High = 1569.50, Low = 1548.05, Ltp = 1546.85, Change = 12.80, PercentageChange = 0.83, WeekHigh = 1620100.00, WeekLow = 25246.34 },
                        new TreeLiveData { Id = 16, IndexFunds = "M&M", Open = 1551.45, High = 1569.50, Low = 1548.05, Ltp = 1546.85, Change = 12.80, PercentageChange = 0.83, WeekHigh = 1620100.00, WeekLow = 25246.34 },
                        new TreeLiveData { Id = 17, IndexFunds = "DIVISLAB", Open = 3695.00, High = 3743.00, Low = 3681.10, Ltp = 3686.00, Change = 25.85, PercentageChange = 0.70, WeekHigh = 260824.00, WeekLow = 9699.55 },
                        new TreeLiveData { Id = 18, IndexFunds = "DRREDDY", Open = 5420.00, High = 5479.95, Low = 5391.85, Ltp = 5391.70, Change = 36.90, PercentageChange = 0.68, WeekHigh = 380683.00, WeekLow = 20691.49 },
                        new TreeLiveData { Id = 19, IndexFunds = "GRASIM", Open = 1814.00, High = 1842.80, Low = 1812.05, Ltp = 1813.05, Change = 11.60, PercentageChange = 0.64, WeekHigh = 372552.00, WeekLow = 6815.06 },
                        new TreeLiveData { Id = 20, IndexFunds = "ADANIENT", Open = 2428.00, High = 2442.00, Low = 2416.00, Ltp = 2418.20, Change = 12.80, PercentageChange = 0.53, WeekHigh = 1157354.00, WeekLow = 28099.51 },
                        new TreeLiveData { Id = 21, IndexFunds = "EICHERMOT", Open = 3325.55, High = 3365.00, Low = 3312.75, Ltp = 3307.85, Change = 16.80, PercentageChange = 0.51, WeekHigh = 777189.00, WeekLow = 25983.60 },
                        new TreeLiveData { Id = 22, IndexFunds = "MARUTI", Open = 9624.00, High = 9774.95, Low = 9616.80, Ltp = 9694.80, Change = 42.25, PercentageChange = 0.44, WeekHigh = 204165.00, WeekLow = 19827.18 },
                        new TreeLiveData { Id = 23, IndexFunds = "ADANIPORTS", Open = 737.65, High = 742.65, Low = 733.15, Ltp = 735.30, Change = 3.20, PercentageChange = 0.44, WeekHigh = 1261375.00, WeekLow = 9309.07 },
                        new TreeLiveData { Id = 24, IndexFunds = "BAJFINANCE", Open = 7649.40, High = 7649.40, Low = 7541.05, Ltp = 7581.60, Change = 32.50, PercentageChange = 0.43, WeekHigh = 688337.00, WeekLow = 52271.14 },
                        new TreeLiveData { Id = 25, IndexFunds = "BAJFINANCE", Open = 7649.40, High = 7649.40, Low = 7541.05, Ltp = 7581.60, Change = 32.50, PercentageChange = 0.43, WeekHigh = 688337.00, WeekLow = 52271.14 },
                        new TreeLiveData { Id = 26, IndexFunds = "APOLLOHOSP", Open = 5153.80, High = 5209.60, Low = 5153.80, Ltp = 5180.80, Change = 19.20, PercentageChange = 0.37, WeekHigh = 489756.00, WeekLow = 25433.08 },
                        new TreeLiveData { Id = 27, IndexFunds = "CIPLA", Open = 1058.00, High = 1061.75, Low = 1049.40, Ltp = 1048.95, Change = 3.65, PercentageChange = 0.35, WeekHigh = 449508.00, WeekLow = 4743.88 },
                        new TreeLiveData { Id = 28, IndexFunds = "TATACONSUM", Open = 863.10, High = 866.70, Low = 856.00, Ltp = 863.10, Change = 2.70, PercentageChange = 0.31, WeekHigh = 660067.00, WeekLow = 5694.33 },
                        new TreeLiveData { Id = 29, IndexFunds = "HEROMOTOCO", Open = 3179.00, High = 3179.00, Low = 3132.35, Ltp = 3134.05, Change = 9.75, PercentageChange = 0.31, WeekHigh = 629778.00, WeekLow = 19904.26 },
                        new TreeLiveData { Id = 30, IndexFunds = "ICICIBANK", Open = 999.00, High = 999.00, Low = 988.25, Ltp = 992.00, Change = 2.85, PercentageChange = 0.29, WeekHigh = 23811685.00, WeekLow = 236161.91 },
                        new TreeLiveData { Id = 31, IndexFunds = "RELIANCE", Open = 2494.00, High = 2505.20, Low = 2480.00, Ltp = 2487.40, Change = 6.80, PercentageChange = 0.27, WeekHigh = 4800972.00, WeekLow = 119741.52 },
                        new TreeLiveData { Id = 32, IndexFunds = "TCS", Open = 3397.50, High = 3406.80, Low = 3380.20, Ltp = 3394.75, Change = 7.75, PercentageChange = 0.23, WeekHigh = 921863.00, WeekLow = 31302.87 },
                        new TreeLiveData { Id = 33, IndexFunds = "HDFCLIFE", Open = 653.15, High = 660.00, Low = 650.00, Ltp = 653.15, Change = 0.35, PercentageChange = 0.05, WeekHigh = 3696010.00, WeekLow = 24229.93 },
                        new TreeLiveData { Id = 34, IndexFunds = "INFY", Open = 1337.00, High = 1342.85, Low = 1324.25, Ltp = 1336.60, Change = 0.60, PercentageChange = 0.04, WeekHigh = 4919396.00, WeekLow = 65677.38 },
                        new TreeLiveData { Id = 35, IndexFunds = "HCLTECH", Open = 1118.50, High = 1119.00, Low = 1105.10, Ltp = 1112.90, Change = -0.95, PercentageChange = -0.09, WeekHigh = 2136495.00, WeekLow = 23732.40 },
                        new TreeLiveData { Id = 36, IndexFunds = "HINDUNILVR", Open = 2580.20, High = 2586.60, Low = 2565.65, Ltp = 2580.25, Change = -7.35, PercentageChange = -0.28, WeekHigh = 979277.00, WeekLow = 25195.72 },
                        new TreeLiveData { Id = 37, IndexFunds = "NESTLEIND", Open = 23140.00, High = 23140.00, Low = 22675.25, Ltp = 22820.10, Change = -70.35, PercentageChange = -0.31, WeekHigh = 48529.00, WeekLow = 11059.62 },
                        new TreeLiveData { Id = 38, IndexFunds = "BAJAJFINSV", Open = 1664.90, High = 1664.90, Low = 1635.05, Ltp = 1657.50, Change = -5.35, PercentageChange = -0.32, WeekHigh = 1158371.00, WeekLow = 19085.20 },
                        new TreeLiveData { Id = 39, IndexFunds = "LTIM", Open = 4890.00, High = 4899.00, Low = 4852.50, Ltp = 4879.05, Change = -17.95, PercentageChange = -0.37, WeekHigh = 196553.00, WeekLow = 9574.84 },
                        new TreeLiveData { Id = 40, IndexFunds = "TECHM", Open = 1164.00, High = 1164.70, Low = 1145.00, Ltp = 1161.85, Change = -4.55, PercentageChange = -0.39, WeekHigh = 1989662.00, WeekLow = 22933.04 },
                        new TreeLiveData { Id = 41, IndexFunds = "SUNPHARMA", Open = 1110.00, High = 1110.00, Low = 1095.90, Ltp = 1100.40, Change = -4.45, PercentageChange = -0.40, WeekHigh = 1264846.00, WeekLow = 13918.11 },
                        new TreeLiveData { Id = 42, IndexFunds = "COALINDIA", Open = 232.30, High = 232.35, Low = 228.85, Ltp = 230.95, Change = -1.45, PercentageChange = -0.63, WeekHigh = 9934694.00, WeekLow = 22926.29 },
                        new TreeLiveData { Id = 43, IndexFunds = "WIPRO", Open = 405.50, High = 405.50, Low = 401.15, Ltp = 404.05, Change = -2.55, PercentageChange = -0.63, WeekHigh = 2462513.00, WeekLow = 9922.45 },
                        new TreeLiveData { Id = 44, IndexFunds = "AXISBANK", Open = 977.65, High = 977.65, Low = 953.80, Ltp = 971.50, Change = -6.60, PercentageChange = -0.68, WeekHigh = 10818685.00, WeekLow = 103953.50 },
                        new TreeLiveData { Id = 45, IndexFunds = "BPCL", Open = 387.80, High = 390.90, Low = 384.30, Ltp = 389.55, Change = -2.90, PercentageChange = -0.74, WeekHigh = 1877008.00, WeekLow = 7268.90 },
                        new TreeLiveData { Id = 46, IndexFunds = "KOTAKBANK", Open = 1901.00, High = 1902.00, Low = 1856.45, Ltp = 1897.25, Change = -14.55, PercentageChange = -0.77, WeekHigh = 6677760.00, WeekLow = 125479.12 },
                        new TreeLiveData { Id = 47, IndexFunds = "LT", Open = 2616.00, High = 2617.75, Low = 2565.90, Ltp = 2605.25, Change = -21.10, PercentageChange = -0.81, WeekHigh = 1562905.00, WeekLow = 40379.53 },
                        new TreeLiveData { Id = 48, IndexFunds = "BHARTIARTL", Open = 888.00, High = 894.70, Low = 879.10, Ltp = 888.15, Change = -8.45, PercentageChange = -0.95, WeekHigh = 2857158.00, WeekLow = 25310.13 },
                        new TreeLiveData { Id = 49, IndexFunds = "SBIN", Open = 621.80, High = 621.80, Low = 604.20, Ltp = 617.65, Change = -5.95, PercentageChange = -0.96, WeekHigh = 15239945.00, WeekLow = 93038.34 },
                        new TreeLiveData { Id = 50, IndexFunds = "SBILIFE", Open = 1318.00, High = 1320.00, Low = 1290.10, Ltp = 1317.15, Change = -13.40, PercentageChange = -1.02, WeekHigh = 1179419.00, WeekLow = 15340.11 },
                        new TreeLiveData { Id = 51, IndexFunds = "INDUSINDBK", Open = 1437.00, High = 1446.00, Low = 1419.30, Ltp = 1435.70, Change = -15.20, PercentageChange = -1.06, WeekHigh = 2629942.00, WeekLow = 37748.35 }

                    }
                },
                    new TreeLiveData()
                    {
                        Id = 52,
                        IndexFunds = "NIFTY NEXT 50",
                        Open = 44253.25,
                        High = 44432.25,
                        Low = 44118.00,
                        Ltp = 44407.55,
                        Change = 230.75,
                        PercentageChange = 0.52,
                        WeekHigh = 45509.70,
                        WeekLow = 36850.75,
                        subTasks = new List<TreeLiveData>(){
                            new TreeLiveData { Id = 53, IndexFunds = "ADANIGREEN", Open = 990.00, High = 1088.05, Low = 990.00, Ltp = 1088.05, Change = 98.90, PercentageChange = 10.00, WeekHigh = 2572.00, WeekLow = 439.10 },
                            new TreeLiveData { Id = 54, IndexFunds = "ADANITRANS", Open = 779.75, High = 843.00, Low = 770.55, Ltp = 836.10, Change = 62.85, PercentageChange = 8.13, WeekHigh = 4236.75, WeekLow = 631.50 },
                            new TreeLiveData { Id = 55, IndexFunds = "JINDALSTEL", Open = 635.70, High = 667.95, Low = 633.65, Ltp = 663.95, Change = 34.60, PercentageChange = 5.50, WeekHigh = 667.95, WeekLow = 357.25 },
                            new TreeLiveData { Id = 56, IndexFunds = "ATGL", Open = 631.15, High = 662.65, Low = 628.00, Ltp = 662.65, Change = 31.55, PercentageChange = 5.00, WeekHigh = 4000.00, WeekLow = 620.05 },
                            new TreeLiveData { Id = 57, IndexFunds = "AWL", Open = 399.00, High = 419.65, Low = 398.00, Ltp = 418.25, Change = 19.70, PercentageChange = 4.94, WeekHigh = 841.70, WeekLow = 327.25 },
                            new TreeLiveData { Id = 58, IndexFunds = "ACC", Open = 1810.00, High = 1895.00, Low = 1810.00, Ltp = 1889.00, Change = 84.40, PercentageChange = 4.68, WeekHigh = 2785.00, WeekLow = 1592.35 },
                            new TreeLiveData { Id = 59, IndexFunds = "GAIL", Open = 112.70, High = 117.00, Low = 112.20, Ltp = 116.90, Change = 4.85, PercentageChange = 4.33, WeekHigh = 117.00, WeekLow = 83.00 },
                            new TreeLiveData { Id = 60, IndexFunds = "SHREECEM", Open = 23323.00, High = 23709.95, Low = 23200.00, Ltp = 23708.00, Change = 471.00, PercentageChange = 2.03, WeekHigh = 27049.00, WeekLow = 20039.95 },
                            new TreeLiveData { Id = 61, IndexFunds = "VEDL", Open = 274.90, High = 277.75, Low = 272.10, Ltp = 276.75, Change = 5.45, PercentageChange = 2.01, WeekHigh = 340.75, WeekLow = 235.90 },
                            new TreeLiveData { Id = 62, IndexFunds = "TORNTPHARM", Open = 1948.90, High = 1982.00, Low = 1941.55, Ltp = 1979.00, Change = 38.00, PercentageChange = 1.96, WeekHigh = 1984.25, WeekLow = 1430.00 },
                            new TreeLiveData { Id = 63, IndexFunds = "ZOMATO", Open = 81.30, High = 83.20, Low = 79.30, Ltp = 82.85, Change = 1.55, PercentageChange = 1.91, WeekHigh = 85.25, WeekLow = 40.60 },
                            new TreeLiveData { Id = 64, IndexFunds = "SBICARD", Open = 863.80, High = 879.90, Low = 860.20, Ltp = 875.00, Change = 15.20, PercentageChange = 1.77, WeekHigh = 1028.65, WeekLow = 695.55 },
                            new TreeLiveData { Id = 65, IndexFunds = "ICICIPRULI", Open = 567.05, High = 580.95, Low = 567.05, Ltp = 578.50, Change = 8.30, PercentageChange = 1.46, WeekHigh = 615.60, WeekLow = 380.70 },
                            new TreeLiveData { Id = 66, IndexFunds = "MOTHERSON", Open = 97.70, High = 100.50, Low = 96.75, Ltp = 98.45, Change = 1.40, PercentageChange = 1.44, WeekHigh = 100.50, WeekLow = 61.80 },
                            new TreeLiveData { Id = 67, IndexFunds = "INDUSTOWER", Open = 171.00, High = 174.25, Low = 169.95, Ltp = 171.85, Change = 2.40, PercentageChange = 1.42, WeekHigh = 229.75, WeekLow = 135.15 },
                            new TreeLiveData { Id = 68, IndexFunds = "HDFCAMC", Open = 2496.00, High = 2538.40, Low = 2463.75, Ltp = 2526.00, Change = 28.45, PercentageChange = 1.14, WeekHigh = 2589.35, WeekLow = 1589.50 },
                            new TreeLiveData { Id = 69, IndexFunds = "NAUKRI", Open = 4575.00, High = 4624.00, Low = 4567.35, Ltp = 4619.00, Change = 50.95, PercentageChange = 1.12, WeekHigh = 4768.75, WeekLow = 3308.20 },
                            new TreeLiveData { Id = 70, IndexFunds = "MARICO", Open = 535.35, High = 541.90, Low = 532.35, Ltp = 541.25, Change = 5.85, PercentageChange = 1.09, WeekHigh = 558.75, WeekLow = 462.70 },
                            new TreeLiveData { Id = 71, IndexFunds = "MUTHOOTFIN", Open = 1303.00, High = 1318.85, Low = 1286.60, Ltp = 1310.00, Change = 13.25, PercentageChange = 1.02, WeekHigh = 1318.85, WeekLow = 911.25 },
                            new TreeLiveData { Id = 72, IndexFunds = "BAJAJHLDNG", Open = 7417.00, High = 7545.40, Low = 7409.25, Ltp = 7501.00, Change = 72.90, PercentageChange = 0.98, WeekHigh = 7590.00, WeekLow = 4825.00 },
                            new TreeLiveData { Id = 73, IndexFunds = "TATAPOWER", Open = 217.50, High = 220.50, Low = 217.50, Ltp = 219.40, Change = 2.05, PercentageChange = 0.94, WeekHigh = 251.15, WeekLow = 182.35 },
                            new TreeLiveData { Id = 74, IndexFunds = "BEL", Open = 126.55, High = 127.20, Low = 125.35, Ltp = 127.15, Change = 1.15, PercentageChange = 0.91, WeekHigh = 128.80, WeekLow = 87.00 },
                            new TreeLiveData { Id = 75, IndexFunds = "HAVELLS", Open = 1296.00, High = 1308.90, Low = 1290.65, Ltp = 1306.00, Change = 9.30, PercentageChange = 0.72, WeekHigh = 1408.30, WeekLow = 1024.50 },
                            new TreeLiveData { Id = 76, IndexFunds = "MCDOWELL-N", Open = 986.15, High = 990.00, Low = 974.00, Ltp = 984.60, Change = 6.95, PercentageChange = 0.71, WeekHigh = 1049.00, WeekLow = 730.55 },
                            new TreeLiveData { Id = 77, IndexFunds = "DABUR", Open = 566.95, High = 569.60, Low = 563.10, Ltp = 569.20, Change = 3.90, PercentageChange = 0.69, WeekHigh = 610.75, WeekLow = 503.65 },
                            new TreeLiveData { Id = 78, IndexFunds = "SRF", Open = 2059.00, High = 2183.00, Low = 2040.00, Ltp = 2153.30, Change = 8.95, PercentageChange = 0.42, WeekHigh = 2865.00, WeekLow = 2040.00 },
                            new TreeLiveData { Id = 79, IndexFunds = "ABB", Open = 4335.00, High = 4369.45, Low = 4271.15, Ltp = 4335.35, Change = 13.30, PercentageChange = 0.31, WeekHigh = 4614.35, WeekLow = 2635.40 },
                            new TreeLiveData { Id = 80, IndexFunds = "COLPAL", Open = 1896.95, High = 1902.35, Low = 1870.55, Ltp = 1891.65, Change = 3.05, PercentageChange = 0.16, WeekHigh = 1902.35, WeekLow = 1434.60 },
                            new TreeLiveData { Id = 81, IndexFunds = "DMART", Open = 3668.05, High = 3701.75, Low = 3660.05, Ltp = 3672.00, Change = 3.80, PercentageChange = 0.10, WeekHigh = 4609.00, WeekLow = 3292.00 },
                            new TreeLiveData { Id = 82, IndexFunds = "BOSCHLTD", Open = 19100.00, High = 19200.00, Low = 18869.60, Ltp = 19021.00, Change = -3.25, PercentageChange = -0.02, WeekHigh = 19990.00, WeekLow = 15300.00 },
                            new TreeLiveData { Id = 83, IndexFunds = "SIEMENS", Open = 3699.85, High = 3729.40, Low = 3666.30, Ltp = 3688.60, Change = -6.30, PercentageChange = -0.17, WeekHigh = 3938.40, WeekLow = 2573.05 },
                            new TreeLiveData { Id = 84, IndexFunds = "IRCTC", Open = 621.50, High = 625.00, Low = 615.60, Ltp = 619.00, Change = -1.30, PercentageChange = -0.21, WeekHigh = 774.90, WeekLow = 557.10 },
                            new TreeLiveData { Id = 85, IndexFunds = "NYKAA", Open = 145.75, High = 145.75, Low = 144.05, Ltp = 144.65, Change = -0.35, PercentageChange = -0.24, WeekHigh = 247.76, WeekLow = 114.25 },
                            new TreeLiveData { Id = 86, IndexFunds = "GODREJCP", Open = 1038.35, High = 1040.85, Low = 1028.85, Ltp = 1033.10, Change = -3.30, PercentageChange = -0.32, WeekHigh = 1102.05, WeekLow = 793.85 },
                            new TreeLiveData { Id = 87, IndexFunds = "LICI", Open = 626.75, High = 630.80, Low = 621.05, Ltp = 622.75, Change = -3.90, PercentageChange = -0.62, WeekHigh = 754.25, WeekLow = 530.05 },
                            new TreeLiveData { Id = 88, IndexFunds = "IOC", Open = 99.95, High = 100.25, Low = 98.70, Ltp = 99.20, Change = -0.65, PercentageChange = -0.65, WeekHigh = 101.45, WeekLow = 65.20 },
                            new TreeLiveData { Id = 89, IndexFunds = "PAGEIND", Open = 37510.00, High = 37955.00, Low = 36900.00, Ltp = 37190.00, Change = -267.50, PercentageChange = -0.71, WeekHigh = 54349.10, WeekLow = 34952.65 },
                            new TreeLiveData { Id = 90, IndexFunds = "ICICIGI", Open = 1390.10, High = 1401.00, Low = 1368.00, Ltp = 1375.00, Change = -12.50, PercentageChange = -0.90, WeekHigh = 1423.30, WeekLow = 1049.05 },
                            new TreeLiveData { Id = 91, IndexFunds = "BANKBARODA", Open = 200.40, High = 200.40, Low = 195.60, Ltp = 196.30, Change = -2.05, PercentageChange = -1.03, WeekHigh = 210.80, WeekLow = 113.35 },
                            new TreeLiveData { Id = 92, IndexFunds = "HAL", Open = 3899.00, High = 3905.00, Low = 3828.05, Ltp = 3835.00, Change = -50.25, PercentageChange = -1.29,WeekHigh = 3950.00, WeekLow = 1868.05 },
                            new TreeLiveData { Id = 93, IndexFunds = "CHOLAFIN", Open = 1145.50, High = 1154.20, Low = 1120.00, Ltp = 1128.95, Change = -15.70, PercentageChange = -1.37, WeekHigh = 1214.60, WeekLow = 658.00 },
                            new TreeLiveData { Id = 94, IndexFunds = "BERGEPAINT", Open = 680.85, High = 692.25, Low = 666.75, Ltp = 675.15, Change = -10.70, PercentageChange = -1.56, WeekHigh = 710.30, WeekLow = 527.15 },
                            new TreeLiveData { Id = 95, IndexFunds = "PIIND", Open = 3630.00, High = 3648.70, Low = 3546.20, Ltp = 3573.00, Change = -58.20, PercentageChange = -1.60, WeekHigh = 4011.15, WeekLow = 2868.90 },
                            new TreeLiveData { Id = 96, IndexFunds = "VBL", Open = 816.50, High = 816.50, Low = 799.00, Ltp = 804.50, Change = -13.20, PercentageChange = -1.61, WeekHigh = 873.50, WeekLow = 429.50 },
                            new TreeLiveData { Id = 97, IndexFunds = "PIDILITIND", Open = 2648.00, High = 2648.00, Low = 2587.80, Ltp = 2607.00, Change = -44.60, PercentageChange = -1.68, WeekHigh = 2890.80, WeekLow = 2074.00 },
                            new TreeLiveData { Id = 98, IndexFunds = "HCLTECH", Open = 1184.90, High = 1187.90, Low = 1172.25, Ltp = 1165.00, Change = -15.60, PercentageChange = -1.32,WeekHigh = 1261.75, WeekLow = 870.00 },
                            new TreeLiveData { Id = 99, IndexFunds = "CUMMINSIND", Open = 1062.00, High = 1072.75, Low = 1047.00, Ltp = 1045.00, Change = -14.35, PercentageChange = -1.35, WeekHigh = 1148.50, WeekLow = 797.50 },
                            new TreeLiveData { Id = 100, IndexFunds = "IDFCFIRSTB", Open = 59.45, High = 59.90, Low = 58.60, Ltp = 58.50, Change = -0.70, PercentageChange = -1.18, WeekHigh = 74.80, WeekLow = 46.80 },
                            new TreeLiveData { Id = 101, IndexFunds = "CROMPTON", Open = 510.20, High = 510.70, Low = 503.55, Ltp = 501.95, Change = -5.30, PercentageChange = -1.04, WeekHigh = 561.85, WeekLow = 413.20 },
                            new TreeLiveData { Id = 102, IndexFunds = "HDFCLIFE", Open = 702.80, High = 708.60, Low = 700.10, Ltp = 696.60, Change = -6.85, PercentageChange = -0.97, WeekHigh = 751.75, WeekLow = 590.05 }
                        }

                    },
                    new TreeLiveData()
                    {
                        Id = 103,
                        IndexFunds = "NIFTY BANK",
                        Open = 46154.70,
                        High = 46156.10,
                        Low = 45622.85,
                        Ltp = 45845.00,
                        Change = -78.05,
                        PercentageChange = -0.17,
                        WeekHigh = 46369.50,
                        WeekLow = 37221.15,
                        subTasks = new List<TreeLiveData>(){
                            new TreeLiveData { Id = 104, IndexFunds = "HDFCBANK", Open = 1684.65, High = 1699.00, Low = 1678.40, Ltp = 1694.55, Change = 16.15, PercentageChange = 0.96, WeekHigh = 1757.50, WeekLow = 1365.00 },
                            new TreeLiveData { Id = 105, IndexFunds = "ICICIBANK", Open = 999.00, High = 999.00, Low = 988.25, Ltp = 993.90, Change = 1.90, PercentageChange = 0.19, WeekHigh = 1008.70, WeekLow = 791.65 },
                            new TreeLiveData { Id = 106, IndexFunds = "BANDHANBNK", Open = 219.50, High = 220.55, Low = 216.25, Ltp = 218.35, Change = -0.30, PercentageChange = -0.14, WeekHigh = 314.80, WeekLow = 182.15 },
                            new TreeLiveData { Id = 107, IndexFunds = "IDFCFIRSTB", Open = 84.05, High = 84.30, Low = 82.60, Ltp = 83.15, Change = -0.55, PercentageChange = -0.66, WeekHigh = 85.50, WeekLow = 35.35 },
                            new TreeLiveData { Id = 108, IndexFunds = "FEDERALBNK", Open = 134.60, High = 134.75, Low = 131.70, Ltp = 132.95, Change = -1.00, PercentageChange = -0.75, WeekHigh = 143.40, WeekLow = 105.05 },
                            new TreeLiveData { Id = 109, IndexFunds = "AUBANK", Open = 745.00, High = 745.30, Low = 725.10, Ltp = 733.60, Change = -5.55, PercentageChange = -0.75, WeekHigh = 795.00, WeekLow = 548.00 },
                            new TreeLiveData { Id = 110, IndexFunds = "AXISBANK", Open = 977.65, High = 977.65, Low = 953.80, Ltp = 963.00, Change = -8.50, PercentageChange = -0.87, WeekHigh = 990.00, WeekLow = 702.05 },
                            new TreeLiveData { Id = 111, IndexFunds = "BANKBARODA", Open = 200.40, High = 200.40, Low = 195.60, Ltp = 196.30, Change = -2.05, PercentageChange = -1.03, WeekHigh = 210.80, WeekLow = 113.35 },
                            new TreeLiveData { Id = 112, IndexFunds = "INDUSINDBK", Open = 1437.00, High = 1446.00, Low = 1411.40, Ltp = 1418.00, Change = -17.70, PercentageChange = -1.23, WeekHigh = 1446.00, WeekLow = 939.55 },
                            new TreeLiveData { Id = 113, IndexFunds = "SBIN", Open = 621.80, High = 621.80, Low = 604.20, Ltp = 609.90, Change = -7.75, PercentageChange = -1.25, WeekHigh = 629.55, WeekLow = 499.35 },
                            new TreeLiveData { Id = 114, IndexFunds = "KOTAKBANK", Open = 1901.00, High = 1902.00, Low = 1856.45, Ltp = 1871.65, Change = -25.60, PercentageChange = -1.35, WeekHigh = 2064.40, WeekLow = 1643.50 },
                            new TreeLiveData { Id = 115, IndexFunds = "PNB", Open = 62.45, High = 63.00, Low = 60.55, Ltp = 60.70, Change = -1.40, PercentageChange = -2.25, WeekHigh = 65.15, WeekLow = 31.30 },

                        }
                    },
                    new TreeLiveData()
                    {
                        Id = 116,
                        IndexFunds = "NIFTY ALPHA 50",
                        Open = 33331.00,
                        High = 33338.95,
                        Low = 33001.50,
                        Ltp = 33070.05,
                        Change = -66.40,
                        PercentageChange = -0.20,
                        WeekHigh = 0,
                        WeekLow = 0,
                        subTasks = new List<TreeLiveData>(){
                            new TreeLiveData { Id = 117, IndexFunds = "TVSMOTOR", Open = 1333.00, High = 1388.45, Low = 1313.65, Ltp = 1383.70, Change = 76.60, PercentageChange = 5.86, WeekHigh = 1388.45, WeekLow = 837.05 },
                            new TreeLiveData { Id = 118, IndexFunds = "JINDALSTEL", Open = 635.70, High = 667.95, Low = 633.65, Ltp = 663.95, Change = 34.60, PercentageChange = 5.50, WeekHigh = 667.95, WeekLow = 357.25 },
                            new TreeLiveData { Id = 119, IndexFunds = "JSL", Open = 362.50, High = 375.50, Low = 362.50, Ltp = 372.35, Change = 12.20, PercentageChange = 3.39, WeekHigh = 375.50, WeekLow = 112.70 },
                            new TreeLiveData { Id = 120, IndexFunds = "APLAPOLLO", Open = 1473.00, High = 1505.00, Low = 1459.55, Ltp = 1482.95, Change = 48.15, PercentageChange = 3.36, WeekHigh = 1505.00, WeekLow = 881.00 },
                            new TreeLiveData { Id = 121, IndexFunds = "POONAWALLA", Open = 375.00, High = 380.95, Low = 370.25, Ltp = 379.10, Change = 10.65, PercentageChange = 2.89, WeekHigh = 385.00, WeekLow = 243.00 },
                            new TreeLiveData { Id = 122, IndexFunds = "APOLLOTYRE", Open = 417.20, High = 420.80, Low = 414.00, Ltp = 420.50, Change = 5.80, PercentageChange = 1.40, WeekHigh = 436.50, WeekLow = 206.25 },
                            new TreeLiveData { Id = 123, IndexFunds = "PHOENIXLTD", Open = 1630.00, High = 1669.90, Low = 1614.55, Ltp = 1652.15, Change = 21.70, PercentageChange = 1.33, WeekHigh = 1734.10, WeekLow = 1186.40 },
                            new TreeLiveData { Id = 124, IndexFunds = "M&M", Open = 1551.45, High = 1569.50, Low = 1548.05, Ltp = 1566.00, Change = 19.15, PercentageChange = 1.24, WeekHigh = 1594.80, WeekLow = 1123.40 },
                            new TreeLiveData { Id = 125, IndexFunds = "CUMMINSIND", Open = 1922.00, High = 1928.50, Low = 1903.35, Ltp = 1925.00, Change = 22.90, PercentageChange = 1.20, WeekHigh = 1953.50, WeekLow = 1103.80 },
                            new TreeLiveData { Id = 126, IndexFunds = "ZYDUSLIFE", Open = 614.95, High = 624.00, Low = 613.00, Ltp = 621.00, Change = 7.20, PercentageChange = 1.17, WeekHigh = 624.00, WeekLow = 340.00 },
                            new TreeLiveData { Id = 127, IndexFunds = "BAJAJHLDNG", Open = 7417.00, High = 7545.40, Low = 7409.25, Ltp = 7501.00, Change = 72.90, PercentageChange = 0.98, WeekHigh = 7590.00, WeekLow = 4825.00 },
                            new TreeLiveData { Id = 128, IndexFunds = "BEL", Open = 126.55, High = 127.20, Low = 125.35, Ltp = 127.15, Change = 1.15, PercentageChange = 0.91, WeekHigh = 128.80, WeekLow = 87.00 },
                            new TreeLiveData { Id = 129, IndexFunds = "SONATSOFTW", Open = 1049.95, High = 1064.70, Low = 1041.50, Ltp = 1051.00, Change = 8.85, PercentageChange = 0.85, WeekHigh = 1094.70, WeekLow = 487.25 },
                            new TreeLiveData { Id = 130, IndexFunds = "ESCORTS", Open = 2371.20, High = 2392.00, Low = 2357.25, Ltp = 2375.00, Change = 16.25, PercentageChange = 0.69, WeekHigh = 2395.00, WeekLow = 1604.65 },
                            new TreeLiveData { Id = 131, IndexFunds = "KPITTECH", Open = 1078.35, High = 1107.00, Low = 1038.85, Ltp = 1061.95, Change = 5.15, PercentageChange = 0.49, WeekHigh = 1160.00, WeekLow = 510.00 },
                            new TreeLiveData { Id = 132, IndexFunds = "EQUITASBNK", Open = 96.25, High = 97.70, Low = 95.30, Ltp = 95.75, Change = 0.30, PercentageChange = 0.31, WeekHigh = 99.15, WeekLow = 42.85 },
                            new TreeLiveData { Id = 133, IndexFunds = "ABB", Open = 4335.00, High = 4369.45, Low = 4271.15, Ltp = 4335.35, Change = 13.30, PercentageChange = 0.31, WeekHigh = 4614.35, WeekLow = 2635.40 },
                            new TreeLiveData { Id = 134, IndexFunds = "IDFC", Open = 114.10, High = 114.50, Low = 112.60, Ltp = 113.95, Change = 0.20, PercentageChange = 0.18, WeekHigh = 116.85, WeekLow = 51.90 },
                            new TreeLiveData { Id = 135, IndexFunds = "KARURVYSYA", Open = 131.05, High = 131.30, Low = 128.15, Ltp = 129.50, Change = 0.15, PercentageChange = 0.12, WeekHigh = 137.75, WeekLow = 53.00 },
                            new TreeLiveData { Id = 136, IndexFunds = "POLYCAB", Open = 4740.00, High = 4784.00, Low = 4650.10, Ltp = 4703.20, Change = 4.75, PercentageChange = 0.10, WeekHigh = 4924.00, WeekLow = 2201.10 },
                            new TreeLiveData { Id = 137, IndexFunds = "INDHOTEL", Open = 392.40, High = 396.35, Low = 388.00, Ltp = 391.80, Change = 0.20, PercentageChange = 0.05, WeekHigh = 406.00, WeekLow = 251.70 },
                            new TreeLiveData { Id = 138, IndexFunds = "BHEL", Open = 98.70, High = 99.60, Low = 97.20, Ltp = 98.00, Change = -0.05, PercentageChange = -0.05, WeekHigh = 99.60, WeekLow = 51.35 },
                            new TreeLiveData { Id = 139, IndexFunds = "SCHAEFFLER", Open = 3200.00, High = 3230.00, Low = 3150.00, Ltp = 3170.00, Change = -1.95, PercentageChange = -0.06, WeekHigh = 3969.85, WeekLow = 2460.00 },
                            new TreeLiveData { Id = 140, IndexFunds = "NHPC", Open = 50.60, High = 51.80, Low = 49.00, Ltp = 49.85, Change = -0.05, PercentageChange = -0.10, WeekHigh = 51.80, WeekLow = 32.75 },
                            new TreeLiveData { Id = 141, IndexFunds = "SIEMENS", Open = 3699.85, High = 3729.40, Low = 3666.30, Ltp = 3688.60, Change = -6.30, PercentageChange = -0.17, WeekHigh = 3938.40, WeekLow = 2573.05 },
                            new TreeLiveData { Id = 142, IndexFunds = "MRF", Open = 102202.10, High = 102699.00, Low = 102000.00, Ltp = 102508.15, Change = -215.35, PercentageChange = -0.21, WeekHigh = 103186.70, WeekLow = 78689.95 },
                            new TreeLiveData { Id = 143, IndexFunds = "ABCAPITAL", Open = 189.95, High = 191.25, Low = 187.60, Ltp = 188.40, Change = -0.45, PercentageChange = -0.24, WeekHigh = 199.30, WeekLow = 101.65 },
                            new TreeLiveData { Id = 144, IndexFunds = "COALINDIA", Open = 232.30, High = 232.35, Low = 228.85, Ltp = 229.95, Change = -1.00, PercentageChange = -0.43, WeekHigh = 263.40, WeekLow = 194.60 },
                            new TreeLiveData { Id = 145, IndexFunds = "CGPOWER", Open = 404.80, High = 409.80, Low = 398.50, Ltp = 400.00, Change = -1.85, PercentageChange = -0.46, WeekHigh = 424.65, WeekLow = 212.10 },
                            new TreeLiveData { Id = 146, IndexFunds = "PFC", Open = 241.95, High = 243.45, Low = 235.40, Ltp = 238.50, Change = -1.25, PercentageChange = -0.52, WeekHigh = 244.00, WeekLow = 100.85 },
                            new TreeLiveData { Id = 147, IndexFunds = "UNIONBANK", Open = 89.05, High = 90.35, Low = 86.75, Ltp = 88.15, Change = -0.50, PercentageChange = -0.56, WeekHigh = 96.40, WeekLow = 36.80 },
                            new TreeLiveData { Id = 148, IndexFunds = "IDFCFIRSTB", Open = 84.05, High = 84.30, Low = 82.60, Ltp = 83.15, Change = -0.55, PercentageChange = -0.66, WeekHigh = 85.50, WeekLow = 35.35 },
                            new TreeLiveData { Id = 149, IndexFunds = "FEDERALBNK", Open = 134.60, High = 134.75, Low = 131.70, Ltp = 132.95, Change = -1.00, PercentageChange = -0.75, WeekHigh = 143.40, WeekLow = 105.05 },
                            new TreeLiveData { Id = 150, IndexFunds = "NCC", Open = 138.80, High = 138.85, Low = 135.70, Ltp = 137.35, Change = -1.10, PercentageChange = -0.79, WeekHigh = 142.85, WeekLow = 55.60 },
                            new TreeLiveData { Id = 151, IndexFunds = "BANKBARODA", Open = 200.40, High = 200.40, Low = 195.60, Ltp = 196.30, Change = -2.05, PercentageChange = -1.03, WeekHigh = 210.80, WeekLow = 113.35 },
                            new TreeLiveData { Id = 152, IndexFunds = "HAL", Open = 3899.00, High = 3905.00, Low = 3828.05, Ltp = 3835.00, Change = -50.25, PercentageChange = -1.29, WeekHigh = 3950.00, WeekLow = 1868.05 },
                            new TreeLiveData { Id = 153, IndexFunds = "CHOLAFIN", Open = 1145.50, High = 1154.20, Low = 1120.00, Ltp = 1128.95, Change = -15.70, PercentageChange = -1.37, WeekHigh = 1214.60, WeekLow = 658.00 },
                            new TreeLiveData { Id = 154, IndexFunds = "TIINDIA", Open = 3200.00, High = 3208.95, Low = 3127.00, Ltp = 3129.00, Change = -45.25, PercentageChange = -1.43, WeekHigh = 3398.70, WeekLow = 1981.00 },
                            new TreeLiveData { Id = 155, IndexFunds = "CYIENT", Open = 1482.35, High = 1487.95, Low = 1460.00, Ltp = 1461.00, Change = -21.35, PercentageChange = -1.44, WeekHigh = 1555.00, WeekLow = 723.80 },
                            new TreeLiveData { Id = 156, IndexFunds = "BRITANNIA", Open = 5007.00, High = 5007.00, Low = 4875.00, Ltp = 4896.00, Change = -72.90, PercentageChange = -1.47, WeekHigh = 5270.35, WeekLow = 3564.10 },
                            new TreeLiveData { Id = 157, IndexFunds = "M&MFIN", Open = 324.85, High = 325.35, Low = 313.75, Ltp = 316.45, Change = -4.80, PercentageChange = -1.49, WeekHigh = 346.55, WeekLow = 176.10 },
                            new TreeLiveData { Id = 158, IndexFunds = "VBL", Open = 816.50, High = 816.50, Low = 799.00, Ltp = 804.50, Change = -13.20, PercentageChange = -1.61, WeekHigh = 873.50, WeekLow = 429.50 },
                            new TreeLiveData { Id = 159, IndexFunds = "BANKINDIA", Open = 84.80, High = 85.75, Low = 82.50, Ltp = 82.90, Change = -1.45, PercentageChange = -1.72, WeekHigh = 103.50, WeekLow = 45.85 },
                            new TreeLiveData { Id = 160, IndexFunds = "CANBK", Open = 342.00, High = 342.90, Low = 330.00, Ltp = 333.00, Change = -6.70, PercentageChange = -1.97, WeekHigh = 351.40, WeekLow = 207.50 },
                            new TreeLiveData { Id = 161, IndexFunds = "ITC", Open = 467.90, High = 468.50, Low = 455.40, Ltp = 461.35, Change = -10.00, PercentageChange = -2.12, WeekHigh = 499.70, WeekLow = 298.80 },
                            new TreeLiveData { Id = 162, IndexFunds = "PNB", Open = 62.45, High = 62.50, Low = 59.90, Ltp = 60.90, Change = -1.30, PercentageChange = -2.09, WeekHigh = 70.55, WeekLow = 28.50 },
                            new TreeLiveData { Id = 163, IndexFunds = "J&KBANK", Open = 59.80, High = 59.95, Low = 57.90, Ltp = 58.75, Change = -1.25, PercentageChange = -2.08, WeekHigh = 71.60, WeekLow = 37.80 },
                            new TreeLiveData { Id = 164, IndexFunds = "SUNPHARMA", Open = 816.00, High = 819.90, Low = 790.65, Ltp = 802.15, Change = -17.05, PercentageChange = -2.08, WeekHigh = 883.80, WeekLow = 523.40 },
                            new TreeLiveData { Id = 165, IndexFunds = "AUROPHARMA", Open = 779.50, High = 781.00, Low = 759.10, Ltp = 763.15, Change = -16.20, PercentageChange = -2.08, WeekHigh = 833.65, WeekLow = 479.00 }
                        }
                    }

                };
            return tradeData;
        }
    }
}
