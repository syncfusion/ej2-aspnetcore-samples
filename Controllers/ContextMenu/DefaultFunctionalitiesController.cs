using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ContextMenuController : Controller
    {
        public IActionResult DefaultFunctionalities()
        {

            List<object> menuItems = new List<object>();
            menuItems.Add(new
            {
                text = "Cut",
                iconCss = "e-cm-icons e-cut"
            });
            menuItems.Add(new
            {
                text = "Copy",
                iconCss = "e-cm-icons e-copy"
            });
            menuItems.Add(new
            {
                text = "Paste",
                iconCss = "e-cm-icons e-paste",
                items = new List<object>()
                {
                    new { text = "Paste Text", iconCss = "e-cm-icons e-pastetext" },
                    new { text = "Paste Special", iconCss = "e-cm-icons e-pastespecial" }
                }
            });
            menuItems.Add(new
            {
                separator = true
            });
            menuItems.Add(new
            {
                text = "Link",
                iconCss = "e-cm-icons e-link"
            });
            menuItems.Add(new
            {
                text = "New Comment",
                iconCss = "e-cm-icons e-comment"
            });
            ViewBag.menuItems = menuItems;
            return View();
        }
    }
}
