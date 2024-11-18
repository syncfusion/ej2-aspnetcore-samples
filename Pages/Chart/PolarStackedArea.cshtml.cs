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
    public class PolarStackedAreaModel : PageModel
    {
        public List<PolarStackedAreaData> ChartPoints { get; set; }
        public string[] Select { get; set; } 
        
        public void OnGet()
        {
            ChartPoints = new List<PolarStackedAreaData>
            {
                new PolarStackedAreaData { Country = "Japan", GDP_2013 = 5156, GDP_2014 = 4849, GDP_2015 = 4382, GDP_2016 = 4939 },
                new PolarStackedAreaData { Country = "Germany", GDP_2013 = 3754, GDP_2014 = 3885, GDP_2015 = 3365, GDP_2016 = 3467 },
                new PolarStackedAreaData { Country = "France", GDP_2013 = 2809, GDP_2014 = 2844, GDP_2015 = 2420, GDP_2016 = 2463 },
                new PolarStackedAreaData { Country = "United Kingdom", GDP_2013 = 2721, GDP_2014 = 3002, GDP_2015 = 2863, GDP_2016 = 2629 },
                new PolarStackedAreaData { Country = "Brazil", GDP_2013 = 2472, GDP_2014 = 2456, GDP_2015 = 1801, GDP_2016 = 1799 },
                new PolarStackedAreaData { Country = "Russia", GDP_2013 = 2231, GDP_2014 = 2064, GDP_2015 = 1366, GDP_2016 = 1281 },
                new PolarStackedAreaData { Country = "Italy", GDP_2013 = 2131, GDP_2014 = 2155, GDP_2015 = 1826, GDP_2016 = 1851 },
                new PolarStackedAreaData { Country = "India", GDP_2013 = 1857, GDP_2014 = 2034, GDP_2015 = 2088, GDP_2016 = 2256 },
                new PolarStackedAreaData { Country = "Canada", GDP_2013 = 1843, GDP_2014 = 1793, GDP_2015 = 1553, GDP_2016 = 1529 }
            };
            Select = new string[] { "Polar", "Radar" };
        }
    }
    public class PolarStackedAreaData
    {
        public string Country;
        public double GDP_2013;
        public double GDP_2014;
        public double GDP_2015;
        public double GDP_2016;
    }
}