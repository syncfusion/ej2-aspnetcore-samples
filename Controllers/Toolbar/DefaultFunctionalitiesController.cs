using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ToolbarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DefaultFunctionalities()
        {
            return View();
        }
    }
}
