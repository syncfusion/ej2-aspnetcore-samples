using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Syncfusion.EJ2.PdfViewer;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;

namespace EJ2CoreSampleBrowser.Controllers.PdfViewer
{
    
    public partial class PdfViewerController : Controller
    {        
        // GET: Default
        public ActionResult Annotations()
        {
            return View();
        }

    }
}