#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers.Kanban
{
    public partial class KanbanController : Controller
    {
        List<sortData> sortData = new List<sortData>();
        public IActionResult Sorting()
        {
            ViewBag.data = new KanbanDataModels().KanbanTasks();
            sortData.Add(new sortData { Id = "DataSourceOrder", Sort = "Data Source Order" });
            sortData.Add(new sortData { Id = "Index", Sort = "Index" });
            sortData.Add(new sortData { Id = "Custom", Sort = "Custom" });
            ViewBag.SortByData = sortData;
            ViewBag.FieldData = new string[] { "None" };
            ViewBag.DirectionData = new string[] { "Ascending", "Descending" };
            return View();
        }
    }
    public class sortData
    {
        public string Id { get; set; }
        public string Sort { get; set; }

    }
}