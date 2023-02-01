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
        public IActionResult DrillDown()
        {
            ViewBag.data = new PivotTableData().GetPivot_Data();
            ViewBag.drillDownOptions = new DrillDownOptions().GetDrillDownOptions();
            ViewBag.drillDownFields = new DrillDownFields().GetDrillDownFields();
            ViewBag.selectedOption = "rowHeaders";
            ViewBag.selectedField = "Country";
            ViewBag.drillDownValues = new List<object>();
            return View();
        }
        public class DrillDownOptions
        {
            public string value { get; set; }
            public string text { get; set; }
            public List<DrillDownOptions> GetDrillDownOptions()
            {
                List<DrillDownOptions> drillDownOptions = new List<DrillDownOptions>();
                drillDownOptions.Add(new DrillDownOptions { value = "allHeaders", text = "All headers" });
                drillDownOptions.Add(new DrillDownOptions { value = "rowHeaders", text = "Row headers" });
                drillDownOptions.Add(new DrillDownOptions { value = "columnHeader", text = "Column headers" });
                drillDownOptions.Add(new DrillDownOptions { value = "specificFields", text = "Specific fields" });
                drillDownOptions.Add(new DrillDownOptions { value = "specificHeaders", text = "Specific headers" });
                return drillDownOptions;
            }
        }
        public class DrillDownFields
        {
            public string Field { get; set; }
            public bool expandAll { get; set; }
            public List<DrillDownFields> GetDrillDownFields()
            {
                List<DrillDownFields> drillDownFields = new List<DrillDownFields>();
                drillDownFields.Add(new DrillDownFields { Field = "Country", expandAll = false });
                drillDownFields.Add(new DrillDownFields { Field = "Year", expandAll = false });
                return drillDownFields;
            }
        }
    }
}
