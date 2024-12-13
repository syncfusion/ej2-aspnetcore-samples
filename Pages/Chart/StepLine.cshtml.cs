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
    public class StepLineModel : PageModel
    {
        public List<StepLineChartData> StepLineData { get; set; }

        public void OnGet()
        {
            StepLineData = new List<StepLineChartData>
            {
                new StepLineChartData { Period = new DateTime(1975, 01, 01), CHN_UnemploymentRate = 16, AUS_UnemploymentRate = 35, ITA_UnemploymentRate = 3.4 },
                new StepLineChartData { Period = new DateTime(1978, 01, 01), CHN_UnemploymentRate = 12.5, AUS_UnemploymentRate = 45, ITA_UnemploymentRate = 4.4 },
                new StepLineChartData { Period = new DateTime(1981, 01, 01), CHN_UnemploymentRate = 19, AUS_UnemploymentRate = 55, ITA_UnemploymentRate = 6 },
                new StepLineChartData { Period = new DateTime(1984, 01, 01), CHN_UnemploymentRate = 14.4, AUS_UnemploymentRate = 20, ITA_UnemploymentRate = 7 },
                new StepLineChartData { Period = new DateTime(1987, 01, 01), CHN_UnemploymentRate = 11.5, AUS_UnemploymentRate = 10, ITA_UnemploymentRate = 11.3 },
                new StepLineChartData { Period = new DateTime(1990, 01, 01), CHN_UnemploymentRate = 14, AUS_UnemploymentRate = 42, ITA_UnemploymentRate = 10.1 },
                new StepLineChartData { Period = new DateTime(1993, 01, 01), CHN_UnemploymentRate = 10, AUS_UnemploymentRate = 35, ITA_UnemploymentRate = 7.8 },
                new StepLineChartData { Period = new DateTime(1996, 01, 01), CHN_UnemploymentRate = 16, AUS_UnemploymentRate = 22, ITA_UnemploymentRate = 8.5 },
                new StepLineChartData { Period = new DateTime(2000, 01, 01), CHN_UnemploymentRate = 16, AUS_UnemploymentRate = 65, ITA_UnemploymentRate = 8.5 },
                new StepLineChartData { Period = new DateTime(2005, 01, 01), CHN_UnemploymentRate = 16, AUS_UnemploymentRate = 65, ITA_UnemploymentRate = 8.5 },
                new StepLineChartData { Period = new DateTime(2010, 01, 01), CHN_UnemploymentRate = 16, AUS_UnemploymentRate = 58, ITA_UnemploymentRate = 8.5 }
            };   
        }
    }
    public class StepLineChartData
    {
        public DateTime Period;
        public double CHN_UnemploymentRate;
        public double AUS_UnemploymentRate;
        public double ITA_UnemploymentRate;
    }
}