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
        public IActionResult SwitchFor()
        {
            SwitchModel model = new SwitchModel();
            model.check = true;
            return View(model);
        }
        [HttpPost]
        public IActionResult SwitchFor(SwitchModel model)
        {
            return View(model);
        }
    }
    public class SwitchModel
    {
        [Range(typeof(bool), "true", "true", ErrorMessage = "You need to agree to receive newsletter")]
        public bool check { get; set; }
    }
}