using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class DateRangePickerController: Controller
    {
        // GET: /<controller>/
        public IActionResult Format()
        {
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(20);
            ViewBag.start = startDate;
            ViewBag.end = endDate;
            return View();
        }
    }
}
