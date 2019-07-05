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

        public IActionResult SummaryCustomization()
        {
            ViewBag.data = new PivotTableData().GetPivot_Data();
            ViewBag.drilledMembers = new string[] { "France" };
            ViewBag.filterMembers = new string[] { "Gloves", "Helmets", "Shorts", "Vests" };
            ViewBag.fielddata = new Fields().FieldList();
            return View();
        }
    }

    public class Fields
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Fields> FieldList()
        {
            List<Fields> fields = new List<Fields>();
            fields.Add(new Fields { Name = "Country" });
            fields.Add(new Fields { Name = "Year" });
            return fields;
        }
    }
}
