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
    public class StackedBar100Model : PageModel
    {
        public List<StackedBar100ChartData> ChartPoints { get; set; }

        public void OnGet()
        {
            ChartPoints = new List<StackedBar100ChartData>
            {
                new StackedBar100ChartData { Month = "Jan", AppleSales = 6, OrangeSales = 6, Wasteage = 1 },
                new StackedBar100ChartData { Month = "Feb", AppleSales = 8, OrangeSales = 8, Wasteage = 1.5 },
                new StackedBar100ChartData { Month = "Mar", AppleSales = 12, OrangeSales = 11, Wasteage = 2 },
                new StackedBar100ChartData { Month = "Apr", AppleSales = 15, OrangeSales = 16, Wasteage = 2.5 },
                new StackedBar100ChartData { Month = "May", AppleSales = 20, OrangeSales = 21, Wasteage = 3 },
                new StackedBar100ChartData { Month = "Jun", AppleSales = 24, OrangeSales = 25, Wasteage = 3.5 }
            };
        }
    }
    public class StackedBar100ChartData
    {
        public string Month;
        public double AppleSales;
        public double OrangeSales;
        public double Wasteage;
    }
}