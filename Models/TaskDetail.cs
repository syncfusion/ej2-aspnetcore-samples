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
using System.Web;

namespace EJ2CoreSampleBrowser.Models
{
    public class TaskDetail
    {
        public TaskDetail()
        {

        }
        public TaskDetail(string Id, string Title, string Status, string Summary, string Type, string Priority, string Tags , Double Estimate, Double Spent, string Assignee, int RankId)
        {
            this.Id = Id;
            this.Title = Title;
            this.Status = Status;
            this.Summary = Summary;
            this.Type = Type;
            this.Priority = Priority;
            this.Tags = Tags;
            this.Estimate = Estimate;
            this.Spent = Spent;
            this.Assignee = Assignee;
            this.RankId = RankId;

        }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Summary { get; set; }
        public string Type { get; set; }
        public string Priority { get; set; }
        public string Tags { get; set; }
        public Double Estimate { get; set; }
        public Double Spent { get; set; }
        public string Assignee { get; set; }
        public int RankId { get; set; }

        public static List<TaskDetail> GetAllRecords()
        {
            List<TaskDetail> task = new List<Models.TaskDetail>();
            task.Add(new TaskDetail { Id = "Task 1", Title = "Task  - 29001", Status = "Open", Summary = "Analyze the new requirements gathered from the customer.", Type = "Story", Priority = "Low", Tags = "Analyze,Customer", Estimate = 3.5, Spent = 2, Assignee = "John", RankId = 1 });
            task.Add(new TaskDetail { Id = "Task 2", Title = "Task  - 29002", Status = "InProgress", Summary = "Improve application performance", Type = "Improvement", Priority = "Normal", Tags = "Improvement", Estimate = 6, Spent = 12, Assignee = "Suyama", RankId = 1 });
            task.Add(new TaskDetail { Id = "Task 3", Title = "Task  - 29003", Status = "Open", Summary = "Arrange a web meeting with the customer to get new requirements.", Type = "Others", Priority = "Critical", Tags = "Meeting", Estimate = 5.5, Spent = 0, Assignee = "Janet", RankId = 2 });
            task.Add(new TaskDetail { Id = "Task 4", Title = "Task  - 29004", Status = "InProgress", Summary = "Fix the issues reported in the IE browser.", Type = "Bug", Priority = "Release Breaker", Tags = "IE", Estimate = 2.5, Spent = 1.5, Assignee = "Janet", RankId = 2 });
            task.Add(new TaskDetail { Id = "Task 5", Title = "Task  - 29005", Status = "InProgress", Summary = "Fix the issues reported by the customer.", Type = "Bug", Priority = "Low", Tags = "Customer", Estimate = 3.5, Spent = 4.5, Assignee = "Peacock", RankId = 1 });
            task.Add(new TaskDetail { Id = "Task 6", Title = "Task  - 29007", Status = "Testing", Summary = "Validate new requirements", Type = "Improvement", Priority = "Low", Tags = "Validation", Estimate = 1.5, Spent = 3.17, Assignee = "Fuller", RankId = 1 });
            task.Add(new TaskDetail { Id = "Task 7", Title = "Task  - 29009", Status = "InProgress", Summary = "Fix the issues reported in Safari browser.", Type = "Bug", Priority = "Release Breaker", Tags = "Fix,Safari", Estimate = 1.5, Spent = 0.25, Assignee = "John", RankId = 2 });
            task.Add(new TaskDetail { Id = "Task 8", Title = "Task  - 29010", Status = "Close", Summary = "Test the application in the IE browser.", Type = "Story", Priority = "Low", Tags = "Review,IE", Estimate = 5.5, Spent = 5.5, Assignee = "Leverling" });
            task.Add(new TaskDetail { Id = "Task 9", Title = "Task  - 29011", Status = "Close", Summary = "Validate the issues reported by the customer.", Type = "Story", Priority = "High", Tags = "Validation,Fix", Estimate = 1, Spent = 0.5, Assignee = "Buchanan", RankId = 1 });
            task.Add(new TaskDetail { Id = "Task 10", Title = "Task  - 29015", Status = "Open", Summary = "Show the retrieved data from the server in grid control.", Type = "Story", Priority = "High", Tags = "Database,SQL", Estimate = 5.5, Spent = 0, Assignee = "Leverling", RankId = 4 });
            task.Add(new TaskDetail { Id = "Task 11", Title = "Task  - 29016", Status = "InProgress", Summary = "Fix cannot open user’s default database SQL error.", Priority = "Critical", Type = "Bug", Tags = "Database,Sql2008", Estimate = 2.5, Spent = 3.75, Assignee = "Davolio", RankId = 4 });
            task.Add(new TaskDetail { Id = "Task 12", Title = "Task  - 29017", Status = "Testing", Summary = "Fix the issues reported in data binding.", Type = "Story", Priority = "Normal", Tags = "Databinding", Estimate = 3.5, Spent = 3.5, Assignee = "Janet", RankId = 4 });
            task.Add(new TaskDetail { Id = "Task 13", Title = "Task  - 29018", Status = "Close", Summary = "Analyze SQL server 2008 connection.", Type = "Story", Priority = "Release Breaker", Tags = "Grid,Sql", Estimate = 2, Spent = 4, Assignee = "Suyama", RankId = 4 });
            task.Add(new TaskDetail { Id = "Task 14", Title = "Task  - 29019", Status = "Validate", Summary = "Validate databinding issues.", Type = "Story", Priority = "Low", Tags = "Validation", Estimate = 1.5, Spent = 1.5, Assignee = "Leverling", RankId = 1 });
            task.Add(new TaskDetail { Id = "Task 15", Title = "Task  - 29020", Status = "Close", Summary = "Analyze grid control.", Type = "Story", Priority = "High", Tags = "Analyze", Estimate = 2.5, Spent = 5.5, Assignee = "Leverling", RankId = 5 });
            task.Add(new TaskDetail { Id = "Task 16", Title = "Task  - 29021", Status = "Close", Summary = "Stored procedure for initial data binding of the grid.", Type = "Others", Priority = "Release Breaker", Tags = "Databinding", Estimate = 1.5, Spent = 1.25, Assignee = "Robert", RankId = 6 });
            task.Add(new TaskDetail { Id = "Task 17", Title = "Task  - 29022", Status = "Close", Summary = "Analyze stored procedures.", Type = "Story", Priority = "Release Breaker", Tags = "Procedures", Estimate = 5.5, Spent = 6.5, Assignee = "Janet", RankId = 7 });
            task.Add(new TaskDetail { Id = "Task 18", Title = "Task  - 29023", Status = "InProgress", Summary = "Validate editing issues.", Type = "Story", Priority = "Critical", Tags = "Editing", Estimate = 1, Spent = 0.75, Assignee = "Davolio", RankId = 1 });
            task.Add(new TaskDetail { Id = "Task 19", Title = "Task  - 29024", Status = "Open", Summary = "Test editing functionality.", Type = "Story", Priority = "Normal", Tags = "Editing,Test", Estimate = 0.5, Spent = 0, Assignee = "Robert" });
            task.Add(new TaskDetail { Id = "Task 20", Title = "Task  - 29025", Status = "Open", Summary = "Enhance editing functionality.", Type = "Improvement", Priority = "Low", Tags = "Editing", Estimate = 3.5, Spent = 0, Assignee = "Suyama", RankId = 5 });
            task.Add(new TaskDetail { Id = "Task 21", Title = "Task  - 29026", Status = "Close", Summary = "Improve the performance of the editing functionality.", Type = "Epic", Priority = "High", Tags = "Performance", Estimate = 5.5, Spent = 7.5, Assignee = "John", RankId = 5 });
            task.Add(new TaskDetail { Id = "Task 22", Title = "Task  - 29027", Status = "InProgress", Summary = "Arrange web meeting with the customer to show editing demo.", Type = "Others", Priority = "High", Tags = "Meeting,Editing", Estimate = 6, Spent = 8, Assignee = "John", RankId = 6 });
            task.Add(new TaskDetail { Id = "Task 23", Title = "Task  - 29029", Status = "Close", Summary = "Fix the editing issues reported by the customer.", Type = "Bug", Priority = "Low", Tags = "Editing,Fix", Estimate = 4.5, Spent = 2, Assignee = "Peacock", RankId = 6 });
            task.Add(new TaskDetail { Id = "Task 24", Title = "Task  - 29030", Status = "Open", Summary = "Fix the issues reported by the customer.", Type = "Bug", Priority = "Critical", Tags = "Customer", Estimate = 1.5, Spent = 3, Assignee = "Buchanan", RankId = 1 });
            task.Add(new TaskDetail { Id = "Task 25", Title = "Task  - 29031", Status = "Open", Summary = "Fix the issues reported in Safari browser.", Type = "Bug", Priority = "Release Breaker", Tags = "Fix,Safari", Estimate = 5.5, Spent = 7, Assignee = "Fuller", RankId = 2 });
            task.Add(new TaskDetail { Id = "Task 26", Title = "Task  - 29032", Status = "InProgress", Summary = "Check Login page validation.", Type = "Story", Priority = "Release Breaker", Tags = "Testing", Estimate = 2.5, Spent = 2, Assignee = "Davolio", RankId = 3 });
            task.Add(new TaskDetail { Id = "Task 27", Title = "Task  - 29033", Status = "Testing", Summary = "Fix the issues reported in data binding.", Type = "Story", Priority = "Normal", Tags = "Databinding", Estimate = 6.5, Spent = 8, Assignee = "Janet", RankId = 4 });
            task.Add(new TaskDetail { Id = "Task 28", Title = "Task  - 29034", Status = "Open", Summary = "Test editing functionality.", Type = "Story", Priority = "Normal", Tags = "Editing,Test", Estimate = 4.5, Spent = 2, Assignee = "Peacock", RankId = 5 });
            task.Add(new TaskDetail { Id = "Task 29", Title = "Task  - 29035", Status = "InProgress", Summary = "Fix editing issues reported in Firefox.", Type = "Bug", Priority = "Critical", Tags = "Editing,Fix", Estimate = 4, Spent = 4, Assignee = "Robert", RankId = 7 });
            task.Add(new TaskDetail { Id = "Task 30", Title = "Task  - 29036", Status = "Close", Summary = "Test editing feature in the IE browser.", Type = "Story", Priority = "Normal", Tags = "Testing", Estimate = 4.5, Spent = 4, Assignee = "Fuller", RankId = 10 });
            return task;
        }
    }
}
