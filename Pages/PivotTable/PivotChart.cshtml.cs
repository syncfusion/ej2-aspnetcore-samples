#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser_NET8.Pages.PivotTable;

public class PivotChart : PageModel
{
    public List<DropDownData> unitData = new List<DropDownData>();
    public void OnGet()
    {
        unitData.Add(new DropDownData { Name = "Line", Value = "Line" });
        unitData.Add(new DropDownData { Name = "Column", Value = "Column" });
        unitData.Add(new DropDownData { Name = "Bar", Value = "Bar" });
        unitData.Add(new DropDownData { Name = "Spline", Value = "Spline" });
        unitData.Add(new DropDownData { Name = "Area", Value = "Area" });
        unitData.Add(new DropDownData { Name = "SplineArea", Value = "SplineArea" });
        unitData.Add(new DropDownData { Name = "StepLine", Value = "StepLine" });
        unitData.Add(new DropDownData { Name = "StepArea", Value = "StepArea" });
        unitData.Add(new DropDownData { Name = "StackingColumn", Value = "StackingColumn" });
        unitData.Add(new DropDownData { Name = "StackingBar", Value = "StackingBar" });
        unitData.Add(new DropDownData { Name = "StackingArea", Value = "StackingArea" });
        unitData.Add(new DropDownData { Name = "StackingColumn100", Value = "StackingColumn100" });
        unitData.Add(new DropDownData { Name = "StackingBar100", Value = "StackingBar100" });
        unitData.Add(new DropDownData { Name = "StackingArea100", Value = "StackingArea100" });
        unitData.Add(new DropDownData { Name = "Scatter", Value = "Scatter" });
        unitData.Add(new DropDownData { Name = "Bubble", Value = "Bubble" });
        unitData.Add(new DropDownData { Name = "Pareto", Value = "Pareto" });
        unitData.Add(new DropDownData { Name = "Polar", Value = "Polar" });
        unitData.Add(new DropDownData { Name = "Radar", Value = "Radar" });
        unitData.Add(new DropDownData { Name = "Pie", Value = "Pie" });
        unitData.Add(new DropDownData { Name = "Doughnut", Value = "Doughnut" });
        unitData.Add(new DropDownData { Name = "Funnel", Value = "Funnel" });
        unitData.Add(new DropDownData { Name = "Pyramid", Value = "Pyramid" });
    }
}
public class DropDownData
{
    public string Name { get; set; }
    public string Value { get; set; }
}