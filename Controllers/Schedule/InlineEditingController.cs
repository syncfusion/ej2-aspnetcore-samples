using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {
        public IActionResult InlineEditing()
        {
            ScheduleData data = new ScheduleData();
            List<ScheduleData.ResourceData> resourceData = data.GetResourceData();
            List<ScheduleData.ResourceData> timelineResourceData = data.GetTimelineResourceData();
            ViewBag.datasource = resourceData.Concat(timelineResourceData);

            List<ResourceDataSourceModel> categories = new List<ResourceDataSourceModel>();
            categories.Add(new ResourceDataSourceModel { text = "Nancy", id = 1, groupId = 1, color = "#df5286" });
            categories.Add(new ResourceDataSourceModel { text = "Steven", id = 2, groupId = 1, color = "#7fa900" });
            categories.Add(new ResourceDataSourceModel { text = "Robert", id = 3, groupId = 2, color = "#ea7a57" });
            categories.Add(new ResourceDataSourceModel { text = "Smith", id = 4, groupId = 2, color = "#5978ee" });
            categories.Add(new ResourceDataSourceModel { text = "Micheal", id = 5, groupId = 3, color = "#df5286" });
            categories.Add(new ResourceDataSourceModel { text = "Root", id = 6, groupId = 3, color = "#00bdae" });
            ViewBag.Categories = categories;

            ViewBag.Resources = new string[] { "Categories" };
            return View();
        }
    }
}
