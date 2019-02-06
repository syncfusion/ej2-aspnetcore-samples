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
        public IActionResult Api()
        {
            List<object> data = new List<object>() {
                new {
                    header = "Events",
                    subItems = new List<object>() {
                        new { text= "Conferences" },
                        new { text= "Music" },
                        new { text= "Workshops" }
                    }
                },
                new {
                    header = "Movies",
                    subItems = new List<object>() {
                        new { text= "Now Showing" },
                        new { text= "Coming Soon" }
                    }
                },
                new {
                    header = "Directory",
                    subItems = new List<object>() {
                        new { text= "Media Gallery" },
                        new { text= "Newsletters" }
                    }
                },
                new {
                    header = "Queries",
                    subItems = new List<object>() {
                        new { text= "Our Policy" },
                        new { text= "Site Map"},
                        new { text= "24x7 Support"}
                    }
                },
                new { header= "Services" }
            };

            MenuFieldSettings menuFields = new MenuFieldSettings()
            {
                IconCss = "icon",
                Text = new string[] { "header", "text", "value" },
                Children = new string[] { "subItems", "options" }
            };

            List<object> headerData = new List<object>()
            {
                new { text= "Events" },
                new { text= "Movies"},
                new { text= "Directory" },
                new {text= "Queries" },
                new { text= "Services" }
            };

            List<object> ddlData = new List<object>()
            {
                new { value = "Horizontal", text = "Horizontal" },
                new { value = "Vertical", text = "Vertical" },
            };

            ViewBag.data = data;
            ViewBag.menuFields = menuFields;
            ViewBag.ddlData = ddlData;
            ViewBag.headerData = headerData;
            return View();
        }
    }
}