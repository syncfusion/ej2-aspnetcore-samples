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
        public IActionResult PolarScatter()
        {
            List<PolarScatterData> data = new List<PolarScatterData>
            {
                new PolarScatterData { text= "Myanmar", x= "MMR", y= 7.3, y1= 6.3, y2= 7.5 },
                new PolarScatterData { text= "India", x= "IND", y= 7.9, y1= 6.8, y2= 7.2 },
                new PolarScatterData { text= "Bangladesh", x= "BGD", y= 6.8, y1= 6.9, y2= 6.9 },
                new PolarScatterData { text= "Cambodia", x= "KHM", y= 7.0, y1= 7.0, y2= 6.9 },
                new PolarScatterData { text= "China", x= "CHN", y= 6.9, y1= 6.7, y2= 6.6 },
                new PolarScatterData { text= "Bhutan", x= "BTN", y= 6.1, y1= 6.2, y2= 5.9 },
                new PolarScatterData { text= "Iceland", x= "ISL", y= 4.1, y1= 7.2, y2= 5.7 },
                new PolarScatterData { text= "Nepal", x= "NPL", y= 2.7, y1= 0.6, y2= 5.5 },
                new PolarScatterData { text= "Pakistan", x= "PAK", y= 4.0, y1= 4.7, y2= 5.0 },
                new PolarScatterData { text= "Poland", x= "POL", y= 3.9, y1= 2.7, y2= 3.4 },
                new PolarScatterData { text= "Australia", x= "AUS", y= 2.4, y1= 2.5, y2= 3.1 },
                new PolarScatterData { text= "Korea", x= "KOR", y= 2.8, y1= 2.8, y2= 2.7 },
                new PolarScatterData { text= "Singapore", x= "SGP", y= 1.9, y1= 2.0, y2= 2 },
                new PolarScatterData { text= "Canada", x= "CAN", y= 0.9, y1= 1.4, y2= 1.9 },
                new PolarScatterData { text= "Germany", x= "DEU", y= 1.5, y1= 1.8, y2= 1.6 },
                new PolarScatterData { text= "Denmark", x= "DNK", y= 1.6, y1= 1.1, y2= 1.5 },
                new PolarScatterData { text= "France", x= "FRA", y= 1.3, y1= 1.3, y2= 1.4 },
                new PolarScatterData { text= "Austria", x= "AUT", y= 1.0, y1= 1.5, y2= 1.4 }
            };
            ViewBag.dataSource = data;
            ViewBag.select = new string[] { "Polar", "Radar" };
            ViewBag.format = "${ point.text} : < b >${ point.y}%</ b >";
            return View();
        }
        public class PolarScatterData
        {
            public string text;
            public string x;
            public double y;
            public double y1;
            public double y2;
        }
    }
}