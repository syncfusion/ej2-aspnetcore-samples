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
    public class CornerRadiusModel : PageModel
    {
        public List<CornerRadiusChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<CornerRadiusChartData>
            {
                new CornerRadiusChartData { X = "Operations",                Y = 30.0,  Text = "30.0%" },
                new CornerRadiusChartData { X = "Miscellaneous",             Y = 10.0,  Text = "10.0%" },
                new CornerRadiusChartData { X = "Human Resources",           Y = 15.0,  Text = "15.0%" },
                new CornerRadiusChartData { X = "Research and Development",  Y = 20.0,  Text = "20.0%" },
                new CornerRadiusChartData { X = "Marketing",                 Y = 25.0,  Text = "25.0%" }
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
