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
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class PivotTableController : Controller
    {

        public IActionResult CustomSorting()
        {
            ViewBag.data = new PivotTableData().GetPivot_Data();
            ViewBag.drilledMembers = new string[] { "Germany" };
            ViewBag.sortSettings = new string[] { "France", "United States" };
            ViewBag.sortSettings_1 = new string[] { "FY 2018", "FY 2017" };
            ViewBag.sortSettings_2 = new string[] { "Gloves", "Bottles and Cages" };
            return View();
        }
    }
}
