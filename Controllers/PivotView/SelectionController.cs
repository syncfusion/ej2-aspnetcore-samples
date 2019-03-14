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

        public IActionResult Selection()
        {
            ViewBag.data = new PivotViewData().GetPivot_Data();
            ViewBag.modeData = GetModes();
            ViewBag.typeData = GetTypes();
            return View();
        }
        public List<DropDownData> GetModes()
        {
            List<DropDownData> unitData = new List<DropDownData>();
            unitData.Add(new DropDownData { Value = "Cell", Name = "Cell" });
            unitData.Add(new DropDownData { Value = "Row", Name = "Row Only" });
            unitData.Add(new DropDownData { Value = "Column", Name = "Column Only" });
            unitData.Add(new DropDownData { Value = "Both", Name = "Both" });            
            return unitData;
        }
        public List<DropDownData> GetTypes()
        {
            List<DropDownData> unitData = new List<DropDownData>();
            unitData.Add(new DropDownData { Name = "Single", Value = "Single" });
            unitData.Add(new DropDownData { Name = "Multiple", Value = "Multiple" });
            return unitData;
        }
    }
}
