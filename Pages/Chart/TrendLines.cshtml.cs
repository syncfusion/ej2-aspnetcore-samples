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
    public class TrendlinesModel : PageModel
    {
        public List<TrendlinesChartData> ChartPoints { get; set; }

        public void OnGet()
        {
            ChartPoints = new List<TrendlinesChartData>
            {
                new TrendlinesChartData {Period = 1947, Rupees = 4.76},
                new TrendlinesChartData {Period = 1967, Rupees = 7.50},
                new TrendlinesChartData {Period = 1974, Rupees = 8.10},
                new TrendlinesChartData {Period = 1989, Rupees = 16.64},
                new TrendlinesChartData {Period = 1990, Rupees = 17.32},
                new TrendlinesChartData {Period = 2000, Rupees = 43.56},
                new TrendlinesChartData {Period = 2007, Rupees = 39.27},
                new TrendlinesChartData {Period = 2013, Rupees = 56.57},
                new TrendlinesChartData {Period = 2019, Rupees = 71.74},
                new TrendlinesChartData {Period = 2020, Rupees = 76.67},
                new TrendlinesChartData {Period = 2021, Rupees = 72.75}
            };
        }
    }
    public class TrendlinesChartData
    {
        public double Period;
        public double Rupees;
    }
}