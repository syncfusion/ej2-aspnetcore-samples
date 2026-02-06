#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeView
{
    public class TemplateModel : PageModel
    {
        public List<TreeViewTemplates> Emp = new List<TreeViewTemplates>();
        public void OnGet()
        {   
            Emp.Add(new TreeViewTemplates { Id = 1, Name = "Favorites", HasChild = true });
            Emp.Add(new TreeViewTemplates { Id = 2, Pid = 1, Name = "Sales Reports", Count = "4" });
            Emp.Add(new TreeViewTemplates { Id = 3, Pid = 1, Name = "Sent Items" });
            Emp.Add(new TreeViewTemplates { Id = 4, Pid = 1, Name = "Marketing Reports ", Count = "6" });
            Emp.Add(new TreeViewTemplates { Id = 5, Name = "My Folder", HasChild = true, Expanded = true });
            Emp.Add(new TreeViewTemplates { Id = 6, Pid = 5, Name = "Inbox", Selected = true, Count = "20" });
            Emp.Add(new TreeViewTemplates { Id = 7, Pid = 5, Name = "Drafts", Count = "5" });
            Emp.Add(new TreeViewTemplates { Id = 8, Pid = 5, Name = "Deleted Items" });
            Emp.Add(new TreeViewTemplates { Id = 9, Pid = 5, Name = "Sent Items" });
            Emp.Add(new TreeViewTemplates { Id = 11, Pid = 5, Name = "Sales Reports", Count = "4" });
            Emp.Add(new TreeViewTemplates { Id = 12, Pid = 5, Name = "Marketing Reports", Count = "6" });
            Emp.Add(new TreeViewTemplates { Id = 13, Pid = 5, Name = "Outbox" });
        }
    }
    public class TreeViewTemplates
    {
        public string Name { get; set; }
        public string Count { get; set; }
        public int Id { get; set; }
        public int Pid { get; set; }
        public bool HasChild { get; set; }
        public bool Expanded { get; set; }
        public bool Selected { get; set; }
    }
}
