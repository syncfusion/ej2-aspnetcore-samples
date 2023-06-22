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

namespace EJ2CoreSampleBrowser.Controllers
{
    public class Space
    {
        public double[] cellSpacing { get; set; }

    }
    public class PieData
    {
        public string x;
        public double y;
        public string text;
    }

    public class LineData
    {
        public string x;
        public double y;
    }

    public class SplineData
    {
        public DateTime x;
        public double y;
    }
    public partial class DashboardLayoutController : Controller
    {
        public IActionResult EditableLayout()
        {
            List<PieData> pieChartData = new List<PieData>
            {
                new PieData {
                    x = "Jan",
                    y = 12.5,
                    text = "January"
                },
                new PieData {
                    x = "Feb",
                    y = 25,
                    text = "February"
                },
                new PieData {
                    x = "Mar",
                    y = 50,
                    text = "March"
                }
            };
            ViewBag.pieSource = pieChartData;
            List<LineData> LineChartData = new List<LineData>
            {
                new LineData {
                    x = "Jan",
                    y = 37,
                },
                new LineData {
                    x = "Feb",
                    y = 23,
                },
                new LineData {
                    x = "Mar",
                    y = 18,
                }
            };
            ViewBag.lineSource = LineChartData;
            List<LineData> LineChartData1 = new List<LineData>
            {
                new LineData {
                    x = "Jan",
                    y = 46,
                },
                new LineData {
                    x = "Feb",
                    y = 27,
                },
                new LineData {
                    x = "Mar",
                    y = 26,
                }
            };
            ViewBag.lineSource1 = LineChartData1;
            List<LineData> LineChartData2 = new List<LineData>
            {
                new LineData {
                    x = "Jan",
                    y = 38,
                },
                new LineData {
                    x = "Feb",
                    y = 17,
                },
                new LineData {
                    x = "Mar",
                    y = 26,
                }
            };
            ViewBag.lineSource2 = LineChartData2;
            ViewBag.pallets = new string[] { "#00bdae", "#357cd2", "#e56691" };
            List<SplineData> SplineChartData1 = new List<SplineData>
            {
                new SplineData { x =  new DateTime(2002, 1, 1), y =  2.2 }, new SplineData { x =  new DateTime(2003, 1, 1), y =  3.4 },
                new SplineData { x =  new DateTime(2004, 1, 1), y =  2.8 }, new SplineData { x =  new DateTime(2005, 1, 1), y =  1.6 },
                new SplineData { x =  new DateTime(2006, 1, 1), y =  2.3 }, new SplineData { x =  new DateTime(2007, 1, 1), y =  2.5 },
                new SplineData { x =  new DateTime(2008, 1, 1), y =  2.9 }, new SplineData { x =  new DateTime(2009, 1, 1), y =  3.8 },
                new SplineData { x =  new DateTime(2010, 1, 1), y =  1.4 }, new SplineData { x = new DateTime(2011, 1, 1), y =  3.1 }
            };
            ViewBag.splineSource1 = SplineChartData1;
            List<SplineData> SplineChartData2 = new List<SplineData>
            {
                new SplineData { x =  new DateTime(2002, 1, 1), y =  2 }, new SplineData { x =  new DateTime(2003, 1, 1), y =  1.7 },
                new SplineData { x =  new DateTime(2004, 1, 1), y =  1.8 }, new SplineData { x =  new DateTime(2005, 1, 1), y =  2.1 },
                new SplineData { x =  new DateTime(2006, 1, 1), y =  2.3 }, new SplineData { x =  new DateTime(2007, 1, 1), y =  1.7 },
                new SplineData { x =  new DateTime(2008, 1, 1), y =  1.5 }, new SplineData { x =  new DateTime(2009, 1, 1), y =  2.8 },
                new SplineData { x =  new DateTime(2010, 1, 1), y =  1.5 }, new SplineData { x = new DateTime(2011, 1, 1), y =  2.3 }
            };
            ViewBag.splineSource2 = SplineChartData2;
            Space modelValue = new Space();
            modelValue.cellSpacing = new double[] { 10, 10 };
            return View(modelValue);
        }
    }
}