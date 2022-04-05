#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Syncfusion.Presentation;
using Microsoft.AspNetCore.Hosting;
using Syncfusion.PresentationToPdfConverter;
using Syncfusion.Pdf;
using Syncfusion.Office;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class PowerPointController : Controller
    {
        public IActionResult PPTXToPDF()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult PPTXToPDF(string Browser, string view)
        {
            string basePath = _hostingEnvironment.WebRootPath;
            if (view.Trim() == "INPUT TEMPLATE")
            {

                FileStream fileStreamInput = new FileStream(basePath + @"/PowerPoint/Template.pptx", FileMode.Open, FileAccess.Read);
                IPresentation presentation = Presentation.Open(fileStreamInput);
                MemoryStream ms = new MemoryStream();

                //Saves the presentation to the memory stream.
                presentation.Save(ms);
                //Set the position of the stream to beginning.
                ms.Position = 0;
                return File(ms, "application/vnd.openxmlformats-officedocument.presentationml.presentation", "InputTemplate.pptx");
            }
            else
            {
                FileStream fileStreamInput = new FileStream(basePath + @"/PowerPoint/Template.pptx", FileMode.Open, FileAccess.Read);
                //Open the existing PowerPoint presentation.
                IPresentation presentation = Presentation.Open(fileStreamInput);

                // Add a custom fallback font collection for Presentation.
                AddFallbackFonts(presentation);

                //Convert the PowerPoint document to PDF document.
                PdfDocument pdfDocument = PresentationToPdfConverter.Convert(presentation);

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
                fileStreamResult.FileDownloadName = "PPTXToPDF.pdf";

                return fileStreamResult;
            }
        }

        /// <summary>
        /// Add a custom fallback font collection for IPresentation.
        /// </summary>
        /// <param name="presentation">Represent a presentation to add.</param>
        private void AddFallbackFonts(IPresentation presentation)
        {
            //Add customized fallback font names.

            // Arabic
            presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x0600, 0x06ff, "Arial"));
            // Hebrew
            presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x0590, 0x05ff, "Arial, David"));
            // Hindi
            presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x0900, 0x097F, "Mangal"));
            // Chinese
            presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x4E00, 0x9FFF, "DengXian"));
            // Japanese
            presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x3040, 0x309F, "MS Mincho"));
            // Korean
            presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0xAC00, 0xD7A3, "Malgun Gothic"));
        }
    }
}
