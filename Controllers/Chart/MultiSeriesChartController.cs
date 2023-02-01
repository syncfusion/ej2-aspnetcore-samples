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
        public IActionResult MultiSeriesChart()
        {
            List<CombinationSeriesData> chartData = new List<CombinationSeriesData>
            {
                    new CombinationSeriesData { x= "2007", y= 1 },
                    new CombinationSeriesData { x= "2008", y= 0.25 },
                    new CombinationSeriesData { x= "2009", y= 0.1 }, 
                    new CombinationSeriesData { x= "2010", y= 1 },
                    new CombinationSeriesData { x= "2011", y= 0.1 }, 
                    new CombinationSeriesData { x= "2012", y= -0.25 },
                    new CombinationSeriesData { x= "2013", y= 0.25 }, 
                    new CombinationSeriesData { x= "2014", y= 0.6 }
            };
            ViewBag.dataSource = chartData;
            List<CombinationSeriesData> chartData1 = new List<CombinationSeriesData>
            {
                    new CombinationSeriesData { x= "2007", y= 0.5 },
                    new CombinationSeriesData { x= "2008", y= 0.35 },
                    new CombinationSeriesData { x= "2009", y= 0.9 },
                    new CombinationSeriesData { x= "2010", y= 0.5 },
                    new CombinationSeriesData { x= "2011", y= 0.25 },
                    new CombinationSeriesData { x= "2012", y= -0.5 },
                    new CombinationSeriesData { x= "2013", y= 0.5 },
                    new CombinationSeriesData { x= "2014", y= 0.6 }
            };
            ViewBag.dataSource1 = chartData1;
            List<CombinationSeriesData> chartData2 = new List<CombinationSeriesData>
            {
                    new CombinationSeriesData { x= "2007", y= 1.5 },
                    new CombinationSeriesData { x= "2008", y= 0.35 },
                    new CombinationSeriesData { x= "2009", y= -2.7 },
                    new CombinationSeriesData { x= "2010", y= 0.5 },
                    new CombinationSeriesData { x= "2011", y= 0.25 },
                    new CombinationSeriesData { x= "2012", y= -0.1 },
                    new CombinationSeriesData { x= "2013", y= -0.3 },
                    new CombinationSeriesData { x= "2014", y= -0.6 }
            };
            ViewBag.dataSource2 = chartData2;
            List<CombinationSeriesData> chartData3 = new List<CombinationSeriesData>
            {
                    new CombinationSeriesData { x= "2007", y= -1 },
                    new CombinationSeriesData { x= "2008", y= -.35 },
                    new CombinationSeriesData { x= "2009", y= -0.3 },
                    new CombinationSeriesData { x= "2010", y= -0.5 },
                    new CombinationSeriesData { x= "2011", y= 1 },
                    new CombinationSeriesData { x= "2012", y= -0.4 },
                    new CombinationSeriesData { x= "2013", y= 0.1 },
                    new CombinationSeriesData { x= "2014", y= -0.6 }
            };
            ViewBag.dataSource3 = chartData3;
            List<CombinationSeriesData> chartData4 = new List<CombinationSeriesData>
            {
                    new CombinationSeriesData { x= "2007", y= 2 },
                    new CombinationSeriesData { x= "2008", y= 0.1 },
                    new CombinationSeriesData { x= "2009", y= -2.7 },
                    new CombinationSeriesData { x= "2010", y= 1.8 },
                    new CombinationSeriesData { x= "2011", y= 2 },
                    new CombinationSeriesData { x= "2012", y= 0.4 },
                    new CombinationSeriesData { x= "2013", y= 0.9 },
                    new CombinationSeriesData { x= "2014", y= 0.4 }
            };
            ViewBag.dataSource4 = chartData4;
            return View();
        }
        public class CombinationSeriesData
        {
            public string x;
            public double y;
        }
    }
}