#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart;

public class SplineUpdate : PageModel
{
    public List<SplineUpdateChartData> ChartPoints = new List<SplineUpdateChartData>();
    public void OnGet()
    {
        ChartPoints.Add(new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 3), Y = 42 });
        ChartPoints.Add(new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 5), Y = 52 });
        ChartPoints.Add(new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 7), Y = 83 });
        ChartPoints.Add(new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 9), Y = 75 });
        ChartPoints.Add(new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 11), Y = 35 });
        ChartPoints.Add(new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 13), Y = 85 });
        ChartPoints.Add(new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 15), Y = 78 });
        ChartPoints.Add(new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 17), Y = 29 });
        ChartPoints.Add(new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 19), Y = 62 });
        ChartPoints.Add(new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 21), Y = 95 });
        ChartPoints.Add(new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 23), Y = 32 });
        ChartPoints.Add(new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 25), Y = 76 });
        ChartPoints.Add(new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 27), Y = 83 });
        ChartPoints.Add(new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 29), Y = 53 });
        ChartPoints.Add(new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 31), Y = 32 });
        ChartPoints.Add(new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 33), Y = 75 });
    }
}
public class SplineUpdateChartData
{
    public DateTime X;
    public double Y;
}