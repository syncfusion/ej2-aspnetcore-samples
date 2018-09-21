using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Charts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ChartController : Controller
    {

        public IActionResult Pie()
        {
            List<PieData> chartData = new List<PieData>  
            {
                new PieData { xValue =  "Chrome", yValue = 37, text = "37%" },
                new PieData { xValue =  "UC Browser", yValue = 17, text = "17%" },
                new PieData { xValue =  "iPhone", yValue = 19, text = "19%" },
                new PieData { xValue =  "Others", yValue = 4, text = "4%" },
                new PieData { xValue =  "Opera", yValue = 11, text = "11%" },
                new PieData { xValue =  "Android", yValue = 12, text = "12%" },                
            };
            ViewBag.dataSource = chartData;
            return View();
        }

        public class PieData
        {
            public string xValue;
            public double yValue;
            public string text;
        }
    }
}
