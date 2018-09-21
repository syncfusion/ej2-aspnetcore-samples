using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class CalendarController : Controller
    {
        // GET: /<controller>/
        public IActionResult DateRange()
        {
            ViewBag.minDate= new DateTime(DateTime.Now.Year,DateTime.Now.Month,05);
            ViewBag.maxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 27);
            return View();
        }
    }
}
