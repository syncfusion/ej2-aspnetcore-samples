#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
        public IActionResult StackedArea100()
        {
            List<StackedArea100ChartData> chartData = new List<StackedArea100ChartData>
            {
               new StackedArea100ChartData { x= new DateTime(2000, 01, 01), y= 0.61 },
               new StackedArea100ChartData { x= new DateTime(2001, 01, 01), y= 0.81 },
               new StackedArea100ChartData { x= new DateTime(2002, 01, 01), y= 0.91 },
               new StackedArea100ChartData { x= new DateTime(2003, 01, 01), y= 1.00 },
               new StackedArea100ChartData  { x= new DateTime(2004, 01, 01), y= 1.19 },
               new StackedArea100ChartData { x= new DateTime(2005, 01, 01), y= 1.47 },
               new StackedArea100ChartData  { x= new DateTime(2006, 01, 01), y= 1.74 },
               new StackedArea100ChartData { x= new DateTime(2007, 01, 01), y= 1.98 },
               new StackedArea100ChartData  { x= new DateTime(2008, 01, 01), y= 1.99 },
               new StackedArea100ChartData { x= new DateTime(2009, 01, 01), y= 1.70 },
               new StackedArea100ChartData  { x= new DateTime(2010, 01, 01), y= 1.48 },
               new StackedArea100ChartData { x= new DateTime(2011, 01, 01), y= 1.38 },
               new StackedArea100ChartData { x= new DateTime(2012, 01, 01), y= 1.66 },
               new StackedArea100ChartData { x= new DateTime(2013, 01, 01), y= 1.66 },
               new StackedArea100ChartData  { x= new DateTime(2014, 01, 01), y= 1.67 }
            };
            ViewBag.dataSource = chartData;
            List<StackedArea100ChartData> chartData1 = new List<StackedArea100ChartData>
            {
              new StackedArea100ChartData { x= new DateTime(2000, 01, 01), y= 0.03 },
              new StackedArea100ChartData { x= new DateTime(2001, 01, 01), y= 0.05 },
              new StackedArea100ChartData { x= new DateTime(2002, 01, 01), y= 0.06 },
              new StackedArea100ChartData { x= new DateTime(2003, 01, 01), y= 0.09 },
              new StackedArea100ChartData { x= new DateTime(2004, 01, 01), y= 0.14 },
              new StackedArea100ChartData { x= new DateTime(2005, 01, 01), y= 0.20 },
              new StackedArea100ChartData { x= new DateTime(2006, 01, 01), y= 0.29 },
              new StackedArea100ChartData { x= new DateTime(2007, 01, 01), y= 0.46 },
              new StackedArea100ChartData { x= new DateTime(2008, 01, 01), y= 0.64 },
              new StackedArea100ChartData { x= new DateTime(2009, 01, 01), y= 0.75 },
              new StackedArea100ChartData { x= new DateTime(2010, 01, 01), y= 1.06 },
              new StackedArea100ChartData { x= new DateTime(2011, 01, 01), y= 1.25 },
              new StackedArea100ChartData { x= new DateTime(2012, 01, 01), y= 1.55 },
              new StackedArea100ChartData { x= new DateTime(2013, 01, 01), y= 1.55 },
              new StackedArea100ChartData { x= new DateTime(2014, 01, 01), y= 1.65 }
            };
            ViewBag.dataSource1 = chartData1;
            List<StackedArea100ChartData> chartData2 = new List<StackedArea100ChartData>
            {
             new StackedArea100ChartData { x= new DateTime(2000, 01, 01), y= 0.48 },
       new StackedArea100ChartData { x= new DateTime(2001, 01, 01), y= 0.53 },
    new StackedArea100ChartData { x= new DateTime(2002, 01, 01), y= 0.57 },
        new StackedArea100ChartData { x= new DateTime(2003, 01, 01), y= 0.61 },
    new StackedArea100ChartData { x= new DateTime(2004, 01, 01), y= 0.63 },
        new StackedArea100ChartData { x= new DateTime(2005, 01, 01), y= 0.64 },
    new StackedArea100ChartData { x= new DateTime(2006, 01, 01), y= 0.66 },
       new StackedArea100ChartData { x= new DateTime(2007, 01, 01), y= 0.76 },
   new StackedArea100ChartData { x= new DateTime(2008, 01, 01), y= 0.77 },
        new StackedArea100ChartData { x= new DateTime(2009, 01, 01), y= 0.55 },
   new StackedArea100ChartData { x= new DateTime(2010, 01, 01), y= 0.54 },
      new StackedArea100ChartData { x= new DateTime(2011, 01, 01), y= 0.57 },
   new StackedArea100ChartData { x= new DateTime(2012, 01, 01), y= 0.61 },
        new StackedArea100ChartData { x= new DateTime(2013, 01, 01), y= 0.67 },
   new StackedArea100ChartData { x= new DateTime(2014, 01, 01), y= 0.67 }
            };
            ViewBag.dataSource2 = chartData2;
            List<StackedArea100ChartData> chartData3 = new List<StackedArea100ChartData>
            {
              new StackedArea100ChartData { x= new DateTime(2000, 01, 01), y= 0.23 },
        new StackedArea100ChartData { x= new DateTime(2001, 01, 01), y= 0.17 },
        new StackedArea100ChartData { x= new DateTime(2002, 01, 01), y= 0.17 },
       new StackedArea100ChartData { x= new DateTime(2003, 01, 01), y= 0.20 },
       new StackedArea100ChartData { x= new DateTime(2004, 01, 01), y= 0.23 },
       new StackedArea100ChartData { x= new DateTime(2005, 01, 01), y= 0.36 },
        new StackedArea100ChartData { x= new DateTime(2006, 01, 01), y= 0.43 },
       new StackedArea100ChartData { x= new DateTime(2007, 01, 01), y= 0.51 },
       new StackedArea100ChartData { x= new DateTime(2008, 01, 01), y= 0.72 },
       new StackedArea100ChartData { x= new DateTime(2009, 01, 01), y= 1.29 },
       new StackedArea100ChartData { x= new DateTime(2010, 01, 01), y= 1.38 },
       new StackedArea100ChartData { x= new DateTime(2011, 01, 01), y= 1.82 },
       new StackedArea100ChartData { x= new DateTime(2012, 01, 01), y= 2.16 },
       new StackedArea100ChartData { x= new DateTime(2013, 01, 01), y= 2.51 },
       new StackedArea100ChartData { x= new DateTime(2014, 01, 01), y= 2.61 }
            };
            ViewBag.dataSource3 = chartData3;
            return View();
        }
        public class StackedArea100ChartData
        {
            public DateTime x;
            public double y;
        }
    }
}