using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers.TreeGrid
{
    public partial class TreeGridController : Controller
    {
        public IActionResult BatchEditing()
        {
            var order = TreeData.GetDefaultData();
            ViewBag.dataSource = order;
            return View();
        }
    }
}