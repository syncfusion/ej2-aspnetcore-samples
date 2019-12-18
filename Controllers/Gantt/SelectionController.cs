using System.Collections.Generic;
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Gantt
{
    public partial class GanttController : Controller
    {
        public IActionResult Selection()
        {
            ViewBag.dataSource = GanttData.ProjectNewData();
            ViewBag.data1 = DropDownListData1.SelectionModeList();
            ViewBag.data2 = DropDownListData1.SelectionTypeList();
            ViewBag.data3 = DropDownListData2.ToggleList();
            return View();
        }
        public class DropDownListData1
        {
            public string id { get; set; }
            public string type { get; set; }

            public static List<DropDownListData1> SelectionModeList()
            {
                List<DropDownListData1> Data = new List<DropDownListData1>();
                Data.Add(new DropDownListData1 { id = "Row", type = "Row" });
                Data.Add(new DropDownListData1 { id = "Cell", type = "Cell" });
                return Data;
            }

            public static List<DropDownListData1> SelectionTypeList()
            {
                List<DropDownListData1> Data = new List<DropDownListData1>();
                Data.Add(new DropDownListData1 { id = "Single", type = "Single" });
                Data.Add(new DropDownListData1 { id = "Multiple", type = "Multiple" });
                return Data;
            }
        }
        public class DropDownListData2
        {
            public bool id { get; set; }
            public string type { get; set; }

            public static List<DropDownListData2> ToggleList()
            {
                List<DropDownListData2> Data = new List<DropDownListData2>();
                Data.Add(new DropDownListData2 { id = true, type = "Enable" });
                Data.Add(new DropDownListData2 { id = false, type = "Disable" });
                return Data;
            }
        }
    }
}