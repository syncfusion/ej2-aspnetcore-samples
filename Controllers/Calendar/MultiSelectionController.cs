using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Calendar
{
    public partial class CalendarController : Controller
    {
        public IActionResult MultiSelection()
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            ViewBag.multiValue = new DateTime[] { new DateTime(year, month, 10), new DateTime(year, month, 15), new DateTime(year, month, 25) };
            return View();
        }
    }
}