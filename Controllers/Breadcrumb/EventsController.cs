using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class BreadcrumbController : Controller
    {
        public IActionResult Events()
        {
            return View();
        }
    }
}
