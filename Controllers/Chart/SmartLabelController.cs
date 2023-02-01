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

        public IActionResult SmartLabel()
        {
            List<PieData> chartData = new List<PieData>  
            {
                new PieData { xValue =  "USA", yValue = 46, text = "United States of America: 46" },
                new PieData { xValue =  "China", yValue = 26, text = "China: 26" },
                new PieData { xValue =  "Russia", yValue = 19, text = "Russia: 19" },
                new PieData { xValue =  "Japan", yValue = 12, text = "Germany: 17" },
                new PieData { xValue =  "France", yValue = 10, text = "France: 10" },
                new PieData { xValue =  "South Korea", yValue = 9, text = "South korea: 9" },
                new PieData { xValue =  "Great Britain", yValue = 27, text = "France: 27" },
                new PieData { xValue =  "Italy", yValue = 8, text = "Italy: 8" },
                new PieData { xValue =  "Australia", yValue = 8, text = "Australia: 8" },
                new PieData { xValue =  "Netherlands", yValue = 8, text = "Netherlands: 8" },
                new PieData { xValue =  "Newzealand", yValue = 4, text = "Newzealand: 4" },
                new PieData { xValue =  "Uzebekistan", yValue = 4, text = "Uzebekistan: 4" },
                new PieData { xValue =  "Kazhakastan", yValue = 3, text = "Kazhakastan: 3" },
                new PieData { xValue =  "Columbia", yValue = 3, text = "Columbia: 3" },
                new PieData { xValue =  "Switzerland", yValue = 3, text = "Switzerland: 3" },
                new PieData { xValue =  "Argentina", yValue = 3, text = "Argentina: 3" },
                new PieData { xValue =  "South Africa", yValue = 2, text = "South Africa: 2" },
                new PieData { xValue =  "North Korea", yValue = 2, text = "North Korea: 2" },

            };
            ViewBag.dataSource = chartData;
            return View();
        }        
    }
}
