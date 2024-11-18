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
    public class MultiSeriesChartModel : PageModel
    {
        public List<CombinationSeriesData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<CombinationSeriesData>
            {
                new CombinationSeriesData { Period = "2005", PVT_Consumption = 1.2, GOVT_Consumption = 0.5, Investment = 0.7, Trade = -0.8, GDP = 1.5 },
                new CombinationSeriesData { Period = "2006", PVT_Consumption = 1, GOVT_Consumption = 0.5, Investment = 1.4, Trade = 0, GDP = 2.3 },
                new CombinationSeriesData { Period = "2007", PVT_Consumption = 1, GOVT_Consumption = 0.5, Investment = 1.5, Trade = -1, GDP = 2 },
                new CombinationSeriesData { Period = "2008", PVT_Consumption = 0.25, GOVT_Consumption = 0.35, Investment = 0.35, Trade = -.35, GDP = 0.1 },
                new CombinationSeriesData { Period = "2009", PVT_Consumption = 0.1, GOVT_Consumption = 0.9, Investment = -2.7, Trade = -0.3, GDP = -2.7 },
                new CombinationSeriesData { Period = "2010", PVT_Consumption = 1, GOVT_Consumption = 0.5, Investment = 0.5, Trade = -0.5, GDP = 1.8 },
                new CombinationSeriesData { Period = "2011", PVT_Consumption = 0.1, GOVT_Consumption = 0.25, Investment = 0.25, Trade = 0, GDP = 2 },
                new CombinationSeriesData { Period = "2012", PVT_Consumption = -0.25, GOVT_Consumption = -0.5, Investment = -0.1, Trade = -0.4, GDP = 0.4 },
                new CombinationSeriesData { Period = "2013", PVT_Consumption = 0.25, GOVT_Consumption = 0.5, Investment = -0.3, Trade = 0, GDP = 0.9 },
                new CombinationSeriesData { Period = "2014", PVT_Consumption = 0.6, GOVT_Consumption = 0.6, Investment = -0.6, Trade = -0.6, GDP = 0.4 },
                new CombinationSeriesData { Period = "2015", PVT_Consumption = 0.9, GOVT_Consumption = 0.5, Investment = 0, Trade = -0.3, GDP = 1.3 }
            };
        }
    }
    public class CombinationSeriesData
    {
        public string Period;
        public double PVT_Consumption;
        public double GOVT_Consumption;
        public double Investment;
        public double Trade;
        public double GDP;
    }
}
