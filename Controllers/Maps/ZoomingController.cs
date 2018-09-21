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
        public IActionResult Zooming()
        {
            ViewBag.worldmap = GetWroldMap();
            ViewBag.random = GetRandomCountry();
            return View();
        }
		public object GetRandomCountry() {
			string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/randomcountrydata.js");
            return JsonConvert.DeserializeObject(allText);
		}
    }
}