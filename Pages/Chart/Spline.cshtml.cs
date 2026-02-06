#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class SplineModel : PageModel
    {
        public List<SplineChartData> SplineData { get; set; }

        public void OnGet()
        {
            SplineData = new List<SplineChartData>
            {
                new SplineChartData { Days = "Jan", MaxTemp = 41.02, AvgTemp = 31.89, MinTemp = 22.75},
                new SplineChartData { Days = "Feb", MaxTemp = 51.93, AvgTemp = 40.82, MinTemp = 29.71 },
                new SplineChartData { Days = "Mar", MaxTemp = 56.39, AvgTemp = 44.96, MinTemp = 33.53 },
                new SplineChartData { Days = "Apr", MaxTemp = 66.06, AvgTemp = 53.64, MinTemp = 41.22 },
                new SplineChartData { Days = "May", MaxTemp = 74.64, AvgTemp = 62.28, MinTemp = 49.87 },
                new SplineChartData { Days = "Jun", MaxTemp = 84.58, AvgTemp = 71.80, MinTemp = 59.02 },
                new SplineChartData { Days = "Jul", MaxTemp = 88.43, AvgTemp = 75.69, MinTemp = 62.94},
                new SplineChartData { Days = "Aug", MaxTemp = 86.72, AvgTemp = 73.99, MinTemp = 61.27},
                new SplineChartData { Days = "Sep", MaxTemp = 81.86, AvgTemp = 68.61, MinTemp = 55.36},
                new SplineChartData { Days = "Oct", MaxTemp = 73.13, AvgTemp = 58.95, MinTemp = 44.76},
                new SplineChartData { Days = "Nov", MaxTemp = 55.54, AvgTemp = 45.18, MinTemp = 34.79},
                new SplineChartData { Days = "Dec", MaxTemp = 48.36, AvgTemp = 38.21, MinTemp = 28.04},
            };
        }
    }
    public class SplineChartData
    {
        public string Days;
        public double MaxTemp;
        public double AvgTemp;
        public double MinTemp;
    }
}