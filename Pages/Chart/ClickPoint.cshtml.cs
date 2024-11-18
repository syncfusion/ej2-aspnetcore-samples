#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart;

public class ClickPoint : PageModel
{
    public List<ClickPointChartData> ChartPoints = new List<ClickPointChartData>();
    public void OnGet()
    {
        ChartPoints.Add(new ClickPointChartData { X = 20, Y = 20 });
        ChartPoints.Add(new ClickPointChartData { X = 80, Y = 80 });
    }
}
public class ClickPointChartData
{
    public double X;
    public double Y;
}