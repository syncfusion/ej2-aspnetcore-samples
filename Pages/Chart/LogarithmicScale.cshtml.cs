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
    public class LogarithmicScaleModel : PageModel
    {
        public List<LogarithmicScaleChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<LogarithmicScaleChartData>
            {
                new LogarithmicScaleChartData { Period = new DateTime(1995, 1, 1),  ProfitInfo = 80  },
                new LogarithmicScaleChartData { Period = new DateTime(1996, 1, 1),  ProfitInfo = 200 },
                new LogarithmicScaleChartData { Period = new DateTime(1997, 1, 1),  ProfitInfo = 400 },
                new LogarithmicScaleChartData { Period = new DateTime(1998, 1, 1),  ProfitInfo = 600 },
                new LogarithmicScaleChartData { Period = new DateTime(1999, 1, 1),  ProfitInfo = 700 },
                new LogarithmicScaleChartData { Period = new DateTime(2000, 1, 1),  ProfitInfo = 1400 },
                new LogarithmicScaleChartData { Period = new DateTime(2001, 1, 1),  ProfitInfo = 2000 },
                new LogarithmicScaleChartData { Period = new DateTime(2002, 1, 1),  ProfitInfo = 4000 },
                new LogarithmicScaleChartData { Period = new DateTime(2003, 1, 1),  ProfitInfo = 6000 },
                new LogarithmicScaleChartData { Period = new DateTime(2004, 1, 1),  ProfitInfo = 8000 },
                new LogarithmicScaleChartData { Period = new DateTime(2005, 1, 1),  ProfitInfo = 11000 }
            };
        }
    }
    public class LogarithmicScaleChartData
    {
        public DateTime Period;
        public double ProfitInfo;
    }
}
