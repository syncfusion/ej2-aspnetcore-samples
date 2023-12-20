#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser_NET6.Controllers.ThreeDimensionsChart
{
    public partial class ThreeDimensionsChartController : Controller
    {
        public IActionResult Column()
        {
            List<ColumnChartData> ChartPoints = new List<ColumnChartData>
            {
                new ColumnChartData { X = "Tesla",    Y = 137429 },
                new ColumnChartData { X = "Aion",     Y = 80308  },
                new ColumnChartData { X = "Wuling",   Y = 76418  },
                new ColumnChartData { X = "Changan",  Y = 52849  },
                new ColumnChartData { X = "Geely",    Y = 47234  },
                new ColumnChartData { X = "Nio",      Y = 31041  },
                new ColumnChartData { X = "Neta",     Y = 22449  },
                new ColumnChartData { X = "BMW",      Y = 18733  }               
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class ColumnChartData
        {
            public string X;
            public double Y;
        }
    }
}
