using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJCoreSampleBrowser.Controllers.XlsIO
{
    public partial class XlsIOController : Controller
    {
        public IActionResult ExcelToPDF()
        {
            return View();
        }
    }
}