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
    public class ColumnModel : PageModel
    {
        public List<ColumnChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<ColumnChartData>
            {
                new ColumnChartData { Country = "Chile", Walnuts = 175000, Almonds = 11300 },
                new ColumnChartData { Country = "European Union", Walnuts = 140000, Almonds = 135000 },
                new ColumnChartData {Country = "Turkey", Walnuts = 67000, Almonds = 24000 },
                new ColumnChartData {Country = "India", Walnuts = 33000, Almonds = 4200 },
                new ColumnChartData {Country = "Australia", Walnuts = 12000, Almonds = 154000 }
            };
        }
    }
    public class ColumnChartData
    {
        public string Country;
        public double Walnuts;
        public double Almonds;
    }
}
