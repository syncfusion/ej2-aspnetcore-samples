#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.ThreeDimensionsChart;

public class EmptyPointModel : PageModel
{
    public List<EmptyPointChartData> ChartPoints { get; set; }
    public void OnGet()
    {
        ChartPoints = new List<EmptyPointChartData>
        {
            new EmptyPointChartData { X = "Italy",        Y = 10 },
            new EmptyPointChartData { X = "Kenya",        Y = 4  },
            new EmptyPointChartData { X = "France",       Y = 10 },
            new EmptyPointChartData { X = "Hungary",      Y = 0  },
            new EmptyPointChartData { X = "Australia",    Y = 17 },
            new EmptyPointChartData { X = "Brazil",       Y = 7  },
            new EmptyPointChartData { X = "Netherlands",  Y = 10 },
            new EmptyPointChartData { X = "Unspecified",  Y = Double.NaN },
            new EmptyPointChartData { X = "Germany",      Y = 10 },
            new EmptyPointChartData { X = "Serbia",       Y = 3  }
        };
    }
}
public class EmptyPointChartData
{
    public string X;
    public double Y;
}