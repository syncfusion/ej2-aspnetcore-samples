using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Schedule
{
    public partial class ScheduleController : Controller
    {

        public IActionResult CalendarIntegration()
        {
            return View();
        }
    }
}