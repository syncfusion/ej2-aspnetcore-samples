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
using System.Web;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class LeaveAvailability
    {
        public int Casual { get; set; }
        public int Earned { get; set; }
        public int Sick { get; set; }
    }

    public class UseCaseEmployee
    {
        public UseCaseEmployee() { }
        public string ID { get; set; }
        public string EmployeeName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public string Location { get; set; }
        public DateTime JoinDate { get; set; }
        public double Salary { get; set; }
        public string Status { get; set; }
        public string Contact { get; set; }
        public int LeaveCount { get; set; }
        public LeaveAvailability LeaveAvailability { get; set; }
        public string ProjectDetails { get; set; }
        public string ProjectStatus { get; set; }
        public int Experience { get; set; }
        public string WorkMode { get; set; }
        public List<UseCaseEmployee> Children { get; set; }

        public static List<UseCaseEmployee> GetData()
        {
            return new List<UseCaseEmployee>
            {
                new UseCaseEmployee
                {
                    ID = "EMP001",
                    EmployeeName = "Steven Buchanan",
                    FullName = "StevenBuchanan",
                    Email = "stevenbuchanan@abc.com",
                    Department = "Director",
                    JobTitle = "CEO",
                    Location = "USA",
                    JoinDate = new DateTime(2010, 4, 23),
                    Salary = 300000,
                    Status = "Available",
                    Contact = "1234567890",
                    LeaveCount = 12,
                    LeaveAvailability = new LeaveAvailability { Casual = 2, Earned = 5, Sick = 12 },
                    ProjectDetails = "",
                    ProjectStatus = "In Progress",
                    Experience = 20,
                    WorkMode = "Work From Home",
                    Children = new List<UseCaseEmployee>
                    {
                        new UseCaseEmployee
                        {
                            ID = "EMP002",
                            EmployeeName = "Romey Wilson",
                            FullName = "RomeyWilson",
                            Email = "romeywilson@abc.com",
                            Department = "Development",
                            JobTitle = "Manager",
                            Location = "USA",
                            JoinDate = new DateTime(2018, 4, 23),
                            Salary = 150000,
                            Status = "Available",
                            Contact = "9876543210",
                            LeaveCount = 4,
                            LeaveAvailability = new LeaveAvailability { Casual = 10, Earned = 11, Sick = 11 },
                            ProjectDetails = "Smart Inventory Management",
                            ProjectStatus = "Pending",
                            Experience = 10,
                            WorkMode = "Work From Home",
                            Children = new List<UseCaseEmployee>
                            {
                                new UseCaseEmployee
                                {
                                    ID = "EMP003",
                                    EmployeeName = "Robert King",
                                    FullName = "RobertKing",
                                    Email = "robertking@abc.com",
                                    Department = "Development",
                                    JobTitle = "Team Lead",
                                    Location = "Germany",
                                    JoinDate = new DateTime(2018, 4, 23),
                                    Salary = 100000,
                                    Status = "Leave",
                                    Contact = "5551112233",
                                    LeaveCount = 1,
                                    LeaveAvailability = new LeaveAvailability { Casual = 12, Earned = 11, Sick = 12 },
                                    ProjectDetails = "Smart Inventory Management",
                                    ProjectStatus = "In Progress",
                                    Experience = 7,
                                    WorkMode = "Work From Home",
                                    Children = new List<UseCaseEmployee>
                                    {
                                        new UseCaseEmployee
                                        {
                                            ID = "EMP004",
                                            EmployeeName = "Andrew Fuller",
                                            FullName = "AndrewFuller",
                                            Email = "andrewfuller@abc.com",
                                            Department = "Development",
                                            JobTitle = "UseCaseEmployee",
                                            Location = "Canada",
                                            JoinDate = new DateTime(2018, 4, 23),
                                            Salary = 60000,
                                            Status = "Available",
                                            Contact = "5551112233",
                                            LeaveCount = 1,
                                            LeaveAvailability = new LeaveAvailability { Casual = 12, Earned = 11, Sick = 12 },
                                            ProjectDetails = "Smart Inventory Management",
                                            ProjectStatus = "In Progress",
                                            Experience = 2,
                                            WorkMode = "Work From Home",
                                        },
                                        new UseCaseEmployee
                                        {
                                            ID = "EMP005",
                                            EmployeeName = "Anne Dodsworth",
                                            FullName = "AnneDodsworth",
                                            Email = "annedodsworth@abc.com",
                                            Department = "Development",
                                            JobTitle = "UseCaseEmployee",
                                            Location = "Egypt",
                                            JoinDate = new DateTime(2018, 4, 23),
                                            Salary = 70000,
                                            Status = "Available",
                                            Contact = "5551112233",
                                            LeaveCount = 12,
                                            LeaveAvailability = new LeaveAvailability { Casual = 8, Earned = 4, Sick = 12 },
                                            ProjectDetails = "Smart Inventory Management",
                                            ProjectStatus = "In Progress",
                                            Experience = 2,
                                            WorkMode = "Work From Home",
                                        },
                                        new UseCaseEmployee
                                        {
                                            ID = "EMP006",
                                            EmployeeName = "Davey Hanks",
                                            FullName = "DaveyHanks",
                                            Email = "daveyhanks@abc.com",
                                            Department = "Development",
                                            JobTitle = "UseCaseEmployee",
                                            Location = "Greece",
                                            JoinDate = new DateTime(2019, 7, 12),
                                            Salary = 76000,
                                            Status = "Available",
                                            Contact = "5552223344",
                                            LeaveCount = 5,
                                            LeaveAvailability = new LeaveAvailability { Casual = 11, Earned = 8, Sick = 12 },
                                            ProjectDetails = "Support Ticket System",
                                            ProjectStatus = "In Progress",
                                            Experience = 5,
                                            WorkMode = "Work From Home",
                                        },
                                        new UseCaseEmployee
                                        {
                                            ID = "EMP007",
                                            EmployeeName = "Jason Gills",
                                            FullName = "JasonGills",
                                            Email = "jasongills@abc.com",
                                            Department = "Development",
                                            JobTitle = "UseCaseEmployee",
                                            Location = "USA",
                                            JoinDate = new DateTime(2020, 1, 30),
                                            Salary = 72000,
                                            Status = "Busy",
                                            Contact = "5553334455",
                                            LeaveCount = 7,
                                            LeaveAvailability = new LeaveAvailability { Casual = 9, Earned = 8, Sick = 12 },
                                            ProjectDetails = "Support Ticket System",
                                            ProjectStatus = "In Progress",
                                            Experience = 4,
                                            WorkMode = "Hybrid",
                                        },
                                        new UseCaseEmployee
                                        {
                                            ID = "EMP008",
                                            EmployeeName = "Laura Callahan",
                                            FullName = "LauraCallahan",
                                            Email = "lauracallahan@abc.com",
                                            Department = "Development",
                                            JobTitle = "UseCaseEmployee",
                                            Location = "Canada",
                                            JoinDate = new DateTime(2017, 10, 5),
                                            Salary = 78000,
                                            Status = "Available",
                                            Contact = "5554445566",
                                            LeaveCount = 1,
                                            LeaveAvailability = new LeaveAvailability { Casual = 11, Earned = 12, Sick = 12 },
                                            ProjectDetails = "Support Ticket System",
                                            ProjectStatus = "Completed",
                                            Experience = 3,
                                            WorkMode = "Hybrid",
                                        },
                                        new UseCaseEmployee
                                        {
                                            ID = "EMP009",
                                            EmployeeName = "Jade Lynch",
                                            FullName = "JadeLynch",
                                            Email = "JadeLynch@abc.com",
                                            Department = "Development",
                                            JobTitle = "UseCaseEmployee",
                                            Location = "USA",
                                            JoinDate = new DateTime(2021, 8, 18),
                                            Salary = 71000,
                                            Status = "Available",
                                            Contact = "5556667788",
                                            LeaveCount = 20,
                                            LeaveAvailability = new LeaveAvailability { Casual = 4, Earned = 11, Sick = 1 },
                                            ProjectDetails = "Support Ticket System",
                                            ProjectStatus = "In Progress",
                                            Experience = 2,
                                            WorkMode = "Hybrid",
                                        }
                                    }
                                }
                            }
                        },
                        new UseCaseEmployee
                {
                    ID = "EMP010",
                    EmployeeName = "David William",
                    FullName = "DavidWilliam",
                    Email = "davidwilliam@abc.com",
                    Department = "UI/UX",
                    JobTitle = "Manager",
                    Location = "Greece",
                    JoinDate = new DateTime(2018, 4, 23),
                    Salary = 170000,
                    Status = "Leave",
                    Contact = "5551112233",
                    LeaveCount = 1,
                    LeaveAvailability = new LeaveAvailability { Casual = 12, Earned = 11, Sick = 12 },
                    ProjectDetails = "Chat Bot",
                    ProjectStatus = "Pending",
                    Experience = 12,
                    WorkMode = "Work From Office",
                    Children = new List<UseCaseEmployee>
                    {
                        new UseCaseEmployee
                        {
                            ID = "EMP011",
                            EmployeeName = "Janet Leverling",
                            FullName = "JanetLeverling",
                            Email = "janetleverling@abc.com",
                            Department = "UI/UX",
                            JobTitle = "Team Lead",
                            Location = "USA",
                            JoinDate = new DateTime(2018, 4, 23),
                            Salary = 120000,
                            Status = "Available",
                            Contact = "5551112233",
                            LeaveCount = 4,
                            LeaveAvailability = new LeaveAvailability { Casual = 11, Earned = 10, Sick = 11 },
                            ProjectDetails = "Chat Bot",
                            ProjectStatus = "In Progress",
                            Experience = 7,
                            WorkMode = "Work From Office",
                            Children = new List<UseCaseEmployee>
                            {
                                new UseCaseEmployee
                                {
                                    ID = "EMP012",
                                    EmployeeName = "Aria Jose",
                                    FullName = "AriaJose",
                                    Email = "ariajose@abc.com",
                                    Department = "UI/UX",
                                    JobTitle = "UseCaseEmployee",
                                    Location = "Greece",
                                    JoinDate = new DateTime(2018, 4, 23),
                                    Salary = 80000,
                                    Status = "Leave",
                                    Contact = "5551112233",
                                    LeaveCount = 9,
                                    LeaveAvailability = new LeaveAvailability { Casual = 3, Earned = 12, Sick = 12 },
                                    ProjectDetails = "Chat Bot",
                                    ProjectStatus = "Completed",
                                    Experience = 1,
                                    WorkMode = "Work From Office",
                                },
                                new UseCaseEmployee
                                {
                                    ID = "EMP013",
                                    EmployeeName = "Margaret Peacock",
                                    FullName = "MargaretPeacock",
                                    Email = "margaretpeacock@abc.com",
                                    Department = "UI/UX",
                                    JobTitle = "UseCaseEmployee",
                                    Location = "Germany",
                                    JoinDate = new DateTime(2018, 4, 23),
                                    Salary = 75000,
                                    Status = "Available",
                                    Contact = "5551112233",
                                    LeaveCount = 9,
                                    LeaveAvailability = new LeaveAvailability { Casual = 5, Earned = 10, Sick = 12 },
                                    ProjectDetails = "Chat Bot",
                                    ProjectStatus = "Completed",
                                    Experience = 3,
                                    WorkMode = "Work From Office",
                                },
                                new UseCaseEmployee
                                {
                                    ID = "EMP014",
                                    EmployeeName = "George Miller",
                                    FullName = "GeorgeMiller",
                                    Email = "georgemiller@abc.com",
                                    Department = "UI/UX",
                                    JobTitle = "UseCaseEmployee",
                                    Location = "Egypt",
                                    JoinDate = new DateTime(2020, 2, 10),
                                    Salary = 69000,
                                    Status = "Busy",
                                    Contact = "5557778899",
                                    LeaveCount = 18,
                                    LeaveAvailability = new LeaveAvailability { Casual = 12, Earned = 6, Sick = 0 },
                                    ProjectDetails = "Dashboard UI",
                                    ProjectStatus = "In Progress",
                                    Experience = 3,
                                    WorkMode = "Work From Office",
                                },
                                new UseCaseEmployee
                                {
                                    ID = "EMP015",
                                    EmployeeName = "Ken Adams",
                                    FullName = "KenAdams",
                                    Email = "kenadams@abc.com",
                                    Department = "UI/UX",
                                    JobTitle = "UseCaseEmployee",
                                    Location = "Canada",
                                    JoinDate = new DateTime(2016, 6, 15),
                                    Salary = 85000,
                                    Status = "Available",
                                    Contact = "5558889900",
                                    LeaveCount = 6,
                                    LeaveAvailability = new LeaveAvailability { Casual = 9, Earned = 10, Sick = 11 },
                                    ProjectDetails = "Dashboard UI",
                                    ProjectStatus = "Completed",
                                    Experience = 4,
                                    WorkMode = "Work From Office",
                                },
                                new UseCaseEmployee
                                {
                                    ID = "EMP016",
                                    EmployeeName = "Nancy Davolio",
                                    FullName = "NancyDavolio",
                                    Email = "nancydavolio@abc.com",
                                    Department = "UI/UX",
                                    JobTitle = "UseCaseEmployee",
                                    Location = "USA",
                                    JoinDate = new DateTime(2018, 12, 3),
                                    Salary = 74000,
                                    Status = "Available",
                                    Contact = "5559990011",
                                    LeaveCount = 2,
                                    LeaveAvailability = new LeaveAvailability { Casual = 12, Earned = 10, Sick = 12 },
                                    ProjectDetails = "Dashboard UI",
                                    ProjectStatus = "In Progress",
                                    Experience = 5,
                                    WorkMode = "Work From Office",
                                },
                                new UseCaseEmployee
                                {
                                    ID = "EMP017",
                                    EmployeeName = "Merlyn Lawrance",
                                    FullName = "MerlynLawrance",
                                    Email = "merlynlawrance@abc.com",
                                    Department = "UI/UX",
                                    JobTitle = "UseCaseEmployee",
                                    Location = "USA",
                                    JoinDate = new DateTime(2021, 3, 14),
                                    Salary = 70000,
                                    Status = "Busy",
                                    Contact = "5551122334",
                                    LeaveCount = 15,
                                    LeaveAvailability = new LeaveAvailability { Casual = 6, Earned = 8, Sick = 7 },
                                    ProjectDetails = "Dashboard UI",
                                    ProjectStatus = "In Progress",
                                    Experience = 2,
                                    WorkMode = "Work From office",
                                },
                            }
                        }
                    }
                },
                new UseCaseEmployee
                {
                    ID = "EMP018",
                    EmployeeName = "Michael Suyama",
                    FullName = "MichaelSuyama",
                    Email = "michaelsuyama@abc.com",
                    Department = "Documentation",
                    JobTitle = "Manager",
                    Location = "Canada",
                    JoinDate = new DateTime(2018, 4, 23),
                    Salary = 160000,
                    Status = "Available",
                    Contact = "5551112233",
                    LeaveCount = 10,
                    LeaveAvailability = new LeaveAvailability { Casual = 7, Earned = 11, Sick = 8 },
                    ProjectDetails = "Documentation Review",
                    ProjectStatus = "Completed",
                    Experience = 13,
                    WorkMode = "Work From Home",
                    Children = new List<UseCaseEmployee>
                    {
                        new UseCaseEmployee
                        {
                            ID = "EMP019",
                            EmployeeName = "Linda Belton",
                            FullName = "LindaBelton",
                            Email = "lindabelton@abc.com",
                            Department = "Documentation",
                            JobTitle = "Team Lead",
                            Location = "Egypt",
                            JoinDate = new DateTime(2018, 4, 23),
                            Salary = 110000,
                            Status = "Available",
                            Contact = "5551112233",
                            LeaveCount = 6,
                            LeaveAvailability = new LeaveAvailability { Casual = 6, Earned = 12, Sick = 12 },
                            ProjectDetails = "Blazor Documentation",
                            ProjectStatus = "Completed",
                            Experience = 8,
                            WorkMode = "Work From Home",
                            Children = new List<UseCaseEmployee>
                            {
                                new UseCaseEmployee
                                {
                                    ID = "EMP020",
                                    EmployeeName = "Henry Williams",
                                    FullName = "HenryWilliams",
                                    Email = "henrywilliams@abc.com",
                                    Department = "Documentation",
                                    JobTitle = "UseCaseEmployee",
                                    Location = "Greece",
                                    JoinDate = new DateTime(2018, 4, 23),
                                    Salary = 85000,
                                    Status = "Available",
                                    Contact = "5551112233",
                                    LeaveCount = 7,
                                    LeaveAvailability = new LeaveAvailability { Casual = 6, Earned = 11, Sick = 12 },
                                    ProjectDetails = "Blazor Documentation",
                                    ProjectStatus = "Completed",
                                    Experience = 3,
                                    WorkMode = "Work From Home",
                                },
                                new UseCaseEmployee
                                {
                                    ID = "EMP021",
                                    EmployeeName = "Olivia Adams",
                                    FullName = "OliviaAdams",
                                    Email = "oliviaadams@abc.com",
                                    Department = "Documentation",
                                    JobTitle = "UseCaseEmployee",
                                    Location = "USA",
                                    JoinDate = new DateTime(2018, 4, 23),
                                    Salary = 60000,
                                    Status = "Leave",
                                    Contact = "5551112233",
                                    LeaveCount = 14,
                                    LeaveAvailability = new LeaveAvailability { Casual = 12, Earned = 3, Sick = 7 },
                                    ProjectDetails = "Blazor Documentation",
                                    ProjectStatus = "Completed",
                                    Experience = 2,
                                    WorkMode = "Work From Home",
                                },
                                new UseCaseEmployee
                                {
                                    ID = "EMP022",
                                    EmployeeName = "Yvonne McKay",
                                    FullName = "YvonneMcKay",
                                    Email = "yvonnemcKay@abc.com",
                                    Department = "Documentation",
                                    JobTitle = "UseCaseEmployee",
                                    Location = "Greece",
                                    JoinDate = new DateTime(2019, 11, 9),
                                    Salary = 79000,
                                    Status = "Available",
                                    Contact = "5553344556",
                                    LeaveCount = 3,
                                    LeaveAvailability = new LeaveAvailability { Casual = 10, Earned = 11, Sick = 12 },
                                    ProjectDetails = "Typescript Documentation",
                                    ProjectStatus = "Completed",
                                    Experience = 4,
                                    WorkMode = "Hybrid",
                                },
                                new UseCaseEmployee
                                {
                                    ID = "EMP023",
                                    EmployeeName = "Tedd Lawson",
                                    FullName = "TeddLawson",
                                    Email = "teddlawson@abc.com",
                                    Department = "Documentation",
                                    JobTitle = "UseCaseEmployee",
                                    Location = "USA",
                                    JoinDate = new DateTime(2015, 9, 21),
                                    Salary = 88000,
                                    Status = "Available",
                                    Contact = "5554455667",
                                    LeaveCount = 0,
                                    LeaveAvailability = new LeaveAvailability { Casual = 12, Earned = 12, Sick = 12 },
                                    ProjectDetails = "React Documentation",
                                    ProjectStatus = "Completed",
                                    Experience = 1,
                                    WorkMode = "Hybrid"
                                },

                                new UseCaseEmployee
                                {
                                    ID = "EMP024",
                                    EmployeeName = "Bobby Knight",
                                    FullName = "BobbyKnight",
                                    Email = "bobbyknight@abc.com",
                                    Department = "Documentation",
                                    JobTitle = "Employee",
                                    Location = "Germany",
                                    JoinDate = new DateTime(2020, 5, 5),
                                    Salary = 75000,
                                    Status = "Busy",
                                    Contact = "5555566778",
                                    LeaveCount = 9,
                                    LeaveAvailability = new LeaveAvailability { Casual = 9, Earned = 6, Sick = 12 },
                                    ProjectDetails = "Release Notes",
                                    ProjectStatus = "Completed",
                                    Experience = 2,
                                    WorkMode = "Hybrid"
                                },
                                new UseCaseEmployee
                                {
                                    ID = "EMP025",
                                    EmployeeName = "Scarlet Portman",
                                    FullName = "ScarletPortman",
                                    Email = "scarletportman@abc.com",
                                    Department = "Documentation",
                                    JobTitle = "Employee",
                                    Location = "Egypt",
                                    JoinDate = new DateTime(2018, 1, 20),
                                    Salary = 71000,
                                    Status = "Available",
                                    Contact = "5556677889",
                                    LeaveCount = 14,
                                    LeaveAvailability = new LeaveAvailability { Casual = 7, Earned = 3, Sick = 12 },
                                    ProjectDetails = "Release Notes",
                                    ProjectStatus = "Completed",
                                    Experience = 3,
                                    WorkMode = "Hybrid"
                                },
                                new UseCaseEmployee
                                {
                                    ID = "EMP026",
                                    EmployeeName = "Isabella Johnson",
                                    FullName = "IsabellaJohnson",
                                    Email = "isabellajohnson@abc.com",
                                    Department = "Network",
                                    JobTitle = "Manager",
                                    Location = "Canada",
                                    JoinDate = new DateTime(2018, 4, 23),
                                    Salary = 140000,
                                    Status = "Available",
                                    Contact = "5551112233",
                                    LeaveCount = 2,
                                    LeaveAvailability = new LeaveAvailability { Casual = 12, Earned = 10, Sick = 12 },
                                    ProjectDetails = "Intruder detection system",
                                    ProjectStatus = "Completed",
                                    Experience = 15,
                                    WorkMode = "Work From Office",
                                    Children = new List<UseCaseEmployee>
                                    {
                                        new UseCaseEmployee
                                        {
                                            ID = "EMP027",
                                            EmployeeName = "Nathan Drake",
                                            FullName = "NathanDrake",
                                            Email = "nathandrake@abc.com",
                                            Department = "Network",
                                            JobTitle = "Team Lead",
                                            Location = "Germany",
                                            JoinDate = new DateTime(2018, 4, 23),
                                            Salary = 105000,
                                            Status = "Leave",
                                            Contact = "5551112233",
                                            LeaveCount = 10,
                                            LeaveAvailability = new LeaveAvailability { Casual = 11, Earned = 7, Sick = 8 },
                                            ProjectDetails = "Intruder detection system",
                                            ProjectStatus = "Completed",
                                            Experience = 7,
                                            WorkMode = "Work From Office",
                                            Children = new List<UseCaseEmployee>
                                            {
                                                new UseCaseEmployee
                                                {
                                                    ID = "EMP028",
                                                    EmployeeName = "Sherly Hathaway",
                                                    FullName = "SherlyHathaway",
                                                    Email = "sherlyhathaway@abc.com",
                                                    Department = "Network",
                                                    JobTitle = "Employee",
                                                    Location = "Canada",
                                                    JoinDate = new DateTime(2018, 4, 23),
                                                    Salary = 70000,
                                                    Status = "Available",
                                                    Contact = "5551112233",
                                                    LeaveCount = 0,
                                                    LeaveAvailability = new LeaveAvailability { Casual = 12, Earned = 12, Sick = 12 },
                                                    ProjectDetails = "Intruder detection system",
                                                    ProjectStatus = "Completed",
                                                    Experience = 1,
                                                    WorkMode = "Work From Office"
                                                },
                                                new UseCaseEmployee
                                                {
                                                    ID = "EMP029",
                                                    EmployeeName = "Neil Kepler",
                                                    FullName = "NeilKepler",
                                                    Email = "neilkepler@abc.com",
                                                    Department = "Network",
                                                    JobTitle = "Employee",
                                                    Location = "Greece",
                                                    JoinDate = new DateTime(2018, 4, 23),
                                                    Salary = 80000,
                                                    Status = "Available",
                                                    Contact = "5551112233",
                                                    LeaveCount = 5,
                                                    LeaveAvailability = new LeaveAvailability { Casual = 12, Earned = 7, Sick = 12 },
                                                    ProjectDetails = "Firewall Configuration",
                                                    ProjectStatus = "Completed",
                                                    Experience = 2,
                                                    WorkMode = "Work From Office"
                                                },
                                                new UseCaseEmployee
                                                {
                                                    ID = "EMP030",
                                                    EmployeeName = "Ivy walker",
                                                    FullName = "Ivywalker",
                                                    Email = "ivywalker@abc.com",
                                                    Department = "Network",
                                                    JobTitle = "Employee",
                                                    Location = "USA",
                                                    JoinDate = new DateTime(2022, 2, 11),
                                                    Salary = 67000,
                                                    Status = "Busy",
                                                    Contact = "5557788990",
                                                    LeaveCount = 3,
                                                    LeaveAvailability = new LeaveAvailability { Casual = 12, Earned = 12, Sick = 9 },
                                                    ProjectDetails = "Firewall Configuration",
                                                    ProjectStatus = "In Progress",
                                                    Experience = 1,
                                                    WorkMode = "Work From Office"
                                                },
                                                new UseCaseEmployee
                                                {
                                                    ID = "EMP031",
                                                    EmployeeName = "Richard Roe",
                                                    FullName = "RichardRoe",
                                                    Email = "richardroe@abc.com",
                                                    Department = "Network",
                                                    JobTitle = "Employee",
                                                    Location = "Canada",
                                                    JoinDate = new DateTime(2020, 8, 25),
                                                    Salary = 76000,
                                                    Status = "Available",
                                                    Contact = "5558899001",
                                                    LeaveCount = 1,
                                                    LeaveAvailability = new LeaveAvailability { Casual = 12, Earned = 11, Sick = 12 },
                                                    ProjectDetails = "Firewall Configuration",
                                                    ProjectStatus = "Completed",
                                                    Experience = 2,
                                                    WorkMode = "Work From Office"
                                                },
                                                new UseCaseEmployee
                                                {
                                                    ID = "EMP032",
                                                    EmployeeName = "Chris Mathew",
                                                    FullName = "ChrisMathew",
                                                    Email = "chrismathew@abc.com",
                                                    Department = "Network",
                                                    JobTitle = "Employee",
                                                    Location = "Greece",
                                                    JoinDate = new DateTime(2021, 12, 7),
                                                    Salary = 73000,
                                                    Status = "Busy",
                                                    Contact = "5559900112",
                                                    LeaveCount = 8,
                                                    LeaveAvailability = new LeaveAvailability { Casual = 4, Earned = 12, Sick = 12 },
                                                    ProjectDetails = "Network Topology Mapping",
                                                    ProjectStatus = "In Progress",
                                                    Experience = 3,
                                                    WorkMode = "Work From Office"
                                                },
                                                new UseCaseEmployee
                                                {
                                                    ID = "EMP033",
                                                    EmployeeName = "Sara Callagen",
                                                    FullName = "SaraCallagen",
                                                    Email = "saracallagen@abc.com",
                                                    Department = "Network",
                                                    JobTitle = "Employee",
                                                    Location = "Germany",
                                                    JoinDate = new DateTime(2017, 3, 16),
                                                    Salary = 80000,
                                                    Status = "Available",
                                                    Contact = "5550011223",
                                                    LeaveCount = 7,
                                                    LeaveAvailability = new LeaveAvailability { Casual = 6, Earned = 11, Sick = 12 },
                                                    ProjectDetails = "Network Topology Mapping",
                                                    ProjectStatus = "Completed",
                                                    Experience = 1,
                                                    WorkMode = "Work From Office"
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                    },
                    
                }
                
            };
        }
    }
}
