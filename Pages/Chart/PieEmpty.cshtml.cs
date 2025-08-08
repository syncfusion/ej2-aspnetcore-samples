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
    public class PieEmptyModel : PageModel
    {
        public List<PieChartEmptyPointsData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<PieChartEmptyPointsData>
            {
                new PieChartEmptyPointsData { Product= "Action",  ProfitPercentage= 35 },
                new PieChartEmptyPointsData { Product= "Drama",   ProfitPercentage= 25 },
                new PieChartEmptyPointsData { Product= "Comedy",  ProfitPercentage= null },
                new PieChartEmptyPointsData { Product= "Romance", ProfitPercentage= 20 },
                new PieChartEmptyPointsData { Product= "Horror",  ProfitPercentage= 10 },
                new PieChartEmptyPointsData { Product= "Sci-Fi",  ProfitPercentage= null }
            };
        }
    }
    public class PieChartEmptyPointsData
    {
        public string Product;
        public double? ProfitPercentage;
    }
    
}