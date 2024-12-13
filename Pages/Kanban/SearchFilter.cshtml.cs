#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Kanban;

public class SearchFilter : PageModel
{
    public List<statusData> data = new List<statusData>();
    public void OnGet()
    {
        data.Add(new statusData { Id = "None", Value = "None" });
        data.Add(new statusData { Id = "To Do", Value = "Open" });
        data.Add(new statusData { Id = "In Progress", Value = "InProgress" });
        data.Add(new statusData { Id = "Testing", Value = "Testing" });
        data.Add(new statusData { Id = "Done", Value = "Close" });
    }
}

public class statusData
{
    public string Id { get; set; }
    public string Value { get; set; }

}