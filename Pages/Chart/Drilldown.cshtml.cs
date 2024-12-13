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
    public class DrilldownModel : PageModel
    {
        public List<CategoryData> ChartData { get; set; }
        public void OnGet()
        {
            ChartData = new List<CategoryData>
            {
                new CategoryData { x = "SUV", y = 25 },
                new CategoryData { x = "Car", y = 37 },
                new CategoryData { x = "Pickup", y = 15 },
                new CategoryData { x = "Minivan", y = 23 }
            };
        }
    }
    public class CategoryData
    {
        public string x;
        public double y;
    }
}
