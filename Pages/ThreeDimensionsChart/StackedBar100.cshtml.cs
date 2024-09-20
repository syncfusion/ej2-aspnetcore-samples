#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.ThreeDimensionsChart;

public class StackedBar100Model : PageModel
{
    public List<StackedBar100ChartData> ChartPoints { get; set; }
    public void OnGet()
    {
        ChartPoints = new List<StackedBar100ChartData>
        {
            new StackedBar100ChartData { X = "2013", Y = 9628912, Y1 = 4298390, Y2 = 2842133, Y3 = 2006366 },
            new StackedBar100ChartData { X = "2014", Y = 9609326, Y1 = 4513769, Y2 = 3016710, Y3 = 2165566 },
            new StackedBar100ChartData { X = "2015", Y = 7485587, Y1 = 4543838, Y2 = 3034081, Y3 = 2279503 },
            new StackedBar100ChartData { X = "2016", Y = 7793066, Y1 = 4999266, Y2 = 2945295, Y3 = 2359756 },
            new StackedBar100ChartData { X = "2017", Y = 6856880, Y1 = 5235842, Y2 = 3302336, Y3 = 2505741 }
        };
    }
}
public class StackedBar100ChartData
{
    public string X;
    public double Y;
    public double Y1;
    public double Y2;
    public double Y3;
}