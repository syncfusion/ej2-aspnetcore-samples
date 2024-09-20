#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser_NET6.Controllers.CircularChart3D
{
    public partial class CircularChart3DController : Controller
    {
        public IActionResult PieWithLegend()
        {
            List<PieWithLegendChartData> ChartPoints = new List<PieWithLegendChartData>
            {
                new PieWithLegendChartData { X = "Chrome",            Y = 62.92, Text = "62.92%" },
                new PieWithLegendChartData { X = "Internet Explorer", Y = 6.12,  Text = "6.12%"  },
                new PieWithLegendChartData { X = "Opera",             Y = 3.15,  Text = "3.15%"  },
                new PieWithLegendChartData { X = "Edge",              Y = 5.5,   Text = "5.5%"   },
                new PieWithLegendChartData { X = "Safari",            Y = 19.97, Text = "19.97%" },
                new PieWithLegendChartData { X = "Others",            Y = 2.34,  Text = "2.34%"  }
            };
            ViewBag.ChartData = ChartPoints;
            return View();
        }
        public class PieWithLegendChartData
        {
            public string X;
            public double Y;
            public string Text;
        }
    }
}
