#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Syncfusion.Pdf.Parsing;
using EJ2CoreSampleBrowser.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        // GET: /FindText/
        public IActionResult FindText()
        {
            FindTextMessage message = new FindTextMessage();
            message.Message = string.Empty;
            return View("FindText", message);
        }

        [HttpPost]
        public IActionResult FindText(string ViewTemplate, string Find)
        {
            string basePath = _hostingEnvironment.WebRootPath;
            FileStream fileStreamInput = new FileStream(basePath + @"/PDF/Manual.pdf", FileMode.Open, FileAccess.Read);
            if (!string.IsNullOrEmpty(ViewTemplate))
            {
                FileStreamResult fileStreamResult = new FileStreamResult(fileStreamInput, "application/pdf");
                fileStreamResult.FileDownloadName = "Manual.pdf";
                return fileStreamResult;
            }
            else if (!string.IsNullOrEmpty(Find))
            {
                PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStreamInput);
                Dictionary<int, List<Syncfusion.Drawing.RectangleF>> matchRects = new Dictionary<int, List<Syncfusion.Drawing.RectangleF>>();
                loadedDocument.FindText("document", out matchRects);
                FindTextMessage message = new FindTextMessage();
                for (int i = 0; i < loadedDocument.Pages.Count;)
                {
                    List<Syncfusion.Drawing.RectangleF> rectCoords = matchRects[i];
                    message.Message = "First Occurrence: X:" + rectCoords[0].X + "; Y:" + rectCoords[0].Y + "; Width:" + rectCoords[0].Width+"; Height:" + rectCoords[0].Height + Environment.NewLine +
                        "Second Occurrence: X:" + rectCoords[1].X + "; Y:" + rectCoords[1].Y + "; Width:" + rectCoords[1].Width + "; Height:" + rectCoords[1].Height + Environment.NewLine +
                        "Third Occurrence: X:" + rectCoords[2].X + "; Y:" + rectCoords[2].Y + "; Width:" + rectCoords[2].Width + "; Height:" + rectCoords[2].Height + Environment.NewLine +
                        "Fourth Occurrence: X:" + rectCoords[3].X + "; Y:" + rectCoords[3].Y + "; Width:" + rectCoords[3].Width + "; Height:" + rectCoords[3].Height + Environment.NewLine;
                    return View("FindText", message);
                }
            }
            return View("FindText");
        }
    }
}
