#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Threading.Tasks;
using System.Collections.Generic;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Gantt
{
    public partial class GanttController : Controller
    {
        public IActionResult ShowHide()
        {
            ViewBag.dataSource = GanttData.ProjectNewData();
            List<object> columnNames = new List<object>();
            columnNames.Add(new { text = "ID", value = "TaskId" });
            columnNames.Add(new { text = "Start Date", value = "StartDate" });
            columnNames.Add(new { text = "End Date", value = "EndDate" });
            columnNames.Add(new { text = "Duration", value = "Duration" });
            columnNames.Add(new { text = "Progress", value = "Progress" });
            columnNames.Add(new { text = "Dependency", value = "Predecessor" });
            ViewBag.columns = columnNames;
            return View();
        }
    }
}