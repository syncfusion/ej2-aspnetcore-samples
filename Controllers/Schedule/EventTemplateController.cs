using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {

        public IActionResult EventTemplate()
        {
            ViewBag.appointments = new ScheduleData().GetWebinarData();
            return View();
        }
    }
}
