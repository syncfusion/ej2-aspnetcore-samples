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
        public IActionResult API()
        {
            ViewBag.value = @"<p>RichTextEditor is a WYSIWYG editing control which will reduce the effort for users while trying to express their formatting word content as HTML or Markdown format.</p>
                    <p><b>API’s:</b></p>
                    <ul><li><p>maxLength - allows to restrict the maximum length to be entered.</p></li>
                    <li><p>readOnly - allows to change it as non-editable state.</p></li>
                    <li><p>enabled - enable or disable the RTE component.</p></li>
                    <li><p>enableHtmlEncode - Get the encoded string value through value property and source code panel</p></li>
                    <li><p>getValue - get the value of RTE.</p></li>
                    <li><p>getSelection - get the selected text of RTE.</p></li>
                    <li><p>selectAll - select all content in RTE.</p></li>
                    </ul>";
            return View();
        }
    }
}
