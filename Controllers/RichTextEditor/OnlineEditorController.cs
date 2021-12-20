using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class RichTextEditorController : Controller
    {
        // GET: /<controller>/
        public IActionResult OnlineEditor()
        {
            ViewBag.Tools = new[] { "Bold", "Italic", "Underline", "StrikeThrough",
                "FontName", "FontSize", "FontColor", "BackgroundColor",
                "LowerCase", "UpperCase", "SuperScript", "SubScript", "|",
                "Formats", "Alignments", "NumberFormatList", "BulletFormatList",
                "Outdent", "Indent", "|",
                "CreateTable", "CreateLink", "Image", "FileManager", "|", "ClearFormat", "Print",
                "SourceCode", "FullScreen", "|", "Undo", "Redo" };
            return View();
        }
    }
}
