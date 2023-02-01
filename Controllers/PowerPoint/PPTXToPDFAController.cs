#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Syncfusion.Presentation;
using Microsoft.AspNetCore.Hosting;
using Syncfusion.PresentationRenderer;
using Syncfusion.Pdf;
using Syncfusion.Office;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class PowerPointController : Controller
    {
        public IActionResult PPTXToPDFA()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult PPTXToPDFA(string button, string view)
        {
            if (button == null)
                return View();
            Stream stream = GetPresentation();
            if (stream != null)
            {
                try
                {
                    string output = (Request.Form.Files != null && Request.Form.Files.Count != 0) ? Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName) : "PPTXToPDF_Pdf_A3A";
                    IPresentation presentation = Presentation.Open(stream);
                    stream.Dispose();
                    stream = null;

                    // Create new instance for PresentationToPdfConverterSettings.
                    PresentationToPdfConverterSettings settings = new PresentationToPdfConverterSettings();
                    //Set the Pdf conformance level to A3A.
                    settings.PdfConformanceLevel = PdfConformanceLevel.Pdf_A3A;

                    //Convert the PowerPoint document to PDF document.
                    PdfDocument pdfDocument = PresentationToPdfConverter.Convert(presentation,settings);

                    MemoryStream pdfStream = new MemoryStream();

                    //Save the converted PDF document to Memory stream.
                    pdfDocument.Save(pdfStream);
                    pdfStream.Position = 0;

                    //Close the PDF document.
                    pdfDocument.Close(true);

                    //Close the PowerPoint Presentation.
                    presentation.Close();

                    //Initialize the file stream to download the converted PDF.
                    FileStreamResult fileStreamResult = new FileStreamResult(pdfStream, "application/pdf");
                    //Set the file name.
                    fileStreamResult.FileDownloadName = output+".pdf";

                    return fileStreamResult;
                }
                catch
                {
                    ViewBag.Message = string.Format("The input document could not be processed completely, Could you please email the document to support@syncfusion.com for troubleshooting.");
                }
            }
            return View();
        }
    }
}
