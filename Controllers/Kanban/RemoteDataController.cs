
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class KanbanController : Controller
    {
 
        public IActionResult RemoteData()
        {
            return View();
        }
    }
}
