#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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

        public IActionResult PieLegend()
        {
            List<PieDataPoints> PieChartPoints = new List<PieDataPoints>  
            {
                new PieDataPoints { ExpenseCategory =  "Internet Explorer", ExpensePercentage = 6.12, legendName="Internet <br> Explorer", DataLabelMappingName = "6.12%" },
                new PieDataPoints { ExpenseCategory =  "Chrome", ExpensePercentage = 57.28, legendName="Chrome", DataLabelMappingName = "57.28%" },
                new PieDataPoints { ExpenseCategory =  "Safari", ExpensePercentage = 4.73, legendName="Safari", DataLabelMappingName = "4.73%" },
                new PieDataPoints { ExpenseCategory =  "QQ", ExpensePercentage = 5.96, legendName="QQ", DataLabelMappingName = "5.96%" },
                new PieDataPoints { ExpenseCategory =  "UC Browser", ExpensePercentage = 4.37, legendName="UC Browser", DataLabelMappingName = "4.37%" },
                new PieDataPoints { ExpenseCategory =  "Edge", ExpensePercentage = 7.48, legendName="Edge", DataLabelMappingName = "7.48%" },
                new PieDataPoints { ExpenseCategory =  "Others", ExpensePercentage = 14.06, legendName="Others", DataLabelMappingName = "14.06%" }
            };
            ViewBag.PieChartPoints = PieChartPoints;
            return View();
        }
        public class PieDataPoints
        {
            public string ExpenseCategory;
            public double ExpensePercentage;
            public string legendName;
            public string DataLabelMappingName;
        }
    }
}
