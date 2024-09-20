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
    public class DateTimeAxisModel : PageModel
    {
        public List<DateTimeData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<DateTimeData>
            {
                new DateTimeData { Period = new DateTime(2016, 3, 07), MaxTemp = 6.3,  MinTemp = -5.3},
                new DateTimeData { Period = new DateTime(2016, 4, 15), MaxTemp = 13.3, MinTemp = 1.0 },
                new DateTimeData { Period = new DateTime(2016, 5, 10), MaxTemp = 18.0, MinTemp = 6.9 },
                new DateTimeData { Period = new DateTime(2016, 6, 17), MaxTemp = 19.8, MinTemp = 9.4 },
                new DateTimeData { Period = new DateTime(2016, 7, 13), MaxTemp = 18.1, MinTemp = 7.6 },
                new DateTimeData { Period = new DateTime(2016, 8, 11), MaxTemp = 13.1, MinTemp = 2.6 },
                new DateTimeData { Period = new DateTime(2016, 9, 16), MaxTemp = 4.1,  MinTemp = -4.9 }
            };
        }
    }
    public class DateTimeData
    {
        public DateTime Period;
        public double MaxTemp;
        public double MinTemp;
    }
}
