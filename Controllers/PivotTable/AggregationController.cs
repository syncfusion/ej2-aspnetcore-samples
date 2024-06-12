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

        public IActionResult Aggregation()
        {
            ViewBag.data = new PivotTableData().GetrenewableEnergy();
            ViewBag.drilledMembers = new string[] { "Biomass", "Free Energy" };
            ViewBag.costdata = GetCostData();
            ViewBag.unitdata = GetUnitData();
            return View();
        }

        public List<DropDownData> GetCostData()
        {
            List<DropDownData> costData = new List<DropDownData>();
            costData.Add(new DropDownData { Name = "Sum", Value = "Sum" });
            costData.Add(new DropDownData { Name = "Avg", Value = "Average" });
            costData.Add(new DropDownData { Name = "Median", Value = "Median" });
            costData.Add(new DropDownData { Name = "Min", Value = "Min" });
            costData.Add(new DropDownData { Name = "Max", Value = "Max" });
            costData.Add(new DropDownData { Name = "Product", Value = "Product" });
            costData.Add(new DropDownData { Name = "Index", Value = "Index" });
            costData.Add(new DropDownData { Name = "PopulationStDev", Value = "Population StDev" });
            costData.Add(new DropDownData { Name = "SampleStDev", Value = "Sample StDev" });
            costData.Add(new DropDownData { Name = "PopulationVar", Value = "Population Var" });
            costData.Add(new DropDownData { Name = "SampleVar", Value = "Sample Var" });
            costData.Add(new DropDownData { Name = "RunningTotals", Value = "Running Totals" });
            costData.Add(new DropDownData { Name = "DifferenceFrom", Value = "Difference From" });
            costData.Add(new DropDownData { Name = "PercentageOfDifferenceFrom", Value = "% of Difference From" });
            costData.Add(new DropDownData { Name = "PercentageOfGrandTotal", Value = "% of Grand Total" });
            costData.Add(new DropDownData { Name = "PercentageOfColumnTotal", Value = "% of Column Total" });
            costData.Add(new DropDownData { Name = "PercentageOfRowTotal", Value = "% of Row Total" });
            costData.Add(new DropDownData { Name = "PercentageOfParentTotal", Value = "% of Parent Total" });
            costData.Add(new DropDownData { Name = "PercentageOfParentColumnTotal", Value = "% of Parent Column Total" });
            costData.Add(new DropDownData { Name = "PercentageOfParentRowTotal", Value = "% of Parent Row Total" });
            return costData;
        }

        public List<DropDownData> GetUnitData()
        {
            List<DropDownData> unitData = new List<DropDownData>();
            unitData.Add(new DropDownData { Name = "Sum", Value = "Sum" });
            unitData.Add(new DropDownData { Name = "Avg", Value = "Average" });
            unitData.Add(new DropDownData { Name = "Median", Value = "Median" });
            unitData.Add(new DropDownData { Name = "Count", Value = "Count" });
            unitData.Add(new DropDownData { Name = "Min", Value = "Min" });
            unitData.Add(new DropDownData { Name = "Max", Value = "Max" });
            unitData.Add(new DropDownData { Name = "DistinctCount", Value = "Distinct Count" });
            unitData.Add(new DropDownData { Name = "Product", Value = "Product" });
            unitData.Add(new DropDownData { Name = "Index", Value = "Index" });
            unitData.Add(new DropDownData { Name = "PopulationStDev", Value = "Population StDev" });
            unitData.Add(new DropDownData { Name = "SampleStDev", Value = "Sample StDev" });
            unitData.Add(new DropDownData { Name = "PopulationVar", Value = "Population Var" });
            unitData.Add(new DropDownData { Name = "SampleVar", Value = "Sample Var" });
            unitData.Add(new DropDownData { Name = "RunningTotals", Value = "Running Totals" });
            unitData.Add(new DropDownData { Name = "DifferenceFrom", Value = "Difference From" });
            unitData.Add(new DropDownData { Name = "PercentageOfDifferenceFrom", Value = "% of Difference From" });
            unitData.Add(new DropDownData { Name = "PercentageOfGrandTotal", Value = "% of Grand Total" });
            unitData.Add(new DropDownData { Name = "PercentageOfColumnTotal", Value = "% of Column Total" });
            unitData.Add(new DropDownData { Name = "PercentageOfRowTotal", Value = "% of Row Total" });
            unitData.Add(new DropDownData { Name = "PercentageOfParentTotal", Value = "% of Parent Total" });
            unitData.Add(new DropDownData { Name = "PercentageOfParentColumnTotal", Value = "% of Parent Column Total" });
            unitData.Add(new DropDownData { Name = "PercentageOfParentRowTotal", Value = "% of Parent Row Total" });
            return unitData;
        }
    }
}
