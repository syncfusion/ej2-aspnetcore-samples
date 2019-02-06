using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class InPlaceEditorController : Controller
    {
        public IActionResult Pickers()
        {
            ViewBag.dateData = new { placeholder = "Select a date" };
            ViewBag.timeData = new { placeholder = "Select a time" };
            ViewBag.dateTimeData = new { placeholder = "Select a date and time" };
            ViewBag.dateRangeData = new { placeholder = "Select a date range" };
            ViewBag.dateRangeValue =new DateTime[2] { new DateTime(2017, 05, 23), new DateTime(2017, 07, 05) };
            ViewBag.dateValue =new DateTime(2017, 05, 23);
            ViewBag.modeData = new string[] { "Inline", "Popup" };
            return View();
        }
    }
}
