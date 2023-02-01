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

        public IActionResult LogarithmicScale()
        {
            List<DateTimeData> chartData = new List<DateTimeData>
            {
                new DateTimeData {xValue = new DateTime(1995, 1, 1), yValue1 =80  },
                new DateTimeData {xValue = new DateTime(1996, 1, 1), yValue1 =200  },
                new DateTimeData {xValue = new DateTime(1997, 1, 1), yValue1 =400  },
                new DateTimeData {xValue = new DateTime(1998, 1, 1), yValue1 = 600  },
                new DateTimeData {xValue = new DateTime(1999, 1, 1), yValue1 = 700 },
                new DateTimeData {xValue = new DateTime(2000, 1, 1), yValue1 = 1400 },
                new DateTimeData {xValue = new DateTime(2001, 1, 1), yValue1 = 2000 } ,
                new DateTimeData {xValue = new DateTime(2002, 1, 1), yValue1 = 4000 },
                new DateTimeData {xValue = new DateTime(2003, 1, 1), yValue1 = 6000 },
                new DateTimeData {xValue = new DateTime(2004, 1, 1), yValue1 = 8000  },
                new DateTimeData {xValue = new DateTime(2005, 1, 1), yValue1 = 11000  },

                            };
            ViewBag.dataSource = chartData;
            return View();
        }        
    }
}
