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
        public long PhoneNo { get; set; }
        public string Location { get; set; }

        public List<WorkersDetails> GetAllRecords()
        {
            List<WorkersDetails> workers = new List<WorkersDetails>();
            workers.Add(new WorkersDetails { Name = "John Smith", Department = "HR", Position = "Manager", PhoneNo = 7801234567, Location = "New York" });
            workers.Add(new WorkersDetails { Name = "John Doe", Department = "IT", Position = "Developer", PhoneNo = 7812345678, Location = "San Francisco" });
            workers.Add(new WorkersDetails { Name = "Alice Brown", Department = "Finance", Position = "Analyst", PhoneNo = 7823456789, Location = "Chicago" });
            workers.Add(new WorkersDetails { Name = "Robert", Department = "Marketing", Position = "Coordinator", PhoneNo = 7834567890, Location = "Boston" });
            workers.Add(new WorkersDetails { Name = "Emma Black", Department = "IT", Position = "SysAdmin", PhoneNo = 7845678901, Location = "Seattle" });
            workers.Add(new WorkersDetails { Name = "Michael", Department = "HR", Position = "Recruiter", PhoneNo = 7856789012, Location = "New York" });
            workers.Add(new WorkersDetails { Name = "Linda Blue", Department = "Finance", Position = "Controller", PhoneNo = 7878901234, Location = "San Francisco" });
            workers.Add(new WorkersDetails { Name = "Steve Grey", Department = "Marketing", Position = "Specialist", PhoneNo = 7889012345, Location = "Chicago" });
            workers.Add(new WorkersDetails { Name = "Natalie", Department = "Sales", Position = "Executive", PhoneNo = 7890123456, Location = "Boston" });
            workers.Add(new WorkersDetails { Name = "Paul Red", Department = "Sales", Position = "Assistant", PhoneNo = 7901234567, Location = "Seattle" });
            workers.Add(new WorkersDetails { Name = "Rachel", Department = "IT", Position = "Developer", PhoneNo = 7912345678, Location = "New York" });
            workers.Add(new WorkersDetails { Name = "Eric Pink", Department = "Marketing", Position = "Analyst", PhoneNo = 7923456789, Location = "San Francisco" });
            workers.Add(new WorkersDetails { Name = "Jessica", Department = "HR", Position = "Assistant", PhoneNo = 7801234567, Location = "Chicago" });
            workers.Add(new WorkersDetails { Name = "James", Department = "Finance", Position = "Auditor", PhoneNo = 7934567890, Location = "Boston" });
            workers.Add(new WorkersDetails { Name = "Olivia Teal", Department = "Sales", Position = "Assistant", PhoneNo = 7945678901, Location = "Seattle" });
            return workers;
        }
    }
}