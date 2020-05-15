using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class DocumentEditorController : Controller
    {
        public IActionResult ToolbarCustomization()
        {
            List<object> exportItems = new List<object>();
            exportItems.Add(new { text = "Microsoft Word (.docx)", id = "word" });
            exportItems.Add(new { text = "Syncfusion Document Text (.sfdt)", id = "sfdt" });
            ViewBag.ExportItems = exportItems;
            ViewBag.toolbarItems = new string[] {"New", "Open", "Undo", "Redo","Comments", "Image","Table", "Hyperlink","Bookmark", "TableOfContents", "Header",  "Footer",
        "PageSetup", "PageNumber","Break","Find","LocalClipboard", "RestrictEditing" };
            return View();
        }
    }
}