#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        public ActionResult TiffToPDF()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TiffToPDF(string viewTemplate, string createPDF)
        {
            string dataPath = _hostingEnvironment.WebRootPath + @"/PDF/";

            //Load TIFF image to stream
            FileStream imageFileStream = new FileStream(dataPath + "image.tiff", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            if (viewTemplate == "View Template")
            {
                return File(imageFileStream, "application/image", "image.tiff");
            }
            else if (createPDF == "Generate PDF")
            {
                //Create a new PDF document
                PdfDocument document = new PdfDocument();

                //Set margin to the page
                document.PageSettings.Margins.All = 0;

                //Load Multiframe Tiff image
                PdfTiffImage tiffImage = new PdfTiffImage(imageFileStream);

                //Get the frame count
                int frameCount = tiffImage.FrameCount;

                //Access each frame and draw into the page
                for (int i = 0; i < frameCount; i++)
                {
                    //Add new page for each frames
                    PdfPage page = document.Pages.Add();

                    //Get page graphics
                    PdfGraphics graphics = page.Graphics;

                    //Set active frame.
                    tiffImage.ActiveFrame = i;

                    //Draw Tiff image into page
                    graphics.DrawImage(tiffImage, 0, 0, page.GetClientSize().Width, page.GetClientSize().Height);

                }

                //Save PDF document
                MemoryStream stream = new MemoryStream();

                document.Save(stream);

                //Close the PDF document
                document.Close(true);

                stream.Position = 0;

                //Download the PDF document in the browser.
                FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
                fileStreamResult.FileDownloadName = "TiffToPDF.pdf";
                return fileStreamResult;
            }
            else
                return View();
        }

    }
}
