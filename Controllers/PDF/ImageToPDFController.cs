#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
using System.Collections.Generic;
using System.Linq;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        public ActionResult ImageToPDF()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImageToPDF(string Browser, string pageSize, string pageOrientation, string margin)
        {
            if (Request.Form.Files != null && Request.Form.Files.Count != 0)
            {
                //Create a new PDF document
                PdfDocument document = new PdfDocument();

                for (int i = 0; i < Request.Form.Files.Count; i++)
                {
                    if (Request.Form.Files[i].ContentType.Contains("image/"))
                    {
                        //Load the image from the file
                        Stream imageStream = Request.Form.Files[i].OpenReadStream();

                        PdfTiffImage image = new PdfTiffImage(imageStream);

                        PdfSection section = document.Sections.Add();

                        SizeF pageSizeF = GetPdfPageSize(pageSize);

                        //Set the page size
                        section.PageSettings.Size = pageSizeF == SizeF.Empty ? image.PhysicalDimension : pageSizeF;

                        if (pageOrientation != "Default")
                        {
                            //Set the page orientation
                            section.PageSettings.Orientation = pageOrientation == "Portrait" ? PdfPageOrientation.Portrait : PdfPageOrientation.Landscape;
                        }
                        //Set the page margins
                        section.PageSettings.Margins.All = GetPdfMargin(margin);

                        //Create a new PDF page
                        PdfPage page = section.Pages.Add();

                        //Draw the image on the PDF page
                        page.Graphics.DrawImage(image, 0, 0, page.GetClientSize().Width, page.GetClientSize().Height);

                        //Close the image stream
                        imageStream.Dispose();
                    }
                }
                //Create a new memory stream

                MemoryStream stream = new MemoryStream();

                //Save the PDF document
                document.Save(stream);

                stream.Position = 0;

                //Close the PDF document
                document.Close(true);

                //Download the PDF document in the browser.
                FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
                fileStreamResult.FileDownloadName = "ImageToPDF.pdf";
                return fileStreamResult;
            }
            else
            {
                ViewBag.lab = "Choose a valid image files to convert into PDF document.";
                return View();            
            }
        }
        private SizeF GetPdfPageSize(string pageSize)
        {
            switch (pageSize)
            {
                case "A4":
                    return PdfPageSize.A4;
                case "Letter":
                    return PdfPageSize.Letter;
                default:
                    return SizeF.Empty;
            }
        }
        private float GetPdfMargin(string margin)
        {
            switch (margin)
            {
                case "Small":
                    return 20;
                case "Large":
                    return 40;
                default:
                    return 0;
            }
        }
    }
}
