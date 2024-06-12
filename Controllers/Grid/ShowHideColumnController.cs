#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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