using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EJ2CoreSampleBrowser.Controllers.SparkLine
{
    public partial class SparkLineController : Controller
    {
        public IActionResult SparkGrid()
        {
            ViewBag.dataSource = this.getDataSource("OrderData");
            return View();
        }
        public object getDataSource(string filename)
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/SparkLine/" + filename + ".js");
            return JsonConvert.DeserializeObject(allText);
        }
    }
}