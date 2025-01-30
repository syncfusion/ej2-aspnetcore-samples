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
    public class StackedBarModel : PageModel
    {
        public List<StackedBarChartData> ChartPoints { get; set; }

        public void OnGet()
        {
            ChartPoints = new List<StackedBarChartData>
            {
                new StackedBarChartData { Month = "Jan", AppleSales = 6, OrangeSales = 6, Wastage = -1 },
                new StackedBarChartData { Month = "Feb", AppleSales = 8, OrangeSales = 8, Wastage = -1.5 },
                new StackedBarChartData { Month = "Mar", AppleSales = 12, OrangeSales = 11, Wastage = -2 },
                new StackedBarChartData { Month = "Apr", AppleSales = 15.5, OrangeSales = 16, Wastage = -2.5 },
                new StackedBarChartData { Month = "May", AppleSales = 20, OrangeSales = 21, Wastage = -3 },
                new StackedBarChartData { Month = "Jun", AppleSales = 24, OrangeSales = 25, Wastage = -3.5 }
            };
        }
    }
    public class StackedBarChartData
    {
        public string Month;
        public double AppleSales;
        public double OrangeSales;
        public double Wastage;
    }
}