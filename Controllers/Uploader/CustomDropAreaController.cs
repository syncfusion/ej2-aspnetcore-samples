using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Uploader
{
    public partial class UploaderController : Controller
    {
        public IActionResult CustomDropArea()
        {
            return View();
        }
    }
}