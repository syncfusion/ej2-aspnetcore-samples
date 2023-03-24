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
        public IActionResult Multilevellabel()
        {
            List<MultiLevelLabelsData> ChartPoints = new List<MultiLevelLabelsData>
            {
                new MultiLevelLabelsData { Fruits = "Grapes",  Sales = 28 },
                new MultiLevelLabelsData { Fruits = "Apples",  Sales = 87 },
                new MultiLevelLabelsData { Fruits = "Pears",   Sales = 42 },
                new MultiLevelLabelsData { Fruits = "Grapes",  Sales = 13 },
                new MultiLevelLabelsData { Fruits = "Apples",  Sales = 13 },
                new MultiLevelLabelsData { Fruits = "Pears",   Sales = 10 },
                new MultiLevelLabelsData { Fruits = "Tomato",  Sales = 31 },
                new MultiLevelLabelsData { Fruits = "Potato",  Sales = 96 },
                new MultiLevelLabelsData { Fruits = "Cucumber",Sales = 41 },
                new MultiLevelLabelsData { Fruits = "Onion",   Sales = 59 }
             };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class MultiLevelLabelsData
        {
            public string Fruits;
            public double Sales;
        }
    }
}