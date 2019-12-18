using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Gantt
{
    public partial class GanttController : Controller
    {
        public IActionResult ColumnTemplate()
        {
            ViewBag.dataSource = GanttData.TemplateData();
            ViewBag.projectResources = GanttData.EditingResources();
            return View();
        }
    }
}