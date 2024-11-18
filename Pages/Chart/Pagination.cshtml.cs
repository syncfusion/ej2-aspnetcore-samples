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
    public class PaginationModel : PageModel
    {
        public List<PaginationChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<PaginationChartData>
            {
                new PaginationChartData { X = 1,  XValue = "1 am",  Y = 20 },
                new PaginationChartData { X = 2,  XValue = "4 am",  Y = 20 },
                new PaginationChartData { X = 3,  XValue = "7 am",  Y = 20 },
                new PaginationChartData { X = 4,  XValue = "10 am", Y = 21 },
                new PaginationChartData { X = 5,  XValue = "1 pm",  Y = 21 },
                new PaginationChartData { X = 6,  XValue = "4 pm",  Y = 24 },
                new PaginationChartData { X = 7,  XValue = "1 am",  Y = 19 },
                new PaginationChartData { X = 8,  XValue = "4 am",  Y = 20 },
                new PaginationChartData { X = 9,  XValue = "7 am",  Y = 20 },
                new PaginationChartData { X = 10, XValue = "10 am", Y = 21 },
                new PaginationChartData { X = 11, XValue = "1 pm",  Y = 24 },
                new PaginationChartData { X = 12, XValue = "4 pm",  Y = 24 },
                new PaginationChartData { X = 13, XValue = "1 am",  Y = 21 },
                new PaginationChartData { X = 14, XValue = "4 am",  Y = 21 },
                new PaginationChartData { X = 15, XValue = "7 am",  Y = 21 },
                new PaginationChartData { X = 16, XValue = "10 am", Y = 22 },
                new PaginationChartData { X = 17, XValue = "1 pm",  Y = 23 },
                new PaginationChartData { X = 18, XValue = "4 pm",  Y = 24 },
                new PaginationChartData { X = 19, XValue = "1 am",  Y = 20 },
                new PaginationChartData { X = 20, XValue = "4 am",  Y = 19 },
                new PaginationChartData { X = 21, XValue = "7 am",  Y = 19 },
                new PaginationChartData { X = 22, XValue = "10 am", Y = 18 },
                new PaginationChartData { X = 23, XValue = "1 pm",  Y = 19 },
                new PaginationChartData { X = 24, XValue = "4 pm",  Y = 19 },
                new PaginationChartData { X = 25, XValue = "1 am",  Y = 16 },
                new PaginationChartData { X = 26, XValue = "4 am",  Y = 15 },
                new PaginationChartData { X = 27, XValue = "7 am",  Y = 14 },
                new PaginationChartData { X = 28, XValue = "10 am", Y = 15 },
                new PaginationChartData { X = 29, XValue = "1 pm",  Y = 16 },
                new PaginationChartData { X = 30, XValue = "4 pm",  Y = 18 }
            };
        }
    }
    public class PaginationChartData
    {
        public double X;
        public string XValue;
        public double Y;
    }
}
