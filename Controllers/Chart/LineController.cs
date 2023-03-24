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

        public IActionResult Line()
        {
            List<LineChartData> chartData = new List<LineChartData>
            {
                new LineChartData { Period = new DateTime(2012, 01, 01), Can_Growth = 11.0, Viet_Growth = 19.5, Mal_Growth = 7.1, Egy_Growth = 8.2, Ind_Growth = 9.3 },
                new LineChartData { Period = new DateTime(2013, 01, 01), Can_Growth = 12.9, Viet_Growth = 17.5, Mal_Growth = 6.8, Egy_Growth = 7.3, Ind_Growth = 7.8 },
                new LineChartData { Period = new DateTime(2014, 01, 01), Can_Growth = 13.4, Viet_Growth = 15.5, Mal_Growth = 4.1, Egy_Growth = 7.8, Ind_Growth = 6.2  },
                new LineChartData { Period = new DateTime(2015, 01, 01), Can_Growth = 13.7, Viet_Growth = 10.3, Mal_Growth = 2.8, Egy_Growth = 6.8, Ind_Growth = 5.3 },
                new LineChartData { Period = new DateTime(2016, 01, 01), Can_Growth = 12.7, Viet_Growth = 7.8, Mal_Growth = 2.8, Egy_Growth = 5.0, Ind_Growth = 4.8 },
                new LineChartData { Period = new DateTime(2017, 01, 01), Can_Growth = 12.5, Viet_Growth = 5.7, Mal_Growth = 3.8, Egy_Growth = 5.5, Ind_Growth = 4.9 },
                new LineChartData { Period = new DateTime(2018, 01, 01), Can_Growth = 12.7, Viet_Growth = 5.9, Mal_Growth = 4.3, Egy_Growth = 6.5, Ind_Growth = 4.4 },
                new LineChartData { Period = new DateTime(2019, 01, 01), Can_Growth = 12.4, Viet_Growth = 5.6, Mal_Growth = 4.7, Egy_Growth = 6.8, Ind_Growth = 2.6 },
                new LineChartData { Period = new DateTime(2020, 01, 01), Can_Growth = 13.5, Viet_Growth = 5.3, Mal_Growth = 5.6, Egy_Growth = 6.6, Ind_Growth = 2.3 }
            };
            ViewBag.ChartData = chartData;
            return View();
        }

        public class LineChartData
        {
            public DateTime Period;
            public double Can_Growth;
            public double Viet_Growth;
            public double Mal_Growth;
            public double Egy_Growth;
            public double Ind_Growth;
        }
    }
}
