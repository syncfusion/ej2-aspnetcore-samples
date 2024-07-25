#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
        public IActionResult Drilldown()
        {
			ViewBag.defaultdata = GetDefaultData();
            ViewBag.worldmap = GetWroldMap();
            ViewBag.asia = GetAsia();
            ViewBag.africa = GetAfrica();
            ViewBag.northamerica = GetNorthAmerica();
            ViewBag.southamerica = GetSouthAmerica();
            ViewBag.oceania = GetOceania();
            ViewBag.europe = GetEurope();
            return View();
        }
        public object GetDefaultData()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/defaultdata.js");
            return JsonConvert.DeserializeObject(allText);
        }
        public object GetAsia()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/asia.json");
            return JsonConvert.DeserializeObject(allText);
        }
        public object GetNorthAmerica()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/northamerica.json");
            return JsonConvert.DeserializeObject(allText);
        }
        public object GetSouthAmerica()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/southamerica.json");
            return JsonConvert.DeserializeObject(allText);
        }
        public object GetOceania()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/oceania.json");
            return JsonConvert.DeserializeObject(allText);
        }
        public object GetEurope()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/europe.json");
            return JsonConvert.DeserializeObject(allText);
        }
        public object GetAfrica()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/africa.js");
            return JsonConvert.DeserializeObject(allText);
        }
    }
}