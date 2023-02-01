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

namespace EJ2CoreSampleBrowser.Controllers.TreeGrid
{
    public partial class TreeGridController : Controller
    {
        public IActionResult ColumnFormatting()
        {
            ViewBag.datasource = TreeDataFormat.GetDataFormat();
            var columns = new List<Object>() {
                new { id= "price", name= "Price" },
                new { id= "orderDate", name= "Order Date" }
            };
            ViewBag.columns = columns;

            var numberFormats = new List<Object>() {
               new { id= "n2", format= "n2" },
               new { id= "n3", format= "n3" },
               new { id= "c2", format= "c2" },
               new { id= "c3", format= "c3" },
               new { id= "p2", format= "p2" },
               new { id= "p3", format= "p3" }
            };
            ViewBag.numberFormats = numberFormats;

            var dateFormats = new List<Object>() {
               new { id= "M/d/yyyy", format= "Short Date" },
               new { id= "dddd, MMMM dd, yyyy", format= "Long Date" },
               new { id= "MMMM, yyyy", format= "Month/Year" },
               new { id= "MMMM, dd", format= "Month/Day" }
            };
            ViewBag.dateFormats = dateFormats;
            return View();
        }
    }
}