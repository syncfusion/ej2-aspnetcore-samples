#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class GridOverviewModel : PageModel
{
    public List<object> DataRange { get; set; }
    public void OnGet()
    {
        DataRange = new List<object>();
        DataRange.Add(new { Text = "1,000 Rows 11 Columns", Value = "1000" });
        DataRange.Add(new { Text = "10,000 Rows 11 Columns", Value = "10000" });
        DataRange.Add(new { Text = "1,00,000 Rows 11 Columns", Value = "100000" });
    }
}