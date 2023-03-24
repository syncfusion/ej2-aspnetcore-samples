#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
        public IActionResult ProgrammaticZoom()
        {
            ViewBag.world = getWorldMap();
            ViewBag.markerLocation = getMarkerLocation();
            return View();
        }
        public object getWorldMap()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/WorldMap.json");
            return JsonConvert.DeserializeObject(allText);
        }
        public object getMarkerLocation()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/SouthAmericanCountryCapitals.js");
            return JsonConvert.DeserializeObject(allText);
        }
    }
}