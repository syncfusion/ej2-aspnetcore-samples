#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser_NET8.Pages.Schedule;

public class GroupEditing : PageModel
{
    public List<ResourceDataSourceModel> conferences = new List<ResourceDataSourceModel>();
    public void OnGet()
    {
        conferences.Add(new ResourceDataSourceModel { text = "Margaret", id = 1, color = "#1aaa55" });
        conferences.Add(new ResourceDataSourceModel { text = "Robert", id = 2, color = "#357cd2" });
        conferences.Add(new ResourceDataSourceModel { text = "Laura", id = 3, color = "#7fa900" });
    }
}