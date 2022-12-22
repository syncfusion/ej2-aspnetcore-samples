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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Syncfusion.EJ2.PdfViewer;
using System.IO;
using Newtonsoft.Json;
#if REDIS
using Microsoft.Extensions.Caching.Distributed;
#endif

namespace EJ2CoreSampleBrowser.Controllers.PdfViewer
{
    public partial class PdfViewerController : Controller
    {
        private IMemoryCache _cache;
        private readonly IWebHostEnvironment _hostingEnvironment;
#if REDIS
        private IDistributedCache _distributedCache;
        public PdfViewerController(IMemoryCache memoryCache, IDistributedCache distributedCache, IWebHostEnvironment hostingEnvironment)
#else
        public PdfViewerController(IMemoryCache memoryCache, IWebHostEnvironment hostingEnvironment)
#endif
        {
            _cache = memoryCache;
#if REDIS
            _distributedCache = distributedCache;
#endif
            _hostingEnvironment = hostingEnvironment;
        }
        // GET: Default
        public ActionResult Default()
        {
            return View();
        }
        [AcceptVerbs("Post")]
        [HttpPost]
        [Route("api/[controller]/Load")]
        public IActionResult Load([FromBody] Dictionary<string, string> jsonObject)
        {
#if REDIS
            PdfRenderer pdfviewer = new PdfRenderer(_cache, _distributedCache);
#else
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
#endif
            MemoryStream stream = new MemoryStream();
            object jsonResult = new object();
            if (jsonObject != null && jsonObject.ContainsKey("document"))
            {
                if (bool.Parse(jsonObject["isFileName"]))
                {
                    string documentPath = GetDocumentPath(jsonObject["document"]);
                    if (!string.IsNullOrEmpty(documentPath))
                    {
                        byte[] bytes = System.IO.File.ReadAllBytes(documentPath);
                        stream = new MemoryStream(bytes);
                    }
                    else
                    {
                        return this.Content(jsonObject["document"] + " is not found");
                    }
                }
                else
                {
                    byte[] bytes = Convert.FromBase64String(jsonObject["document"]);
                    stream = new MemoryStream(bytes);
                }
            }
            jsonResult = pdfviewer.Load(stream, jsonObject);
            return Content(JsonConvert.SerializeObject(jsonResult));
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
        [Route("api/[controller]/RenderAnnotationComments")]
        public IActionResult RenderAnnotationComments([FromBody] Dictionary<string, string> jsonObject)
        {
#if REDIS
            PdfRenderer pdfviewer = new PdfRenderer(_cache, _distributedCache);
#else
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
#endif
            object jsonResult = pdfviewer.GetAnnotationComments(jsonObject);
            return Content(JsonConvert.SerializeObject(jsonResult));
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
        [Route("api/[controller]/Bookmarks")]
        public IActionResult Bookmarks([FromBody] Dictionary<string, string> jsonObject)
        {
#if REDIS
            PdfRenderer pdfviewer = new PdfRenderer(_cache, _distributedCache);
#else
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
#endif
            object jsonResult = pdfviewer.GetBookmarks(jsonObject);
            return Content(JsonConvert.SerializeObject(jsonResult));
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
        [AcceptVerbs("Post")]
        [HttpPost]
        [Route("api/[controller]/ExportAnnotations")]
        public IActionResult ExportAnnotations([FromBody] Dictionary<string, string> jsonObject)
        {
#if REDIS
            PdfRenderer pdfviewer = new PdfRenderer(_cache, _distributedCache);
#else
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
#endif
            string result = pdfviewer.ExportAnnotation(jsonObject);
            return Content(result);
        }
        [AcceptVerbs("Post")]
        [HttpPost]
        [Route("api/[controller]/ImportAnnotations")]
        public IActionResult ImportAnnotations([FromBody] Dictionary<string, string> jsonObject)
        {
#if REDIS
            PdfRenderer pdfviewer = new PdfRenderer(_cache, _distributedCache);
#else
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
#endif
            string jsonResult = string.Empty;
            object JsonResult;
            if (jsonObject != null && jsonObject.ContainsKey("fileName"))
            {
                string documentPath = GetDocumentPath(jsonObject["fileName"]);
                if (!string.IsNullOrEmpty(documentPath))
                {
                    jsonResult = System.IO.File.ReadAllText(documentPath);
                }
                else
                {
                    return this.Content(jsonObject["document"] + " is not found");
                }
            }
            else
            {
                string extension = Path.GetExtension(jsonObject["importedData"]);
                if (extension != ".xfdf")
                {
                    JsonResult = pdfviewer.ImportAnnotation(jsonObject);
                    return Content(JsonConvert.SerializeObject(JsonResult));
                }
                else
                {
                    string documentPath = GetDocumentPath(jsonObject["importedData"]);
                    if (!string.IsNullOrEmpty(documentPath))
                    {
                        byte[] bytes = System.IO.File.ReadAllBytes(documentPath);
                        jsonObject["importedData"] = Convert.ToBase64String(bytes);
                        JsonResult = pdfviewer.ImportAnnotation(jsonObject);
                        return Content(JsonConvert.SerializeObject(JsonResult));
                    }
                    else
                    {
                        return this.Content(jsonObject["document"] + " is not found");
                    }
                }
            }
            return Content(jsonResult);
        }

        [AcceptVerbs("Post")]
        [HttpPost]
        [Route("api/[controller]/RenderPdfTexts")]
        public IActionResult RenderPdfTexts([FromBody] Dictionary<string, string> jsonObject)
        {
#if REDIS
            PdfRenderer pdfviewer = new PdfRenderer(_cache, _distributedCache);
#else
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
#endif
            object result = pdfviewer.GetDocumentText(jsonObject);
            return Content(JsonConvert.SerializeObject(result));
        }

        [AcceptVerbs("Post")]
        [HttpPost]
        [Route("api/[controller]/ExportFormFields")]
        public IActionResult ExportFormFields([FromBody] Dictionary<string, string> jsonObject)
        {
#if REDIS
            PdfRenderer pdfviewer = new PdfRenderer(_cache, _distributedCache);
#else
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
#endif
            string jsonResult = pdfviewer.ExportFormFields(jsonObject);
            return Content(jsonResult);
        }

        [AcceptVerbs("Post")]
        [HttpPost]
        [Route("api/[controller]/ImportFormFields")]
        public IActionResult ImportFormFields([FromBody] Dictionary<string, string> jsonObject)
        {
#if REDIS
            PdfRenderer pdfviewer = new PdfRenderer(_cache, _distributedCache);
#else
            PdfRenderer pdfviewer = new PdfRenderer(_cache);
#endif
            jsonObject["data"] = GetDocumentPath(jsonObject["data"]);
            object jsonResult = pdfviewer.ImportFormFields(jsonObject);
            return Content(JsonConvert.SerializeObject(jsonResult));
        }

        private string GetDocumentPath(string document)
        {
            string documentPath = string.Empty;
            if (!System.IO.File.Exists(document))
            {
                string basePath = _hostingEnvironment.WebRootPath;
                string dataPath = string.Empty;
                dataPath = basePath + @"/PdfViewer/";
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
