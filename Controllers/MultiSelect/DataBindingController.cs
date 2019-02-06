using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class MultiSelectController : Controller
    {
        public IActionResult DataBinding()
        {
            ViewBag.localdata = new GameList().GameLists();
            ViewBag.sort = "Ascending";
            ViewBag.query = "new ej.data.Query().select(['FirstName ', 'EmployeeID']).take(10).requiresCount()";
            return View();
        }
    }
}