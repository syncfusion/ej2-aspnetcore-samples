using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class DropDownListController : Controller
    {
        public IActionResult GroupingAndIcon()
        {
            ViewBag.groupdata = new Vegetables().VegetablesList();
            ViewBag.icondata = new SocialMedia().SocialMediaList();
            return View();
        }
    }
}