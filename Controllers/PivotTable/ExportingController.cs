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

        public IActionResult Exporting()
        {
            ViewBag.data = new PivotTableData().GetPivot_Data();
            ViewBag.exportdata = GetExportData();
            return View();
        }
        public List<DropDownData> GetExportData()
        {
            List<DropDownData> exportData = new List<DropDownData>();
            exportData.Add(new DropDownData { Name = "Excel", Value = "excel" });
            exportData.Add(new DropDownData { Name = "CSV", Value = "csv" });
            exportData.Add(new DropDownData { Name = "PDF", Value = "pdf" });
            return exportData;
        }
    }
}
