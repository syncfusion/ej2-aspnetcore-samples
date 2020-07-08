using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Controllers.HeatMapChart
{
    public partial class HeatMapChartController : Controller
    {
        public IActionResult LargeData()
        {
            ViewBag.dataSource = new HeatMapData().GetLargeData();
            return View();
        }
    }
}