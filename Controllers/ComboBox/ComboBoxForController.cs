using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;
using System.ComponentModel.DataAnnotations;

namespace EJ2CoreSampleBrowser.Controllers
{
    public class ComboBoxValue
    {
        [Required(ErrorMessage = "Please enter a value")]
        public string val { get; set; }
        public string[] data { get; set; }
    }
    public partial class ComboBoxController : Controller
    {
        public string[] dataSource = new string[] { "American Football", "Badminton", "Basketball", "Cricket", "Football", "Golf", "Hockey", "Rugby", "Snooker", "Tennis" };

        public IActionResult ComboBoxFor()
        {
            ComboBoxValue model = new ComboBoxValue();
            model.data = dataSource;
            return View(model);
        }
        [HttpPost]
        public IActionResult ComboBoxFor(ComboBoxValue model)
        {
            model.data = dataSource;
            model.val = model.val;
            return View(model);
        }
    }
}
