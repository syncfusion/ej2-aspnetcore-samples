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
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Grids;

namespace EJ2CoreSampleBrowser.Controllers.Grid
{
    public partial class TreeGridController : Controller
    {
       
        public IActionResult SortingAPI()
        {
            var order = TreeData.GetDefaultData();
            ViewBag.dataSource = order;
            var columns = new List<object>() {
               new { id= "TaskId", name= "Task ID" },
               new { id= "TaskName", name= "Task Name" },
               new { id= "Progress", name= "Progress" },
               new { id= "Duration", name= "Duration" }
            };
            ViewBag.columnsdata = columns;
            var directions = new List<object>() {
               new { id= "Ascending", name= "Ascending" },
               new { id= "Descending", name= "Descending" }
            };
            ViewBag.directionData = directions;
            return View();
        }       
    }
}