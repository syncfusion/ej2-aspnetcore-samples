using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Tooltip
{
    public partial class TooltipController : Controller
    {
        public IActionResult AjaxContent()
        {
            List<object> country = new List<object>();
            country.Add(new { id = "1", text = "Australia" });
            country.Add(new { id = "2", text = "Bhutan" });
            country.Add(new { id = "3", text = "China" });
            country.Add(new { id = "4", text = "Cuba" });
            country.Add(new { id = "5", text = "India" });
            country.Add(new { id = "6", text = "Switzerland" });
            country.Add(new { id = "7", text = "United States" });
            ViewBag.data = country;
            ViewBag.content = "Loading...";
            return View();

        }
    }
}
