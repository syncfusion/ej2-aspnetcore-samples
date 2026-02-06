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
    public class PiePatternsModel : PageModel
    {
        public List<PiePatternsChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<PiePatternsChartData>
            {
                new PiePatternsChartData { X = "Internet Explorer",  Y = 6.12,   Text = "Internet Explorer: 6.12%" },
                new PiePatternsChartData { X = "Chrome",             Y = 57.28,  Text = "Chrome: 57.28%" },
                new PiePatternsChartData { X = "Safari",             Y = 4.73,   Text = "Safari: 4.73%" },
                new PiePatternsChartData { X = "QQ",                 Y = 5.96,   Text = "QQ: 5.96%" },
                new PiePatternsChartData { X = "UC Browser",         Y = 4.37,   Text = "UC Browser: 4.37%" },
                new PiePatternsChartData { X = "Edge",               Y = 7.48,   Text = "Edge: 7.48%" },
                new PiePatternsChartData { X = "Others",             Y = 14.06,  Text = "Others: 14.06%" }
            };
            bool isMobile = Request.Headers["User-Agent"].ToString().Contains("Mobi");
            if (isMobile)
            {
                ChartPoints[0].Text = "Internet Explorer:<br> 6.12%";
                ChartPoints[1].Text = "Chrome:<br> 57.282%";
                ChartPoints[2].Text = "Safari:<br> 4.73%";
                ChartPoints[3].Text = "QQ:<br>5.96%";
                ChartPoints[4].Text = "UC Browser:<br>4.37%";
                ChartPoints[5].Text = "Edge:<br> 7.48%";
                ChartPoints[6].Text = "Others:<br> 14.06%";
            };
        }
    }
    public class PiePatternsChartData
    {
        public string X;
        public double Y;
        public string Text;
    }
}
