using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;
using System.Collections.Generic;
using System.Linq;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {
        // GET: /<controller>/
        public IActionResult MultipleDrag()
        {
            ScheduleData data = new ScheduleData();
            List<ScheduleData.ResourceData> resourceData = data.GetResourceData();
            List<ScheduleData.ResourceData> timelineResourceData = data.GetTimelineResourceData();
            ViewBag.datasource = resourceData.Concat(timelineResourceData);
            List<ResourceDataSourceModel> categories = new List<ResourceDataSourceModel>();
            categories.Add(new ResourceDataSourceModel { text = "Nancy", id = 1, color = "#df5286" });
            categories.Add(new ResourceDataSourceModel { text = "Steven", id = 2, color = "#7fa900" });
            categories.Add(new ResourceDataSourceModel { text = "Robert", id = 3, color = "#ea7a57" });
            categories.Add(new ResourceDataSourceModel { text = "Smith", id = 4, color = "#5978ee" });
            categories.Add(new ResourceDataSourceModel { text = "Michael", id = 5, color = "#df5286" });
            categories.Add(new ResourceDataSourceModel { text = "Root", id = 6, color = "#00bdae" });
            ViewBag.Owners = categories;
            string[] resources = new string[] { "Owners" };
            ViewBag.Resources = resources;
            return View();
        }
    }
}
