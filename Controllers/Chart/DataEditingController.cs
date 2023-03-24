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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ChartController : Controller
    {

        public IActionResult DataEditing()
        {
            List<DataEditingData> ConsumerDetails = new List<DataEditingData>
            {
                new DataEditingData { Period = "2005", ProductA_Sales = 21, ProductB_Sales= 28},
                new DataEditingData { Period = "2006", ProductA_Sales = 24, ProductB_Sales= 44},
                new DataEditingData { Period = "2007", ProductA_Sales = 36, ProductB_Sales= 48},
                new DataEditingData { Period = "2008", ProductA_Sales = 38, ProductB_Sales= 50},
                new DataEditingData { Period = "2009", ProductA_Sales = 54, ProductB_Sales= 66},
                new DataEditingData { Period = "2010", ProductA_Sales = 57, ProductB_Sales= 78},
                new DataEditingData { Period = "2011", ProductA_Sales = 70, ProductB_Sales= 84}
            };
            ViewBag.ConsumerDetails = ConsumerDetails;
            return View();
        }
        public class DataEditingData
        {
            public string Period;
            public double ProductA_Sales;
            public double ProductB_Sales;
        }
    }
}
