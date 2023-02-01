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
    public partial class PivotTableController : Controller
    {

        public IActionResult Exporting()
        {
            ViewBag.data = new PivotTableData().GetPivot_Data();
            ViewBag.exportdata = GetExportData();
            return View();
        }
        public List<DropDownData> GetExportData()
        {
            List<DropDownData> exportData = new List<DropDownData>();
            exportData.Add(new DropDownData { Name = "Excel", Value = "excel" });
            exportData.Add(new DropDownData { Name = "CSV", Value = "csv" });
            exportData.Add(new DropDownData { Name = "PDF", Value = "pdf" });
            return exportData;
        }
    }
}
