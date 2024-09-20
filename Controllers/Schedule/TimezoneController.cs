#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {

        public IActionResult Timezone()
        {
            ViewBag.appointments = new ScheduleData().GetFifaEventsData();
            ViewBag.data = TimezoneData();
            return View();
        }

        public List<TimezoneData> TimezoneData()
        {
            List<TimezoneData> timeZone = new List<TimezoneData>();
            timeZone.Add(new TimezoneData { Name = "(UTC-05:00) Eastern Time", Value = "America/New_York" });
            timeZone.Add(new TimezoneData { Name = "UTC", Value = "Coordinated Universal Time" });
            timeZone.Add(new TimezoneData { Name = "(UTC+03:00) Moscow+00 - Moscow", Value = "Europe/Moscow" });
            timeZone.Add(new TimezoneData { Name = "(UTC+05:30) India Standard Time", Value = "Asia/Kolkata" });
            timeZone.Add(new TimezoneData { Name = "(UTC+08:00) Western Time - Perth", Value = "Australia/Perth" });
            return timeZone;
        }
    }

    public class TimezoneData
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
