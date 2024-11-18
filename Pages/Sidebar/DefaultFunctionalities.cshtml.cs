#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Sidebar;

public class DefaultFunctionalities : PageModel
{
    public List<listData> InboxData = new List<listData>();

    public Dictionary<string, object> HtmlAttribute = new Dictionary<string, object>()
        { { "class", "default-sidebar" } };

    public List<TreeData> LocalData = new List<TreeData>();
    public void OnGet()
    {
        InboxData.Add(new listData
        {
            Id = "1", Text = "Albert Lives", Subject = "Business dinner invitation", Message = "Hello Uta Morgan,"
        });
        InboxData.Add(new listData
        {
            Id = "2", Text = "Ila Russo", Subject = "Opening for Sales Manager", Message = "Hello Jelani Moreno,"
        });
        InboxData.Add(new listData
        {
            Id = "3", Text = "Garth Owen", Subject = "Application for Job Title", Message = "Hello Ila Russo,"
        });
        InboxData.Add(new listData
        {
            Id = "4", Text = "Ursula Patterson", Subject = "Programmer Position Application",
            Message = "Hello Kerry Best,"
        });
        InboxData.Add(new listData
        {
            Id = "5", Text = "Nichole Rivas", Subject = "Annual Conference", Message = "Hi Igor Mccoy,"
        });
            
            
        LocalData.Add(new TreeData
        {
            Id = "1",
            Name = "Favorites",
            HasChild = true,
            Expanded = true
        });
        LocalData.Add(new TreeData
        {
            Id = "2",
            Pid = "1",
            Selected = true,
            Name = "Inbox",
        });
        LocalData.Add(new TreeData
        {
            Id = "3",
            Pid = "1",
            Name = "Sent Items"
        });
        LocalData.Add(new TreeData
        {
            Id = "5",
            HasChild = true,
            Name = "John",
            Expanded = true
        });
        LocalData.Add(new TreeData
        {
            Id = "6",
            Pid = "5",
            Name = "Inbox"
        });
        LocalData.Add(new TreeData
        {
            Id = "7",
            Pid = "5",
            Name = "Drafts",
        });
        LocalData.Add(new TreeData
        {
            Id = "8",
            Pid = "5",
            Name = "Deleted Items"
        });
        LocalData.Add(new TreeData
        {
            Id = "9",
            Pid = "5",
            Name = "Sent Items"
        });
        LocalData.Add(new TreeData
        {
            Id = "12",
            Pid = "5",
            Name = "Outbox"
        });
    }
}

public class listData
{
    public string Id { get; set; }
    public string Text { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}
public class TreeData
{
    public string Id { get; set; }
    public string Pid { get; set; }
    public string Name { get; set; }
    public bool HasChild { get; set; }
    public bool Expanded { get; set; }
    public bool Selected { get; set; }
}