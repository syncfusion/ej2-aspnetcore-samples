using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace EJ2CoreSampleBrowser.Controllers.Barcode
{
    public partial class BarcodeController : Controller
    {
        public IActionResult qrcode()
        {
            List<coorectionLevel> level = new List<coorectionLevel>();
            level.Add(new coorectionLevel() { text = "Low", value = "7" });
            level.Add(new coorectionLevel() { text = "Medium", value = "15" });
            level.Add(new coorectionLevel() { text = "Quartile", value = "25" });
            level.Add(new coorectionLevel() { text = "High", value = "30" });
            ViewBag.level = level;
            ViewBag.value = "Medium";
         
            return View();
        }

    }
    public class coorectionLevel
    {
        public string text;
        public string value;
    }
}