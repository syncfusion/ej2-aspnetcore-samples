using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {

        public IActionResult SearchEvents()
        {
            ViewBag.appointments = new ScheduleData().GetScheduleData();
            return View();
        }
    }
}