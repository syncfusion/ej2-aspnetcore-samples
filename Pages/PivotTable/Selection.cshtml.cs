#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.PivotTable;

public class Selection : PageModel
{
    public List<DrillDownData> unitData = new List<DrillDownData>();
    public List<DropDownData> typeData = new List<DropDownData>();
    public void OnGet()
    {
        unitData.Add(new DrillDownData { Value = "Cell", Name = "Cell" });
        unitData.Add(new DrillDownData { Value = "Row", Name = "Row Only" });
        unitData.Add(new DrillDownData { Value = "Column", Name = "Column Only" });
        unitData.Add(new DrillDownData { Value = "Both", Name = "Both" });
        
        typeData.Add(new DropDownData { Name = "Single", Value = "Single" });
        typeData.Add(new DropDownData { Name = "Multiple", Value = "Multiple" });
    }
}
public class DrillDownData
{
    public string Name { get; set; }
    public string Value { get; set; }
}