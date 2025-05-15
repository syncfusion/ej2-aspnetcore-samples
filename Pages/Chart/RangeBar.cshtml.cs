#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class RangeBarModel : PageModel
    {
        public List<RangeBarChartData> ChartPoints { get; set; }

        public void OnGet()
        {
            ChartPoints = new List<RangeBarChartData>
            {
                new RangeBarChartData { Country = "Solomon Islands", Low = 44, High = 134 },
                new RangeBarChartData { Country = "Tonga", Low = 52, High = 131 },
                new RangeBarChartData { Country = "Trinidad and Tobago", Low = 36, High = 151 },
                new RangeBarChartData { Country = "Samoa", Low = 49, High = 131 },
                new RangeBarChartData { Country = "Saint Lucia", Low = 39, High = 148 },
                new RangeBarChartData { Country = "Georgia", Low = 68, High = 122 },
                new RangeBarChartData { Country = "Peru", Low = 56, High = 141 },
                new RangeBarChartData { Country = "Grenada", Low = 41, High = 147 },
                new RangeBarChartData { Country = "Dominica", Low = 46, High = 143 },
                new RangeBarChartData { Country = "Ukraine", Low = 64, High = 148 },
                new RangeBarChartData { Country = "Colombia", Low = 64, High = 134 }
            };
        }
    }
    public class RangeBarChartData
    {
        public string Country;
        public double Low;
        public double High;
    }
}