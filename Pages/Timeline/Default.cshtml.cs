#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Syncfusion.EJ2.Layouts;

namespace EJ2CoreSampleBrowser.Pages.Timeline
{
    public class DefaultModel : PageModel
    {
        public List<TimelineItem> Items { get; set; }

        public void OnGet()
        {
            Items = new List<TimelineItem>
            {
                new TimelineItem { Content = "Ordered \n 9:15 AM, January 1, 2024", DotCss = "state-success", CssClass = "completed" },
                new TimelineItem { Content = "Shipped \n 12:20 PM, January 4, 2024", DotCss = "state-success", CssClass = "completed" },
                new TimelineItem { Content = "Out for delivery \n 07:00 AM, January 8, 2024", DotCss = "state-progress", CssClass = "intermediate" },
                new TimelineItem { Content = "Delivered \n Estimated delivery by 09:20 AM" }
            };
        }
    }
}