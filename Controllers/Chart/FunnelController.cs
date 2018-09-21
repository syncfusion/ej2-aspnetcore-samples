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
                new FunnelData { xValue =  "Renewed", yValue = 18.20, text = "18.20%" },
                new FunnelData { xValue =  "Subscribed", yValue = 27.3, text = "27.3%" },
                new FunnelData { xValue =  "Support", yValue = 55.9, text = "55.9%" },
                new FunnelData { xValue =  "Dowmloaded", yValue = 76.8, text = "76.8%" },
                new FunnelData { xValue =  "Visited", yValue = 100, text = "100%" },                
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
