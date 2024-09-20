#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.Chart
{
    public class MultipleAxisModel : PageModel
    {
        public List<MultipleAxesChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<MultipleAxesChartData>
            {
                new MultipleAxesChartData { Day = "SUN", DEU_Temp = 35, JPN_Temp = 31 },
                new MultipleAxesChartData { Day = "MON", DEU_Temp = 40, JPN_Temp = 28 },
                new MultipleAxesChartData { Day = "TUE", DEU_Temp = 50, JPN_Temp = 29 },
                new MultipleAxesChartData { Day = "WED", DEU_Temp = 70, JPN_Temp = 30 },
                new MultipleAxesChartData { Day = "THU", DEU_Temp = 65, JPN_Temp = 33 },
                new MultipleAxesChartData { Day = "FRI", DEU_Temp = 55, JPN_Temp = 32},
                new MultipleAxesChartData { Day = "SAT", DEU_Temp = 50, JPN_Temp = 34 },          
            };
        }
    }
    public class MultipleAxesChartData
    {
        public string Day;
        public double DEU_Temp;
        public double JPN_Temp;
    }
}
