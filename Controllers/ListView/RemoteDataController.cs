using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.ListView
{
    public partial class ListViewController : Controller
    {
        public IActionResult RemoteData()
        {
            return View();
        }
    }
}