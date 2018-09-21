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
        public IActionResult ChipCustomization()
        {
            ViewBag.data = new ColorsData().GetColorsData();
            ViewBag.val = new string[] { "#2F5D81", "#D44FA3", "#4CD242", "#FE2A00", "#75523C"};
            return View();
        }
    }
}