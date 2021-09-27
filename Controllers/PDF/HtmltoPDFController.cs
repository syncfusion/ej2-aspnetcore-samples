using System;
using System.IO;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.Runtime.InteropServices;
using EJ2CoreSampleBrowser.Models;

namespace HtmlToPdf.Controllers
{
    public partial class PdfController : Controller
    {     
        public ActionResult HtmltoPDF()
        {
            return View();
        }               
    }
}
