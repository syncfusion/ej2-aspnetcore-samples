using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.RangeNavigator
{
    public partial class RangeNavigatorController : Controller
    {
        public IActionResult Print()
        {
            return View();
        }
    }
}