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
    public class SeriesAnimationModel : PageModel
    {
        public List<DataPoint> LineData { get; set; }
        public List<DataPoint> ColumnData { get; set; }
        public List<DataPoint> SplineData { get; set; }
        public List<DataPoint> AreaData { get; set; }
        public List<DataPoint> BarData { get; set; }
        public List<DataPoint> BubbleData { get; set; }
        public List<DataPoint> ScatterData { get; set; }
        public List<DataPoint> StepLineData { get; set; }
        public List<DataRangePoint> RangeColumnData { get; set; }

        public void OnGet()
        {
            LineData = new List<DataPoint>
            {
                new DataPoint { x = "1", y = 30 },
                new DataPoint { x = "2", y = 10 },
                new DataPoint { x = "3", y = 80 },
                new DataPoint { x = "4", y = 20 },
                new DataPoint { x = "5", y = 30 },
                new DataPoint { x = "6", y = 5 },
                new DataPoint { x = "7", y = 69 },
                new DataPoint { x = "8", y = 15 },
                new DataPoint { x = "9", y = 60 },
                new DataPoint { x = "10", y = 70 }
            };
            ColumnData = new List<DataPoint>
            {
                new DataPoint { x = "1", y = 90 },
                new DataPoint { x = "2", y = 10 },
                new DataPoint { x = "3", y = 50 },
                new DataPoint { x = "4", y = 20 },
                new DataPoint { x = "5", y = 30 },
                new DataPoint { x = "6", y = 70 },
                new DataPoint { x = "7", y = 9 }
            };

            SplineData = new List<DataPoint>
            {
                new DataPoint { x = "1", y = 30 },
                new DataPoint { x = "2", y = 10 },
                new DataPoint { x = "3", y = 80 },
                new DataPoint { x = "4", y = 20 },
                new DataPoint { x = "5", y = 30 },
                new DataPoint { x = "6", y = 5 },
                new DataPoint { x = "7", y = 69 },
                new DataPoint { x = "8", y = 15 },
                new DataPoint { x = "9", y = 60 },
                new DataPoint { x = "10", y = 70 }
            };

            AreaData = new List<DataPoint>
            {
                new DataPoint { x = "1", y = 10 },
                new DataPoint { x = "2", y = 20 },
                new DataPoint { x = "3", y = 80 },
                new DataPoint { x = "4", y = 15 },
                new DataPoint { x = "5", y = 30 },
                new DataPoint { x = "6", y = 40 },
                new DataPoint { x = "7", y = 69 },
                new DataPoint { x = "8", y = 15 }
            };

            BarData = new List<DataPoint>
            {
                new DataPoint { x = "1", y = 90 },
                new DataPoint { x = "2", y = 10 },
                new DataPoint { x = "3", y = 50 },
                new DataPoint { x = "4", y = 20 },
                new DataPoint { x = "5", y = 30 },
                new DataPoint { x = "6", y = 70 },
                new DataPoint { x = "7", y = 9 }
            };

            BubbleData = new List<DataPoint>
            {
                new DataPoint { x = "1.5", y = 80, size = 5 },
                new DataPoint { x = "2", y = 60, size = 10 },
                new DataPoint { x = "3", y = 70, size = 8 },
                new DataPoint { x = "4", y = 13, size = 6 },
                new DataPoint { x = "5", y = 30, size = 9 },
                new DataPoint { x = "6", y = 20, size = 7 },
                new DataPoint { x = "6.5", y = 40, size = 11 }
            };

            ScatterData = new List<DataPoint>
            {
                new DataPoint { x = "1", y = 15, y1 = 10 },
                new DataPoint { x = "1.25", y = 35, y1 = 20 },
                new DataPoint { x = "1.5", y = 60, y1 = 50 },
                new DataPoint { x = "1.75", y = 25, y1 = 15 },
                new DataPoint { x = "2", y = 25, y1 = 35 },
                new DataPoint { x = "2.25", y = 30, y1 = 30 },
                new DataPoint { x = "2.5", y = 45, y1 = 30 },
                new DataPoint { x = "2.75", y = 40, y1 = 20 },
                new DataPoint { x = "3", y = 30, y1 = 45 },
                new DataPoint { x = "3.25", y = 55, y1 = 35 },
                new DataPoint { x = "3.5", y = 65, y1 = 20 },
                new DataPoint { x = "3.75", y = 40, y1 = 50 },
                new DataPoint { x = "4", y = 40, y1 = 60 },
                new DataPoint { x = "4.25", y = 60, y1 = 25 },
                new DataPoint { x = "4.5", y = 15, y1 = 25 },
                new DataPoint { x = "4.75", y = 75, y1 = 55 },
                new DataPoint { x = "5", y = 50, y1 = 40 },
                new DataPoint { x = "5.25", y = 45, y1 = 30 },
                new DataPoint { x = "5.5", y = 20, y1 = 15 },
                new DataPoint { x = "5.75", y = 65, y1 = 35 },
                new DataPoint { x = "6", y = 65, y1 = 65 },
                new DataPoint { x = "6.25", y = 35, y1 = 50 },
                new DataPoint { x = "6.5", y = 70, y1 = 35 },
                new DataPoint { x = "6.75", y = 50, y1 = 40 },
                new DataPoint { x = "7", y = 25, y1 = 60 },
                new DataPoint { x = "7.25", y = 60, y1 = 45 },
                new DataPoint { x = "7.5", y = 45, y1 = 20 },
                new DataPoint { x = "7.75", y = 30, y1 = 15 },
                new DataPoint { x = "8", y = 60, y1 = 50 },
                new DataPoint { x = "8.25", y = 25, y1 = 35 },
                new DataPoint { x = "8.5", y = 30, y1 = 10 },
                new DataPoint { x = "8.75", y = 45, y1 = 25 },
                new DataPoint { x = "9", y = 75, y1 = 45 },
                new DataPoint { x = "9.25", y = 40, y1 = 50 },
                new DataPoint { x = "9.5", y = 20, y1 = 15 },
                new DataPoint { x = "9.75", y = 30, y1 = 40 },
                new DataPoint { x = "10", y = 60, y1 = 25 }
            };

            StepLineData = new List<DataPoint>
            {
                new DataPoint { x = "1", y = 10 },
                new DataPoint { x = "2", y = 30 },
                new DataPoint { x = "3", y = 80 },
                new DataPoint { x = "4", y = 20 },
                new DataPoint { x = "5", y = 30 },
                new DataPoint { x = "6", y = 40 },
                new DataPoint { x = "7", y = 69 },
                new DataPoint { x = "8", y = 15 },
                new DataPoint { x = "9", y = 60 },
                new DataPoint { x = "10", y = 70 }
            };

            RangeColumnData = new List<DataRangePoint>
            {
                new DataRangePoint { x = "1", low = 30, high = 60 },
                new DataRangePoint { x = "2", low = 42, high = 73 },
                new DataRangePoint { x = "3", low = 35, high = 80 },
                new DataRangePoint { x = "4", low = 20, high = 50 },
                new DataRangePoint { x = "5", low = 30, high = 80 },
                new DataRangePoint { x = "6", low = 10, high = 40 },
                new DataRangePoint { x = "7", low = 15, high = 69 }
            };


        }
        public class DataPoint
        {
            public string x { get; set; }
            public double y { get; set; }
			public double? size { get; set; }
            public double? y1 { get; set; }  // Only used for scatter with multiple series
        }

        public class DataRangePoint
        {
            public string x { get; set; }
            public double low { get; set; }
            public double high { get; set; }
        }
    }
}