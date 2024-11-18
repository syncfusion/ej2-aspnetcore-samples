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
    public class PolarRangeColumnModel : PageModel
    {
        public List<PolarRangeColumnData> ChartPoints { get; set; }
        public string[] Select { get; set; }

        public void OnGet()
        {
            ChartPoints = new List<PolarRangeColumnData>
            {
                new PolarRangeColumnData { Month = "Jan", MinTemp = 2, MaxTemp = 7 },
                new PolarRangeColumnData { Month = "Feb", MinTemp = 3, MaxTemp = 7 },
                new PolarRangeColumnData { Month = "Mar", MinTemp = 3, MaxTemp = 7 },
                new PolarRangeColumnData { Month = "Apr", MinTemp = 4, MaxTemp = 9 },
                new PolarRangeColumnData { Month = "May", MinTemp = 6, MaxTemp = 11 },
                new PolarRangeColumnData { Month = "June", MinTemp = 8,MaxTemp = 14 }
            };
            Select = new string[] { "Polar", "Radar" };
        }
    }
    public class PolarRangeColumnData
    {
        public string Month;
        public double MinTemp;
        public double MaxTemp;
    }
    
}