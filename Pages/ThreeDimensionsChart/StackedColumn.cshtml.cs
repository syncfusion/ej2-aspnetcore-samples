#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.ThreeDimensionsChart;

public class StackedColumnModel : PageModel
{
    public List<StackedColumnChartData> ChartPoints { get; set; }
    public void OnGet()
    {
        ChartPoints = new List<StackedColumnChartData>
        {
            new StackedColumnChartData { X = "2018",  Y = 24.5, Y1 = 6.2,  Y2 = 24.5, Y3 = 15.4 },
            new StackedColumnChartData { X = "2019",  Y = 25.6, Y1 = 15.6, Y2 = 23.2, Y3 = 21.1 },
            new StackedColumnChartData { X = "2020",  Y = 29,   Y1 = 14.3, Y2 = 20.4, Y3 = 13.9 },
            new StackedColumnChartData { X = "2021",  Y = 28.5, Y1 = 9.3,  Y2 = 23.2, Y3 = 11.6 },
            new StackedColumnChartData { X = "2022",  Y = 30.6, Y1 = 7.8,  Y2 = 24.5, Y3 = 14.4 }
        };
    }
}
public class StackedColumnChartData
{
    public string X;
    public double Y;
    public double Y1;
    public double Y2;
    public double Y3;
}