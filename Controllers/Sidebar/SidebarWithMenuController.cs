#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class SidebarController : Controller
    {
        // GET: /<controller>/
        public IActionResult SidebarWithMenu()
        {
            Dictionary<string, object> HtmlAttribute = new Dictionary<string, object>()
            {   {"class", "sidebar-menu" } };
            List<MenuItem> MainMenuItems = new List<MenuItem>{
                new MenuItem {
                    Text = "Overview", IconCss = "icon-user icon",
                    Items = new List<MenuItem> {
                        new MenuItem{ Text = "All Data" },
                        new MenuItem{ Text = "Category2" },
                        new MenuItem{ Text = "Category3" }
                    }
                },
                new MenuItem {
                    Text = "Notification",
                    IconCss = "icon-bell-alt icon",
                    Items = new List<MenuItem> {
                        new MenuItem{ Text = "Change Profile" },
                        new MenuItem{ Text = "Add Name" },
                        new MenuItem{ Text = "Add Details" }
                    }
                },
                new MenuItem {
                    Text = "Info",
                    IconCss = "icon-tag icon",
                    Items = new List<MenuItem> {
                        new MenuItem{ Text = "Message" },
                        new MenuItem{ Text = "Facebook" },
                        new MenuItem{ Text = "Twitter" }
                    }
                },
                new MenuItem {
                    Text = "Comments",
                    IconCss = "icon-comment-inv-alt2 icon",
                    Items = new List<MenuItem> {
                        new MenuItem{ Text = "Category1 " },
                        new MenuItem{ Text = "Category2" },
                        new MenuItem{ Text = "Category3" }
                    }
                },
                new MenuItem {
                    Text = "Bookmarks",
                    IconCss = "icon-bookmark icon",
                    Items = new List<MenuItem> {
                        new MenuItem{ Text = "All Comments" },
                        new MenuItem{ Text = "Add Comments" },
                        new MenuItem{ Text = "Delete Comments" }
                    }
                },
                new MenuItem {
                    Text = "Images",
                    IconCss = "icon-picture icon",
                    Items = new List<MenuItem> {
                        new MenuItem{ Text = "Add Name" },
                        new MenuItem{ Text = "Add Mobile Number" }
                    }
                },
                new MenuItem {
                    Text = "Users",
                    IconCss = "icon-user icon",
                    Items = new List<MenuItem> {
                        new MenuItem{ Text = "Mobile User" },
                        new MenuItem{ Text = "Laptop User" },
                        new MenuItem{ Text = "Desktop User" }
                    }
                },
                new MenuItem {
                    Text = "Settings",
                    IconCss = "icon-eye icon",
                    Items = new List<MenuItem> {
                        new MenuItem{ Text = "Change Profile" },
                        new MenuItem{ Text = "Add Name" },
                        new MenuItem{ Text = "Add Details" }
                    }
                },
                new MenuItem {
                    Text = "Info",
                    IconCss = "icon-tag icon",
                    Items = new List<MenuItem> {
                        new MenuItem{ Text = "Facebook" },
                        new MenuItem{ Text = "Mobile" }
                    }
                }
            };
            ViewBag.HtmlAttribute = HtmlAttribute;
            ViewBag.Items = MainMenuItems;
            return View();
        }
    }
}

