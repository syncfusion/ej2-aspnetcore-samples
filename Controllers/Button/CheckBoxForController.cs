using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ButtonController : Controller
    {
        public IActionResult CheckboxFor()
        {
            CheckboxModel model = new CheckboxModel();
            model.check = true;
            return View(model);
        }
        [HttpPost]
        public IActionResult CheckboxFor(CheckboxModel model)
        {
            return View(model);
        }
    }
    public class CheckboxModel
    {
        [Range(typeof(bool), "true", "true", ErrorMessage = "You need to agree to the Terms and Conditions")]
        public bool check { get; set; }
    }
}