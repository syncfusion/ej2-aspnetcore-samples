#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Exporting;
using EJ2CoreSampleBrowser.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        // GET: /ImageExtraction/
        public IActionResult ImageExtraction()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ImageExtraction(string ViewTemplate, string Extract)
        {
            string basePath = _hostingEnvironment.WebRootPath;
            FileStream fileStreamInput = new FileStream(basePath + @"/PDF/ImageTemplate.pdf", FileMode.Open, FileAccess.Read);
            if (!string.IsNullOrEmpty(ViewTemplate))
            {
                FileStreamResult fileStreamResult = new FileStreamResult(fileStreamInput, "application/pdf");
                fileStreamResult.FileDownloadName = "Template.pdf";
                return fileStreamResult;
            }
            else if (!string.IsNullOrEmpty(Extract))
            {
                PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStreamInput);
                System.Drawing.Image[] extractedImages = loadedDocument.Pages[0].ExtractImages();
                MemoryStream imageStream = new MemoryStream();
                extractedImages[0].Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                imageStream.Position = 0;
                FileStreamResult fileStreamResult = new FileStreamResult(imageStream, "image/jpeg");
                fileStreamResult.FileDownloadName = "Sample.jpg";
                return fileStreamResult;
            }
            return View();
        }
    }
}
