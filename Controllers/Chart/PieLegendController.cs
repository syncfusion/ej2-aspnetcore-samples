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

        public IActionResult PieLegend()
        {
            List<pieDataPoints> chartData = new List<pieDataPoints>  
            {
                new pieDataPoints { x =  "Net-tution and Fees", y = 21, text = "21%" },
                new pieDataPoints { x =  "Self-supporting Operations", y = 21, text = "21%" },
                new pieDataPoints { x =  "Private Gifts", y = 8, text = "8%" },
                new pieDataPoints { x =  "All Other", y = 8, text = "8%" },
                new pieDataPoints { x =  "Local Revenue", y = 4, text = "4%" },
                new pieDataPoints { x =  "State Revenue", y = 21, text = "21%" },
                new pieDataPoints { x =  "Federal Revenue", y = 16, text = "16%" },
            };
            ViewBag.dataSource = chartData;
            return View();
        }
        public class pieDataPoints
        {
            public string x;
            public double y;
            public string text;
        }
    }
}
