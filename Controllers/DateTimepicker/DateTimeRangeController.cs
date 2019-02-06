using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class DateTimePickerController : Controller
    {
        // GET: /<controller>/
        public IActionResult DateTimeRange()
        {
            ViewBag.minDate= new DateTime(DateTime.Now.Year,DateTime.Now.Month,05, 10,00,00);
            ViewBag.maxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 27, 22, 30, 00);
            ViewBag.value =new DateTime(DateTime.Now.Year,DateTime.Now.Month,09, 11,00,00);
            return View();
        }
    }
}
