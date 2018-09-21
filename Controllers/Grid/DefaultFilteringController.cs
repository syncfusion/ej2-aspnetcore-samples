using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers.Grid
{
    public partial class GridController : Controller
    {
        
        public IActionResult DefaultFiltering()
        {
            
            var product = Category.GetAllRecords();
            ViewBag.datasource = product;
            return View();
        }
       
    }
}