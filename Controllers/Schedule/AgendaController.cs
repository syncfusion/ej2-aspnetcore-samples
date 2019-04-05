using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {

        public IActionResult Agenda()
        {
            ViewBag.appointments = new ScheduleData().GetFifaEventsData();
            ViewBag.data = GetScrollData();
            return View();
        }
        public List<ScrollData> GetScrollData()
        {
            List<ScrollData> view = new List<ScrollData>();
            view.Add(new ScrollData { Name = "False", Value = "false" });
            view.Add(new ScrollData { Name = "True", Value = "true" });
            return view;
        }
    }
    public class ScrollData
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
