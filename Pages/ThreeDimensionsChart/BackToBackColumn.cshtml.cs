#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.ThreeDimensionsChart;

public class BackToBackColumnModel : PageModel
{
    public List<BackToBackColumnChartData> ChartPoints { get; set; }
    public void OnGet()
    {
       ChartPoints = new List<BackToBackColumnChartData>
        {
            new BackToBackColumnChartData { X = "Jamesh",  Y = 1, Y1 = 4, Y2 = 5, Y3 = 10, Text = "Total 10" },
            new BackToBackColumnChartData { X = "Michael", Y = 2, Y1 = 3, Y2 = 4, Y3 = 9,  Text = "Total 9"  },
            new BackToBackColumnChartData { X = "John",    Y = 2, Y1 = 4, Y2 = 5, Y3 = 11, Text = "Total 11" },
            new BackToBackColumnChartData { X = "Jack",    Y = 1, Y1 = 2, Y2 = 5, Y3 = 8,  Text = "Total 8"  },
            new BackToBackColumnChartData { X = "Lucas",   Y = 1, Y1 = 3, Y2 = 6, Y3 = 10, Text = "Total 10" }
        };
    }
}
public class BackToBackColumnChartData
{
    public string X;
    public double Y;
    public double Y1;
    public double Y2;
    public double Y3;
    public string Text;
}