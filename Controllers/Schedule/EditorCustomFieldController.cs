using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {

        public IActionResult EditorCustomField()
        {
            ViewBag.appointments = new ScheduleData().GetEventsData();
            return View();
        }
    }
}
