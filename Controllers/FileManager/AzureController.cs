using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.FileManager
{
    public partial class FileManagerController : Controller
    {
        public IActionResult Azure()
        {
            return View();
        }
    }
}