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
    public class SortingModel : PageModel
    {
        public List<SortingData> ChartData { get; set; }
        public String[] Select { get; set; }

        public void OnGet()
        {
            ChartData = new List<SortingData>
            {
                new SortingData { x= "Asia ", car= 120, trucks= 90, bike= 180, cycle= 90 },
                new SortingData { x= "Canada ", car= 100, trucks= 80, bike= 90, cycle= 80 },
                new SortingData { x= "Europe ", car= 80, trucks= 90, bike= 60, cycle= 50 },
                new SortingData { x= "Africa ", car= 40, trucks= 20, bike= 30, cycle= 30 },
                new SortingData { x= "Mexico ", car= 40, trucks= 50, bike= 80, cycle= 50 },
                new SortingData { x= "US ", car= 140, trucks= 90, bike= 75, cycle= 70 }
            };
            Select = new String[] { "None", "Sort By X", "Sort By Y" };
        }
    }
    public class SortingData
    {
        public string x;
        public double car;
        public double trucks;
        public double bike;
        public double cycle;
    }
}