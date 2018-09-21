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
        public IActionResult BoxandWhisker()
        {
            Double[] y1 = { 22, 22, 23, 25, 25, 25, 26, 27, 27, 28, 28, 29, 30, 32, 34, 32, 34, 36, 35, 38 };
            Double[] y2 = { 22, 33, 23, 25, 26, 28, 29, 30, 34, 33, 32, 31, 50 };
            Double[] y3 = { 22, 24, 25, 30, 32, 34, 36, 38, 39, 41, 35, 36, 40, 56 };
            Double[] y4 = { 26, 27, 28, 30, 32, 34, 35, 37, 35, 37, 45 };
            Double[] y5 = { 26, 27, 29, 32, 34, 35, 36, 37, 38, 39, 41, 43, 58 };
            Double[] y6 = { 27, 26, 28, 29, 29, 29, 32, 35, 32, 38, 53 };
            Double[] y7 = { 21, 23, 24, 25, 26, 27, 28, 30, 34, 36, 38 };
            Double[] y8 = { 26, 28, 29, 30, 32, 33, 35, 36, 52 };
            Double[] y9 = { 28, 29, 30, 31, 32, 34, 35, 36 };

            List<BoxandWhiskerData> chartData = new List<BoxandWhiskerData>
            {
                    new BoxandWhiskerData { x= "Development", y=y1},
                    new BoxandWhiskerData { x= "Testing", y=y2 },
                    new BoxandWhiskerData { x= "HR", y=y3 },
                    new BoxandWhiskerData { x= "Finance", y=y4 },
                    new BoxandWhiskerData { x= "R&D", y=y5},
                    new BoxandWhiskerData { x= "Sales", y=y6},
                    new BoxandWhiskerData { x= "Inventory", y=y7 },
                    new BoxandWhiskerData { x= "Graphics", y=y8},
                    new BoxandWhiskerData { x= "Training", y=y9}
        };
            ViewBag.dataSource = chartData;
            ViewBag.mode = new string[] { "Normal", "Inclusive", "Exclusive" };
            return View();
        }
        public class BoxandWhiskerData
        {
            public string x;
            public double[] y;
        }
    }
}