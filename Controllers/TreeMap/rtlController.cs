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