#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
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
                new RangeColumnChartData { Month = "Jan", Min = 22.75, Max = 41.02, TooltipText = "January" },
                new RangeColumnChartData { Month = "Feb", Min = 29.71, Max = 51.93, TooltipText = "February" },
                new RangeColumnChartData { Month = "Mar", Min = 33.53, Max = 56.39, TooltipText = "March" },
                new RangeColumnChartData { Month = "Apr", Min = 41.22, Max = 66.06, TooltipText = "April" },
                new RangeColumnChartData { Month = "May", Min = 49.87, Max = 74.64, TooltipText = "May" },
                new RangeColumnChartData { Month = "Jun", Min = 59.02, Max = 84.58, TooltipText = "June" },
                new RangeColumnChartData { Month = "Jul", Min = 62.94, Max = 88.43, TooltipText = "July" },
                new RangeColumnChartData { Month = "Aug", Min = 61.27, Max = 86.72, TooltipText = "August" },
                new RangeColumnChartData { Month = "Sep", Min = 55.36, Max = 81.86, TooltipText = "September" },
                new RangeColumnChartData { Month = "Oct", Min = 44.76, Max = 73.13, TooltipText = "October" },
                new RangeColumnChartData { Month = "Nov", Min = 34.79, Max = 55.54, TooltipText = "November" },
                new RangeColumnChartData { Month = "Dec", Min = 28.04, Max = 48.36, TooltipText = "December" }
            };
        }
    }
    public class RangeColumnChartData
    {
        public string Month;
        public double Min;
        public double Max;
        public string TooltipText;
    }
}