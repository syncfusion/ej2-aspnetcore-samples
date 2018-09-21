using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EJ2CoreSampleBrowser.Controllers.Maps
{
    public partial class MapsController: Controller
    {
        public IActionResult Tooltip()
        {
            ViewBag.worldmap = GetWroldMap();
			ViewBag.worldcup = GetWorldcup();
            return View();
        }
		public object GetWorldcup() {
			string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/worldcup.js");
            return JsonConvert.DeserializeObject(allText);
		}
    }
}