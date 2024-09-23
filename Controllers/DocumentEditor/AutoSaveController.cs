using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class DocumentEditorController : Controller
    {
        public IActionResult AutoSave()
        {
            List<object> exportItems = new List<object>();
            exportItems.Add(new { text = "Syncfusion Document Text (*.sfdt)", id = "sfdt" });
            exportItems.Add(new { text = "Word Document (*.docx)", id = "word" });
            exportItems.Add(new { text = "Word Template (*.dotx)", id = "dotx" });
            exportItems.Add(new { text = "Plain Text (*.txt)", id = "txt" });
            ViewBag.ExportItems = exportItems;
            return View();
        }
    }
}