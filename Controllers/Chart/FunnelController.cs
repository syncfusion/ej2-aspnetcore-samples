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

        public IActionResult Funnel()
        {

            List<FunnelData> chartData = new List<FunnelData>  
            {
                new FunnelData { xValue = "China", yValue = 1409517397, text = "China" },
                new FunnelData { xValue = "India", yValue = 1339180127, text = "India" },
                new FunnelData { xValue = "United States", yValue = 324459463, text = "United States" },
                new FunnelData { xValue = "Indonesia", yValue = 263991379, text = "Indonesia" },
                new FunnelData { xValue = "Brazil", yValue = 209288278, text = "Brazil" },
                new FunnelData { xValue = "Pakistan", yValue = 197015955, text = "Pakistan" },
                new FunnelData { xValue = "Nigeria", yValue = 190886311, text = "Nigeria" },
                new FunnelData { xValue = "Bangladesh", yValue = 164669751, text = "Bangladesh" },
                new FunnelData { xValue = "Russia", yValue = 143989754, text = "Russia" },
                new FunnelData { xValue = "Mexico", yValue = 129163276, text = "Mexico" },
                new FunnelData { xValue = "Japan", yValue = 127484450, text = " Japan" },
                new FunnelData { xValue = "Ethiopia", yValue = 104957438, text = "Ethiopia" },
                new FunnelData { xValue = "Philippines", yValue = 104918090, text = "Philippines" },
                new FunnelData { xValue = "Egypt", yValue = 97553151, text = "Egypt" },
                new FunnelData { xValue = "Vietnam", yValue = 95540800, text = "Vietnam" },
                new FunnelData { xValue = "Germany", yValue = 82114224, text = "Germany" }
               
            };
            ViewBag.dataSource = chartData;           
            return View();
        }

        public class FunnelData
        {
            public string xValue;
            public double yValue;
            public string text;
        }
    }
}
