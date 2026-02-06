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
    public class StackedBar100Model : PageModel
    {
        public List<StackedBar100ChartData> ChartPoints { get; set; }

        public void OnGet()
        {
            ChartPoints = new List<StackedBar100ChartData>
            {
                new StackedBar100ChartData { X = "2020", Y1 = 466, Y2 = 261, Y3 = 1355 },
                new StackedBar100ChartData { X = "2021", Y1 = 656, Y2 = 327, Y3 = 1340 },
                new StackedBar100ChartData { X = "2022", Y1 = 763, Y2 = 427, Y3 = 1352 },
                new StackedBar100ChartData { X = "2023", Y1 = 886, Y2 = 584, Y3 = 1286 }
            };
        }
    }
    public class StackedBar100ChartData
    {
        public string X;
        public double Y1;
        public double Y2;
        public double Y3;
    }
}