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
        public IActionResult Default()
        {
			List<DefaultBulletData> bulletData1 = new List<DefaultBulletData>
            {
                new DefaultBulletData { value = 270, target = 250}     
            };
            List<DefaultBulletData> bulletData2 = new List<DefaultBulletData>
            {
                new DefaultBulletData { value = 23, target = 27}
            };
            List<DefaultBulletData> bulletData3 = new List<DefaultBulletData>
            {
                new DefaultBulletData { value = 350, target = 550}
            };
            List<DefaultBulletData> bulletData4 = new List<DefaultBulletData>
            {
                new DefaultBulletData { value = 1600, target = 2100}
            };
            List<DefaultBulletData> bulletData5 = new List<DefaultBulletData>
            {
                new DefaultBulletData { value = 4.9, target = 4}
            };
            ViewBag.dataSource1 = bulletData1;
            ViewBag.dataSource2 = bulletData2;
            ViewBag.dataSource3 = bulletData3;
            ViewBag.dataSource4 = bulletData4;
            ViewBag.dataSource5 = bulletData5;
            return View();
        }
		public class DefaultBulletData
        {           
            public double value;
            public double target;
        }
    }
}