
using System;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Microsoft.AspNetCore.Http;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        //
        // GET: /DigitalSignature/

        public ActionResult DigitalSignature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DigitalSignature(string Browser, string password, string Reason, string Location, string Contact, string RadioButtonList2, string NewPDF, string submit, IFormFile pdfdocument, IFormFile certificate)
        {
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = string.Empty;
            dataPath = basePath + @"/PDF/";

            if (submit == "Create Sign PDF")
            {
                if (pdfdocument != null && pdfdocument.Length > 0 && certificate != null && certificate.Length > 0 && certificate.FileName.Contains(".pfx") && password != null && Location != null && Reason != null && Contact != null)
                {
                    PdfLoadedDocument ldoc = new PdfLoadedDocument(pdfdocument.OpenReadStream());
                    PdfCertificate pdfCert = new PdfCertificate(certificate.OpenReadStream(), password);                   
                    PdfPageBase page = ldoc.Pages[0];
                    PdfSignature signature = new PdfSignature(ldoc, page, pdfCert, "Signature");
                    signature.Bounds = new RectangleF(new PointF(5, 5), new SizeF(200,200));
                    signature.ContactInfo = Contact;
                    signature.LocationInfo = Location;
                    signature.Reason = Reason;
                    MemoryStream stream = new MemoryStream();
                    ldoc.Save(stream);
                    stream.Position = 0;
                    ldoc.Close(true);

                    //Download the PDF document in the browser.
                    FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
                    fileStreamResult.FileDownloadName = "SignedPDF.pdf";
                    return fileStreamResult;
                    return View();
                }
                else
                {
                    ViewBag.lab = "NOTE: Fill all fields and then create PDF";
                    return View();
                }
            }
            else
            {
                //Read the PFX file
                FileStream pfxFile = new FileStream(dataPath + "PDF.pfx", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                PdfDocument doc = new PdfDocument();
                PdfPage page = doc.Pages.Add();
                PdfSolidBrush brush = new PdfSolidBrush(Color.Black);
                PdfPen pen = new PdfPen(brush, 0.2f);
                PdfFont font = new PdfStandardFont(PdfFontFamily.Courier, 12, PdfFontStyle.Regular);
                PdfCertificate pdfCert = new PdfCertificate(pfxFile, "syncfusion");
                PdfSignature signature = new PdfSignature(page, pdfCert, "Signature");
                FileStream jpgFile = new FileStream(dataPath + "logo.png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                PdfBitmap bmp = new PdfBitmap(jpgFile);
                signature.Bounds = new RectangleF(new PointF(5, 5), page.GetClientSize());
                signature.ContactInfo = "johndoe@owned.us";
                signature.LocationInfo = "Honolulu, Hawaii";
                signature.Reason = "I am author of this document.";

                if (RadioButtonList2 == "Standard")
                    signature.Certificated = true;
                else
                    signature.Certificated = false;
                PdfGraphics graphics = signature.Appearence.Normal.Graphics;

                string validto = "Valid To: " + signature.Certificate.ValidTo.ToString();
                string validfrom = "Valid From: " + signature.Certificate.ValidFrom.ToString();

                graphics.DrawImage(bmp, 0, 0);

                doc.Pages[0].Graphics.DrawString(validfrom, font, pen, brush, 0, 90);
                doc.Pages[0].Graphics.DrawString(validto, font, pen, brush, 0, 110);

                doc.Pages[0].Graphics.DrawString(" Protected Document. Digitally signed Document.", font, pen, brush, 0, 130);
                doc.Pages[0].Graphics.DrawString("* To validate Signature click on the signature on this page \n * To check Document Status \n click document status icon on the bottom left of the acrobat reader.", font, pen, brush, 0, 150);

                // Save the pdf document to the Stream.
                MemoryStream stream = new MemoryStream();

                doc.Save(stream);

                //Close document
                doc.Close();

                stream.Position = 0;

                // Download the PDF document in the browser.
                FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
                fileStreamResult.FileDownloadName = "SignedPDF.pdf";
                return fileStreamResult;

                return View();
            }
        }
    }
}
