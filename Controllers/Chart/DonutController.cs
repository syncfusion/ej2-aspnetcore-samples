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

        public IActionResult Donut()
        {
            List<DoughnutChartData> ChartPoints = new List<DoughnutChartData>
            {
                new DoughnutChartData { Browser= "Chrome", Users= 61.3, DataLabelMappingName= "Chrome: 61.3%" },
                new DoughnutChartData { Browser= "Safari", Users= 24.6, DataLabelMappingName= "Safari: 24.6%" },
                new DoughnutChartData { Browser= "Edge", Users= 5.0, DataLabelMappingName= "Edge: 5.0%" },
                new DoughnutChartData { Browser= "Samsung Internet", Users= 2.7, DataLabelMappingName= "Samsung Internet: 2.7%" },
                new DoughnutChartData { Browser= "Firefox", Users= 2.6, DataLabelMappingName= "Firefox: 2.6%" },
                new DoughnutChartData { Browser= "Others", Users= 3.6, DataLabelMappingName= "Others: 3.6%" }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class DoughnutChartData
        {
            public string Browser;
            public double Users;
            public string DataLabelMappingName;
        
        }
    }
}
