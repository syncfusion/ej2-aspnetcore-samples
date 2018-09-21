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
        public IActionResult Annotation()
        {
            ViewBag.africa = GetAfricaSingle();
            return View();
        }
        public object GetAfricaSingle()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/africasingle.js");
            return JsonConvert.DeserializeObject(allText);
        }
    }
}