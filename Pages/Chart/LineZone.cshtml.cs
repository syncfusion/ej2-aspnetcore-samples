#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
    public class LineZoneModel : PageModel
    {
        public List<ChartSegment> Segments { get; set; }
        public void OnGet()
        {
            Segments = new List<ChartSegment>();
            ChartSegment segment1 = new ChartSegment();
            segment1.Value = 450;
            segment1.Color = "red";
            Segments.Add(segment1);

            ChartSegment segment2 = new ChartSegment();
            segment2.Value = 500;
            segment2.Color = "green";
            Segments.Add(segment2);

            ChartSegment segment3 = new ChartSegment();
            segment3.Color = "blue";
            Segments.Add(segment3);
        }
    }
}
