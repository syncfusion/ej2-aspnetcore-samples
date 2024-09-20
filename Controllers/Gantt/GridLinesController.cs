#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Gantt
{
    public partial class GanttController : Controller
    {
        public IActionResult GridLines()
        {
            ViewBag.dataSource = GanttData.ProjectNewData();
            ViewBag.data = DropDownLists.GridLinesData();
            return View();
        }
        public class DropDownLists
        {
            public string id { get; set; }
            public string type { get; set; }

            public static List<DropDownLists> GridLinesData()
            {
                List<DropDownLists> Data = new List<DropDownLists>();
                Data.Add(new DropDownLists { id = "Both", type = "Both" });
                Data.Add(new DropDownLists { id = "Vertical", type = "Vertical" });
                Data.Add(new DropDownLists { id = "Horizontal", type = "Horizontal" });
                Data.Add(new DropDownLists { id = "None", type = "None" });
                return Data;
            }
        }
    }
}