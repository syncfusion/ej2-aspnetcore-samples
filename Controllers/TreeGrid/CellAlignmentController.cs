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
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Grids;

namespace EJ2CoreSampleBrowser.Controllers.Grid
{
    public partial class TreeGridController : Controller
    {

        public IActionResult CellAlignment()
        {
            var columns = new List<Object>() {
                new { id= "TaskId", name= "Task ID" },
                new { id= "StartDate", name= "Start Date" },
                new { id= "Duration", name= "Duration" },
                new { id= "Progress", name= "Progress" }
            };
            ViewBag.columns = columns;

            var indexes = new List<Object>() {
                new { id= "Right", name= "Right" },
                new { id= "Left", name= "Left" },
                new { id= "Center", name= "Center" },
                new { id= "Justify", name= "Justify" }
            };
            ViewBag.indexes = indexes;
            var order = TreeData.GetDefaultData();
            ViewBag.dataSource = order;
            return View();  
        }
    }
}