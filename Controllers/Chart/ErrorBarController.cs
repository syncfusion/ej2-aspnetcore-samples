#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
using Syncfusion.EJ2.Charts;

namespace EJ2CoreSampleBrowser.Controllers.Chart
{
    public partial class ChartController : Controller
    {
        public IActionResult ErrorBar()
        {
            List<ErrorBarData> ChartPoints = new List<ErrorBarData>
            {
                new ErrorBarData { Items = "Printer", Quality = 750, Error=50 },
                new ErrorBarData { Items = "Desktop", Quality = 500, Error=70 },
                new ErrorBarData { Items = "Charger", Quality = 550, Error=60 },
                new ErrorBarData { Items = "Mobile", Quality = 575, Error=80 },
                new ErrorBarData { Items = "Keyboard", Quality = 400, Error=20 },
                new ErrorBarData { Items = "Power Bank", Quality = 450, Error=90 },
                new ErrorBarData { Items = "Laptop", Quality = 650, Error=40 },
                new ErrorBarData { Items = "Battery", Quality = 525, Error=84 }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class ErrorBarData
        {
            public string? Items;
            public double Quality;
            public double Error;
        }
    }
}