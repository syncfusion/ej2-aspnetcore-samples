using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Grid
{
    public partial class GridController : Controller
    {
        public IActionResult DefaultSelection()
        {
            var Emp = EmployeeView.GetAllRecords();
            ViewBag.datasource = Emp;
            ViewBag.type = new string[] { "Single", "Multiple" };
            ViewBag.mode = new string[] { "Row", "Cell", "Both" };
            return View();
        }
    }
}