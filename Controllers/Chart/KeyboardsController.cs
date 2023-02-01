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
        public IActionResult Keyboards()
        {
            List<ChartStripLine> yAxisStrips = new List<ChartStripLine>
            {
                new ChartStripLine { IsSegmented = true, Start = 33, End = 35.5, Visible = true, SegmentStart = 0, SegmentEnd = 5 },
                new ChartStripLine { IsSegmented = true, Start = 39, End = 39.2, Visible = true, Text = "Jan - Mar", SegmentStart = 0, SegmentEnd = 5, Color = "transparent" },
                new ChartStripLine { IsSegmented = true, Start = 65, End = 67.5, Visible = true, SegmentStart = 7, SegmentEnd = 12 },
                new ChartStripLine { IsSegmented = true, Start = 70, End = 70.2, Visible = true, Text = "Apr - Jun", SegmentStart = 7, SegmentEnd = 12, Color = "transparent" },
                new ChartStripLine { IsSegmented = true, Start = 65, End = 67.5, Visible = true, SegmentStart = 14, SegmentEnd = 19 },
                new ChartStripLine { IsSegmented = true, Start = 70, End = 70.2, Visible = true, Text = "Jul - Sep", SegmentStart = 14, SegmentEnd = 19, Color = "transparent" },
                new ChartStripLine { IsSegmented = true, Start = 104, End = 106.5, Visible = true, SegmentStart  = 21, SegmentEnd = 26 },
                new ChartStripLine { IsSegmented = true, Start = 109, End = 109.2, Visible = true, Text = "Oct - Dec", SegmentStart = 21, SegmentEnd = 26, Color = "transparent" }        
            };
            ViewBag.yAxisStrips = yAxisStrips;

            List<KeyBoardData> chartData = new List<KeyBoardData>
            {
               new KeyBoardData { xValue = "Jan 15", yValue = 10 },
               new KeyBoardData { xValue = "Jan 31", yValue = 15 },
               new KeyBoardData { xValue = "Feb 15", yValue = 15 },
               new KeyBoardData { xValue = "Feb 28", yValue = 20 },
               new KeyBoardData { xValue = "March 15", yValue = 20 },
               new KeyBoardData { xValue = "March 31", yValue = 25 },
               new KeyBoardData { xValue = "March", yValue = null }
            };

            List<KeyBoardData> chartData1 = new List<KeyBoardData>
            {
               new KeyBoardData { xValue = "Apr 15", yValue = 36 },
               new KeyBoardData { xValue = "Apr 30", yValue = 48 },
               new KeyBoardData { xValue = "May 15", yValue = 43 },
               new KeyBoardData { xValue = "May 31", yValue = 59 },
               new KeyBoardData { xValue = "Jun 15", yValue = 35 },
               new KeyBoardData { xValue = "Jun 30", yValue = 50 },
               new KeyBoardData { xValue = "Jun", yValue = null }
            };
            List<KeyBoardData> chartData2 = new List<KeyBoardData>
            {
               new KeyBoardData { xValue = "Jul 15", yValue = 30 },
               new KeyBoardData { xValue = "Jul 31", yValue = 45 },
               new KeyBoardData { xValue = "Aug 15", yValue = 30 },
               new KeyBoardData { xValue = "Aug 31", yValue = 55 },
               new KeyBoardData { xValue = "Sep 15", yValue = 57 },
               new KeyBoardData { xValue = "Sep 30", yValue = 60 },
               new KeyBoardData { xValue = "Sep", yValue = null }
            };
            List<KeyBoardData> chartData3 = new List<KeyBoardData>
            {
               new KeyBoardData { xValue = "Oct 15", yValue = 60 },
               new KeyBoardData { xValue = "Oct 31", yValue = 70 },
               new KeyBoardData { xValue = "Nov 15", yValue = 70 },
               new KeyBoardData { xValue = "Nov 30", yValue = 70 },
               new KeyBoardData { xValue = "Dec 15", yValue = 90 },
               new KeyBoardData { xValue = "Dec 31", yValue = 100 }
            };
            ViewBag.dataSource = chartData;
            ViewBag.dataSource1 = chartData1;
            ViewBag.dataSource2 = chartData2;
            ViewBag.dataSource3 = chartData3;
            return View();
        }

        public class KeyBoardData
        {
            public string xValue;
            public double? yValue;

        }
    }
}