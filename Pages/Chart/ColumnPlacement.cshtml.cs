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
    public class ColumnPlacementModel : PageModel
    {
        public List<ColumnPlacementChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints= new List<ColumnPlacementChartData>
            {
                new ColumnPlacementChartData { Country = "India", Population = 1450935791, Male = 748323427, Female = 702612364 },
                new ColumnPlacementChartData { Country = "China", Population = 1419321278, Male = 723023723, Female = 696297555 },
                new ColumnPlacementChartData { Country = "USA", Population = 345426571, Male = 173551527, Female = 171875044 },
                new ColumnPlacementChartData { Country = "Indonesia", Population = 283487931, Male = 142407931, Female = 141080014 },
                new ColumnPlacementChartData { Country = "Pakistan", Population = 251269164, Male = 127433405, Female = 123835758 }
            };
        }
    }
    public class ColumnPlacementChartData
    {
        public string Country;
        public double Population;
        public double Male;
        public double Female;
    }
}
