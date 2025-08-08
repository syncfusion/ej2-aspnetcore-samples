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
using Syncfusion.PresentationRenderer;
using Syncfusion.Pdf;
using Syncfusion.Office;
using System.Collections.Generic;
using Syncfusion.EJ2.PdfViewer;
using System;
using Newtonsoft.Json;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class PowerPointController : Controller
    {
        public IActionResult PowerPointViewer()
        {
            return View();
        }
        [HttpGet]
        [Route("api/[controller]/ConvertPPTXToPDF")]
        //Get action for obtaing the byte array of the PDF document
        public IActionResult ConvertPPTXToPDF(string fileName)
        {
#if REDIS
            PdfRenderer pdfviewer = new PdfRenderer(_cache, _distributedCache);
#else
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
#endif
            MemoryStream stream = new MemoryStream();
            if (!string.IsNullOrEmpty(fileName))
            {
                string documentPath = GetDocumentPath(fileName);
                if(!string.IsNullOrEmpty(documentPath))
                {
                    byte[] bytes = System.IO.File.ReadAllBytes(documentPath);
                    stream = new MemoryStream(bytes);
                }
                else
                {
                    return this.Content(fileName + " is not found");
                }
            }

            try
            {
                //Open the PowerPoint presentation using Syncfusion Presentation library
                IPresentation presentation = Presentation.Open(stream);
                //Convert a PowerPoint presentation as PDF to view the generated PDF file in our Syncfusion PdfViewer
                PdfDocument pdfDocument = PresentationToPdfConverter.Convert(presentation);
                stream.Dispose();
                //Save the converted Pdf document to get a physical DOM of PDF document.
                stream = new MemoryStream();
                pdfDocument.Save(stream);
                //Dispose the pdf and presentation instance.
                pdfDocument.Dispose();
                presentation.Dispose();
                //Reset the pdf stream position.
                stream.Position = 0;
            }
            catch
            {

            }
            // Return the byte array as a file
            return File(stream.ToArray(), "application/pdf", fileName);
        }
        [HttpPost]
        [AcceptVerbs("Post")]
        [Route("api/[controller]/ConvertPPTXToPDFCustomer")]
        public IActionResult ConvertPPTXToPDFCustomer([FromBody] Dictionary<string, string> jsonObject)
        {
            string base64 = jsonObject["data"];
            string data = base64.Split(',')[1];
            MemoryStream stream = new MemoryStream();
            byte[] byteArray = Convert.FromBase64String(data);
            stream = new MemoryStream(byteArray);
            try
            {
                //Open the PowerPoint presentation using Syncfusion Presentation library
                IPresentation presentation = Presentation.Open(stream);
                //Convert a PowerPoint presentation as PDF to view the generated PDF file in our Syncfusion PdfViewer
                PdfDocument pdfDocument = PresentationToPdfConverter.Convert(presentation);
                stream.Dispose();
                //Save the converted Pdf document to get a physical DOM of PDF document.
                stream = new MemoryStream();
                pdfDocument.Save(stream);
                //Dispose the pdf and presentation instance.
                pdfDocument.Dispose();
                presentation.Dispose();
                //Reset the pdf stream position.
                stream.Position = 0;
            }
            catch
            {
                // Handle exceptions (if needed)
            }
            // Convert the updated PDF stream to a base64-encoded string
            string updatedDocumentBase = Convert.ToBase64String(stream.ToArray());
            string documentBase = "data:application/pdf;base64," + updatedDocumentBase;
            return Content(documentBase);
        }
        [AcceptVerbs("Post")]
        [HttpPost]
        [Route("api/[controller]/Unload")]
        public IActionResult Unload([FromBody] Dictionary<string, string> jsonObject)
        {
#if REDIS
            PdfRenderer pdfviewer = new PdfRenderer(_cache, _distributedCache);
#else
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
#endif
            pdfviewer.ClearCache(jsonObject);
            return this.Content("Document cache is cleared");
        }

        [AcceptVerbs("Post")]
        [HttpPost]
        [Route("api/[controller]/RenderPdfPages")]
        public IActionResult RenderPdfPages([FromBody] Dictionary<string, string> jsonObject)
        {
#if REDIS
            PdfRenderer pdfviewer = new PdfRenderer(_cache, _distributedCache);
#else
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
#endif
            object jsonResult = pdfviewer.GetPage(jsonObject);
            return Content(JsonConvert.SerializeObject(jsonResult));
        }

        [AcceptVerbs("Post")]
        [HttpPost]
        [Route("api/[controller]/RenderThumbnailImages")]
        public IActionResult RenderThumbnailImages([FromBody] Dictionary<string, string> jsonObject)
        {
#if REDIS
            PdfRenderer pdfviewer = new PdfRenderer(_cache, _distributedCache);
#else
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
#endif
            object result = pdfviewer.GetThumbnailImages(jsonObject);
            return Content(JsonConvert.SerializeObject(result));
        }
        [AcceptVerbs("Post")]
        [HttpPost]
        [Route("api/[controller]/Download")]
        public IActionResult Download([FromBody] Dictionary<string, string> jsonObject)
        {
#if REDIS
            PdfRenderer pdfviewer = new PdfRenderer(_cache, _distributedCache);
#else
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
#endif
            string documentBase = pdfviewer.GetDocumentAsBase64(jsonObject);
            return Content(documentBase);
        }
        [AcceptVerbs("Post")]
        [HttpPost]
        [Route("api/[controller]/PrintImages")]
        public IActionResult PrintImages([FromBody] Dictionary<string, string> jsonObject)
        {
#if REDIS
            PdfRenderer pdfviewer = new PdfRenderer(_cache, _distributedCache);
#else
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
#endif
            object pageImage = pdfviewer.GetPrintImage(jsonObject);
            return Content(JsonConvert.SerializeObject(pageImage));
        }
        private string GetDocumentPath(string document)
        {
            string documentPath = string.Empty;
            if (!System.IO.File.Exists(document))
            {
                string basePath = _hostingEnvironment.WebRootPath;
                string dataPath = string.Empty;
                dataPath = basePath + @"/PowerPoint/";
                if (System.IO.File.Exists(dataPath + document))
                    documentPath = dataPath + document;
            }
            else
            {
                documentPath = document;
            }
            return documentPath;
        }
    }
}
