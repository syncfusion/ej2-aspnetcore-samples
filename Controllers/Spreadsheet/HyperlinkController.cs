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
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class SpreadsheetController : Controller
    {
        public IActionResult Hyperlink()
        {
            List<object> data = new List<object>()
            {
                new { ProductName= "Coffee Maker", category="Kitchen", Quantity= "43",  Price= "399",  Total= "=E4*D4" },
                new { ProductName= "Apple Pencil", category="Electronics",  Quantity= "7",  Price= "200",  Total= "=E5*D5" },
                new { ProductName= "Juicer", category="Kitchen",  Quantity= "12",  Price= "100",  Total= "=E6*D6" },
                new { ProductName= "Toaster", category="Kitchen",  Quantity= "69",  Price= "183",  Total= "=E7*D7" },
                new { ProductName= "Tea Kettle", category="Kitchen",  Quantity= "83",  Price= "169",  Total= "=E8*D8" },
                new { ProductName= "Logitech Mouse", category="Electronics",  Quantity= "16",  Price= "250",  Total= "=E9*D9" },
                new { ProductName= "Skillet", category="Kitchen",  Quantity= "20",  Price= "149",  Total= "=E10*D10" },
                new { ProductName= "Hamilton Blender", category="Appliances",  Quantity= "68",  Price= "109",  Total= "=E11*D11" },
                new { ProductName= "Plate set", category="Kitchen",  Quantity= "59",  Price= "168",  Total= "=E12*D12" }
            };
            List<object> data1 = new List<object>()
            {
                new { ProductId= "AG940Z",  ProductsReceived= "100",  ProductsSold= "=100-Cart!D4",  AvailableQuantity= "=B2-C2" },
                new { ProductId= "BJ120K",  ProductsReceived= "100",  ProductsSold= "=100-Cart!D5",  AvailableQuantity= "=B3-C3" },
                new { ProductId= "BC120M",  ProductsReceived= "100",  ProductsSold= "=100-Cart!D6",  AvailableQuantity= "=B4-C4" },
                new { ProductId= "BS121L",  ProductsReceived= "100",  ProductsSold= "=100-Cart!D7",  AvailableQuantity= "=B5-C5" },
                new { ProductId= "BU121K",  ProductsReceived= "100",  ProductsSold= "=100-Cart!D8",  AvailableQuantity= "=B6-C6" },
                new { ProductId= "BD121M",  ProductsReceived= "100",  ProductsSold= "=100-Cart!D9",  AvailableQuantity= "=B7-C7" },
                new { ProductId= "AT992X",  ProductsReceived= "100",  ProductsSold= "=100-Cart!D10",  AvailableQuantity= "=B8-C8" },
                new { ProductId= "AP992Z",  ProductsReceived= "100",  ProductsSold= "=100-Cart!D11",  AvailableQuantity= "=B9-C9" },
                new { ProductId= "AW920X",  ProductsReceived= "100",  ProductsSold= "=100-Cart!D12",  AvailableQuantity= "=B10-C10" }
            };
            ViewBag.HyperlinkCart = data;
            ViewBag.HyperlinkStock = data1;
            return View();
        }
    }
}