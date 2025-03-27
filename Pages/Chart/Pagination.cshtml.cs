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
    public class PaginationModel : PageModel
    {
        public List<PaginationChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<PaginationChartData>
            {
                new PaginationChartData { X = 1, XValue = "1 am", Y = 6, DataLabel = "6", DataLabel1 = "43" },
                new PaginationChartData { X = 2, XValue = "4 am", Y = 4, DataLabel = "4", DataLabel1 = "39" },
                new PaginationChartData { X = 3, XValue = "7 am", Y = 2, DataLabel = "2", DataLabel1 = "36" },
                new PaginationChartData { X = 4, XValue = "10 am", Y = 8, DataLabel = "8", DataLabel1 = "46" },
                new PaginationChartData { X = 5, XValue = "1 pm", Y = 12, DataLabel = "12", DataLabel1 = "54" },
                new PaginationChartData { X = 6, XValue = "4 pm", Y = 11, DataLabel = "11", DataLabel1 = "52" },
                new PaginationChartData { X = 7, XValue = "1 am", Y = 6, DataLabel = "6", DataLabel1 = "43" },
                new PaginationChartData { X = 8, XValue = "4 am", Y = 7, DataLabel = "7", DataLabel1 = "45" },
                new PaginationChartData { X = 9, XValue = "7 am", Y = 9, DataLabel = "9", DataLabel1 = "48" },
                new PaginationChartData { X = 10, XValue = "10 am", Y = 14, DataLabel = "14", DataLabel1 = "57" },
                new PaginationChartData { X = 11, XValue = "1 pm", Y = 16, DataLabel = "16", DataLabel1 = "61" },
                new PaginationChartData { X = 12, XValue = "4 pm", Y = 15, DataLabel = "15", DataLabel1 = "59" },
                new PaginationChartData { X = 13, XValue = "1 am", Y = 15, DataLabel = "15", DataLabel1 = "59" },
                new PaginationChartData { X = 14, XValue = "4 am", Y = 16, DataLabel = "16", DataLabel1 = "61" },
                new PaginationChartData { X = 15, XValue = "7 am", Y = 17, DataLabel = "17", DataLabel1 = "63" },
                new PaginationChartData { X = 16, XValue = "10 am", Y = 18, DataLabel = "18", DataLabel1 = "64" },
                new PaginationChartData { X = 17, XValue = "1 pm", Y = 18, DataLabel = "18", DataLabel1 = "64" },
                new PaginationChartData { X = 18, XValue = "4 pm", Y = 15, DataLabel = "15", DataLabel1 = "59" },
                new PaginationChartData { X = 19, XValue = "1 am", Y = 14, DataLabel = "14", DataLabel1 = "57" },
                new PaginationChartData { X = 20, XValue = "4 am", Y = 13, DataLabel = "13", DataLabel1 = "55" },
                new PaginationChartData { X = 21, XValue = "7 am", Y = 12, DataLabel = "12", DataLabel1 = "54" },
                new PaginationChartData { X = 22, XValue = "10 am", Y = 14, DataLabel = "14", DataLabel1 = "57" },
                new PaginationChartData { X = 23, XValue = "1 pm", Y = 16, DataLabel = "16", DataLabel1 = "61" },
                new PaginationChartData { X = 24, XValue = "4 pm", Y = 15, DataLabel = "15", DataLabel1 = "59" },
                new PaginationChartData { X = 25, XValue = "1 am", Y = 15, DataLabel = "15", DataLabel1 = "59" },
                new PaginationChartData { X = 26, XValue = "4 am", Y = 14, DataLabel = "14", DataLabel1 = "57" },
                new PaginationChartData { X = 27, XValue = "7 am", Y = 16, DataLabel = "16", DataLabel1 = "61" },
                new PaginationChartData { X = 28, XValue = "10 am", Y = 18, DataLabel = "18", DataLabel1 = "64" },
                new PaginationChartData { X = 29, XValue = "1 pm", Y = 16, DataLabel = "16", DataLabel1 = "61" },
                new PaginationChartData { X = 30, XValue = "4 pm", Y = 17, DataLabel = "17", DataLabel1 = "63" }
            };
        }
    }
    public class PaginationChartData
    {
        public double X;
        public string XValue;
        public double Y;
        public string DataLabel;
        public string DataLabel1;
    }
}
