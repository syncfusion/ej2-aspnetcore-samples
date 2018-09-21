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
        public IActionResult DetailTemplate()
        {
            var Emp = EmployeeView.GetAllRecords();
            ViewBag.datasource = Emp;
            return View();
        }
    }
}