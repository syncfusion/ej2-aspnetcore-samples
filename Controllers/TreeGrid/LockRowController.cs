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
       
        public IActionResult LockRow()
        {
            var order = TreeData.GetDefaultData();
            ViewBag.dataSource = order;
            List<Object> dropdata = new List<Object>();
            for(var i = 1; i <= 36; i++) {
                dropdata.Add(new { text = i.ToString(), value = i });
            }
            ViewBag.dropdata = dropdata;
            return View();
        }       
    }
}