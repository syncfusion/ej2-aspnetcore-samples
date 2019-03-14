using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {

        public IActionResult ViewBasedSettings()
        {
            ViewBag.appointments = new ScheduleData().GetFifaEventsData();

            List<ResourceFields> Resources = new List<ResourceFields>();
            Resources.Add(new ResourceFields { GroupText = "Group A", GroupId = 1, GroupColor = "#1aaa55" });
            Resources.Add(new ResourceFields { GroupText = "Group B", GroupId = 2, GroupColor = "#357cd2" });

            ViewBag.resourceData = Resources;
            return View();
        }
    }
    public class ResourceFields
    {
        public string GroupText { set; get; }
        public int GroupId { set; get; }
        public string GroupColor { set; get; }
    }
}
