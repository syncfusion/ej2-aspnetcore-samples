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
        public IActionResult GridLines()
        {
            var Emp = EmployeeView.GetAllRecords();
            ViewBag.datasource = Emp;
            ViewBag.data = new string[] { "Default", "Both", "None","Horizontal", "Vertical" };
            return View();
        }
    }
}