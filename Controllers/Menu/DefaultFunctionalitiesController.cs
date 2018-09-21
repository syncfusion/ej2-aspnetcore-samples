using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class MenuController : Controller
    {
        public IActionResult DefaultFunctionalities()
        {
            List<object> menuItems = new List<object>();
            menuItems.Add(new
            {
                text = "File",
                iconCss = "em-icons e-file",
                items = new List<object>()
                {
                    new { text= "Open", iconCss= "em-icons e-open" },
                    new { text= "Save", iconCss= "e-icons e-save" },
                    new { separator= true },
                    new { text= "Exit" }
                }
            });

            menuItems.Add(new
            {
                text = "Edit",
                iconCss = "em-icons e-edit",
                items = new List<object>()
                {
                    new { text= "Cut", iconCss= "em-icons e-cut" },
                    new { text= "Copy", iconCss= "em-icons e-copy" },
                    new { text= "Paste", iconCss= "em-icons e-paste" }
                }
            });

            menuItems.Add(new
            {
                text = "View",
                items = new List<object>()
                {
                    new {
                        text = "Toolbars",
                        items = new List<object>()
                        {
                            new { text= "Menu Bar" },
                            new { text= "Bookmarks Toolbar" },
                            new { text= "Customize" }
                        }
                    },
                    new {
                        text = "Zoom",
                        items = new List<object>()
                        {
                            new  { text= "Zoom In" },
                            new { text= "Zoom Out" },
                            new { text= "Reset" },
                        }
                    },
                    new {
                        text = "Full Screen"
                    }
                }
            });

            menuItems.Add(new
            {
                text = "Tools",
                items = new List<object>()
                {
                    new { text= "Spelling & Grammar" },
                    new { text= "Customize" },
                    new { separator= true },
                    new { text= "Options" }
                }
            });

            menuItems.Add(new
            {
                text = "Help",
            });

            ViewBag.menuItems = menuItems;
            return View();
        }
    }
}
