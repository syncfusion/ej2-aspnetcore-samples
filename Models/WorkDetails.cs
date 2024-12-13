#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
    public class WorkDetails
    {
        public string Name { get; set; }
        public DateTime YearOfJoining { get; set; }
        public string Status { get; set; }
        public int Experience { get; set; }
        public string Location { get; set; }

        public List<WorkDetails> GetAllRecords()
        {
            List<WorkDetails> work = new List<WorkDetails>();
            work.Add(new WorkDetails { Name = "John Smith", YearOfJoining = new DateTime(2020, 01, 15), Status = "Active", Experience = 4, Location = "New York" });
            work.Add(new WorkDetails { Name = "John Doe", YearOfJoining = new DateTime(2019, 05, 22), Status = "In Active", Experience = 5, Location = "San Francisco" });
            work.Add(new WorkDetails { Name = "Alice Brown", YearOfJoining = new DateTime(2021, 07, 30), Status = "Active", Experience = 4, Location = "Chicago" });
            work.Add(new WorkDetails { Name = "Robert White", YearOfJoining = new DateTime(2018, 11, 10), Status = "Active", Experience = 4, Location = "Boston" });
            work.Add(new WorkDetails { Name = "Emma Black", YearOfJoining = new DateTime(2022, 03, 05), Status = "In Active", Experience = 4, Location = "Seattle" });
            work.Add(new WorkDetails { Name = "Michael Green", YearOfJoining = new DateTime(2020, 08, 19), Status = "Active", Experience = 4, Location = "New York" });
            work.Add(new WorkDetails { Name = "Linda Blue", YearOfJoining = new DateTime(2017, 12, 12), Status = "Active", Experience = 4, Location = "San Francisco" });
            work.Add(new WorkDetails { Name = "Steve Grey", YearOfJoining = new DateTime(2019, 09, 25), Status = "Active", Experience = 4, Location = "Chicago" });
            work.Add(new WorkDetails { Name = "Natalie Gold", YearOfJoining = new DateTime(2021, 06, 17), Status = "In Active", Experience = 4, Location = "Boston" });
            work.Add(new WorkDetails { Name = "Paul Red", YearOfJoining = new DateTime(2016, 04, 08), Status = "Active", Experience = 4, Location = "Seattle" });
            work.Add(new WorkDetails { Name = "Rachel Orange", YearOfJoining = new DateTime(2022, 01, 21), Status = "In Active", Experience = 4, Location = "New York" });
            work.Add(new WorkDetails { Name = "Eric Pink", YearOfJoining = new DateTime(2018, 10, 14), Status = "Active", Experience = 4, Location = "San Francisco" });
            work.Add(new WorkDetails { Name = "Jessica Violet", YearOfJoining = new DateTime(2021, 11, 11), Status = "Active", Experience = 4, Location = "Chicago" });
            work.Add(new WorkDetails { Name = "James Indigo", YearOfJoining = new DateTime(2019, 02, 19), Status = "Active", Experience = 4, Location = "Boston" });
            work.Add(new WorkDetails { Name = "Olivia Teal", YearOfJoining = new DateTime(2022, 06, 30), Status = "In Active", Experience = 4, Location = "Seattle" });
            return work;
        } 
    }
}