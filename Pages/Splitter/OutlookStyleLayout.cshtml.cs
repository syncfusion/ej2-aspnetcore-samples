#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Splitter;

public class OutlookStyleLayout : PageModel
{
    public List<object> data = new List<object>();
    public List<object> listdata = new List<object>();
    public void OnGet()
    {
        data.Add(new { id = 1, name = "Favorites", hasChild = true });
        data.Add(new { id = 2, pid = 1, name = "Sales Reports", count = "4" });
        data.Add(new { id = 3, pid = 1, name = "Sent Items" });
        data.Add(new { id = 4, pid = 1, name = "Marketing Reports", count = "6" });
        data.Add(new { id = 5, name = "Andrew Fuller", hasChild = true, expanded = true });
        data.Add(new { id = 6, pid = 5, name = "Inbox", selected = true, count = "20" });
        data.Add(new { id = 7, pid = 5, name = "Drafts", count = "5" });
        data.Add(new { id = 8, pid = 5, name = "Deleted Items" });
        data.Add(new { id = 9, pid = 5, name = "Sent Items" });
        data.Add(new { id = 10, pid = 5, name = "Sales Reports", count = "4" });
        data.Add(new { id = 11, pid = 5, name = "Marketing Reports", count = "6" });
        data.Add(new { id = 12, pid = 5, name = "Outbox" });
        data.Add(new { id = 13, pid = 5, name = "Junk Email" });
        data.Add(new { id = 14, pid = 5, name = "RSS Feed" });
        data.Add(new { id = 15, pid = 5, name = "Trash" });
        
        
        listdata.Add(new { Name = "Selma Tally", Content1 = "Apology marketing email", Content2 = "Hello Ananya Singleton", Id = "1", Order = 0 });
        listdata.Add(new { Name = "Illa Russo", Content1 = "Annual conference", Content2 = "Hi jeani Moresa", Id = "4", Order = 0 });
        listdata.Add(new { Name = "Camden Macmellon", Content1 = "Reference request- Camden hester", Content2 = "Hello Kerry Best", Id = "3", Order = 0 });
        listdata.Add(new { Name = "Garth Owen", Content1 = "Application for job Title", Content2 = "Hello Illa Russo", Id = "2", Order = 0 });
        listdata.Add(new { Name = "Ursula Patterson", Content1 = "Programmaer Position Applicant", Content2 = "Hello Kerry best", Id = "5", Order = 0 });
    }
}