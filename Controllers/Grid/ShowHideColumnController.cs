using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Grid
{
    public partial class GridController : Controller
    {
       
        public IActionResult ShowHideColumn()
        {
            var category = Category.GetAllRecords();
            ViewBag.datasource = category;
            List<object> dd = new List<object>();
            dd.Add(new { text = "Category Name", value = "CategoryName" });
            dd.Add(new { text = "Product Name", value = "ProductName" });
            dd.Add(new { text = "Units In Stock", value = "UnitsInStock" });
            dd.Add(new { text = "Discontinued", value = "Discontinued" });
            ViewBag.columns = dd;
            return View();
        }

        
             

           
    }
}