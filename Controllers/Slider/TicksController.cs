using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Button
{
    public partial class SliderController : Controller
    {
        public IActionResult Ticks()
        {
            List<object> placement = new List<object>();
            placement.Add(new { value = "Before", text = "Before" });
            placement.Add(new { value = "After", text = "After" });
            placement.Add(new { value = "Both", text = "Both" });
            placement.Add(new { value = "None", text = "None" });
            ViewBag.rangeValue = new int[] { 30, 70 };
            ViewBag.placement = placement;
            return View();
        }
    }
}




