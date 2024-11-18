#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.PivotTable;

public class Aggregation : PageModel
{
    public List<AggregationDropDownData> costData = new List<AggregationDropDownData>();
    public List<AggregationDropDownData> unitData = new List<AggregationDropDownData>();
    public void OnGet()
    {
        costData.Add(new AggregationDropDownData { Name = "Sum", Value = "Sum" });
        costData.Add(new AggregationDropDownData { Name = "Avg", Value = "Average" });
        costData.Add(new AggregationDropDownData { Name = "Median", Value = "Median" });
        costData.Add(new AggregationDropDownData { Name = "Min", Value = "Min" });
        costData.Add(new AggregationDropDownData { Name = "Max", Value = "Max" });
        costData.Add(new AggregationDropDownData { Name = "Product", Value = "Product" });
        costData.Add(new AggregationDropDownData { Name = "Index", Value = "Index" });
        costData.Add(new AggregationDropDownData { Name = "PopulationStDev", Value = "Population StDev" });
        costData.Add(new AggregationDropDownData { Name = "SampleStDev", Value = "Sample StDev" });
        costData.Add(new AggregationDropDownData { Name = "PopulationVar", Value = "Population Var" });
        costData.Add(new AggregationDropDownData { Name = "SampleVar", Value = "Sample Var" });
        costData.Add(new AggregationDropDownData { Name = "RunningTotals", Value = "Running Totals" });
        costData.Add(new AggregationDropDownData { Name = "DifferenceFrom", Value = "Difference From" });
        costData.Add(new AggregationDropDownData { Name = "PercentageOfDifferenceFrom", Value = "% of Difference From" });
        costData.Add(new AggregationDropDownData { Name = "PercentageOfGrandTotal", Value = "% of Grand Total" });
        costData.Add(new AggregationDropDownData { Name = "PercentageOfColumnTotal", Value = "% of Column Total" });
        costData.Add(new AggregationDropDownData { Name = "PercentageOfRowTotal", Value = "% of Row Total" });
        costData.Add(new AggregationDropDownData { Name = "PercentageOfParentTotal", Value = "% of Parent Total" });
        costData.Add(new AggregationDropDownData { Name = "PercentageOfParentColumnTotal", Value = "% of Parent Column Total" });
        costData.Add(new AggregationDropDownData { Name = "PercentageOfParentRowTotal", Value = "% of Parent Row Total" });
        
        unitData.Add(new AggregationDropDownData { Name = "Sum", Value = "Sum" });
        unitData.Add(new AggregationDropDownData { Name = "Avg", Value = "Average" });
        unitData.Add(new AggregationDropDownData { Name = "Median", Value = "Median" });
        unitData.Add(new AggregationDropDownData { Name = "Count", Value = "Count" });
        unitData.Add(new AggregationDropDownData { Name = "Min", Value = "Min" });
        unitData.Add(new AggregationDropDownData { Name = "Max", Value = "Max" });
        unitData.Add(new AggregationDropDownData { Name = "DistinctCount", Value = "Distinct Count" });
        unitData.Add(new AggregationDropDownData { Name = "Product", Value = "Product" });
        unitData.Add(new AggregationDropDownData { Name = "Index", Value = "Index" });
        unitData.Add(new AggregationDropDownData { Name = "PopulationStDev", Value = "Population StDev" });
        unitData.Add(new AggregationDropDownData { Name = "SampleStDev", Value = "Sample StDev" });
        unitData.Add(new AggregationDropDownData { Name = "PopulationVar", Value = "Population Var" });
        unitData.Add(new AggregationDropDownData { Name = "SampleVar", Value = "Sample Var" });
        unitData.Add(new AggregationDropDownData { Name = "RunningTotals", Value = "Running Totals" });
        unitData.Add(new AggregationDropDownData { Name = "DifferenceFrom", Value = "Difference From" });
        unitData.Add(new AggregationDropDownData { Name = "PercentageOfDifferenceFrom", Value = "% of Difference From" });
        unitData.Add(new AggregationDropDownData { Name = "PercentageOfGrandTotal", Value = "% of Grand Total" });
        unitData.Add(new AggregationDropDownData { Name = "PercentageOfColumnTotal", Value = "% of Column Total" });
        unitData.Add(new AggregationDropDownData { Name = "PercentageOfRowTotal", Value = "% of Row Total" });
        unitData.Add(new AggregationDropDownData { Name = "PercentageOfParentTotal", Value = "% of Parent Total" });
        unitData.Add(new AggregationDropDownData { Name = "PercentageOfParentColumnTotal", Value = "% of Parent Column Total" });
        unitData.Add(new AggregationDropDownData { Name = "PercentageOfParentRowTotal", Value = "% of Parent Row Total" });
    }
}
public class AggregationDropDownData
{
    public string Name { get; set; }
    public string Value { get; set; }
}