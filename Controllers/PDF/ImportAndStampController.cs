#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        //
        // GET: /ImportAndStamp/

        public ActionResult ImportAndStamp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImportAndStamp(string Browser, string Stamptext, IFormFile file)
        {
            PdfLoadedDocument ldoc = null;
            if (file != null && file.Length > 0)
            {
                ldoc = new PdfLoadedDocument(file.OpenReadStream());

                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 36f);

                foreach (PdfPageBase lPage in ldoc.Pages)
                {
                    PdfGraphics graphics = lPage.Graphics;
                    PdfGraphicsState state = graphics.Save();
                    graphics.SetTransparency(0.25f);
                    graphics.RotateTransform(-40);
                    graphics.DrawString(Stamptext, font, PdfPens.Red, PdfBrushes.Red, new PointF(-150, 450));
                    graphics.Restore(state);
                }
            }
            else 
            {
                ViewBag.lab = "NOTE: Please select PDF document.";
                return View();
            }

            MemoryStream stream = new MemoryStream();

            //Save the PDF document
            ldoc.Save(stream);

            stream.Position = 0;

            //Close the PDF document
            ldoc.Close(true);

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = "Stamp.pdf";
            return fileStreamResult;
        }
    }
}
