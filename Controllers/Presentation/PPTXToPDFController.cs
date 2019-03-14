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
using Syncfusion.PresentationToPdfConverter;
using Syncfusion.Pdf;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class PresentationController : Controller
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
		    
            FileStream fileStreamInput = new FileStream(basePath + @"/Presentation/Template.pptx", FileMode.Open, FileAccess.Read);
            IPresentation presentation = Presentation.Open(fileStreamInput);
			MemoryStream ms = new MemoryStream();

            //Saves the presentation to the memory stream.
            presentation.Save(ms);
            //Set the position of the stream to beginning.
            ms.Position = 0;
			return File(ms, "application/vnd.openxmlformats-officedocument.presentationml.presentation","InputTemplate.pptx");
		    }
			else
			{
            FileStream fileStreamInput = new FileStream(basePath + @"/Presentation/Template.pptx", FileMode.Open, FileAccess.Read);
            IPresentation presentation = Presentation.Open(fileStreamInput);
            //Open the existing PowerPoint presentation.
            
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
            fileStreamResult.FileDownloadName = "Sample.pdf";

            return fileStreamResult;
			}
        }        
    }
}
