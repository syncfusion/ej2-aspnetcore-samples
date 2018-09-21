using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class MultiSelectController : Controller
    {
        public IActionResult CheckBox()
        {
            ViewBag.data = new Countries().CountriesList();
            return View();
        }
    }
}