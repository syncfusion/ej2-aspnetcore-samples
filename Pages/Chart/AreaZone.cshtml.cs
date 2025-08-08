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
    public class AreaZoneModel : PageModel
    {
        public List<ChartSegment> Segments { get; set; }
        public void OnGet()
        {
            Segments = new List<ChartSegment>();
            ChartSegment segment1 = new ChartSegment();
            segment1.Value = new DateTime(2016, 4, 1);
            segment1.Color = "url(#winter)";
            Segments.Add(segment1);

            ChartSegment segment2 = new ChartSegment();
            segment2.Value = new DateTime(2016, 8, 1);
            segment2.Color = "url(#summer)";
            Segments.Add(segment2);

            ChartSegment segment3 = new ChartSegment();
            segment3.Color = "url(#spring)";
            Segments.Add(segment3);
        }
    }
    
}