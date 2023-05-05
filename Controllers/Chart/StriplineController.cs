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
        public IActionResult Stripline()
        {
            List<StripLineChartData> WeatherReportsA = new List<StripLineChartData>
            {
               new StripLineChartData { Day = "Jan", Temperature = 90 },
               new StripLineChartData { Day = "Feb", Temperature = 92 },
               new StripLineChartData { Day = "Mar", Temperature = 94 },
               new StripLineChartData { Day = "Apr", Temperature = 95 },
               new StripLineChartData { Day = "May", Temperature = 94 },
               new StripLineChartData { Day = "Jun", Temperature = 96 },
               new StripLineChartData { Day = "Jul", Temperature = 97 },
               new StripLineChartData { Day = "Aug", Temperature = 98 },
               new StripLineChartData { Day = "Sep", Temperature = 97 },
               new StripLineChartData { Day = "Oct", Temperature = 95 },
               new StripLineChartData { Day = "Nov", Temperature = 90 },
               new StripLineChartData { Day = "Dec", Temperature = 95 }
            };
            ViewBag.WeatherReportsA = WeatherReportsA;
            List<StripLineChartData> WeatherReportsB = new List<StripLineChartData>
            {
                new StripLineChartData { Day = "Jan", Temperature = 85 },
                new StripLineChartData { Day = "Feb", Temperature = 86 },
                new StripLineChartData { Day = "Mar", Temperature = 87 },
                new StripLineChartData { Day = "Apr", Temperature = 88 },
                new StripLineChartData { Day = "May", Temperature = 87 },
                new StripLineChartData { Day = "Jun", Temperature = 90 },
                new StripLineChartData { Day = "Jul", Temperature = 91 },
                new StripLineChartData { Day = "Aug", Temperature = 90 },
                new StripLineChartData { Day = "Sep", Temperature = 93 },
                new StripLineChartData { Day = "Oct", Temperature = 90 },
                new StripLineChartData { Day = "Nov", Temperature = 85 },
                new StripLineChartData { Day = "Dec", Temperature = 90 }
            };
            ViewBag.WeatherReportsB = WeatherReportsB;
            List<StripLineChartData> WeatherReportsC = new List<StripLineChartData>
            {
                new StripLineChartData {Day = "Jan", Temperature = 80},
                new StripLineChartData {Day = "Feb", Temperature = 81},
                new StripLineChartData {Day = "Mar", Temperature = 82},
                new StripLineChartData {Day = "Apr", Temperature = 83},
                new StripLineChartData {Day = "May", Temperature = 84},
                new StripLineChartData {Day = "Jun", Temperature = 83},
                new StripLineChartData {Day = "Jul", Temperature = 82},
                new StripLineChartData {Day = "Aug", Temperature = 81},
                new StripLineChartData {Day = "Sep", Temperature = 85},
                new StripLineChartData {Day = "Oct", Temperature = 84},
                new StripLineChartData {Day = "Nov", Temperature = 83},
                new StripLineChartData {Day = "Dec", Temperature = 82}
            };
            ViewBag.WeatherReportsC = WeatherReportsC;
            
            List<ChartStripLine> yaxisstriplines = new List<ChartStripLine>();
            ChartStripLine stripy1 = new ChartStripLine();
            stripy1.Start = "95";
            stripy1.End = "100";
            stripy1.Text = "Good";
            stripy1.Color = "#ff512f";
            stripy1.HorizontalAlignment = Anchor.Middle;
            stripy1.Visible = true;
            stripy1.TextStyle = new ChartFont { Size = "17px", Color = "#ffffff", FontWeight = "500" };
            stripy1.Border = new ChartBorder { Width = 0 };
            yaxisstriplines.Add(stripy1);

            ChartStripLine stripy2 = new ChartStripLine();
            stripy2.Start = "85";
            stripy2.End = "96";
            stripy2.Text = "Ok";
            stripy2.Color = "#fc902a";
            stripy1.HorizontalAlignment = Anchor.Middle;
            stripy2.Visible = true;
            stripy2.TextStyle = new ChartFont { Size = "17px", Color = "#ffffff", FontWeight = "500" };
            stripy1.Border = new ChartBorder { Width = 0 };
            yaxisstriplines.Add(stripy2);

            ChartStripLine stripy3 = new ChartStripLine();
            stripy3.Start = "80";
            stripy3.End = "85";
            stripy3.Text = "Average";
            stripy3.Color = "#f9d423";
            stripy1.HorizontalAlignment = Anchor.Middle;
            stripy3.Visible = true;
            stripy3.TextStyle = new ChartFont { Size = "17px", Color = "#ffffff", FontWeight = "500" };
            stripy1.Border = new ChartBorder { Width = 0 };
            yaxisstriplines.Add(stripy3);
            
            ViewBag.yAxis = yaxisstriplines;
            return View();
        }
        public class StripLineChartData
        {
            public string Day;
            public double Temperature;
        }
    }
}