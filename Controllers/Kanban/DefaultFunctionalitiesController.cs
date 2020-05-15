
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class KanbanController : Controller
    {
 
        public IActionResult DefaultFunctionalities()
        {
            ViewBag.data = new KanbanDataModels().KanbanTasks();
            return View();
        }
    }
}
