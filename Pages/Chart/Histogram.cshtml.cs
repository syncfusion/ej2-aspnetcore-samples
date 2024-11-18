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
    public class HistogramModel : PageModel
    {
        public void OnGet()
        {
        }
        public List<HistogramChartData> ChartPoints = new List<HistogramChartData>
        {
                new HistogramChartData { Score = 5.250 },
                new HistogramChartData { Score = 7.750 },
                new HistogramChartData { Score = 0 },
                new HistogramChartData { Score = 8.275 },
                new HistogramChartData { Score = 9.750 },
                new HistogramChartData { Score = 7.750 },
                new HistogramChartData { Score = 8.275 },
                new HistogramChartData { Score = 6.250 },
                new HistogramChartData { Score = 5.750 },
                new HistogramChartData { Score = 5.250 },
                new HistogramChartData { Score = 23.000 },
                new HistogramChartData { Score = 26.500 },
                new HistogramChartData { Score = 27.750 },
                new HistogramChartData { Score = 25.025 },
                new HistogramChartData { Score = 26.500 },
                new HistogramChartData { Score = 28.025 },
                new HistogramChartData { Score = 29.250 },
                new HistogramChartData { Score = 26.750 },
                new HistogramChartData { Score = 27.250 },
                new HistogramChartData { Score = 26.250 },
                new HistogramChartData { Score = 25.250 },
                new HistogramChartData { Score = 34.500 },
                new HistogramChartData { Score = 25.625 },
                new HistogramChartData { Score = 25.500 },
                new HistogramChartData { Score = 26.625 },
                new HistogramChartData { Score = 36.275 },
                new HistogramChartData { Score = 36.250 },
                new HistogramChartData { Score = 26.875 },
                new HistogramChartData { Score = 40.000 },
                new HistogramChartData { Score = 43.000 },
                new HistogramChartData { Score = 46.500 },
                new HistogramChartData { Score = 47.750 },
                new HistogramChartData { Score = 45.025 },
                new HistogramChartData { Score = 56.500 },
                new HistogramChartData { Score = 58.025},
                new HistogramChartData { Score = 59.250},
                new HistogramChartData { Score = 56.750},
                new HistogramChartData { Score = 57.250},
                new HistogramChartData { Score = 46.250},
                new HistogramChartData { Score = 55.250},
                new HistogramChartData { Score = 44.500},
                new HistogramChartData { Score = 45.525},
                new HistogramChartData { Score = 55.500},
                new HistogramChartData { Score = 46.625},
                new HistogramChartData { Score = 46.275},
                new HistogramChartData { Score = 56.250},
                new HistogramChartData { Score = 46.875},
                new HistogramChartData { Score = 43.000},
                new HistogramChartData { Score = 46.250},
                new HistogramChartData { Score = 55.250},
                new HistogramChartData { Score = 44.500},
                new HistogramChartData { Score = 45.425},
                new HistogramChartData { Score = 55.500},
                new HistogramChartData { Score = 56.625},
                new HistogramChartData { Score = 46.275},
                new HistogramChartData { Score = 56.250},
                new HistogramChartData { Score = 46.875},
                new HistogramChartData { Score = 43.000},
                new HistogramChartData { Score = 46.250},
                new HistogramChartData { Score = 55.250},
                new HistogramChartData { Score = 44.500},
                new HistogramChartData { Score = 45.425},
                new HistogramChartData { Score = 55.500},
                new HistogramChartData { Score = 46.625},
                new HistogramChartData { Score = 56.275},
                new HistogramChartData { Score = 46.250},
                new HistogramChartData { Score = 56.875},
                new HistogramChartData { Score = 41.000},
                new HistogramChartData { Score = 63.000},
                new HistogramChartData { Score = 66.500},
                new HistogramChartData { Score = 67.750},
                new HistogramChartData { Score = 65.025},
                new HistogramChartData { Score = 66.500},
                new HistogramChartData { Score = 76.500},
                new HistogramChartData { Score = 78.025},
                new HistogramChartData { Score = 79.250},
                new HistogramChartData { Score = 76.750},
                new HistogramChartData { Score = 77.250},
                new HistogramChartData { Score = 66.250},
                new HistogramChartData { Score = 75.250},
                new HistogramChartData { Score = 74.500},
                new HistogramChartData { Score = 65.625},
                new HistogramChartData { Score = 75.500},
                new HistogramChartData { Score = 76.625},
                new HistogramChartData { Score = 76.275},
                new HistogramChartData { Score = 66.250},
                new HistogramChartData { Score = 66.875},
                new HistogramChartData { Score = 80.000},
                new HistogramChartData { Score = 85.250},
                new HistogramChartData { Score = 87.750},
                new HistogramChartData { Score = 89.000},
                new HistogramChartData { Score = 88.275},
                new HistogramChartData { Score = 89.750},
                new HistogramChartData { Score = 97.750},
                new HistogramChartData { Score = 98.275},
                new HistogramChartData { Score = 96.250},
                new HistogramChartData { Score = 95.750},
                new HistogramChartData { Score = 95.250}
            };
    }
    public class HistogramChartData
    {
        public double Score;
    }
}
