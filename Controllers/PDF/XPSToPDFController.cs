#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using System.IO;
using Syncfusion.XPS;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        public ActionResult XPSToPDF()
        {
            return View();
        }

        [HttpPost]
        public ActionResult XPSToPDF(string createPDF)
        {
            string dataPath = _hostingEnvironment.WebRootPath + @"/PDF/";

            //Load XPS file to stream
            FileStream inputStream = new FileStream(dataPath + "XPStoPDF.xps", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            XPSToPdfConverter converter = new XPSToPdfConverter();

            //Convert XPS document into PDF document
            PdfDocument document = converter.Convert(inputStream);

            //Save PDF document
            MemoryStream stream = new MemoryStream();

            document.Save(stream);

            //Close the PDF document
            document.Close(true);

            stream.Position = 0;

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = "XPSToPDF.pdf";
            return fileStreamResult;
        }
    }
}
