#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace EJ2CoreSampleBrowser.Pages.Schedule
{
    public class GridToSchedule : PageModel
    {
        public List<ScheduleData.ResourceData> DataSource { get; set; }

        public void OnGet()
        {
            ScheduleData data = new ScheduleData();

            List<ScheduleData.ResourceData> resourceData = data.GetResourceData();
            List<ScheduleData.ResourceData> timelineResourceData = data.GetTimelineResourceData();

            // Assign the combined data to the public property
            DataSource = resourceData.Concat(timelineResourceData).ToList();
        }
    }
}
