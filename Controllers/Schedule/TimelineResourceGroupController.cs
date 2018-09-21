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
        public IActionResult TimelineResourceGroup()
        {
            ScheduleData data = new ScheduleData();
            List<ScheduleData.ResourceData> resourceData = data.GetResourceData();
            List<ScheduleData.ResourceData> timelineResourceData = data.GetTimelineResourceData();
            ViewBag.datasource = resourceData.Concat(timelineResourceData);

            List<ResourceDataSourceModel> projects = new List<ResourceDataSourceModel>();
            projects.Add(new ResourceDataSourceModel { text = "PROJECT 1", id = 1, color = "#cb6bb2" });
            projects.Add(new ResourceDataSourceModel { text = "PROJECT 2", id = 2, color = "#56ca85" });
            projects.Add(new ResourceDataSourceModel { text = "PROJECT 3", id = 3, color = "#df5286" });
            ViewBag.Projects = projects;

            List<ResourceDataSourceModel> categories = new List<ResourceDataSourceModel>();
            categories.Add(new ResourceDataSourceModel { text = "Development", id = 1, color = "#df5286" });
            categories.Add(new ResourceDataSourceModel { text = "Testing", id = 2, color = "#7fa900" });
            ViewBag.Categories = categories;

            ViewBag.Resources = new string[] { "Projects", "Categories" };
            return View();
        }
    }
}
