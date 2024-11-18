#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class DefaultSelectionModel : PageModel
{
    public List<EmployeeView> DataSource { get; set; }
    public string[] type { get; set; }
    public string[] mode { get; set; }

    public void OnGet()
    {
        DataSource = EmployeeView.GetAllRecords();
        type = new string[] { "Single", "Multiple" };
        mode = new string[] { "Row", "Cell", "Both" };
    }
}