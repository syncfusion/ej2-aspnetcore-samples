#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Charts;

namespace EJ2CoreSampleBrowser.Controllers.Chart
{
    public partial class ChartController : Controller
    {
        public IActionResult StriplineRecurrence()
        {
            List<StripLineRecurrenceChartData> PollutionReports = new List<StripLineRecurrenceChartData>
            {
                new StripLineRecurrenceChartData { Period = new DateTime(1970, 1, 1), PollutionRate1 = 16500, PollutionRate2 = 8000 },
                new StripLineRecurrenceChartData { Period = new DateTime(1975, 1, 1), PollutionRate1 = 16000, PollutionRate2 = 7600 },
                new StripLineRecurrenceChartData { Period = new DateTime(1980, 1, 1), PollutionRate1 = 15400, PollutionRate2 = 6400 },
                new StripLineRecurrenceChartData { Period = new DateTime(1985, 1, 1), PollutionRate1 = 15800, PollutionRate2 = 3700 },
                new StripLineRecurrenceChartData { Period = new DateTime(1990, 1, 1), PollutionRate1 = 14000, PollutionRate2 = 7200 },
                new StripLineRecurrenceChartData { Period = new DateTime(1995, 1, 1), PollutionRate1 = 10500, PollutionRate2 = 2300 },
                new StripLineRecurrenceChartData { Period = new DateTime(2000, 1, 1), PollutionRate1 = 13300, PollutionRate2 = 4000 },
                new StripLineRecurrenceChartData { Period = new DateTime(2005, 1, 1), PollutionRate1 = 12800, PollutionRate2 = 4800 }
            };
            ViewBag.PollutionReports = PollutionReports;
            
            List<ChartStripLine> xAxisStrips = new List<ChartStripLine>
            {
                new ChartStripLine {
                    StartFromAxis = true, Size = 5, SizeType=Syncfusion.EJ2.Charts.SizeType.Years,
                    IsRepeat = true, RepeatEvery = "10", Visible = true , Color="rgba(167,169,171, 0.1)"
                }
            };

            List<ChartStripLine> yAxisStrips = new List<ChartStripLine>
            {
                new ChartStripLine {
                    StartFromAxis = true, Size = 2000,
                    IsRepeat = true, RepeatEvery = "4000", Visible = true , Color="rgba(167,169,171, 0.1)"
                }
            };
            ViewBag.xAxisStrips = xAxisStrips;
            ViewBag.yAxisStrips = yAxisStrips;


            return View();
        }

        public class StripLineRecurrenceChartData
        {
            public DateTime Period;
            public double PollutionRate1;
            public double PollutionRate2;
        }


    }
}