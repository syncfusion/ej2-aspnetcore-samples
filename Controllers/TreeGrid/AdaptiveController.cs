using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Grids;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class TreeGridController : Controller
    {

        public IActionResult Adaptive()
        {
            var order = TreeData.GetDefaultData();
            ViewBag.dataSource = order;
            return View();
        }
    }
}