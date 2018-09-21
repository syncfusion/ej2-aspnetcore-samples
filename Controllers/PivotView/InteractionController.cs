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

        public IActionResult Interaction()
        {
            ViewBag.data = new PivotViewData().GetDefaultData();
            ViewBag.linedata = GetLinesData();
            return View();
        }

        public List<DropDownData> GetLinesData()
        {
            List<DropDownData> exportData = new List<DropDownData>();
            exportData.Add(new DropDownData { Name = "Default", Value = "Default" });
            exportData.Add(new DropDownData { Name = "Both", Value = "Both" });
            exportData.Add(new DropDownData { Name = "None", Value = "None" });
            exportData.Add(new DropDownData { Name = "Horizontal", Value = "Horizontal" });
            exportData.Add(new DropDownData { Name = "Vertical", Value = "Vertical" });
            return exportData;
        }
    }
}
