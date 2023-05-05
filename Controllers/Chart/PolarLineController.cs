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
        public IActionResult PolarLine()
        {
            List<PolarLineChartData> ChartPoints = new List<PolarLineChartData>
            {
                new PolarLineChartData { Month = "Jan", GER_Temp = -7.1, ENG_Temp = -17.4 },
                new PolarLineChartData { Month = "Feb", GER_Temp = -3.7, ENG_Temp = -15.6  },
                new PolarLineChartData { Month = "Mar", GER_Temp = 0.8, ENG_Temp = -12.3  },
                new PolarLineChartData { Month = "Apr", GER_Temp = 6.3, ENG_Temp = -5.3 },
                new PolarLineChartData { Month = "May", GER_Temp = 13.3, ENG_Temp = 1.0 },
                new PolarLineChartData { Month = "Jun", GER_Temp = 18.0, ENG_Temp =  6.9  },
                new PolarLineChartData { Month = "Jul", GER_Temp = 19.8 , ENG_Temp = 9.4 },
                new PolarLineChartData { Month = "Aug", GER_Temp = 18.1, ENG_Temp = 7.6 },
                new PolarLineChartData { Month = "Sep", GER_Temp = 13.1 , ENG_Temp = 2.6 },
                new PolarLineChartData { Month = "Oct", GER_Temp = 4.1, ENG_Temp = -4.9},
                new PolarLineChartData { Month = "Nov", GER_Temp = -3.8, ENG_Temp = -13.4 },
                new PolarLineChartData { Month = "Dec", GER_Temp = -6.8, ENG_Temp = -16.4 },
            };
            ViewBag.ChartPoints = ChartPoints;
            ViewBag.data = new string[] { "Polar", "Radar" };
            return View();
        }
        public class PolarLineChartData
        {
            public string Month;
            public double GER_Temp;
            public double ENG_Temp;
        }
    }
}