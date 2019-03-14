using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers.TextBoxes
{
    public partial class TextBoxesController : Controller
    {
        public IActionResult Multiline()
        {
            ViewBag.data = new floatValues().TextBoxModel();
            return View();
        }
    }
}