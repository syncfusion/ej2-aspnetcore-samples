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
        public ActionResult ImageToPDF(string Browser)
        {
            string dataPath = _hostingEnvironment.WebRootPath + @"/PDF/";
            List<Stream?> imageStreams = new List<Stream?>();
            for (int i = 1; i <= 6; i++)
            {
                FileStream jpgImageStream = new FileStream(dataPath + "pdf_succinctly_page" + i + ".jpg", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);              
                imageStreams.Add(jpgImageStream);
            }
            
            //Create ImageToPdfConverter object.
            ImageToPdfConverter imageToPdfConverter = new ImageToPdfConverter();
            
            //Set the image position.
            imageToPdfConverter.ImagePosition = PdfImagePosition.FitToPageAndMaintainAspectRatio;
            
            //Convert the images to PDF.
            PdfDocument document = imageToPdfConverter.Convert(imageStreams);

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
    }
}
