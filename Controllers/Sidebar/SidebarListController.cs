using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Sidebar
{
    public partial class SidebarController : Controller
    {
        public IActionResult SidebarList()
        {
            List<object> dataList = new List<object>();
            dataList.Add(new { text = "Home" });
            dataList.Add(new { text = "About" });
            dataList.Add(new { text = "Careers" });
            dataList.Add(new { text = "FAQs" });
            dataList.Add(new { text = "Blog" });
            dataList.Add(new { text = "Uses" });
            dataList.Add(new { text = "Contact" });
            ViewBag.dataSource = dataList;
            object fields = new { tooltip = "text" };
            return View();
        }
    }
}