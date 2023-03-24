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
       
        public IActionResult InlineEditing()
        {
            var order = TreeData.GetDefaultData();
            ViewBag.dataSource = order;
            List<Object> DropDownData = new List<object>();
            DropDownData.Add(new { id = "CellEditing", name = "Cell Editing" });
            DropDownData.Add(new { id = "RowEditing", name = "Row Editing" });
            ViewBag.DropDownData = DropDownData;
            return View();
        }       
    }
}