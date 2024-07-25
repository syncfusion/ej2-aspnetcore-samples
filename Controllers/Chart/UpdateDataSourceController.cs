#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser_NET6.Controllers.Chart
{
    public partial class ChartController : Controller
    {
        public IActionResult UpdateDataSource()
        {
            List<UpdateChartData> ChartPoints = new List<UpdateChartData>
            {
                new UpdateChartData { X = "Jewellery",          Y = 75 },
                new UpdateChartData { X = "Shoes",              Y = 45 },
                new UpdateChartData { X = "Footwear",           Y = 73 },
                new UpdateChartData { X = "Pet Services",       Y = 53 },
                new UpdateChartData { X = "Business Clothing",  Y = 85 },
                new UpdateChartData { X = "Office Supplies",    Y = 68 },
                new UpdateChartData { X = "Food",               Y = 45 }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class UpdateChartData
        {
            public string? X;
            public double Y;
        }
    }
}
