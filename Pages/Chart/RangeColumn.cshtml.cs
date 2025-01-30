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
    public class RangeColumnModel : PageModel
    {
        public List<RangeColumnChartData> ChartPoints { get; set; }

        public void OnGet()
        {
            ChartPoints = new List<RangeColumnChartData>
            {
                new RangeColumnChartData { Days = "Sun", IND_LowTemp = 3.1, IND_HighTemp = 10.8 },
                new RangeColumnChartData { Days = "Mon", IND_LowTemp = 5.7, IND_HighTemp = 14.4  },
                new RangeColumnChartData { Days = "Tue", IND_LowTemp = 8.4, IND_HighTemp = 16.9 },
                new RangeColumnChartData { Days = "Wed", IND_LowTemp = 9.6, IND_HighTemp = 18.2 },
                new RangeColumnChartData { Days = "Thu", IND_LowTemp = 8.5, IND_HighTemp = 16.1 },
                new RangeColumnChartData { Days = "Fri", IND_LowTemp = 6.0, IND_HighTemp = 12.5 },
                new RangeColumnChartData { Days = "Sat", IND_LowTemp = 1.5, IND_HighTemp = 6.9 }
            };
        }
    }
    public class RangeColumnChartData
    {
        public string Days;
        public double IND_LowTemp;
        public double IND_HighTemp;
    }
}