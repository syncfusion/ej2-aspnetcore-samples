#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Gantt
{
    public partial class GanttController : Controller
    {
        public IActionResult OverView()
        {
            ViewBag.dataSource = GanttData.OverviewData();
            ViewBag.projectResources = GanttData.EditingResources();
            ViewBag.data = GanttDropDownLists.ViewData();
            return View();
        }
        public class GanttDropDownLists
        {
            public string id { get; set; }
            public string type { get; set; }

            public static List<GanttDropDownLists> ViewData()
            {
                List<GanttDropDownLists> Data = new List<GanttDropDownLists>();
                Data.Add(new GanttDropDownLists { id = "Default", type = "Default" });
                Data.Add(new GanttDropDownLists { id = "Grid", type = "Grid" });
                Data.Add(new GanttDropDownLists { id = "Chart", type = "Chart" });
                return Data;
            }
        }
    }
}