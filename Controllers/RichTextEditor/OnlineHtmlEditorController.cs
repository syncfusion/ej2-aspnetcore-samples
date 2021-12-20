using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class RichTextEditorController : Controller
    {
        // GET: /<controller>/
        public IActionResult OnlineHtmlEditor()
        {
            return View();
        }
    }
}
