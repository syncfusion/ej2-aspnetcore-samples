#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser.Pages.Schedule
{
    public class DragScheduleToSchedule : PageModel
    {
        public IEnumerable<object> FirstScheduleData { get; private set; }
        public IEnumerable<object> SecondScheduleData { get; private set; }
        public IEnumerable<object> FirstScheduleResourceDataSource { get; private set; }
        public IEnumerable<object> SecondScheduleResourceDataSource { get; private set; }
        public string[] ResourceNames { get; private set; }

        public void OnGet()
        {
            FirstScheduleData = new ScheduleData().GetResourceData();
            SecondScheduleData = new ScheduleData().GetTimelineResourceData();

            FirstScheduleResourceDataSource = new[]
            {
                new { text = "Steven", id = 1, color = "#7fa900" }
            };

            SecondScheduleResourceDataSource = new[]
            {
                new { text = "John", id = 2, color = "#ffb74d" }
            };

            ResourceNames = new string[] { "Employees" };
        }
    }
}
