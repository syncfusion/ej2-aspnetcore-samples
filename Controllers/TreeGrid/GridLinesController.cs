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


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class TreeGridController : Controller
    {
        public IActionResult GridLines()
        {
            var order = TreeData.GetDefaultData();
            ViewBag.dataSource = order;
            ViewBag.dropdata = new List<object>() {
               new { id= "Vertical", mode= "Vertical" },
               new { id= "Horizontal", mode= "Horizontal" },
               new { id= "Both", mode= "Both" },
               new { id= "None", mode= "None" },
            };
            return View();
        }
    }
}