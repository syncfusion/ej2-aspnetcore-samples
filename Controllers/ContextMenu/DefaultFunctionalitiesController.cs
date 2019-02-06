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
            List<ContextMenuItem> menuitems = new List<ContextMenuItem>() {
                new ContextMenuItem{ Text="Cut", IconCss="e-cm-icons e-cut" },
                new ContextMenuItem{ Text="Copy", IconCss="e-cm-icons e-copy" },
                new ContextMenuItem{ Text="Paste", IconCss="e-cm-icons e-paste",
                    Items = new List<ContextMenuItem>(){
                        new ContextMenuItem{ Text = "Paste Text", IconCss = "e-cm-icons e-pastetext" },
                        new ContextMenuItem{ Text = "Paste Special", IconCss = "e-cm-icons e-pastespecial" }
                    }
                },
                new ContextMenuItem{ Separator= true},
                new ContextMenuItem{ Text = "Link", IconCss = "e-cm-icons e-link"},
                new ContextMenuItem{ Text = "New Comment", IconCss = "e-cm-icons e-comment"}
            };

            ViewBag.menuitems = menuitems;
            return View();
        }
    }
}
