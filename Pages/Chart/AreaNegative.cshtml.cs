#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class AreaNegativeModel : PageModel
    {
        public List<AreaNegativeChartData> MaryValues { get; set; }
        public List<AreaNegativeChartData> PatriciaValues { get; set; }
        public List<AreaNegativeChartData> LindaValues { get; set; }

        public void OnGet()
        {
             MaryValues = new List<AreaNegativeChartData>
            {
                new AreaNegativeChartData { Vegetable = new DateTime(2017, 01, 01),  Price = 3000 },
                new AreaNegativeChartData { Vegetable = new DateTime(2018, 01, 01), Price = 4000 },
                new AreaNegativeChartData { Vegetable = new DateTime(2019, 01, 01), Price = -4000 },
                new AreaNegativeChartData { Vegetable = new DateTime(2020, 01, 01),   Price = -2000 },
                new AreaNegativeChartData { Vegetable = new DateTime(2021, 01, 01), Price = 5000 }
            };
            PatriciaValues = new List<AreaNegativeChartData>
            {
                new AreaNegativeChartData { Vegetable = new DateTime(2017, 01, 01),  Price = 2000 },
                new AreaNegativeChartData { Vegetable = new DateTime(2018, 01, 01), Price = 3000 },
                new AreaNegativeChartData { Vegetable = new DateTime(2019, 01, 01), Price = 4000 },
                new AreaNegativeChartData { Vegetable = new DateTime(2020, 01, 01),   Price = 2000 },
                new AreaNegativeChartData { Vegetable = new DateTime(2021, 01, 01), Price = 3000 }
            };
            LindaValues = new List<AreaNegativeChartData>
            {
                new AreaNegativeChartData { Vegetable = new DateTime(2017, 01, 01),  Price = 2000 },
                new AreaNegativeChartData { Vegetable = new DateTime(2018, 01, 01), Price = -1000 },
                new AreaNegativeChartData { Vegetable = new DateTime(2019, 01, 01), Price = -3000 },
                new AreaNegativeChartData { Vegetable = new DateTime(2020, 01, 01),   Price = 4000 },
                new AreaNegativeChartData { Vegetable = new DateTime(2021, 01, 01), Price = 1000 }
            };
        }
    }
    public class AreaNegativeChartData
    {
        public DateTime Vegetable;
        public double Price;
    }
}
