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
        public IActionResult SortingAPI()
        {
            ViewBag.dataSource = GanttData.EditingData();
            ViewBag.data1 = DropDownList.Columns();
            ViewBag.data2 = DropDownList.Direction();
            return View();
        }
        public class DropDownList
        {
            public string id { get; set; }
            public string type { get; set; }

            public static List<DropDownList> Columns()
            {
                List<DropDownList> Data = new List<DropDownList>();
                Data.Add(new DropDownList { id = "TaskId", type = "TaskId" });
                Data.Add(new DropDownList { id = "TaskName", type = "TaskName" });
                Data.Add(new DropDownList { id = "StartDate", type = "StartDate" });
                Data.Add(new DropDownList { id = "EndDate", type = "EndDate" });
                Data.Add(new DropDownList { id = "Duration", type = "Duration" });
                Data.Add(new DropDownList { id = "Progress", type = "Progress" });
                return Data;
            }

            public static List<DropDownList> Direction()
            {
                List<DropDownList> Data = new List<DropDownList>();
                Data.Add(new DropDownList { id = "Ascending", type = "Ascending" });
                Data.Add(new DropDownList { id = "Descending", type = "Descending" });
                return Data;
            }
        }
    }
}