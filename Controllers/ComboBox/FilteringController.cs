using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ComboBoxController : Controller
    {
        public IActionResult Filtering()
        {
            ViewBag.data = new Countries().CountriesList();
            return View();
        }
    }
}