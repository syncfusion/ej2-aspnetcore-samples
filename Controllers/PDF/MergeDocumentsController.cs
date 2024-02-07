#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System.IO;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        //
        // GET: /MergeDocuments/

        public ActionResult MergeDocuments()
        {
            ViewData["Error"] = "";
            return View();
        }
        [HttpPost]
        public ActionResult MergeDocuments(string InsideBrowser, string OptimizeResources)
        {
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = string.Empty;
            dataPath = basePath + @"/PDF/";

            //Read the file
            FileStream file1 = new FileStream(dataPath + "HTTP Succinctly.pdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            FileStream file2 = new FileStream(dataPath + "HTTP Succinctly.pdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //Load the documents as streams
            PdfLoadedDocument doc1 = new PdfLoadedDocument(file1);
            PdfLoadedDocument doc2 = new PdfLoadedDocument(file2);

            object[] dobj = { doc1, doc2 };
            PdfDocument doc = new PdfDocument();

            if (OptimizeResources == "OptimizeResources")
            {
                PdfMergeOptions mergeOption = new PdfMergeOptions();
                mergeOption.OptimizeResources = true;
                PdfDocument.Merge(doc, mergeOption, dobj);
            }
            else
            {
                PdfDocument.Merge(doc, dobj);
            }

            MemoryStream stream = new MemoryStream();

            //Save the PDF document
            doc.Save(stream);

            stream.Position = 0;

            //Close the PDF document
            doc.Close(true);
            doc1.Close(true);
            doc2.Close(true);

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = "MergedPDF.pdf";
            return fileStreamResult;
        }

    }
}
