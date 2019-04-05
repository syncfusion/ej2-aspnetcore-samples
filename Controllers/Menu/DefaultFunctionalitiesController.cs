using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class MenuController : Controller
    {
        public IActionResult DefaultFunctionalities()
        {

            List<MenuItem> menuItems = new List<MenuItem>(){
            new MenuItem
            {
                Text = "File",
                IconCss = "em-icons e-file",
                Items = new List<MenuItem>()
                {
                    new MenuItem { Text= "Open", IconCss= "em-icons e-open" },
                    new MenuItem { Text= "Save", IconCss= "em-icons e-save" },
                    new MenuItem { Separator= true },
                    new MenuItem { Text= "Exit" }
                }
            },
            new MenuItem
            {
                Text = "Edit",
                IconCss = "em-icons e-edit",
                Items = new List<MenuItem>()
                {
                    new MenuItem { Text= "Cut", IconCss= "em-icons e-cut" },
                    new MenuItem { Text= "Copy", IconCss= "em-icons e-copy" },
                    new MenuItem { Text= "Paste", IconCss= "em-icons e-paste" }
                }
            },
            new MenuItem
            {
                Text = "View",
                Items = new List<MenuItem>()
                {
                    new MenuItem {
                        Text = "Toolbars",
                        Items = new List<MenuItem>()
                        {
                            new MenuItem { Text= "Menu Bar" },
                            new MenuItem { Text= "Bookmarks Toolbar" },
                            new MenuItem { Text= "Customize" }
                        }
                    },
                    new MenuItem {
                        Text = "Zoom",
                        Items = new List<MenuItem>()
                        {
                            new MenuItem { Text= "Zoom In" },
                            new MenuItem { Text= "Zoom Out" },
                            new MenuItem { Text= "Reset" },
                        }
                    },
                    new MenuItem { Text = "Full Screen" }
                }
            },
            new MenuItem
            {
                Text = "Tools",
                Items = new List<MenuItem>()
                {
                    new MenuItem { Text= "Spelling & Grammar" },
                    new MenuItem { Text= "Customize" },
                    new MenuItem { Separator= true },
                    new MenuItem { Text= "Options" }
                }
            },
            new MenuItem { Text = "Help" }
            };

            ViewBag.menuItems = menuItems;
            return View();
        }
    }
}
