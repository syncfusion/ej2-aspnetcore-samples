#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;
using System.Drawing;
using System.IO;
using Syncfusion.Pdf.Exporting;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        public ActionResult RemoveImages()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RemoveImages(string viewTemplate, string RemoveImage)
        {

            if (viewTemplate == "View Template")
            {
                string basePath = _hostingEnvironment.WebRootPath;
                string dataPath = string.Empty;
                dataPath = basePath + @"/PDF/";

                //Read the file
                FileStream file = new FileStream(dataPath + "RemoveImage.pdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                //Load the template document
                PdfLoadedDocument doc = new PdfLoadedDocument(file);

                //Save the PDF to the MemoryStream
                MemoryStream ms = new MemoryStream();
                doc.Save(ms);

                //If the position is not set to '0' then the PDF will be empty.
                ms.Position = 0;

                //Close the PDF document.
                doc.Close(true);

                //Download the PDF document in the browser.
                FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
                fileStreamResult.FileDownloadName = "RemoveImageTemplate.pdf";
                return fileStreamResult;
            }
            else if (RemoveImage == "Remove Images")
            {
                string basePath = _hostingEnvironment.WebRootPath;
                string dataPath = string.Empty;
                dataPath = basePath + @"/PDF/";

                //Read the file
                FileStream file = new FileStream(dataPath + "RemoveImage.pdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                //Load the template document
                PdfLoadedDocument doc = new PdfLoadedDocument(file);

                PdfImageInfo[] imagesInfo = doc.Pages[0].GetImagesInfo();

                foreach (PdfImageInfo imgInfo in imagesInfo)
                {
                    //Removing Image
                    doc.Pages[0].RemoveImage(imgInfo);

                }
                //Save the PDF to the MemoryStream
                MemoryStream ms = new MemoryStream();
                doc.Save(ms);

                //If the position is not set to '0' then the PDF will be empty.
                ms.Position = 0;

                //Close the PDF document.
                doc.Close(true);

                //Download the PDF document in the browser.
                FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
                fileStreamResult.FileDownloadName = "RemoveImage.pdf";
                return fileStreamResult;
            }
            return View();
        }
    }
}
