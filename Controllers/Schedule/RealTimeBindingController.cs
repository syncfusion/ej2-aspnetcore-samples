using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Schedule
{
    public partial class ScheduleController : Controller
    {
        public IActionResult RealTimeBinding()
        {
            ViewBag.appointments = new ScheduleData().GetScheduleData();
            return View();
        }
    }
}