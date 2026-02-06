#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.PivotTable;

public class Exporting : PageModel
{
    public List<ExportDropDownData> exportData = new List<ExportDropDownData>();
    public void OnGet()
    {
        exportData.Add(new ExportDropDownData { Name = "Excel", Value = "excel" });
        exportData.Add(new ExportDropDownData { Name = "CSV", Value = "csv" });
        exportData.Add(new ExportDropDownData { Name = "PDF", Value = "pdf" });
    }
}
public class ExportDropDownData
{
    public string Name { get; set; }
    public string Value { get; set; }
}