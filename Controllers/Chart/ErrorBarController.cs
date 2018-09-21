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
        public IActionResult ErrorBar()
        {
            List<ErrorBarData> chartData = new List<ErrorBarData>
            {
                new ErrorBarData { x= "IND", y= 24 }, 
                new ErrorBarData { x= "AUS", y= 20 }, 
                new ErrorBarData { x= "USA", y= 35 },
                new ErrorBarData { x= "DEU", y= 27 }, 
                new ErrorBarData { x= "ITA", y= 30 },
                new ErrorBarData { x= "UK", y= 41 }, 
                new ErrorBarData { x= "RUS", y= 26 }
            };
            ViewBag.datasource = chartData;
            ViewBag.type = new String[] { "Fixed", "Percentage", "StandardDeviation", "StandardError", "Custom" };
            ViewBag.mode = new String[] { "Vertical", "Horizontal", "Both" };
            ViewBag.direction = new String[] { "Plus", "Minus", "Both" };
            return View();
        }
        public class ErrorBarData
        {
            public string x;
            public double y;
        }
    }
}