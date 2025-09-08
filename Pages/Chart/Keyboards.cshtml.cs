#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Charts;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class KeyboardsModel : PageModel
    {
        public void OnGet()
        {
        }
        public List<ChartStripLine> yAxisStrips = new List<ChartStripLine>
            {
                new ChartStripLine { IsSegmented = true, Start = 33, End = 35.5, Visible = true, SegmentStart = 0, SegmentEnd = 5 },
                new ChartStripLine { IsSegmented = true, Start = 39, End = 39.2, Visible = true, Text = "Jan - Mar", SegmentStart = 0, SegmentEnd = 5, Color = "transparent" },
                new ChartStripLine { IsSegmented = true, Start = 65, End = 67.5, Visible = true, SegmentStart = 7, SegmentEnd = 12 },
                new ChartStripLine { IsSegmented = true, Start = 70, End = 70.2, Visible = true, Text = "Apr - Jun", SegmentStart = 7, SegmentEnd = 12, Color = "transparent" },
                new ChartStripLine { IsSegmented = true, Start = 65, End = 67.5, Visible = true, SegmentStart = 14, SegmentEnd = 19 },
                new ChartStripLine { IsSegmented = true, Start = 70, End = 70.2, Visible = true, Text = "Jul - Sep", SegmentStart = 14, SegmentEnd = 19, Color = "transparent" },
                new ChartStripLine { IsSegmented = true, Start = 104, End = 106.5, Visible = true, SegmentStart  = 21, SegmentEnd = 26 },
                new ChartStripLine { IsSegmented = true, Start = 109, End = 109.2, Visible = true, Text = "Oct - Dec", SegmentStart = 21, SegmentEnd = 26, Color = "transparent" }
            };


        public List<KeyBoardData> Quarter1 = new List<KeyBoardData>
            {
                new KeyBoardData { Month = "Jan 15", Sales = 10 },
                new KeyBoardData { Month = "Jan 31", Sales = 15 },
                new KeyBoardData { Month = "Feb 15", Sales = 15 },
                new KeyBoardData { Month = "Feb 28", Sales = 20 },
                new KeyBoardData { Month = "March 15", Sales = 20 },
                new KeyBoardData { Month = "March 31", Sales = 25 },
                new KeyBoardData { Month = "March", Sales = null }
            };

        public List<KeyBoardData> Quarter2 = new List<KeyBoardData>
            {
                new KeyBoardData { Month = "Apr 15", Sales = 36 },
                new KeyBoardData { Month = "Apr 30", Sales = 48 },
                new KeyBoardData { Month = "May 15", Sales = 43 },
                new KeyBoardData { Month = "May 31", Sales = 59 },
                new KeyBoardData { Month = "Jun 15", Sales = 35 },
                new KeyBoardData { Month = "Jun 30", Sales = 50 },
                new KeyBoardData { Month = "Jun", Sales = null }
            };
        public List<KeyBoardData> Quarter3 = new List<KeyBoardData>
            {
                new KeyBoardData { Month = "Jul 15", Sales = 30 },
                new KeyBoardData { Month = "Jul 31", Sales = 45 },
                new KeyBoardData { Month = "Aug 15", Sales = 30 },
                new KeyBoardData { Month = "Aug 31", Sales = 55 },
                new KeyBoardData { Month = "Sep 15", Sales = 57 },
                new KeyBoardData { Month = "Sep 30", Sales = 60 },
                new KeyBoardData { Month = "Sep", Sales = null }
            };
        public List<KeyBoardData> Quarter4 = new List<KeyBoardData>
            {
                new KeyBoardData { Month = "Oct 15", Sales = 60 },
                new KeyBoardData { Month = "Oct 31", Sales = 70 },
                new KeyBoardData { Month = "Nov 15", Sales = 70 },
                new KeyBoardData { Month = "Nov 30", Sales = 70 },
                new KeyBoardData { Month = "Dec 15", Sales = 90 },
                new KeyBoardData { Month = "Dec 31", Sales = 100 }
            };
    }
    public class KeyBoardData
    {
        public string Month;
        public double? Sales;

    }
}
