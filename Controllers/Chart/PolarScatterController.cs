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
        public IActionResult PolarScatter()
        {
            List<PolarScatterData> Chartpoints = new List<PolarScatterData>
            {
                new PolarScatterData { TooltipMappingName= "Myanmar", Country = "Myanmar", GDP_2013 = 7.3, GDP_2014 = 6.3, GDP_2015 = 7.5 },
                new PolarScatterData { TooltipMappingName= "India", Country = "India", GDP_2013 = 7.9, GDP_2014 = 6.8, GDP_2015 = 7.2 },
                new PolarScatterData { TooltipMappingName= "Bangladesh", Country = "Bangladesh", GDP_2013 = 6.8, GDP_2014 = 6.9, GDP_2015 = 6.9 },
                new PolarScatterData { TooltipMappingName= "Cambodia", Country = "Cambodia", GDP_2013 = 7.0, GDP_2014 = 7.0, GDP_2015 = 6.9 },
                new PolarScatterData { TooltipMappingName= "China", Country = "China", GDP_2013 = 6.9, GDP_2014 = 6.7, GDP_2015 = 6.6 },
                new PolarScatterData { TooltipMappingName= "Bhutan", Country = "Bhutan", GDP_2013 = 6.1, GDP_2014 = 6.2, GDP_2015 = 5.9 },
                new PolarScatterData { TooltipMappingName= "Iceland", Country = "Iceland", GDP_2013 = 4.1, GDP_2014 = 7.2, GDP_2015 = 5.7 },
                new PolarScatterData { TooltipMappingName= "Nepal", Country = "Nepal", GDP_2013 = 2.7, GDP_2014 = 0.6, GDP_2015 = 5.5 },
                new PolarScatterData { TooltipMappingName= "Pakistan", Country = "Pakistan", GDP_2013 = 4.0, GDP_2014 = 4.7, GDP_2015 = 5.0 },
                new PolarScatterData { TooltipMappingName= "Poland", Country = "Poland", GDP_2013 = 3.9, GDP_2014 = 2.7, GDP_2015 = 3.4 },
                new PolarScatterData { TooltipMappingName= "Australia", Country = "Australia", GDP_2013 = 2.4, GDP_2014 = 2.5, GDP_2015 = 3.1 },
                new PolarScatterData { TooltipMappingName= "Korea", Country = "Korea", GDP_2013 = 2.8, GDP_2014 = 2.8, GDP_2015 = 2.7 },
                new PolarScatterData { TooltipMappingName= "Singapore", Country = "Singapore", GDP_2013 = 1.9, GDP_2014 = 2.0, GDP_2015 = 2 },
                new PolarScatterData { TooltipMappingName= "Canada", Country = "Canada", GDP_2013 = 0.9, GDP_2014 = 1.4, GDP_2015 = 1.9 },
                new PolarScatterData { TooltipMappingName= "Germany", Country = "Germany", GDP_2013 = 1.5, GDP_2014 = 1.8, GDP_2015 = 1.6 },
                new PolarScatterData { TooltipMappingName= "Denmark", Country = "Denmark", GDP_2013 = 1.6, GDP_2014 = 1.1, GDP_2015 = 1.5 },
                new PolarScatterData { TooltipMappingName= "France", Country = "France", GDP_2013 = 1.3, GDP_2014 = 1.3, GDP_2015 = 1.4 },
                new PolarScatterData { TooltipMappingName= "Austria", Country = "Austria", GDP_2013 = 1.0, GDP_2014 = 1.5, GDP_2015 = 1.4 }
            };
            ViewBag.Chartpoints = Chartpoints;
            ViewBag.select = new string[] { "Polar", "Radar" };
            return View();
        }
        public class PolarScatterData
        {
            public string TooltipMappingName;
            public string Country;
            public double GDP_2013;
            public double GDP_2014;
            public double GDP_2015;
        }
    }
}