#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
            List<DateTimeData> chartData = new List<DateTimeData>
            {
                 new DateTimeData { xValue = new DateTime(1970, 1, 1), yValue1 = 16500, yValue2 = 8000 },
                 new DateTimeData { xValue = new DateTime(1975, 1, 1), yValue1 = 16000, yValue2 = 7600 },
                 new DateTimeData { xValue = new DateTime(1980, 1, 1), yValue1 = 15400, yValue2 = 6400 },
                 new DateTimeData { xValue = new DateTime(1985, 1, 1), yValue1 = 15800, yValue2 = 3700 },
                 new DateTimeData { xValue = new DateTime(1990, 1, 1), yValue1 = 14000, yValue2 = 7200 },
                 new DateTimeData { xValue = new DateTime(1995, 1, 1), yValue1 = 10500, yValue2 = 2300 },
                 new DateTimeData { xValue = new DateTime(2000, 1, 1), yValue1 = 13300, yValue2 = 4000 },
                 new DateTimeData { xValue = new DateTime(2005, 1, 1), yValue1 = 12800, yValue2 = 4800 }
            };
            ViewBag.dataSource = chartData;
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

        public class DateTimeData
        {
            public DateTime xValue;
            public double yValue1;
            public double yValue2;
        }


    }
}