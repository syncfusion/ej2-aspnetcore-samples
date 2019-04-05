using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EJ2CoreSampleBrowser.Controllers.TextBoxes
{
    public class TextBoxValue
    {
        [Required(ErrorMessage = "Value is required")]
        public string firstname { get; set; }
    }
    public partial class TextBoxesController : Controller
    {
        TextBoxValue textbox = new TextBoxValue();
        public IActionResult TextboxFor()
        {
            textbox.firstname = "John";
            return View(textbox);
        }
        [HttpPost]

        public IActionResult TextboxFor(TextBoxValue model)
        {
            textbox.firstname = model.firstname;
            return View(textbox);
        }
    }
}