using System.Collections.Generic;
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Gantt
{
    public partial class GanttController : Controller
    {
        public IActionResult GridLines()
        {
            ViewBag.dataSource = GanttData.ProjectNewData();
            ViewBag.data = DropDownLists.GridLinesData();
            return View();
        }
        public class DropDownLists
        {
            public string id { get; set; }
            public string type { get; set; }

            public static List<DropDownLists> GridLinesData()
            {
                List<DropDownLists> Data = new List<DropDownLists>();
                Data.Add(new DropDownLists { id = "Both", type = "Both" });
                Data.Add(new DropDownLists { id = "Vertical", type = "Vertical" });
                Data.Add(new DropDownLists { id = "Horizontal", type = "Horizontal" });
                Data.Add(new DropDownLists { id = "None", type = "None" });
                return Data;
            }
        }
    }
}