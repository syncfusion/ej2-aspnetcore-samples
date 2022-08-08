#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using System.IO;
using Syncfusion.Pdf.Interactive;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        //
        // GET: /Conformance/

        public ActionResult Conformance()
        {
             ViewBag.data=new string[] { "PDF/A-1a", "PDF/A-1b", "PDF/A-2a", "PDF/A-2b", "PDF/A-2u", "PDF/A-3a", "PDF/A-3b", "PDF/A-3u","PDF/A-4","PDF/A-4e","PDF/A-4f" };
            return View();
        }
        [HttpPost]
        public ActionResult Conformance(string InsideBrowser, string conformance)
        {
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = string.Empty;
            dataPath = basePath + @"/PDF/";

            PdfDocument document = null;

            if (conformance == "PDF/A-1a")
            {
                //Create a new document with PDF/A standard.
                document = new PdfDocument(PdfConformanceLevel.Pdf_A1A);
            }
            else if (conformance == "PDF/A-1b")
            {
                //Create a new document with PDF/A standard.
                document = new PdfDocument(PdfConformanceLevel.Pdf_A1B);
            }
            else if (conformance == "PDF/A-2a")
            {
                //Create a new document with PDF/A standard.
                document = new PdfDocument(PdfConformanceLevel.Pdf_A2A);
            }
            else if (conformance == "PDF/A-2b")
            {
                //Create a new document with PDF/A standard.
                document = new PdfDocument(PdfConformanceLevel.Pdf_A2B);
            }
            else if (conformance == "PDF/A-2u")
            {
                //Create a new document with PDF/A standard.
                document = new PdfDocument(PdfConformanceLevel.Pdf_A2U);
            }
            else if(conformance == "PDF/A-4")
            {
                //Create a new document with PDF/A standard.
                document = new PdfDocument(PdfConformanceLevel.Pdf_A4);
            }
            else if (conformance == "PDF/A-4e")
            {
                //Create a new document with PDF/A standard.
                document = new PdfDocument(PdfConformanceLevel.Pdf_A4E);
            }           
            else 
            {
                if (conformance == "PDF/A-3a")
                {
                    document = new PdfDocument(PdfConformanceLevel.Pdf_A3A);
                }
                else if (conformance == "PDF/A-3b")
                {
                    document = new PdfDocument(PdfConformanceLevel.Pdf_A3B);
                }
                else if (conformance == "PDF/A-3u")
                {
                    document = new PdfDocument(PdfConformanceLevel.Pdf_A3U);
                }
                else if (conformance == "PDF/A-4f")
                {
                    //Create PDF/A-4F conformance.
                    document = new PdfDocument(PdfConformanceLevel.Pdf_A4F);
                }
                //Read the file
                FileStream file = new FileStream(dataPath + "Text1.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                //Creates an attachment
                PdfAttachment attachment = new PdfAttachment("Text1.txt", file);
                
                attachment.Relationship = PdfAttachmentRelationship.Alternative;
                attachment.ModificationDate = DateTime.Now;

                attachment.Description = "PDF_A";

                attachment.MimeType = "application/xml";

                document.Attachments.Add(attachment);
            }

           
            //Add a page to the document.
            PdfPage page = document.Pages.Add();
            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;

            FileStream imageStream=new FileStream(dataPath + "AdventureCycle.jpg", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            //Load the image from the disk.
            PdfImage img = PdfImage.FromStream(imageStream);
            //Draw the image in the specified location and size.
            graphics.DrawImage(img, new RectangleF(150, 30, 200, 100));


            //Create font
            FileStream fontFileStream = new FileStream(dataPath + "arial.ttf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            PdfFont font = new PdfTrueTypeFont(fontFileStream, 14);

 
            PdfTextElement textElement = new PdfTextElement("Adventure Works Cycles, the fictitious company on which the AdventureWorks sample databases are based," +
                                " is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, " +
                                "European and Asian commercial markets. While its base operation is located in Bothell, Washington with 290 employees, several regional" +
                                " sales teams are located throughout their market base.")
            {
                Font = font
            };
            PdfLayoutResult layoutResult = textElement.Draw(page, new RectangleF(0, 150, page.GetClientSize().Width, page.GetClientSize().Height));

            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            document.Close();
            stream.Position = 0;
            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = "PDF_A.pdf";
            return fileStreamResult;
        }
    }
}
