#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.ListView;

public class CallHistory : PageModel
{
    public List<object> listdata = new List<object>();
    public void OnGet()
    {
        listdata.Add(new { text = "Smith", id = "received-01", icon = "e-custom", type = "received", group = "Received", time = "2 hours ago", category = "Today" });
        listdata.Add(new { text = "Johnson", id = "received-02", icon = "e-custom", type = "received", group = "Received", time = "Yesterday", category = "Yesterday" });
        listdata.Add(new { text = "Williams", id = "missed-01", icon = "e-custom", type = "missed", group = "Missed", time = "4 hours ago", category = "Today" });
        listdata.Add(new { text = "Jones", id = "missed-02", icon = "e-custom", type = "missed", group = "Missed", time = "Yesterday", category = "Yesterday" });
        listdata.Add(new { text = "Brown", id = "received-03", icon = "e-custom", type = "received", group = "Received", time = "Yesterday", category = "Yesterday" });
        listdata.Add(new { text = "Anderson", id = "received-01", icon = "e-custom", type = "received", group = "Received", time = "12 hours ago", category = "Today" });
        listdata.Add(new { text = "Thomas", id = "received-02", icon = "e-custom", type = "received", group = "Received", time = "Yesterday", category = "Yesterday" });
        listdata.Add(new { text = "Jackson", id = "missed-01", icon = "e-custom", type = "missed", group = "Missed", time = "Yesterday", category = "Yesterday" });
        listdata.Add(new { text = "Emily", id = "missed-01", icon = "e-custom", type = "missed", group = "Missed", time = "14 hours ago", category = "Today" });
        listdata.Add(new { text = "White", id = "missed-02", icon = "e-custom", type = "missed", group = "Missed", time = "Yesterday", category = "Yesterday" });
        listdata.Add(new { text = "Jones", id = "missed-02", icon = "e-custom", type = "missed", group = "Missed", time = "18 hours ago", category = "Today" });
        listdata.Add(new { text = "Grace", id = "missed-02", icon = "e-custom", type = "missed", group = "Missed", time = "Yesterday", category = "Yesterday" });
        listdata.Add(new { text = "Brooklyn", id = "missed-02", icon = "e-custom", type = "missed", group = "Missed", time = "Yesterday", category = "Yesterday" });
        listdata.Add(new { text = "Arianna", id = "received-01", icon = "e-custom", type = "received", group = "Received", time = "Yesterday", category = "Yesterday" });
        listdata.Add(new { text = "Katherine", id = "received-02", icon = "e-custom", type = "received", group = "Received", time = "Yesterday", category = "Yesterday" });
    }
}