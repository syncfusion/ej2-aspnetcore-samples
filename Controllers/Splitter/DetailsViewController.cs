using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Splitter
{
    public partial class SplitterController : Controller
    {
        public IActionResult DetailsView()
        {
            List<object> data = new List<object>();
            data.Add(new { name = "Margaret", imgUrl = @Url.Content("~/splitter/images/margaret.png"), id = "1" });
            data.Add(new { name = "Laura", imgUrl = @Url.Content("~/splitter/images/laura.png"), id = "2" });
            data.Add(new { name = "Robert", imgUrl = @Url.Content("~/splitter/images/robert.png"), id = "3" });
            data.Add(new { name = "Michale", imgUrl = @Url.Content("~/splitter/images/michale.png"), id = "4" });
            data.Add(new { name = "Albert", imgUrl = @Url.Content("~/splitter/images/albert.png"), id = "5" });
            ViewBag.dataSource = data;
            return View();
        }
    }
}