#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.Chart
{
    public class TrackballModel : PageModel
    {
        public List<TrackballChartData> ChartData { get; set; }

        public void OnGet()
        {
            ChartData = new List<TrackballChartData>
            {
                new TrackballChartData { xValue = new DateTime(2000, 2, 11), yValue = 14, yValue1 = 39, yValue2 = 60 },
                new TrackballChartData { xValue = new DateTime(2000, 9, 4), yValue = 20, yValue1 = 30, yValue2 = 55 },
                new TrackballChartData { xValue = new DateTime(2001, 2, 11), yValue = 25, yValue1 = 28, yValue2 = 48 },
                new TrackballChartData { xValue = new DateTime(2001, 9, 16), yValue = 21, yValue1 = 35, yValue2 = 57 },
                new TrackballChartData { xValue = new DateTime(2002, 2, 7), yValue = 13, yValue1 = 39, yValue2 = 62 },
                new TrackballChartData { xValue = new DateTime(2002, 9, 7), yValue = 18, yValue1 = 41, yValue2 = 64 },
                new TrackballChartData { xValue = new DateTime(2003, 2, 11), yValue = 24, yValue1 = 45, yValue2 = 57 },
                new TrackballChartData { xValue = new DateTime(2003, 9, 14), yValue = 23, yValue1 = 48, yValue2 = 53 },
                new TrackballChartData { xValue = new DateTime(2004, 2, 6), yValue = 19, yValue1 = 54, yValue2 = 63 },
                new TrackballChartData { xValue = new DateTime(2004, 9, 6), yValue = 31, yValue1 = 55, yValue2 = 50 },
                new TrackballChartData { xValue = new DateTime(2005, 2, 11), yValue = 39, yValue1 = 57, yValue2 = 66 },
                new TrackballChartData { xValue = new DateTime(2005, 9, 11), yValue = 50, yValue1 = 60, yValue2 = 65 },
                new TrackballChartData { xValue = new DateTime(2006, 2, 11), yValue = 24, yValue1 = 60, yValue2 = 79 },
            };
        }
    }
    public class TrackballChartData
    {
        public DateTime xValue;
        public double yValue;
        public double yValue1;
        public double yValue2;
    }
}