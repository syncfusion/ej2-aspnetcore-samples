#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
    public partial class MapsController : Controller
    {
        public IActionResult MultiLayer()
        {
            ViewBag.mapdata = getusMap();
            ViewBag.texas = TexasMap();
            ViewBag.california = CaliforniaMap();
            return View();
        }
        public object GetWroldContinentMap()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/world_continent.js");
            return JsonConvert.DeserializeObject(allText);
        }
        public object TexasMap()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/texas.json");
            return JsonConvert.DeserializeObject(allText);
        }
        public object CaliforniaMap()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/california.json");
            return JsonConvert.DeserializeObject(allText);
        }
    }
}