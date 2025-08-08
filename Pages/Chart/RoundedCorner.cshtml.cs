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
    public class CornerRadiusModel : PageModel
    {
        public List<CornerRadiusChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<CornerRadiusChartData>
            {
                new CornerRadiusChartData { X = "Android",  Y = 45.49, Text = "Android: 45.49%" },
                new CornerRadiusChartData { X = "Windows",  Y = 25.35, Text = "Windows: 25.35%" },
                new CornerRadiusChartData { X = "iOS",      Y = 18.26, Text = "iOS: 18.26%" },
                new CornerRadiusChartData { X = "macOS",    Y = 5.06,  Text = "macOS: 5.06%" },
                new CornerRadiusChartData { X = "Linux",    Y = 1.48,  Text = "Linux: 1.48%" },
                new CornerRadiusChartData { X = "Others",   Y = 4.36,  Text = "Others: 4.36%" }

            };
        }
    }
    public class CornerRadiusChartData
    {
        public string X;
        public double Y;
        public string Text;
    }
}
