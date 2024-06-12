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
         private bool isPointsLoaded;
         private Random randomNum = new Random();
         private List<LineChartData> chartData = null;
         private bool visibleProperty;
         private double value = 0;
            
         public IActionResult ChartPerformance()
         {
             LoadPoints();
             ViewBag.chartPoints = chartData;
             return View();
    
         }
         private void LoadPoints()
         {
             chartData = new List<LineChartData>();
             isPointsLoaded = true;
             visibleProperty = true;
             for (int pts = 0; pts < 100000; pts++)
             {
                 if (pts % 3 == 0)
                 {
                       value -= (randomNum.Next(0, 100) / 3) * 4;
                 }
                 else if (pts % 2 == 0)
                 {
                     value += (randomNum.Next(0, 100) / 3) * 4;
                 }
                 if (value < 0)
                 {
                       value = value * -1;
                 }
                 if (value >= 12000)
                 {
                     value = randomNum.Next(1000, 11000);
                 }
                 chartData.Add(new LineChartData() { x = new DateTime(2005, 1, 1).AddHours(pts), y = value });
             }
                
         }
         public class LineChartData
         {
             public DateTime x;
             public double y;
         }
    }
}