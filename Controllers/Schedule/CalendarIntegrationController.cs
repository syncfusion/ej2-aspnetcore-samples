using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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