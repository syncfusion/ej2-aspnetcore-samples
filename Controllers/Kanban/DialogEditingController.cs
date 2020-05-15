
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class KanbanController : Controller
    {
 
        public IActionResult DialogEditing()
        {

            ViewBag.data = new KanbanDataModels().KanbanTasks();
            ViewBag.status = new KanbanDataModels().DialogStatus();
            ViewBag.assignee = new KanbanDataModels().AssigneeData();
            ViewBag.priority = new KanbanDataModels().PriorityData();
            return View();
        }
    }
}
