using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Sidebar
{
    public partial class SidebarController : Controller
    {
        public IActionResult SidebarMenu()
        {
            List<object> mainMenuItems = new List<object>();
            mainMenuItems.Add(new
            {
                text = "Overview",
                iconCss = "icon-user icon",
                items = new List<object>()
                    {
                        new { text = "All Data" },
                        new { text = "Category2" },
                        new { text = "Category3" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Notification",
                iconCss = "icon-bell-alt icon",
                items = new List<object>()
                    {
                        new { text = "Change Profile" },
                        new { text = "Add Name" },
                        new { text = "Add Details" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Info",
                iconCss = "icon-tag icon",
                items = new List<object>()
                    {
                        new { text = "Message" },
                        new { text = "Facebook" },
                        new { text = "Twitter" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Comments",
                iconCss = "icon-comment-inv-alt2 icon",
                items = new List<object>()
                    {
                        new { text = "Category1 " },
                        new { text = "Category2" },
                        new { text = "Category3" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Bookmarks",
                iconCss = "icon-bookmark icon",
                items = new List<object>()
                    {
                        new { text = "All Comments" },
                        new { text = "Add Comments" },
                        new { text = "Delete Comments" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Images",
                iconCss = "icon-picture icon",
                items = new List<object>()
                    {
                        new { text = "Add Name" },
                        new { text = "Add Mobile Number" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Users",
                iconCss = "icon-user icon",
                items = new List<object>()
                    {
                        new { text = "Mobile User" },
                        new { text = "Laptop User" },
                        new { text = "Desktop User" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Settings",
                iconCss = "icon-eye icon",
                items = new List<object>()
                    {
                        new { text = "Change Profile" },
                        new { text = "Add Name" },
                        new { text = "Add Details" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Info",
                iconCss = "icon-tag icon",
                items = new List<object>()
                    {
                        new { text = "Facebook" },
                        new { text = "Mobile" }
                    }
            });
            ViewBag.mainMenuItems = mainMenuItems;

            List<object> AccountMenuItems = new List<object>();
            AccountMenuItems.Add(new
            {
                text = "Account",
                items = new List<object>()
                    {
                        new { text = "Profile" },
                        new { text = "Sign out" }
                    }
            });
            ViewBag.AccountMenuItems = AccountMenuItems;
           
            return View();
        }
    }
}