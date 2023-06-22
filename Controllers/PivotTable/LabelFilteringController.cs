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

        public IActionResult LabelFiltering()
        {
            ViewBag.data = new PivotTableData().GetPivot_Data();
            ViewBag.filterFields = new string[] { "Country", "Products", "Year" };
            ViewBag.filterOperators = new string[] { "Equals", "DoesNotEquals", "BeginWith", "DoesNotBeginWith", "EndsWith",
                "DoesNotEndsWith", "Contains", "DoesNotContains", "GreaterThan",
                "GreaterThanOrEqualTo", "LessThan", "LessThanOrEqualTo", "Between", "NotBetween" };
            ViewBag.selectedOperator = "DoesNotEquals";
            return View();
        }
    }
}
