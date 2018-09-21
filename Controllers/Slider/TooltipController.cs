using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class SliderController : Controller
    {
        public IActionResult Tooltip()
        {
            ViewBag.sliderValue = new int[] { 30, 70 };

            List<object> placement = new List<object>();
            placement.Add(new { value = "Before", text = "Before" });
            placement.Add(new { value = "After", text = "After" });

            ViewBag.placement = placement;

            List<object> showON = new List<object>();
            showON.Add(new { value = "Auto", text = "Auto" });
            showON.Add(new { value = "Focus", text = "Focus" });
            showON.Add(new { value = "Hover", text = "Hover" });
            showON.Add(new { value = "Always", text = "Always" });

            ViewBag.showON = showON;
            return View();
        }
    }
}
