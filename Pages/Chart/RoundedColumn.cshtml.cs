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
    public class RoundedColumnModel : PageModel
    {
        public List<RoundedColumnChartData> ChartPoints { get; set; }

        public void OnGet()
        {
            ChartPoints = new List<RoundedColumnChartData>
            {
                new RoundedColumnChartData { X = "Healthcare", Y = 0.9, TooltipText = "0.9%" },
                new RoundedColumnChartData { X = "Real Estate", Y = 1.3, TooltipText = "1.3%" },
                new RoundedColumnChartData { X = "Energy", Y = 2.3, TooltipText = "2.3%" },
                new RoundedColumnChartData { X = "Consumer Staples", Y = 12.0, TooltipText = "12.0%" },
                new RoundedColumnChartData { X = "Industrials", Y = 15.6, TooltipText = "15.6%" },
                new RoundedColumnChartData { X = "Utilities", Y = 19.6, TooltipText = "19.6%" },
                new RoundedColumnChartData { X = "S&P 500 Average", Y = 23.3, TooltipText = "23.3%" },
                new RoundedColumnChartData { X = "Financials", Y = 28.4, TooltipText = "28.4%" },
                new RoundedColumnChartData { X = "Consumer Discretionary", Y = 29.1, TooltipText = "29.1%" },
                new RoundedColumnChartData { X = "Information Technology", Y = 35.7, TooltipText = "35.7%" },
                new RoundedColumnChartData { X = "Communication Services", Y = 38.9, TooltipText = "38.9%" }
            };
            bool isMobile = Request.Headers["User-Agent"].ToString().Contains("Mobi");
            if (isMobile)
            {
                ChartPoints[3].X = "Consumer <br> Staples";
                ChartPoints[6].X = "S&P <br> 500 Average";
                ChartPoints[8].X = "Consumer <br> Discretionary";
                ChartPoints[9].X = "Information <br> Technology";
                ChartPoints[10].X = "Communication <br> Services";
            };
        }
    }
    public class RoundedColumnChartData
    {
        public string X;
        public double Y;
        public string TooltipText;
    }
}