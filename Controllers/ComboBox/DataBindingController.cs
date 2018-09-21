using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ComboBoxController : Controller
    {
        public IActionResult DataBinding()
        {
            ViewBag.localdata = new GameList().GameLists();
            ViewBag.remotedata = new { url = "http://services.odata.org/V4/Northwind/Northwind.svc/Customers", adaptor = "ODataV4Adaptor", crossDomain = true };
            ViewBag.sort = "Ascending";
            ViewBag.query = "new ej.data.Query().select(['ContactName', 'CustomerID']).take(25)";
            return View();
        }
    }
}