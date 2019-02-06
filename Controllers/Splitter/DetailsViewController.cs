using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Splitter
{
    public partial class SplitterController : Controller
    {
        public IActionResult DetailsView()
        {
            return View();
        }
    }
}