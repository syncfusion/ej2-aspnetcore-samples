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
        public IActionResult Stripline()
        {
            List<SymbolsData> chartData = new List<SymbolsData>
            {
                new SymbolsData { x = "Sun", y = 25},
                new SymbolsData { x = "Mon", y = 27},
                new SymbolsData { x = "Tue", y = 33},
                new SymbolsData { x = "Wed", y = 36},
                new SymbolsData { x = "Thu", y = 26},
                new SymbolsData { x = "Fri", y = 37.5},
                new SymbolsData { x = "Sat", y = 23}
            };
            ViewBag.dataSource = chartData;

            List<ChartStripLine> xaxisstriplines = new List<ChartStripLine>();
            ChartStripLine strip1 = new ChartStripLine();
            strip1.Start = "-1";
            strip1.End = "1.5";
            strip1.Text = "Winter";
            strip1.Color = "url(#winter)";
            strip1.Rotation = -90;
            strip1.Visible = true;            
            strip1.TextStyle = new ChartFont { Size = "18px", Color = "#ffffff", FontWeight = "600" };
            xaxisstriplines.Add(strip1);


            ChartStripLine strip2 = new ChartStripLine();
            strip2.Start = "1.5";
            strip2.End = "3";
            strip2.Text = "Summer";
            strip2.Color = "url(#summer)";
            strip2.Rotation = -90;
            strip2.Visible = true;         
            strip2.TextStyle = new ChartFont { Size = "18px", Color = "#ffffff", FontWeight = "600" };
            xaxisstriplines.Add(strip2);

            ChartStripLine strip3 = new ChartStripLine();
            strip3.Start = "3";
            strip3.End = "4.5";
            strip3.Text = "Spring";
            strip3.Color = "url(#spring)";
            strip3.Rotation = -90;
            strip3.Visible = true;
            strip3.TextStyle = new ChartFont { Size = "18px", Color = "#ffffff", FontWeight = "600" };
            xaxisstriplines.Add(strip3);

            ChartStripLine strip4 = new ChartStripLine();
            strip4.Start = "4.5";
            strip4.End = "5.5";
            strip4.Text = "Autumn";
            strip4.Color = "url(#autumn)";
            strip4.Rotation = -90;
            strip4.Visible = true;
            strip4.TextStyle = new ChartFont { Size = "18px", Color = "#ffffff", FontWeight = "600" };
            xaxisstriplines.Add(strip4);

            ChartStripLine strip5 = new ChartStripLine();
            strip5.Start = "5.5";
            strip5.End = "6.5";
            strip5.Text = "Winter";
            strip5.Color = "url(#winter)";
            strip5.Rotation = -90;
            strip5.Visible = true;
            strip5.TextStyle = new ChartFont { Size = "18px", Color = "#ffffff", FontWeight = "600" };
            xaxisstriplines.Add(strip5);

            ChartStripLine strip6 = new ChartStripLine();
            strip6.StartFromAxis = true;
            strip6.Size = 2;
            strip6.IsSegmented = true;
            strip6.SegmentStart = "22.5";
            strip6.SegmentEnd = "27.5";
            strip6.Text = "Average Temperature";
            strip6.Color = "#fc902a";          
            strip6.Visible = false;
            strip6.TextStyle = new ChartFont { Size = "18px", Color = "#ffffff", FontWeight = "600" };
            xaxisstriplines.Add(strip6);


            ChartStripLine strip7 = new ChartStripLine();
            strip7.Start = "3.5";
            strip7.Size = 3;
            strip7.IsSegmented = true;
            strip7.SegmentStart = "22.5";
            strip7.SegmentEnd = "27.5";
            strip7.Text = "Average Temperature";
            strip7.Color = "#fc902a";
            strip7.Visible = false;
            strip7.TextStyle = new ChartFont { Size = "18px", Color = "#ffffff", FontWeight = "600" };
            xaxisstriplines.Add(strip7);

            ChartStripLine strip8 = new ChartStripLine();
            strip8.Start = "1.5";
            strip8.Size = 2;
            strip8.IsSegmented = true;
            strip8.SegmentStart = "32.5";
            strip8.SegmentEnd = "37.5";
            strip8.Text = "High Temperature";
            strip8.Color = "#fc902a";
            strip8.Visible = false;
            strip8.TextStyle = new ChartFont { Size = "18px", Color = "#ffffff", FontWeight = "600" };
            xaxisstriplines.Add(strip8);

            List<ChartStripLine> yaxisstriplines = new List<ChartStripLine>();
            ChartStripLine stripy1 = new ChartStripLine();
            stripy1.Start = "30";
            stripy1.End = "40";
            stripy1.Text = "High Temperature";
            stripy1.Color = "#ff512f";       
            stripy1.Visible = false;
            stripy1.TextStyle = new ChartFont { Size = "18px", Color = "#ffffff", FontWeight = "600" };
            yaxisstriplines.Add(stripy1);

            ChartStripLine stripy2 = new ChartStripLine();
            stripy2.Start = "20";
            stripy2.End = "30";
            stripy2.Text = "Average Temperature";
            stripy2.Color = "#fc902a";
            stripy2.Visible = false;
            stripy2.TextStyle = new ChartFont { Size = "18px", Color = "#ffffff", FontWeight = "600" };
            yaxisstriplines.Add(stripy2);

            ChartStripLine stripy3 = new ChartStripLine();
            stripy3.Start = "10";
            stripy3.End = "20";
            stripy3.Text = "Low Temperature";
            stripy3.Color = "#f9d423";
            stripy3.Visible = false;
            stripy3.TextStyle = new ChartFont { Size = "18px", Color = "#ffffff", FontWeight = "600" };
            yaxisstriplines.Add(stripy3);
           
            ViewBag.xAxis = xaxisstriplines;
            ViewBag.yAxis = yaxisstriplines;
            ViewBag.mode = new String[] { "Vertical", "Horizontal", "Segment" };
            return View();
        }        
  

    }
}