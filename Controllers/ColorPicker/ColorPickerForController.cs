using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ColorPickerController : Controller
    {
        public IActionResult ColorPickerFor()
        {
            ColorPickerModel model = new ColorPickerModel();
            model.colorValue = "#000080";
            return View(model);
        }
        [HttpPost]
        public IActionResult ColorPickerFor(ColorPickerModel model)
        {
            return View(model);
        }
    }

    public class ColorPickerModel
    {
        [RegularExpression("^((?!#000080).)*$", ErrorMessage = "Please select color with value other than #000080.")]
        public string colorValue { get; set; }
    }
}