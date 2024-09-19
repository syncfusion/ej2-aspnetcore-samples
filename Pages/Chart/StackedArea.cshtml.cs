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
    public class StackedAreaModel : PageModel
    {
        public List<StackedAreaChartData> ChartPoints { get; set; }

        public void OnGet()
        {
            ChartPoints = new List<StackedAreaChartData>
            {
                new StackedAreaChartData { Period = new DateTime(2000, 01, 01), OrganicSales = 0.61, FairTradeSales = 0.03, VegAlternativesSales = 0.48, OtherSales = 0.23 },
                new StackedAreaChartData { Period = new DateTime(2002, 01, 01), OrganicSales = 0.91, FairTradeSales = 0.06, VegAlternativesSales = 0.57, OtherSales = 0.17 },
                new StackedAreaChartData { Period = new DateTime(2004, 01, 01), OrganicSales = 1.19, FairTradeSales = 0.14, VegAlternativesSales = 0.63, OtherSales = 0.23 },        
                new StackedAreaChartData { Period = new DateTime(2006, 01, 01), OrganicSales = 1.74, FairTradeSales = 0.29, VegAlternativesSales = 0.66, OtherSales = 0.43 },        
                new StackedAreaChartData { Period = new DateTime(2008, 01, 01), OrganicSales = 1.99, FairTradeSales = 0.64, VegAlternativesSales = 0.77, OtherSales = 0.72 },        
                new StackedAreaChartData { Period = new DateTime(2010, 01, 01), OrganicSales = 1.48, FairTradeSales = 1.06, VegAlternativesSales = 0.54, OtherSales = 1.38 },        
                new StackedAreaChartData { Period = new DateTime(2012, 01, 01), OrganicSales = 1.66, FairTradeSales = 1.55, VegAlternativesSales = 0.61, OtherSales = 2.16 },        
                new StackedAreaChartData { Period = new DateTime(2014, 01, 01), OrganicSales = 1.67, FairTradeSales = 1.65, VegAlternativesSales = 0.67, OtherSales = 2.61 }
            };
        }
    }
    public class StackedAreaChartData
    {
        public DateTime Period;
        public double OrganicSales;
        public double FairTradeSales;
        public double VegAlternativesSales;
        public double OtherSales;
    }
}