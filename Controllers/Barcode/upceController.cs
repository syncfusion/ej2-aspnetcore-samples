using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace EJ2CoreSampleBrowser.Controllers.Barcode
{
    public partial class BarcodeController : Controller
    {
        public IActionResult upce()
        {
            List<ExpandOptions> position = new List<ExpandOptions>();
            position.Add(new ExpandOptions() { text = "Bottom", value = "bottom" });
            position.Add(new ExpandOptions() { text = "Top", value = "top" });

            ViewBag.position = position;
            ViewBag.expandValue = "Bottom";
            List<alignment> align = new List<alignment>();
            align.Add(new alignment() { text = "Left", value = "left" });
            align.Add(new alignment() { text = "Right", value = "right" });
            align.Add(new alignment() { text = "Center", value = "center" });

            ViewBag.align = align;
            ViewBag.alignmentValue = "Center";
            return View();
        }

    }
}