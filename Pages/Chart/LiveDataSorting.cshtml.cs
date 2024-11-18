#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class LiveDataSortingModel : PageModel
    {
        public List<LiveChartData> ChartPoints { get; set; }
        public List<LiveChartData> ChartPoints2 { get; set; }
        public List<LiveChartData> ChartPoints3 { get; set; }
        public List<LiveChartData> ChartPoints4 { get; set; }
        public List<LiveChartData> ChartPoints5 { get; set; }
        public List<LiveChartData> ChartPoints6 { get; set; }
        public List<LiveChartData> ChartPoints7 { get; set; }
        public List<LiveChartData> ChartPoints8 { get; set; }
        public List<LiveChartData> ChartPoints9 { get; set; }
        public List<LiveChartData> ChartPoints10 { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<LiveChartData>
            {
                new LiveChartData { X = "India",          Y = 97.21 },
                new LiveChartData { X = "France",         Y = 95.21 },
                new LiveChartData { X = "Indonesia",      Y = 62.74 },
                new LiveChartData { X = "Iceland",        Y = 61.71 },
                new LiveChartData { X = "United States",  Y = 57.97 },
                new LiveChartData { X = "Greece",         Y = 57.51 },
                new LiveChartData { X = "Iran",           Y = 55.31 },
                new LiveChartData { X = "Canada",         Y = 48.76 },
                new LiveChartData { X = "Finland",        Y = 48.50 },
                new LiveChartData { X = "Brazil",         Y = 45.13 }
            };
            ChartPoints2 = new List<LiveChartData>
            {
                new LiveChartData { X = "India",          Y = 102.54 },
                new LiveChartData { X = "France",         Y = 90.76 },
                new LiveChartData { X = "Indonesia",      Y = 64.61 },
                new LiveChartData { X = "Iceland",        Y = 70.95 },
                new LiveChartData { X = "United States",  Y = 61.52 },
                new LiveChartData { X = "Greece",         Y = 49.03 },
                new LiveChartData { X = "Iran",           Y = 33.05 },
                new LiveChartData { X = "Canada",         Y = 59.83 },
                new LiveChartData { X = "Finland",        Y = 43.13 },
                new LiveChartData { X = "Brazil",         Y = 55.56 }
            };
            ChartPoints3 = new List<LiveChartData>
            {
                new LiveChartData { X = "India",          Y = 99.33 },
                new LiveChartData { X = "France",         Y = 94.50 },
                new LiveChartData { X = "Indonesia",      Y = 64.86 },
                new LiveChartData { X = "Iceland",        Y = 77.86 },
                new LiveChartData { X = "United States",  Y = 62.14 },
                new LiveChartData { X = "Greece",         Y = 47.73 },
                new LiveChartData { X = "Iran",           Y = 39.97 },
                new LiveChartData { X = "Canada",         Y = 66.53 },
                new LiveChartData { X = "Finland",        Y = 43.15 },
                new LiveChartData { X = "Brazil",         Y = 50.02 }
            };
            ChartPoints4 = new List<LiveChartData>
            {
                new LiveChartData { X = "India",          Y = 98.85 },
                new LiveChartData { X = "France",         Y = 101.11 },
                new LiveChartData { X = "Indonesia",      Y = 60.72 },
                new LiveChartData { X = "Iceland",        Y = 71.09 },
                new LiveChartData { X = "United States",  Y = 60.97 },
                new LiveChartData { X = "Greece",         Y = 52.07 },
                new LiveChartData { X = "Iran",           Y = 37.99 },
                new LiveChartData { X = "Canada",         Y = 58.35 },
                new LiveChartData { X = "Finland",        Y = 43.41 },
                new LiveChartData { X = "Brazil",         Y = 58.61 }
            };
            ChartPoints5 = new List<LiveChartData>
            {
                new LiveChartData { X = "India",          Y = 100.02 },
                new LiveChartData { X = "France",         Y = 100.55 },
                new LiveChartData { X = "Indonesia",      Y = 62.84 },
                new LiveChartData { X = "Iceland",        Y = 89.05 },
                new LiveChartData { X = "United States",  Y = 59.46 },
                new LiveChartData { X = "Greece",         Y = 54.04 },
                new LiveChartData { X = "Iran",           Y = 42.58 },
                new LiveChartData { X = "Canada",         Y = 59.90 },
                new LiveChartData { X = "Finland",        Y = 46.18 },
                new LiveChartData { X = "Brazil",         Y = 65.06 }
            };
            ChartPoints6 = new List<LiveChartData>
            {
                new LiveChartData { X = "India",          Y = 102.54 },
                new LiveChartData { X = "France",         Y = 103.56 },
                new LiveChartData { X = "Indonesia",      Y = 60.23 },
                new LiveChartData { X = "Iceland",        Y = 94.00 },
                new LiveChartData { X = "United States",  Y = 59.39 },
                new LiveChartData { X = "Greece",         Y = 50.11 },
                new LiveChartData { X = "Iran",           Y = 34.23 },
                new LiveChartData { X = "Canada",         Y = 60.40 },
                new LiveChartData { X = "Finland",        Y = 44.73 },
                new LiveChartData { X = "Brazil",         Y = 50.04 }
            };
            ChartPoints7 = new List<LiveChartData>
            {
                new LiveChartData { X = "India",          Y = 98.84 },
                new LiveChartData { X = "France",         Y = 101.95 },
                new LiveChartData { X = "Indonesia",      Y = 60.86 },
                new LiveChartData { X = "Iceland",        Y = 89.51 },
                new LiveChartData { X = "United States",  Y = 58.26 },
                new LiveChartData { X = "Greece",         Y = 53.20 },
                new LiveChartData { X = "Iran",           Y = 34.28 },
                new LiveChartData { X = "Canada",         Y = 57.22 },
                new LiveChartData { X = "Finland",        Y = 42.99 },
                new LiveChartData { X = "Brazil",         Y = 51.68 }
            };
            ChartPoints8 = new List<LiveChartData>
            {
                new LiveChartData { X = "India",          Y = 100.41 },
                new LiveChartData { X = "France",         Y = 108.54 },
                new LiveChartData { X = "Indonesia",      Y = 56.44 },
                new LiveChartData { X = "Iceland",        Y = 107.98 },
                new LiveChartData { X = "United States",  Y = 57.75 },
                new LiveChartData { X = "Greece",         Y = 56.34 },
                new LiveChartData { X = "Iran",           Y = 35.53 },
                new LiveChartData { X = "Canada",         Y = 57.49 },
                new LiveChartData { X = "Finland",        Y = 43.32 },
                new LiveChartData { X = "Brazil",         Y = 64.56 }
            };
            ChartPoints9 = new List<LiveChartData>
            {
                new LiveChartData { X = "India",          Y = 104.45 },
                new LiveChartData { X = "France",         Y = 102.07 },
                new LiveChartData { X = "Indonesia",      Y = 61.19 },
                new LiveChartData { X = "Iceland",        Y = 97.05 },
                new LiveChartData { X = "United States",  Y = 59.53 },
                new LiveChartData { X = "Greece",         Y = 55.61 },
                new LiveChartData { X = "Iran",           Y = 41.84 },
                new LiveChartData { X = "Canada",         Y = 64.13 },
                new LiveChartData { X = "Finland",        Y = 43.69 },
                new LiveChartData { X = "Brazil",         Y = 64.73 }
            };
            ChartPoints10 = new List<LiveChartData>
            {
                new LiveChartData { X = "India",          Y = 111.84 },
                new LiveChartData { X = "France",         Y = 95.53 },
                new LiveChartData { X = "Indonesia",      Y = 55.15 },
                new LiveChartData { X = "Iceland",        Y = 85.79 },
                new LiveChartData { X = "United States",  Y = 59.53 },
                new LiveChartData { X = "Greece",         Y = 58.93 },
                new LiveChartData { X = "Iran",           Y = 46.53 },
                new LiveChartData { X = "Canada",         Y = 59.52 },
                new LiveChartData { X = "Finland",        Y = 45.67 },
                new LiveChartData { X = "Brazil",         Y = 67.84 }
            };
        }
    }
    public class LiveChartData
    {
        public string X;
        public double Y;
    }
}
