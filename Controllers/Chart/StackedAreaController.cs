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
        public IActionResult StackedArea()
        {
            List<StackedAreaChartData> chartData = new List<StackedAreaChartData>
            {
               new StackedAreaChartData { x= new DateTime(2000, 01, 01), y= 0.61 },
               new StackedAreaChartData { x= new DateTime(2001, 01, 01), y= 0.81 },
               new StackedAreaChartData { x= new DateTime(2002, 01, 01), y= 0.91 },
               new StackedAreaChartData { x= new DateTime(2003, 01, 01), y= 1.00 },
               new StackedAreaChartData  { x= new DateTime(2004, 01, 01), y= 1.19 },
               new StackedAreaChartData { x= new DateTime(2005, 01, 01), y= 1.47 },
               new StackedAreaChartData  { x= new DateTime(2006, 01, 01), y= 1.74 },
               new StackedAreaChartData { x= new DateTime(2007, 01, 01), y= 1.98 },
               new StackedAreaChartData  { x= new DateTime(2008, 01, 01), y= 1.99 },
               new StackedAreaChartData { x= new DateTime(2009, 01, 01), y= 1.70 },
               new StackedAreaChartData  { x= new DateTime(2010, 01, 01), y= 1.48 },
               new StackedAreaChartData { x= new DateTime(2011, 01, 01), y= 1.38 },
               new StackedAreaChartData { x= new DateTime(2012, 01, 01), y= 1.66 },
               new StackedAreaChartData { x= new DateTime(2013, 01, 01), y= 1.66 },
               new StackedAreaChartData  { x= new DateTime(2014, 01, 01), y= 1.67 }
            };
            ViewBag.dataSource = chartData;
            List<StackedAreaChartData> chartData1 = new List<StackedAreaChartData>
            {
              new StackedAreaChartData { x= new DateTime(2000, 01, 01), y= 0.03 },
              new StackedAreaChartData { x= new DateTime(2001, 01, 01), y= 0.05 }, 
              new StackedAreaChartData { x= new DateTime(2002, 01, 01), y= 0.06 },
              new StackedAreaChartData { x= new DateTime(2003, 01, 01), y= 0.09 }, 
              new StackedAreaChartData { x= new DateTime(2004, 01, 01), y= 0.14 },
              new StackedAreaChartData { x= new DateTime(2005, 01, 01), y= 0.20 }, 
              new StackedAreaChartData { x= new DateTime(2006, 01, 01), y= 0.29 },
              new StackedAreaChartData { x= new DateTime(2007, 01, 01), y= 0.46 }, 
              new StackedAreaChartData { x= new DateTime(2008, 01, 01), y= 0.64 },
              new StackedAreaChartData { x= new DateTime(2009, 01, 01), y= 0.75 }, 
              new StackedAreaChartData { x= new DateTime(2010, 01, 01), y= 1.06 },
              new StackedAreaChartData { x= new DateTime(2011, 01, 01), y= 1.25 }, 
              new StackedAreaChartData { x= new DateTime(2012, 01, 01), y= 1.55 },
              new StackedAreaChartData { x= new DateTime(2013, 01, 01), y= 1.55 }, 
              new StackedAreaChartData { x= new DateTime(2014, 01, 01), y= 1.65 }
            };
            ViewBag.dataSource1 = chartData1;
            List<StackedAreaChartData> chartData2 = new List<StackedAreaChartData>
            {
             new StackedAreaChartData { x= new DateTime(2000, 01, 01), y= 0.48 },
       new StackedAreaChartData { x= new DateTime(2001, 01, 01), y= 0.53 }, 
    new StackedAreaChartData { x= new DateTime(2002, 01, 01), y= 0.57 },
        new StackedAreaChartData { x= new DateTime(2003, 01, 01), y= 0.61 }, 
    new StackedAreaChartData { x= new DateTime(2004, 01, 01), y= 0.63 },
        new StackedAreaChartData { x= new DateTime(2005, 01, 01), y= 0.64 }, 
    new StackedAreaChartData { x= new DateTime(2006, 01, 01), y= 0.66 },
       new StackedAreaChartData { x= new DateTime(2007, 01, 01), y= 0.76 }, 
   new StackedAreaChartData { x= new DateTime(2008, 01, 01), y= 0.77 },
        new StackedAreaChartData { x= new DateTime(2009, 01, 01), y= 0.55 }, 
   new StackedAreaChartData { x= new DateTime(2010, 01, 01), y= 0.54 },
      new StackedAreaChartData { x= new DateTime(2011, 01, 01), y= 0.57 }, 
   new StackedAreaChartData { x= new DateTime(2012, 01, 01), y= 0.61 },
        new StackedAreaChartData { x= new DateTime(2013, 01, 01), y= 0.67 }, 
   new StackedAreaChartData { x= new DateTime(2014, 01, 01), y= 0.67 }
            };
            ViewBag.dataSource2 = chartData2;
    List<StackedAreaChartData> chartData3 = new List<StackedAreaChartData>
            {
              new StackedAreaChartData { x= new DateTime(2000, 01, 01), y= 0.23 },
        new StackedAreaChartData { x= new DateTime(2001, 01, 01), y= 0.17 },
        new StackedAreaChartData { x= new DateTime(2002, 01, 01), y= 0.17 },
       new StackedAreaChartData { x= new DateTime(2003, 01, 01), y= 0.20 },
       new StackedAreaChartData { x= new DateTime(2004, 01, 01), y= 0.23 },
       new StackedAreaChartData { x= new DateTime(2005, 01, 01), y= 0.36 },
        new StackedAreaChartData { x= new DateTime(2006, 01, 01), y= 0.43 },
       new StackedAreaChartData { x= new DateTime(2007, 01, 01), y= 0.51 },
       new StackedAreaChartData { x= new DateTime(2008, 01, 01), y= 0.72 },
       new StackedAreaChartData { x= new DateTime(2009, 01, 01), y= 1.29 },
       new StackedAreaChartData { x= new DateTime(2010, 01, 01), y= 1.38 },
       new StackedAreaChartData { x= new DateTime(2011, 01, 01), y= 1.82 },
       new StackedAreaChartData { x= new DateTime(2012, 01, 01), y= 2.16 },
       new StackedAreaChartData { x= new DateTime(2013, 01, 01), y= 2.51 },
       new StackedAreaChartData { x= new DateTime(2014, 01, 01), y= 2.61 }
            };
ViewBag.dataSource3 = chartData3;
            return View();
        }
        public class StackedAreaChartData
        {
            public DateTime x;
            public double y;
        }
    }
}