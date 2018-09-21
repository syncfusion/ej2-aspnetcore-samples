using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class PivotViewController : Controller
    {

        public IActionResult Aggregation()
        {
            ViewBag.data = new PivotViewData().GetrenewableEnergy();
            ViewBag.drilledMembers = new string[] { "Biomass", "Free Energy" };
            ViewBag.costdata = GetCostData();
            ViewBag.unitdata = GetUnitData();
            return View();
        }

        public List<DropDownData> GetCostData()
        {
            List<DropDownData> costData = new List<DropDownData>();
            costData.Add(new DropDownData { Name = "Sum", Value = "Sum" });
            costData.Add(new DropDownData { Name = "Average", Value = "Avg" });
            costData.Add(new DropDownData { Name = "Min", Value = "Min" });
            costData.Add(new DropDownData { Name = "Max", Value = "Max" });
            return costData;
        }

        public List<DropDownData> GetUnitData()
        {
            List<DropDownData> unitData = new List<DropDownData>();
            unitData.Add(new DropDownData { Name = "Sum", Value = "Sum" });
            unitData.Add(new DropDownData { Name = "Average", Value = "Avg" });
            unitData.Add(new DropDownData { Name = "Count", Value = "Count" });
            unitData.Add(new DropDownData { Name = "Min", Value = "Min" });
            unitData.Add(new DropDownData { Name = "Max", Value = "Max" });
            return unitData;
        }
    }
}
