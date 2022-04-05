#region Copyright Syncfusion Inc. 2001-2022
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using System.IO;
using Syncfusion.Pdf.Parsing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {

        public ActionResult CompressExistingPDF()
        {
            ViewData.Add("imageQuality", new SelectList(new string[] { "10", "20", "30", "40", "50", "60", "70", "80", "90", "100" }, "50"));
            return View();
        }

        [HttpPost]
        public ActionResult CompressExistingPDF(bool compressImage =false , bool optPageContents =false , bool removeMetaData =false , bool optFont =false , string imageQuality = "50", string Browser = "null")
        {

            if(Request.Form.Files != null && Request.Form.Files.Count != 0) 
            {
                PdfLoadedDocument ldoc = new PdfLoadedDocument(Request.Form.Files[0].OpenReadStream());

                PdfCompressionOptions options = new PdfCompressionOptions();
                if (compressImage)
                {
                    //Compress image.
                    options.CompressImages = true;
                    options.ImageQuality = int.Parse((imageQuality));
                }
                else
                    options.CompressImages = false;

                //Compress the font data
                if (optFont)
                    options.OptimizeFont = true;
                else
                    options.OptimizeFont = false;

                //Compress the page contents
                if (optPageContents)
                    options.OptimizePageContents = true;
                else
                    options.OptimizePageContents = false;

                //Remove the metadata information.
                if (removeMetaData)
                    options.RemoveMetadata = true;
                else
                    options.RemoveMetadata = false;

                //Set the options to loaded PDF document
                ldoc.Compress(options);

                //If the position is not set to '0' then the PDF will be empty.
                MemoryStream ms = new MemoryStream();
                ldoc.Save(ms);
                ms.Position = 0;
                ldoc.Close(true);
                //Download the PDF document in the browser.
                FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
                fileStreamResult.FileDownloadName = "Compression.pdf";
                return fileStreamResult;


            }
            else
            {
                ViewBag.lab = "Choose a valid PDF file.";
                ViewData.Add("imageQuality", new SelectList(new string[] { "10", "20", "30", "40", "50", "60", "70", "80", "90", "100" }, "50"));
                return View();
            }
        }

     


    }
}
