using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.TreeGrid
{
    public partial class TreeGridController : Controller
    {
        public IActionResult CheckboxSelection()
        {
            var order = TreeData.GetDefaultData();
            ViewBag.dataSource = order;
            return View();
        }
    }
}