#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class GroupByDate : PageModel
{
    public List<ResourceDataSourceModel> owners = new List<ResourceDataSourceModel>();
    public void OnGet()
    {
        owners.Add(new ResourceDataSourceModel { text = "Alice", id = 1, color = "#df5286", workDays = new List<int> { 1, 2, 3, 4 } });
        owners.Add(new ResourceDataSourceModel { text = "Smith", id = 2, color = "#7fa900", workDays = new List<int> { 2, 3, 5 } });
    }
}