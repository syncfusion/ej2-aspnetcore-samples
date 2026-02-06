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
    public class StackedLineModel : PageModel
    {
        public List<StackedLineChartData> ChartPoints { get; set; }

        public void OnGet()
        {
            ChartPoints = new List<StackedLineChartData>
            {
                new StackedLineChartData { X = 2015, Y = 28.2, Y1 = 15.0, Y2 = 8.1, Y3 = 4.6 },
                new StackedLineChartData { X = 2016, Y = 28.6, Y1 = 16.7, Y2 = 8.4, Y3 = 7.5 },
                new StackedLineChartData { X = 2017, Y = 46.0, Y1 = 14.2, Y2 = 7.73, Y3 =12.1 },
                new StackedLineChartData { X = 2018, Y = 52.7, Y1 = 15.3, Y2 = 5.1, Y3 = 25.9 },
                new StackedLineChartData { X = 2019, Y = 62.0, Y1 = 16.4, Y2 = 8.7, Y3 = 39.3 },
                new StackedLineChartData { X = 2020, Y = 64.6, Y1 = 13.9, Y2 = 9.4, Y3 = 50.1 },
                new StackedLineChartData { X = 2021, Y = 60.1, Y1 = 14.8, Y2 = 10.3, Y3 = 60.4 },
                new StackedLineChartData { X = 2022, Y = 68.6, Y1 = 16.1, Y2 = 10.4, Y3 = 73.5 },
                new StackedLineChartData { X = 2023, Y = 71.81, Y1 = 16.02, Y2 = 11.17, Y3 = 102.01 }
            };
        }
    }
    public class StackedLineChartData
    {
        public double X;
        public double Y;
        public double Y1;
        public double Y2;
        public double Y3;
    }
}