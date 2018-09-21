using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.SplitButtons;

namespace EJ2CoreSampleBrowser.Controllers.Button
{
    public partial class ButtonController : Controller
    {
        public IActionResult SplitButton()
        {
            List<object> items = new List<object>();
            items.Add(new
            {
                text = "Paste",
                iconCss = "e-btn-icons e-paste"
            });
            items.Add(new
            {
                text = "Paste Special",
                iconCss = "e-btn-icons e-paste-special"
            });
            items.Add(new
            {
                text = "Paste as Formula",
                iconCss = "e-btn-icons e-paste-formula"
            });
            items.Add(new
            {
                text = "Paste as Hyperlink",
                iconCss = "e-btn-icons e-paste-hyperlink"
            });
            ViewBag.items = items;
            return View();
        }
    }
}