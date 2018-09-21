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
       
        public IActionResult Export()
        {
            List<exportData> chartData = new List<exportData>
            {
                    new exportData {xValue="DEZ", yValue = 35.5},
                    new exportData {xValue="CHN", yValue = 18.3},
                    new exportData {xValue="ITA", yValue = 17.6},
                    new exportData {xValue="JPN", yValue = 13.6},
                    new exportData {xValue="US", yValue = 12},
                    new exportData {xValue="ESP", yValue = 5.6},
                    new exportData {xValue="FRA", yValue = 4.6},
                    new exportData {xValue="AUS", yValue = 3.3},
                    new exportData {xValue="BEL", yValue = 3},
                    new exportData {xValue="UK", yValue = 2.9},                  
            };
            ViewBag.dataSource = chartData;
            ViewBag.mode = new String[] { "JPEG", "PNG", "SVG", "PDF" };
            return View();
        }
        public class exportData
        {
            public string xValue;
            public double yValue;
            
        }

    }
}