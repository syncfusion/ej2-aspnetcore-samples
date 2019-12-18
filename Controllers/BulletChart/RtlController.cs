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
        public IActionResult Rtl()
        {
            List<DotBulletData> bulletData1 = new List<DotBulletData>
            {
                new DotBulletData { value = 270, target = 250}
            };
            ViewBag.dataSource = bulletData1;
            return View();
        }       
    }
}