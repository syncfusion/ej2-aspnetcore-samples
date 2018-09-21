using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {

        public IActionResult Group()
        {
            List<AirlineRes> airlines = new List<AirlineRes>();
            airlines.Add(new AirlineRes { AirlineName = "Airways 1", AirlineId = 1, AirlineColor = "#EA7A57" });
            airlines.Add(new AirlineRes { AirlineName = "Airways 2", AirlineId = 2, AirlineColor = "#357cd2" });
            airlines.Add(new AirlineRes { AirlineName = "Airways 3", AirlineId = 3, AirlineColor = "#7fa900" });
            ViewBag.Airlines = airlines;

            string[] resources = new string[] { "Airlines" };
            ViewBag.Resources = resources;
            return View();
        }
    }
    public class AirlineRes
    {
        public string AirlineName { set; get; }
        public int AirlineId { set; get; }
        public string AirlineColor { set; get; }
    }
}
