using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers {
    public partial class DocumentEditorController : Controller
    {
        public ActionResult Default()
        {
            return View();
        }

        public ActionResult DefaultFunctionality()
        {
            List < object > exportItems = new List<object>();
            exportItems.Add(new { text = "Microsoft Word (.docx)", id = "word" });
            exportItems.Add(new { text = "Syncfusion Document Text (.sfdt)", id = "sfdt" });
            ViewBag.ExportItems = exportItems;

            List < object > zoomItems = new List<object>();
            zoomItems.Add(new { text = "200%" });
            zoomItems.Add(new { text = "175%" });
            zoomItems.Add(new { text = "150%" });
            zoomItems.Add(new { text = "125%" });
            zoomItems.Add(new { text = "100%" });
            zoomItems.Add(new { text = "75%" });
            zoomItems.Add(new { text = "50%" });
            zoomItems.Add(new { text = "25%" });
            zoomItems.Add(new { separator = true });
            zoomItems.Add(new { text = "Fit one page" });
            zoomItems.Add(new { text = "Fit page width" });
            ViewBag.zoomList = zoomItems;

            return PartialView();
        }
    }
}
