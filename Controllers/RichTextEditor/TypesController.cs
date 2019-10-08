using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class RichTextEditorController : Controller
    {
        // GET: /<controller>/
        public IActionResult Types()
        {
            List<Data> datasource = new List<Data>();
            datasource.Add(new Data() { text = "Expand", value = 1 });
            datasource.Add(new Data() { text = "MultiRow", value = 2 });
            ViewBag.data = datasource;
            ViewBag.items = new[] {"Bold", "Italic", "Underline", "StrikeThrough",
                "FontName", "FontSize", "FontColor", "BackgroundColor",
                "LowerCase", "UpperCase", "|",
                "Formats", "Alignments", "OrderedList", "UnorderedList",
                "Outdent", "Indent", "|",
                "CreateLink", "Image", "|", "ClearFormat", "Print",
                "SourceCode", "FullScreen", "|", "Undo", "Redo" };
            return View();
        }
    }

    public class Data
    {
        public Data()
        {
        }

        public string text { get; set; }
        public int value { get; set; }
    }
}
