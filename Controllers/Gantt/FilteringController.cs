using System.Collections.Generic;
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Gantt;

namespace EJ2CoreSampleBrowser.Controllers.Gantt
{
    public partial class GanttController : Controller
    {
        public IActionResult Filtering()
        {
            ViewBag.dataSource = GanttData.FilteredData();
            return View();
        }
    }
}