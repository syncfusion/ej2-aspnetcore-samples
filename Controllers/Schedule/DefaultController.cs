using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {

        public IActionResult Default()
        {
            ViewBag.appointments = new ScheduleEvents().GetAppointmentData();
            return View();
        }
    }
}
