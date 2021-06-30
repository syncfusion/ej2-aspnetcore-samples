using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;
using System.Collections.Generic;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {

        public IActionResult Print()
        {
            ViewBag.appointments = new ScheduleData().GetScheduleData();
            ViewBag.printHeightAndWidthData = new List<string> { "auto", "100%", "500px" };
            return View();
        }
    }
}