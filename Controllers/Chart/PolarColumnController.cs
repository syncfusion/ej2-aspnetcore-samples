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
        public IActionResult PolarColumn()
        {
            List<PolarColumnData> data = new List<PolarColumnData>
            {
                new PolarColumnData { text= "Japan", x= "JPN", y= 137.9, y1= 127.6, y2= 108.8 },
                new PolarColumnData { text= "Indonesia", x= "IDN", y= 85.0, y1= 246.9, y2= 45.5 },
                new PolarColumnData { text= "Russia", x= "RUS", y= 237.1, y1= 143.5, y2= 41.2 },
                new PolarColumnData { text= "Vietnam", x= "VNM", y= 127.7, y1= 88.8, y2= 18.0 },
                new PolarColumnData { text= "Pakistan", x= "PAK", y= 126.1, y1= 179.2 },
                new PolarColumnData { text= "Nigeria", x= "NGA", y= 175.0, y1= 168.8, y2= 12.7 },
                new PolarColumnData { text= "Germany", x= "DEU", y= 113.6, y1= 81.9, y2= 46.0 },
                new PolarColumnData { text= "Bangladesh", x= "BGS", y= 116.0, y1= 154.7, y2= 34.6 },
                new PolarColumnData { text= "Philippines", x= "PHL", y= 109.5, y1= 96.7, y2= 16.6 },
                new PolarColumnData { text= "Mexico", x= "MEX", y= 102.7, y1= 120.8, y2= 19.8 }
            };
            ViewBag.dataSource = data;
            ViewBag.select = new string[] { "Polar", "Radar" };
            ViewBag.format = "${point.text} : <b>${point.y}%</b>";
            return View();
        }
        public class PolarColumnData
        {
            public string text;
            public string x;
            public double y;
            public double y1;
            public double y2;
        }
    }
}