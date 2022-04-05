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
        public IActionResult Annotation()
        {
            List<ChartData> dataSource = new List<ChartData>
            {
                new ChartData {x =  "2014", y0= 51, y1= 77, y2= 66, y3= 34 },
                new ChartData {  x= "2015", y0= 67, y1= 49, y2= 19, y3= 38 },
                new ChartData { x= "2016", y0= 143, y1= 121, y2= 91, y3= 44},
                new ChartData { x= "2017", y0= 19, y1= 28, y2= 65, y3= 51 },
                new ChartData { x= "2018", y0= 30, y1= 66, y2= 32, y3= 61},
                new ChartData { x= "2019", y0= 189, y1= 128, y2= 122, y3= 76},
                new ChartData { x= "2020", y0= 72, y1= 97, y2= 65, y3= 82 },
            };
            ViewBag.dataSource = dataSource;
            Syncfusion.EJ2.Charts.ChartSelectedDataIndex select = new Syncfusion.EJ2.Charts.ChartSelectedDataIndex();
            select.Point = 0;
            //select.Series = 0;

            List<Syncfusion.EJ2.Charts.ChartSelectedDataIndex> index = new List<Syncfusion.EJ2.Charts.ChartSelectedDataIndex>
            {
                select
            };
            ViewBag.selectedData = index;
            ViewBag.content = "<div id='chart_annotation' style='width: 200px; height: 200px'></div>";
            return View();            
        }
        public class ChartData
        {
            public string x;
            public double y0;
            public double y1;
            public double y2;
            public double y3;
        }
    }
}