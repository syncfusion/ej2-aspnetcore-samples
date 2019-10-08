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

        public IActionResult PivotChart()
        {
            ViewBag.data = new PivotTableData().GetPivot_Data();
            ViewBag.chartTypes = GetChartTypes();
            return View();
        }

        public List<DropDownData> GetChartTypes()
        {
            List<DropDownData> unitData = new List<DropDownData>();
            unitData.Add(new DropDownData { Name = "Line", Value = "Line" });
            unitData.Add(new DropDownData { Name = "Column", Value = "Column" });
            unitData.Add(new DropDownData { Name = "Bar", Value = "Bar" });
            unitData.Add(new DropDownData { Name = "Spline", Value = "Spline" });
            unitData.Add(new DropDownData { Name = "Area", Value = "Area" });
            unitData.Add(new DropDownData { Name = "SplineArea", Value = "SplineArea" });
            unitData.Add(new DropDownData { Name = "StepLine", Value = "StepLine" });
            unitData.Add(new DropDownData { Name = "StepArea", Value = "StepArea" });
            unitData.Add(new DropDownData { Name = "StackingColumn", Value = "StackingColumn" });
            unitData.Add(new DropDownData { Name = "StackingBar", Value = "StackingBar" });
            unitData.Add(new DropDownData { Name = "StackingArea", Value = "StackingArea" });
            unitData.Add(new DropDownData { Name = "StackingColumn100", Value = "StackingColumn100" });
            unitData.Add(new DropDownData { Name = "StackingBar100", Value = "StackingBar100" });
            unitData.Add(new DropDownData { Name = "StackingArea100", Value = "StackingArea100" });
            unitData.Add(new DropDownData { Name = "Scatter", Value = "Scatter" });
            unitData.Add(new DropDownData { Name = "Bubble", Value = "Bubble" });
            unitData.Add(new DropDownData { Name = "Pareto", Value = "Pareto" });
            return unitData;
        }
    }
}
