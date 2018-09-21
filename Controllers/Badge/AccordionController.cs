using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class BadgeController : Controller
    {
        public IActionResult Accordion()
        {
            return View();
        }
    }
}