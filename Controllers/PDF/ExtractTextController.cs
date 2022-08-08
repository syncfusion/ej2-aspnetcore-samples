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
using EJ2CoreSampleBrowser.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        // GET: /ExtractText/
        public IActionResult ExtractText()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ExtractText(string ViewTemplate, string Extract)
        {
            string basePath = _hostingEnvironment.WebRootPath;
            FileStream fileStreamInput = new FileStream(basePath + @"/PDF/HTTP Succinctly.pdf", FileMode.Open, FileAccess.Read);
            if (!string.IsNullOrEmpty(ViewTemplate))
            {
                FileStreamResult fileStreamResult = new FileStreamResult(fileStreamInput, "application/pdf");
                fileStreamResult.FileDownloadName = "HTTP Succinctly.pdf";
                return fileStreamResult;
            }
            else if (!string.IsNullOrEmpty(Extract))
            {
                PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStreamInput);
                string extractedText = string.Empty;
                for (var i = 0; i < loadedDocument.Pages.Count; i++)
                {
                    extractedText += loadedDocument.Pages[i].ExtractText(true);
                }
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(extractedText);
                MemoryStream stream = new MemoryStream(byteArray);
                FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/txt");
                fileStreamResult.FileDownloadName = "Sample.txt";
                return fileStreamResult;
            }
            return View();
        }
    }
}
