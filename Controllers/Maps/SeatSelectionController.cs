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
        public IActionResult SeatSelection()
        {
            ViewBag.seatdata = GetSeatData();
            return View();
        }
		
        public object GetSeatData()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/seatdata.json");
            return JsonConvert.DeserializeObject(allText);
        }
    }
}