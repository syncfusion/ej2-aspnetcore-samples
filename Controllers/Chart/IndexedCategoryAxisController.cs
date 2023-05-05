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

        public IActionResult IndexedCategoryAxis()
        {           

            List<IndexedCategoryAxisData> GDP_2015 = new List<IndexedCategoryAxisData>
            {
                new IndexedCategoryAxisData { Country = "India", GDPGrowthRate = 7.9 },
                new IndexedCategoryAxisData { Country = "Myanmar", GDPGrowthRate = 7.3 },
                new IndexedCategoryAxisData { Country = "Bangladesh", GDPGrowthRate = 6.0 },
                new IndexedCategoryAxisData { Country = "Cambodia", GDPGrowthRate = 7.0 },
                new IndexedCategoryAxisData { Country = "China", GDPGrowthRate = 6.9 }
             };
            ViewBag.GDP_2015 = GDP_2015;
            List<IndexedCategoryAxisData> GDP_2016 = new List<IndexedCategoryAxisData>
            {
                new IndexedCategoryAxisData { Country = "Australia", GDPGrowthRate = 2.5 },
                new IndexedCategoryAxisData { Country = "Poland", GDPGrowthRate = 2.7 },
                new IndexedCategoryAxisData { Country = "Singapore", GDPGrowthRate = 2.0 },
                new IndexedCategoryAxisData { Country = "Canada", GDPGrowthRate = 1.4 },
                new IndexedCategoryAxisData { Country = "Germany", GDPGrowthRate = 1.8 },
             };
            ViewBag.GDP_2016 = GDP_2016;
            return View();
        }

        public class IndexedCategoryAxisData
        {
            public string Country;
            public double GDPGrowthRate;
        }
    }
}
