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

namespace EJ2CoreSampleBrowser.Controllers.HeatMapChart
{
    public partial class HeatMapChartController : Controller
    {
        public IActionResult Default()
        {
            ViewBag.dataSource = GetDataSource();
            return View();
        }

        private int[,] GetDataSource()
        {
            int[,] data = new int[12, 6];
            for (int x = 0; x < 12; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    Random random = new Random();
                    data[x, y] = random.Next(0, 100);
                }
            }
            return data;
        }
    }
}