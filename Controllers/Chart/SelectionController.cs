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

        public IActionResult Selection()
        {
            List<SelectionData> ChartPoints = new List<SelectionData>
            {
                new SelectionData { Country = "China", Children = 17, Adult = 54, SeniorAdult = 9  },
                new SelectionData { Country = "USA", Children = 19, Adult = 67, SeniorAdult = 14 },
                new SelectionData { Country = "India", Children = 29, Adult = 65, SeniorAdult = 6  },
                new SelectionData { Country = "Japan", Children = 13, Adult = 61, SeniorAdult = 26 },
                new SelectionData { Country = "Brazil", Children = 24, Adult = 68, SeniorAdult = 8  }
            };
            ViewBag.ChartPoints = ChartPoints;
            // ViewBag.data = new string[] { "Point", "Series", "Cluster"};
            // ViewBag.datapattern = new string[] { "None", "Turquoise", "Chessboard", "Triangle", "Box", "Bubble" };
            return View();
        }
        public class SelectionData
        {
            public string Country;
            public double Children;
            public double Adult;
            public double SeniorAdult;
        }
    }
}
