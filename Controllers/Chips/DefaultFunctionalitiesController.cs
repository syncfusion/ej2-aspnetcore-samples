using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Chips
{
    public partial class ChipsController : Controller
    {

        public IActionResult DefaultFunctionalities()
        {
            int[] choiceSelected = { 1 };
            int[] filterSelected = { 1, 3 };
            ViewBag.choiceSelected = choiceSelected;
            ViewBag.filterSelected = filterSelected;
            return View();
        }
    }
}