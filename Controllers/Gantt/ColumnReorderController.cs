#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser.Controllers.Gantt
{
    public partial class GanttController : Controller
    {
        public IActionResult ColumnReorder()
        {
            ViewBag.dataSource = GanttData.ProjectNewData();

            List<object> columnNames = new List<object>();
            columnNames.Add(new { text = "ID", value = "TaskId" });
            columnNames.Add(new { text = "Task Name", value = "TaskName" });
            columnNames.Add(new { text = "Start Date", value = "StartDate" });
            columnNames.Add(new { text = "End Date", value = "EndDate" });
            columnNames.Add(new { text = "Duration", value = "Duration" });
            columnNames.Add(new { text = "Progress", value = "Progress" });
            columnNames.Add(new { text = "Dependency", value = "Predecessor" });
            ViewBag.columns = columnNames;

            List<object> ColumnsIindex = new List<object>();
            ColumnsIindex.Add(new { text = "1", value = "0" });
            ColumnsIindex.Add(new { text = "2", value = "1" });
            ColumnsIindex.Add(new { text = "3", value = "2" });
            ColumnsIindex.Add(new { text = "4", value = "3" });
            ColumnsIindex.Add(new { text = "5", value = "4" });
            ColumnsIindex.Add(new { text = "6", value = "5" });
            ColumnsIindex.Add(new { text = "7", value = "6" });
            ViewBag.indexes = ColumnsIindex;
            return View();
        }
    }
}