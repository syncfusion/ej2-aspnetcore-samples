#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {
        public IActionResult Timeline()
        {
            ScheduleData data = new ScheduleData();
            List<ScheduleData.AppointmentData> scheduleData = data.GetScheduleData();
            List<ScheduleData.AppointmentData> timelineData = data.GetTimelineData();
            ViewBag.appointments = scheduleData.Concat(timelineData);
            ViewBag.workDays = new int[] { 0, 1, 2, 3, 4, 5 };
            return View();
        }
    }
}
