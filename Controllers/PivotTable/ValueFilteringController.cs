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
        public IActionResult ValueFiltering()
        {
            ViewBag.data = new PivotTableData().GetPivot_Data();
            ViewBag.filterFields = new string[] { "Country", "Products", "Year" };
            ViewBag.filterOperators = new string[] { "Equals", "DoesNotEquals", "GreaterThan", "GreaterThanOrEqualTo",
            "LessThan", "LessThanOrEqualTo", "Between", "NotBetween" };
            ViewBag.filterMeasures = new ValueFilterMeasures().GetValueFilterMeasures();
            ViewBag.selectedMeasure = "In_Stock";
            ViewBag.selectedOperator = "DoesNotEquals";
            return View();
        }
    }
    public class ValueFilterMeasures
    {
        public string value { get; set; }
        public string text { get; set; }
        public List<ValueFilterMeasures> GetValueFilterMeasures()
        {
            List<ValueFilterMeasures> filterMeasures = new List<ValueFilterMeasures>();
            filterMeasures.Add(new ValueFilterMeasures { value = "In_Stock", text = "In Stock" });
            filterMeasures.Add(new ValueFilterMeasures { value = "Sold", text = "Units Sold" });
            filterMeasures.Add(new ValueFilterMeasures { value = "Amount", text = "Sold Amount" });
            return filterMeasures;
        }
    }  
}
