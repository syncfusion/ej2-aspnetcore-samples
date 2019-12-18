using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers
{
    public class RichTextEditorModel
    {
        [Required(ErrorMessage = "Value is required")]
        public string Value { get; set; }
    }
    public partial class RichTextEditorController : Controller
    { 
        RichTextEditorModel rteModel = new RichTextEditorModel();
        public IActionResult RichTextEditorFor()
        {
            rteModel.Value = "<p>Type or edit the content to post the <b>Rich Text Editor</b> value.</p>";
            return View(rteModel);
        }
        [HttpPost]
        public IActionResult RichTextEditorFor(RichTextEditorModel model)
        {
            rteModel.Value = model.Value;
            return View(rteModel);
        }
    }
}