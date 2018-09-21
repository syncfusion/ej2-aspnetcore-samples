using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers.Uploader
{
    public partial class UploaderController : Controller
    {
        public IActionResult ChunkUpload()
        {
            ViewBag.data = new chunkValues().UploaderModel();
            return View();
        }
    }
}