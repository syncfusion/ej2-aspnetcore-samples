using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Charts;

namespace EJ2CoreSampleBrowser.Controllers.BulletChart
{
    public partial class BulletChartController : Controller
    {
        public IActionResult Custom()
        {
            List<CustomBulletData> bulletData1 = new List<CustomBulletData>
            {
                new CustomBulletData { value = 1.7, target = 2.5}
            };

            ViewBag.dataSource = bulletData1;
            return View();
        }
        public class CustomBulletData
        {
            public double value;
            public double target;
        }
    }
}