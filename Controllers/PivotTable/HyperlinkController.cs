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

        public IActionResult Hyperlink()
        {
            ViewBag.data = new PivotTableData().GetPivot_Data();
            ViewBag.drilledMembers = new string[] { "France", "Germany" };
            ViewBag.hyperLinkOptions = GetOptions();
            ViewBag.hyperLinkMeasures = GetMeasures();
            ViewBag.hyperLinkConditions = new string[] { "Equals", "NotEquals", "GreaterThan", "GreaterThanOrEqualTo", "LessThan", 
                "LessThanOrEqualTo", "Between", "NotBetween" };
            ViewBag.selectedOption = "valuecells";
            ViewBag.selectedMeasure = "In_Stock";
            ViewBag.selectedCondition = "NotEquals";
            return View();
        }
        public List<HyperOptions> GetOptions()
        {
            List<HyperOptions> hyperOptions = new List<HyperOptions>();
            hyperOptions.Add(new HyperOptions { value = "allcells", text = "All cells" });
            hyperOptions.Add(new HyperOptions { value = "rowheader", text = "Row headers" });
            hyperOptions.Add(new HyperOptions { value = "columnheader", text = "Column headers" });
            hyperOptions.Add(new HyperOptions { value = "valuecells", text = "Value cells" });
            hyperOptions.Add(new HyperOptions { value = "summarycells", text = "Summary cells" });
            hyperOptions.Add(new HyperOptions { value = "conditional", text = "Condition based option" });
            hyperOptions.Add(new HyperOptions { value = "headertext", text = "Header based option" });
            return hyperOptions;
        }
        public List<HyperMeasures> GetMeasures()
        {
            List<HyperMeasures> hyperMeasures = new List<HyperMeasures>();
            hyperMeasures.Add(new HyperMeasures { value = "In_Stock", text = "In Stock" });
            hyperMeasures.Add(new HyperMeasures { value = "Sold", text = "Units Sold" });
            hyperMeasures.Add(new HyperMeasures { value = "Amount", text = "Sold Amount" });
            return hyperMeasures;
        }
        public class HyperOptions
        {
            public string value { get; set; }
            public string text { get; set; }
        }
        public class HyperMeasures
        {
            public string value { get; set; }
            public string text { get; set; }
        }
    }
}
