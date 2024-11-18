#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Kanban;

public class Sorting : PageModel
{
    public List<sortData> sortData = new List<sortData>();
    public void OnGet()
    {
        sortData.Add(new sortData { Id = "DataSourceOrder", Sort = "Data Source Order" });
        sortData.Add(new sortData { Id = "Index", Sort = "Index" });
        sortData.Add(new sortData { Id = "Custom", Sort = "Custom" });
    }
}

public class sortData
{
    public string Id { get; set; }
    public string Sort { get; set; }
}