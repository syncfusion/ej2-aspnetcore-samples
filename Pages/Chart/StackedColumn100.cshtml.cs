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
    public class StackedColumn100Model : PageModel
    {
        public List<StackedColumnChartData100> ChartPoints { get; set; }

        public void OnGet()
        {
            ChartPoints = new List<StackedColumnChartData100>
            {
               new StackedColumnChartData100 { X = "2019", Y1 = 28500000, Y2 = 26900000, Y3 = 19900000, Y4 = 13000000 },
                new StackedColumnChartData100 { X = "2020", Y1 = 27500000, Y2 = 29300000, Y3 = 14600000, Y4 = 13800000 },
                new StackedColumnChartData100 { X = "2021", Y1 = 24300000, Y2 = 26700000, Y3 = 17500000, Y4 = 10800000 },
                new StackedColumnChartData100 { X = "2022", Y1 = 26300000, Y2 = 30800000, Y3 = 14500000, Y4 = 11700000 },
                new StackedColumnChartData100 { X = "2023", Y1 = 25400000, Y2 = 27400000, Y3 = 12100000, Y4 = 14600000 },
                new StackedColumnChartData100 { X = "2024", Y1 = 25000000, Y2 = 31000000, Y3 = 14400000, Y4 = 17000000 },
            };
            bool isMobile = Request.Headers["User-Agent"].ToString().Contains("Mobi");
            if (isMobile)
            {
                ChartPoints.RemoveRange(0, 2);
            };
        }
    }
    public class StackedColumnChartData100
    {
        public string X;
        public double Y1;
        public double Y2;
        public double Y3;
        public double Y4;
    }
}