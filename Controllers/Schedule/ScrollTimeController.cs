using System;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {

        public IActionResult ScrollTime()
        {
            ViewBag.appointments = new ScheduleData().GetScheduleData();
            ViewBag.value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 9, 0, 0);
            return View();
        }
    }
}
