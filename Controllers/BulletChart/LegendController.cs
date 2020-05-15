using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.BulletChart
{
    public partial class BulletChartController : Controller
    {
        public IActionResult Legend()
        {
            List<LegendData> bulletData1 = new List<LegendData>
            {
                new LegendData { value = 25, target = new double[]{ 20, 26, 28 } }
            };
            ViewBag.dataSource = bulletData1;

            return View();
        }
        public class LegendData
        {
            public double value;
            public double[] target;
        }
    }
}