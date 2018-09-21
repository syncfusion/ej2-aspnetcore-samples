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
        public IActionResult DiacriticsFiltering()
        {
            ViewBag.data = new Diacritics().data;
            return View();
        }
    }
}