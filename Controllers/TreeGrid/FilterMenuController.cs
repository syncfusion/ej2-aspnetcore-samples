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
       
        public IActionResult FilterMenu()
        {
            var order = TreeData.GetDefaultData();
            ViewBag.dataSource = order;
            ViewBag.dropdata = new List<object>() {
               new { id= "Parent", mode= "Parent" },
               new { id= "Child", mode= "Child" },
               new { id= "Both", mode= "Both" },
               new { id= "None", mode= "None" },
            };
            ViewBag.typedropdata = new List<object>() {
               new { id= "Menu", type= "Menu" },
               new { id= "Excel", type= "Excel" },
            };
            return View();
        }       
    }
}