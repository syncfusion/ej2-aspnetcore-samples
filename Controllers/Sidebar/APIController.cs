using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class SidebarController : Controller
    {
        // GET: /<controller>/
        public IActionResult API()
        {
            List<object> dataList = new List<object>();
            dataList.Add(new { text = "Over" });
            dataList.Add(new { text = "Push" });
            dataList.Add(new { text = "Slide" });
            dataList.Add(new { text = "Auto" });
            ViewBag.dataSource = dataList;
            object fields = new { type = "text" };
            return View();
        }

    }
}
