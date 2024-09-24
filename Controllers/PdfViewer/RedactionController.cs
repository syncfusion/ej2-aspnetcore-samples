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
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using Microsoft.AspNetCore.Cors;

namespace EJ2CoreSampleBrowser.Controllers.PdfViewer
{

    public partial class PdfViewerController : Controller
    {
        // GET: Default
        public ActionResult Redaction()
        {
            return View();
        }





    }
}