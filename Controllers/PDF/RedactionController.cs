#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;
using System.Drawing;
using System.IO;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        public ActionResult Redaction()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Redaction(string Browser, string x, string y, string width, string height)
        {

            if (Request.Form.Files != null && Request.Form.Files.Count != 0)
            {
                float x1;
                float y1;
                float width1;
                float height1;
                if (x != null && x.Length > 0 && float.TryParse(x.ToString(), out x1) && y != null && y.Length > 0 && float.TryParse(y.ToString(), out y1) && width != null && width.Length > 0 && float.TryParse(width.ToString(), out width1) && height != null && height.Length > 0 && float.TryParse(height.ToString(), out height1))
                {
                    //Load a PDF document
                    PdfLoadedDocument ldoc = new PdfLoadedDocument(Request.Form.Files[0].OpenReadStream());
                    //Get first page from document
                    PdfLoadedPage lpage = ldoc.Pages[0] as PdfLoadedPage;

                   //Create PDF redaction for the page
		    	    PdfRedaction redaction = new PdfRedaction(new Syncfusion.Drawing.RectangleF(x1, y1, width1, height1),Syncfusion.Drawing.Color.Black);

                    //Adds the redaction to loaded page
                    lpage.AddRedaction(redaction);
                    ldoc.Redact();
                    //Save the PDF to the MemoryStream
                    MemoryStream ms = new MemoryStream();

                    ldoc.Save(ms);

                    //If the position is not set to '0' then the PDF will be empty.
                    ms.Position = 0;

                    ldoc.Close(true);
                    //Download the PDF document in the browser.
                    FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
                    fileStreamResult.FileDownloadName = "Redaction.pdf";
                    return fileStreamResult;
                }
                else
                {
                    ViewBag.lab = "Fill proper redaction bounds to redact";
                }
            }
	    else
            {
                ViewBag.lab = "Choose PDF document to redact";
            }
            return View();
        }
    }
}
