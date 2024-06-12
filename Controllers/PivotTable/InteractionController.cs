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
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class PivotTableController : Controller
    {

        public IActionResult Interaction()
        {
            ViewBag.data = new PivotTableData().GetDefaultData();
            ViewBag.linedata = GetLinesData();
            return View();
        }

        public List<DropDownData> GetLinesData()
        {
            List<DropDownData> exportData = new List<DropDownData>();
            exportData.Add(new DropDownData { Name = "Default", Value = "Default" });
            exportData.Add(new DropDownData { Name = "Both", Value = "Both" });
            exportData.Add(new DropDownData { Name = "None", Value = "None" });
            exportData.Add(new DropDownData { Name = "Horizontal", Value = "Horizontal" });
            exportData.Add(new DropDownData { Name = "Vertical", Value = "Vertical" });
            return exportData;
        }
    }
}
