#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class HorizontalWaterfallModel : PageModel
    {
        public List<HorizontalChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<HorizontalChartData>
            {
                new HorizontalChartData { X = "JAN",   Y = 55 },
                new HorizontalChartData { X = "MAR",   Y = 42 },
                new HorizontalChartData { X = "JUNE",  Y = -12 },
                new HorizontalChartData { X = "AUG",   Y = 40 },
                new HorizontalChartData { X = "OCT",   Y = -26 },
                new HorizontalChartData { X = "DEC",   Y = 45 },
                new HorizontalChartData { X = "2023" }
            };
        }
    }
    public class HorizontalChartData
    {
        public string X;
        public double Y;
    }
}
