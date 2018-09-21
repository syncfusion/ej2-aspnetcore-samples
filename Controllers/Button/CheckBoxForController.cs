using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ButtonController : Controller
    {
        public IActionResult CheckBoxFor()
        {
            CheckBoxModel model = new CheckBoxModel();
            model.check = true;
            return View(model);
        }
        [HttpPost]
        public IActionResult CheckBoxFor(CheckBoxModel model)
        {
            return View(model);
        }
    }
}