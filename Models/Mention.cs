#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EJ2CoreSampleBrowser_NET6.Models
{
    public class SportsData
    {
        public string Name { get; set; }
        public string Eimg { get; set; }
        public string EmailId { get; set; }

        public List<SportsData> SportsList()
        {
            List<SportsData> mention = new List<SportsData>();
            mention.Add(new SportsData { Name = "Selma Rose", Eimg = "7", EmailId = "selma@gmail.com" });
            mention.Add(new SportsData { Name = "Russo Kay", Eimg = "8", EmailId = "russo@gmail.com" });
            mention.Add(new SportsData { Name = "Camden Kate", Eimg = "9", EmailId = "camden@gmail.com" });
            mention.Add(new SportsData { Name = "Garth", Eimg = "3", EmailId = "garth@gmail.com" });
            mention.Add(new SportsData { Name = "Ursula Ann", Eimg = "10", EmailId = "ursula@gmail.com" });
            mention.Add(new SportsData { Name = "Margaret", Eimg = "5", EmailId = "margaret@gmail.com" });
            mention.Add(new SportsData { Name = "Laura Grace", Eimg = "7", EmailId = "laura@gmail.com" });
            mention.Add(new SportsData { Name = "Robert", Eimg = "8", EmailId = "robert@gmail.com" });
            mention.Add(new SportsData { Name = "Michale", Eimg = "9", EmailId = "michale@gmail.com" });
            mention.Add(new SportsData { Name = "Andrew James", Eimg = "3", EmailId = "james@gmail.com" });
            mention.Add(new SportsData { Name = "William", Eimg = "7", EmailId = "william@gmail.com" });
            mention.Add(new SportsData { Name = "David", Eimg = "8", EmailId = "david@gmail.com" });
            mention.Add(new SportsData { Name = "Richard Rose", Eimg = "9", EmailId = "richard@gmail.com" });
            mention.Add(new SportsData { Name = "Joseph", Eimg = "10", EmailId = "joseph@gmail.com" });
            mention.Add(new SportsData { Name = "Thomas", Eimg = "4", EmailId = "thomas@gmail.com" });
            mention.Add(new SportsData { Name = "Charles Danny", Eimg = "5", EmailId = "charles@gmail.com" });
            mention.Add(new SportsData { Name = "Daniel", Eimg = "6", EmailId = "daniel@gmail.com" });
            mention.Add(new SportsData { Name = "Matthew", Eimg = "7", EmailId = "matthew@gmail.com" });
            mention.Add(new SportsData { Name = "Donald Krish", Eimg = "8", EmailId = "donald@gmail.com" });
            mention.Add(new SportsData { Name = "Paul", Eimg = "2", EmailId = "paul@gmail.com" });
            mention.Add(new SportsData { Name = "Kevin Paul", Eimg = "3", EmailId = "kevin@gmail.com" });
            return mention;
        }
    }

    public class ProjectsData
    {
        public string Id { get; set; }
        public string Value { get; set; }

        public List<ProjectsData> ProjectList()
        {
            List<ProjectsData> project = new List<ProjectsData>();
            project.Add(new ProjectsData { Id = "Project1", Value = "ERP" });
            project.Add(new ProjectsData { Id = "Project2", Value = "Help desk" });
            project.Add(new ProjectsData { Id = "Project3", Value = "Banking" });
            project.Add(new ProjectsData { Id = "Project4", Value = "Chat Box" });
            project.Add(new ProjectsData { Id = "Project5", Value = "Accounts" });
            return project;
        }
    }

    public class UseCostsData
    {
        public string Id { get; set; }
        public string Value { get; set; }

        public List<UseCostsData> CostList()
        {
            List<UseCostsData> usecost = new List<UseCostsData>();
            usecost.Add(new UseCostsData { Id = "Cost1", Value = "$1000" });
            usecost.Add(new UseCostsData { Id = "Cost2", Value = "$1500" });
            usecost.Add(new UseCostsData { Id = "Cost3", Value = "$3000" });
            usecost.Add(new UseCostsData { Id = "Cost4", Value = "$3250" });
            usecost.Add(new UseCostsData { Id = "Cost5", Value = "$5000" });
            return usecost;
        }
    }
    public class StatusData
    {
        public string Id { get; set; }
        public string Value { get; set; }

        public List<StatusData> StatusList()
        {
            List<StatusData> status = new List<StatusData>();
            status.Add(new StatusData { Id = "Status1", Value = "Open" });
            status.Add(new StatusData { Id = "Status2", Value = "In-progress" });
            status.Add(new StatusData { Id = "Status3", Value = "Hold" });
            status.Add(new StatusData { Id = "Status4", Value = "Closed" });
            return status;
        }
    }
}
 