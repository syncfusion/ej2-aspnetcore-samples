using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {

        public IActionResult LocalData()
        {
            ViewBag.appointments = new ScheduleData().GetZooEventData();
            return View();
        }
    }
}
