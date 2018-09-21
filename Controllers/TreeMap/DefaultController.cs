using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EJ2CoreSampleBrowser.Controllers.TreeMap
{
    public partial class TreeMapController : Controller
    {
        public IActionResult Default()
        {
            ViewBag.dataSource = this.getDataSource("CarSales");
            return View();
        }

        public object getDataSource(string filename)
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/TreeMapData/" + filename + ".js");
            return JsonConvert.DeserializeObject(allText);
        }
    }
}