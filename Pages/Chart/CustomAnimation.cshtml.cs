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
    public class CustomAnimationModel : PageModel
    {
        public List<CustomAnimationChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<CustomAnimationChartData>
            {
                new CustomAnimationChartData { X = new DateTime(2010, 01, 01), Y = 5.00, Y1 = 4.54, Y2 = 3.62, Y3 = 2.92, Y4 = 1.87 },
                new CustomAnimationChartData { X = new DateTime(2011, 01, 01), Y = 5.69, Y1 = 4.50, Y2 = 3.23, Y3 = 3.00, Y4 = 1.87 },
                new CustomAnimationChartData { X = new DateTime(2012, 01, 01), Y = 4.99, Y1 = 4.60, Y2 = 4.19, Y3 = 2.97, Y4 = 1.85 },
                new CustomAnimationChartData { X = new DateTime(2013, 01, 01), Y = 5.65, Y1 = 5.04, Y2 = 2.99, Y3 = 2.97, Y4 = 1.84 },
                new CustomAnimationChartData { X = new DateTime(2014, 01, 01), Y = 5.43, Y1 = 4.39, Y2 = 3.07, Y3 = 2.00, Y4 = 1.84 },
                new CustomAnimationChartData { X = new DateTime(2015, 01, 01), Y = 5.51, Y1 = 3.86, Y2 = 3.19, Y3 = 1.88, Y4 = 1.65 },
                new CustomAnimationChartData { X = new DateTime(2016, 01, 01), Y = 6.12, Y1 = 4.12, Y2 = 3.28, Y3 = 1.81, Y4 = 1.69 },
                new CustomAnimationChartData { X = new DateTime(2017, 01, 01), Y = 6.68, Y1 = 6.35, Y2 = 4.12, Y3 = 1.79, Y4 = 1.38 },
                new CustomAnimationChartData { X = new DateTime(2018, 01, 01), Y = 5.52, Y1 = 3.90, Y2 = 3.39, Y3 = 1.75, Y4 = 1.72 },
                new CustomAnimationChartData { X = new DateTime(2019, 01, 01), Y = 5.59, Y1 = 4.01, Y2 = 3.46, Y3 = 1.75, Y4 = 1.31 },
                new CustomAnimationChartData { X = new DateTime(2020, 01, 01), Y = 5.46, Y1 = 4.64, Y2 = 3.52, Y3 = 1.78, Y4 = 1.75 },
                new CustomAnimationChartData { X = new DateTime(2021, 01, 01), Y = 6.08, Y1 = 4.12, Y2 = 3.58, Y3 = 1.74, Y4 = 1.29 },
                new CustomAnimationChartData { X = new DateTime(2022, 01, 01), Y = 6.23, Y1 = 3.64, Y2 = 3.40, Y3 = 1.73, Y4 = 1.64 }
            };
        }
    }
    public class CustomAnimationChartData
    {
        public DateTime X;
        public double Y;
        public double Y1;
        public double Y2;
        public double Y3;
        public double Y4;
    }
}
