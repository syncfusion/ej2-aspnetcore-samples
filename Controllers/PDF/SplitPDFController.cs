#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        //
        // GET: /SplitPDF/

        public ActionResult SplitPDF()
        {
            return View();
        }
        private string result;

        [HttpPost]
        public ActionResult SplitPDF(string Browser, string pageIndex, IFormFile file)
        {
            result = null;
            if (file != null && file.Length > 0)
            {
                int splitAtPage = int.Parse(pageIndex.ToString());

                PdfLoadedDocument ldoc = new PdfLoadedDocument(file.OpenReadStream());

                if (splitAtPage <= ldoc.Pages.Count && splitAtPage != 0)
                {
                    //Create pdf split options
                    PdfSplitOptions option = new PdfSplitOptions();

                    //Enable split tags
                    option.SplitTags = true;

                    //Subscribe document split event
                    ldoc.DocumentSplitEvent += DocumentSplitEvent;

                    //Split pdf document by page ranges and split options
                    ldoc.SplitByRanges(new int[,] { { splitAtPage - 1, splitAtPage - 1 } }, option);

                    //Close the PDF document.
                    ldoc.Close(true);

                    if (result == null)
                        return View();

                    //Download the PDF document in the browser.
                    FileStreamResult fileStreamResult = new FileStreamResult(new MemoryStream(Convert.FromBase64String(result)), "application/pdf");
                    fileStreamResult.FileDownloadName = "Split.pdf";
                    return fileStreamResult;
                }
                else
                {
                    ViewBag.lab = "Invalid Page no";
                }
            }
            else
            {
                ViewBag.lab = "Choose PDF document to Split";
            }
            return View();
        }

        private void DocumentSplitEvent(object sender, PdfDocumentSplitEventArgs args)
        {
            MemoryStream ms = new MemoryStream();
            args.PdfDocumentData.CopyTo(ms);
            result = Convert.ToBase64String(ms.ToArray());
            ms.Dispose();
        }
    }
}
