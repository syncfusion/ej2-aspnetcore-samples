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

        public IActionResult Pyramid()
        {

            List<PyramidData> chartData = new List<PyramidData>  
            {
                new PyramidData { xValue =  "Sweet Treats", yValue = 120, text = "120 cal" },
                new PyramidData { xValue =  "Milk, Youghnut, Cheese", yValue = 435, text = "435 cal" },
                new PyramidData { xValue =  "Vegetables", yValue = 470, text = "470 cal" },
                new PyramidData { xValue =  "Meat, Poultry, Fish", yValue = 475, text = "475 cal" },           
                new PyramidData { xValue =  "Fruits", yValue = 520, text = "520 cal" },
                new PyramidData { xValue =  "Bread, Rice, Pasta", yValue = 930, text = "930 cal" },
            };
            ViewBag.dataSource = chartData;
            return View();
        }

        public class PyramidData
        {
            public string xValue;
            public double yValue;
            public string text;
        }
    }
}
