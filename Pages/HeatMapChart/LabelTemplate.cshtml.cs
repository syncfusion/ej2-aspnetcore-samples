#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.HeatMapChart;

public class LabelTemplate : PageModel
{
    public List<HeatmapDatasourceLabel> data = new List<HeatmapDatasourceLabel>();
    public void OnGet()
    {
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Improbable", ColumnId = "Negligible", Value = "2",
            Image = "../styles/Images/heatmap/green-cross.png"
        });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Improbable", ColumnId = "Low", Value = "4", Image = "../styles/Images/heatmap/green-cross.png"
        });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Improbable", ColumnId = "Moderate", Value = "6", Image = "../styles/Images/heatmap/green-cross.png"
        });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Improbable", ColumnId = "Significant", Value = "8",
            Image = "../styles/Images/heatmap/green-cross.png"
        });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Improbable", ColumnId = "Catastrophic", Value = "10",
            Image = "../styles/Images/heatmap/green-cross.png"
        });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Remote", ColumnId = "Negligible", Value = "4", Image = "../styles/Images/heatmap/green-cross.png"
        });
        data.Add(new HeatmapDatasourceLabel
            { RowId = "Remote", ColumnId = "Low", Value = "16", Image = "../styles/Images/heatmap/green-cross.png" });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Remote", ColumnId = "Moderate", Value = "24", Image = "../styles/Images/heatmap/orange-tick.png"
        });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Remote", ColumnId = "Significant", Value = "32", Image = "../styles/Images/heatmap/orange-tick.png"
        });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Remote", ColumnId = "Catastrophic", Value = "40",
            Image = "../styles/Images/heatmap/orange-tick.png"
        });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Occasional", ColumnId = "Negligible", Value = "6",
            Image = "../styles/Images/heatmap/green-cross.png"
        });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Occasional", ColumnId = "Low", Value = "24", Image = "../styles/Images/heatmap/orange-tick.png"
        });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Occasional", ColumnId = "Moderate", Value = "36",
            Image = "../styles/Images/heatmap/orange-tick.png"
        });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Occasional", ColumnId = "Significant", Value = "48",
            Image = "../styles/Images/heatmap/red-tick.png"
        });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Occasional", ColumnId = "Catastrophic", Value = "60",
            Image = "../styles/Images/heatmap/red-tick.png"
        });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Probable", ColumnId = "Negligible", Value = "8", Image = "../styles/Images/heatmap/green-cross.png"
        });
        data.Add(new HeatmapDatasourceLabel
            { RowId = "Probable", ColumnId = "Low", Value = "32", Image = "../styles/Images/heatmap/orange-tick.png" });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Probable", ColumnId = "Moderate", Value = "48", Image = "../styles/Images/heatmap/red-tick.png"
        });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Probable", ColumnId = "Significant", Value = "64", Image = "../styles/Images/heatmap/red-tick.png"
        });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Probable", ColumnId = "Catastrophic", Value = "80", Image = "../styles/Images/heatmap/red-tick.png"
        });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Frequent", ColumnId = "Negligible", Value = "10",
            Image = "../styles/Images/heatmap/green-cross.png"
        });
        data.Add(new HeatmapDatasourceLabel
            { RowId = "Frequent", ColumnId = "Low", Value = "40", Image = "../styles/Images/heatmap/orange-tick.png" });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Frequent", ColumnId = "Moderate", Value = "60", Image = "../styles/Images/heatmap/red-tick.png"
        });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Frequent", ColumnId = "Significant", Value = "80", Image = "../styles/Images/heatmap/red-tick.png"
        });
        data.Add(new HeatmapDatasourceLabel
        {
            RowId = "Frequent", ColumnId = "Catastrophic", Value = "100",
            Image = "../styles/Images/heatmap/red-tick.png"
        });
    }
}

public class HeatmapDatasourceLabel
{
    public string RowId { get; set; }
    public string ColumnId { get; set; }
    public string Value { get; set; }
    public string Image { get; set; }
}