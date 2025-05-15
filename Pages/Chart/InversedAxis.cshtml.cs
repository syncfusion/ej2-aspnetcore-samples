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
    public class InversedAxisModel : PageModel
    {
        public void OnGet()
        {
        }
        public List<InversedAxisChartData> ChartPoints = new List<InversedAxisChartData>
            {
                new InversedAxisChartData { Year = "2008", ExchangeRate = 1.5 },
                new InversedAxisChartData { Year = "2009", ExchangeRate = 7.6 },
                new InversedAxisChartData { Year = "2010", ExchangeRate = 11 },
                new InversedAxisChartData { Year = "2011", ExchangeRate = 16.2 },
                new InversedAxisChartData { Year = "2012", ExchangeRate = 18 },
                new InversedAxisChartData { Year = "2013", ExchangeRate = 21.4 },
                new InversedAxisChartData { Year = "2014", ExchangeRate = 16 },
                new InversedAxisChartData { Year = "2015", ExchangeRate = 17.1 }
             };
    }
    public class InversedAxisChartData
    {
        public string Year;
        public double ExchangeRate;
       
    }
}
