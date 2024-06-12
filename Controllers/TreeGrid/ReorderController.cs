#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
       
        public IActionResult Reorder()
        {
            var columns = new List<Object>() {
                new { id= "TaskId", name= "Task ID" },
                new { id= "TaskName", name= "Task Name" },
                new { id= "StartDate", name= "Start Date" },
                new { id= "Duration", name= "Duration" },
                new { id= "Progress", name= "Progress" }
            };
            ViewBag.columns = columns;

            var indexes = new List<Object>() {
               new { id= 0, index= 1 },
               new { id= 1, index= 2 },
               new { id= 2, index= 3 },
               new { id= 3, index= 4 },
               new { id= 4, index= 5 }
            };
            ViewBag.indexes = indexes;
            var order = TreeData.GetDefaultData();
            ViewBag.dataSource = order;
            return View();
        }       
    }
}