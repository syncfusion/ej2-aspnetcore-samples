using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Popups;
using EJ2CoreSampleBrowser.Models;
using Syncfusion.EJ2.Navigations;
using System.ComponentModel.DataAnnotations;

namespace EJ2CoreSampleBrowser.Controllers.Dialog
{
    public partial class PdfViewerController : Controller
    {
        public IActionResult MultiFormatViewer()
        {
            return View();
        }
    }
}