#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
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
    public class Employee
    {    
        public string Name { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public string Location { get; set; }
        public int Experience { get; set; }

        public List<Employee> GetAllRecords()
        {
            List<Employee> Employee = new List<Employee>();
             Employee.Add(new Employee  { Name = "Alice Johnson", Department = "Engineering", Role = "Software Engineer", Location = "New York", Experience = 5});
             Employee.Add(new Employee  { Name = "Bob Smith", Department = "Marketing", Role = "Marketing Manager", Location = "San Francisco", Experience = 7});
             Employee.Add(new Employee  { Name = "Catherine Lee", Department = "Finance", Role = "Financial Analyst", Location = "Chicago", Experience = 4});
             Employee.Add(new Employee  { Name = "David Kim", Department = "Engineering", Role = "DevOps Engineer", Location = "Austin", Experience = 6});
             Employee.Add(new Employee  { Name = "Eva Brown", Department = "Sales", Role = "Sales Executive", Location = "Boston", Experience = 3});
             Employee.Add(new Employee  { Name = "Frank White", Department = "Human Resources", Role = "HR Manager", Location = "Seattle", Experience = 8});
             Employee.Add(new Employee  { Name = "Grace Green", Department = "Design", Role = "UX Designer", Location = "Los Angeles", Experience = 5});
             Employee.Add(new Employee  { Name = "Hank Wilson", Department = "Engineering", Role = "Front-end Developer", Location = "Denver", Experience = 4});
            return Employee;
        }
    }
}