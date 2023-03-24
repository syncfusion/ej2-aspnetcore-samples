#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
        List<statusData> data = new List<statusData>();
        public IActionResult SearchFilter()
        {
            ViewBag.PriorityData = new string[] { "None", "High", "Normal", "Low" };
            data.Add(new statusData { Id = "None", Value = "None" });
            data.Add(new statusData { Id = "To Do", Value = "Open" });
            data.Add(new statusData { Id = "In Progress", Value = "InProgress" });
            data.Add(new statusData { Id = "Testing", Value = "Testing" });
            data.Add(new statusData { Id = "Done", Value = "Close" });
            ViewBag.StatusData = data;
            ViewBag.data = new KanbanDataModels().KanbanTasks();
            return View();
        }
    }
    public class statusData
    {
        public string Id { get; set; }
        public string Value { get; set; }

    }
}