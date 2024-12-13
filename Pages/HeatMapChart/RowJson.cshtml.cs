#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.HeatMapChart;

public class RowJson : PageModel
{
    public List<heatmapDatasourceRow> data = new List<heatmapDatasourceRow>();
    public void OnGet()
    {
        data.Add(new heatmapDatasourceRow
            { Region = "USA", Year_2000 = 93, Year_2004 = 101, Year_2008 = 112, Year_2012 = 103, Year_2016 = 121 });
        data.Add(new heatmapDatasourceRow
            { Region = "GBR", Year_2000 = 28, Year_2004 = 30, Year_2008 = 49, Year_2012 = 65, Year_2016 = 67 });
        data.Add(new heatmapDatasourceRow
            { Region = "China", Year_2000 = 58, Year_2004 = 63, Year_2008 = 100, Year_2012 = 91, Year_2016 = 70 });
        data.Add(new heatmapDatasourceRow
            { Region = "Russia", Year_2000 = 89, Year_2004 = 90, Year_2008 = 60, Year_2012 = 69, Year_2016 = 55 });
        data.Add(new heatmapDatasourceRow
            { Region = "Germany", Year_2000 = 56, Year_2004 = 49, Year_2008 = 41, Year_2012 = 44, Year_2016 = 42 });
        data.Add(new heatmapDatasourceRow
            { Region = "Japan", Year_2000 = 18, Year_2004 = 37, Year_2008 = 25, Year_2012 = 38, Year_2016 = 41 });
        data.Add(new heatmapDatasourceRow
            { Region = "France", Year_2000 = 38, Year_2004 = 33, Year_2008 = 43, Year_2012 = 35, Year_2016 = 42 });
        data.Add(new heatmapDatasourceRow
            { Region = "KOR", Year_2000 = 28, Year_2004 = 30, Year_2008 = 32, Year_2012 = 30, Year_2016 = 21 });
        data.Add(new heatmapDatasourceRow
            { Region = "Italy", Year_2000 = 34, Year_2004 = 32, Year_2008 = 27, Year_2012 = 28, Year_2016 = 28 });
    }
}

public class heatmapDatasourceRow
{
    public string Region { get; set; }
    public int Year_2000 { get; set; }
    public int Year_2004 { get; set; }
    public int Year_2008 { get; set; }
    public int Year_2012 { get; set; }
    public int Year_2016 { get; set; }
}