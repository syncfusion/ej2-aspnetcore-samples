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
    public class WorkersDetails
    {    
        public string Name { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }

        public List<WorkersDetails> GetAllRecords()
        {
            List<WorkersDetails> workers = new List<WorkersDetails>();
            workers.Add(new WorkersDetails { Name = "John Smith", Department = "HR", Position = "Manager", Status = "Active", Location = "New York" });
            workers.Add(new WorkersDetails { Name = "John Doe", Department = "IT", Position = "Developer", Status = "In Active", Location = "San Francisco" });
            workers.Add(new WorkersDetails { Name = "Alice Brown", Department = "Finance", Position = "Analyst", Status = "Active", Location = "Chicago" });
            workers.Add(new WorkersDetails { Name = "Robert", Department = "Marketing", Position = "Coordinator", Status = "Active", Location = "Boston" });
            workers.Add(new WorkersDetails { Name = "Emma Black", Department = "IT", Position = "SysAdmin", Status = "In Active", Location = "Seattle" });
            workers.Add(new WorkersDetails { Name = "Michael", Department = "HR", Position = "Recruiter", Status = "Active", Location = "New York" });
            workers.Add(new WorkersDetails { Name = "Linda Blue", Department = "Finance", Position = "Controller", Status = "Active", Location = "San Francisco" });
            workers.Add(new WorkersDetails { Name = "Steve Grey", Department = "Marketing", Position = "Specialist", Status = "Active", Location = "Chicago" });
            workers.Add(new WorkersDetails { Name = "Natalie", Department = "Sales", Position = "Executive", Status = "In Active", Location = "Boston" });
            workers.Add(new WorkersDetails { Name = "Paul Red", Department = "Sales", Position = "Assistant", Status = "Active", Location = "Seattle" });
            workers.Add(new WorkersDetails { Name = "Rachel", Department = "IT", Position = "Developer", Status = "In Active", Location = "New York" });
            workers.Add(new WorkersDetails { Name = "Eric Pink", Department = "Marketing", Position = "Analyst", Status = "Active", Location = "San Francisco" });
            workers.Add(new WorkersDetails { Name = "Jessica", Department = "HR", Position = "Assistant", Status = "Active", Location = "Chicago" });
            workers.Add(new WorkersDetails { Name = "James", Department = "Finance", Position = "Auditor", Status = "Active", Location = "Boston" });
            workers.Add(new WorkersDetails { Name = "Olivia Teal", Department = "Sales", Position = "Assistant", Status = "In Active", Location = "Seattle" });
            return workers;
        }
    }
}