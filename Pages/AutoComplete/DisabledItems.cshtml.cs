#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.AutoComplete;

public class DisabledItems : PageModel
{
    public List<StatusData> status = new List<StatusData>();
    public void OnGet()
    {
        status.Add(new StatusData() { Status = "Open", State= false });
        status.Add(new StatusData() { Status = "Waiting for Customer", State= false });
        status.Add(new StatusData() { Status = "On Hold", State= true });
        status.Add(new StatusData() { Status = "Follow-up", State= false });
        status.Add(new StatusData() { Status = "Closed", State= true });
        status.Add(new StatusData() { Status = "Solved", State= false });
        status.Add(new StatusData() { Status = "Fetaure Request", State= false });
    }
}
public class StatusData
{
    public string Status { get; set; }
    public bool State { get; set; }
}