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
    public class WaterfallModel : PageModel
    {
        public List<WaterfallChartData> ChartPoints { get; set; }

        public void OnGet()
        {
            ChartPoints = new List<WaterfallChartData>
            {
                new WaterfallChartData { X = "Income", Y = 971  },
                new WaterfallChartData { X = "Sales", Y = -101 },
                new WaterfallChartData { X = "Development", Y = -268 },
                new WaterfallChartData { X = "Revenue", Y = 403 },
                new WaterfallChartData { X = "Balance" },
                new WaterfallChartData { X = "Expense", Y = -136 },
                new WaterfallChartData { X = "Tax", Y = -365 },
                new WaterfallChartData { X = "Net Profit" }
            };
            
        }
    }
    public class WaterfallChartData 
    {
        public string X;
        public double Y;
    }
}