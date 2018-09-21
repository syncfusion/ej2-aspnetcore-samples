using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class AutoCompleteController : Controller
    {
        public IActionResult Highlight()
        {
            ViewBag.countries = new Countries().CountriesList();
            ViewBag.data = new string[] { "Contains", "StartsWith", "EndsWith" };
            return View();
        }
    }
}