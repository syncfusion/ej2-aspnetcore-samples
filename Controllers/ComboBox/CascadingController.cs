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
        public IActionResult Cascading()
        {
            ViewBag.state = new State().StateList();
            ViewBag.country = new Country().CountryList();
            ViewBag.cities = new Cities().CitiesList();
            ViewBag.popupHeight = "auto";
            return View();
        }
    }
}