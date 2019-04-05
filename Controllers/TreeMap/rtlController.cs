using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EJ2CoreSampleBrowser.Controllers.TreeMap
{
    public partial class TreeMapController : Controller
    {
        public IActionResult rtl()
        {
            ViewBag.dataSource = this.getRTLData("rtl-data");

            return View();
        }
        public object getRTLData(string filename)
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/TreeMapData/" + filename + ".js");
            return JsonConvert.DeserializeObject(allText);
        }
    }
}