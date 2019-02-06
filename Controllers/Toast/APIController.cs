using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Toast
{
    public partial class ToastController : Controller
    {
        // GET: /<controller>/
        public IActionResult API()
        {
            return View();
        }
    }
}
