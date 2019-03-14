using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {

        public IActionResult ExtendedViews()
        {
            ViewBag.appointments = new ScheduleData().GetFifaEventsData();
            return View();
        }
    }
}
