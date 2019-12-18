using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Gantt
{
    public partial class GanttController : Controller
    {
        public IActionResult TooltipTemplate()
        {
            ViewBag.dataSource = GanttData.TooltipData();
            ViewBag.resources = GanttData.EditingResources();
            return View();
        }
    }
}