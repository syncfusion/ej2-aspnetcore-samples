using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class DateRangePickerController : Controller
    {
        // GET: /<controller>/
        public IActionResult DateRange()
        {
            ViewBag.minDate = new DateTime(2017, 01, 05);
            ViewBag.maxDate = new DateTime(2017, 12, 20);
            return View();
        }
    }
}
