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
        public IActionResult RadioButtonFor()
        {
            RadioButtonModel model = new RadioButtonModel();
            model.gender = "female";
            return View(model);
        }
        [HttpPost]
        public IActionResult RadioButtonFor(RadioButtonModel model)
        {
            return View(model);
        }
    }

    public class RadioButtonModel
    {
        [Required]
        public string gender { get; set; }
    }
}