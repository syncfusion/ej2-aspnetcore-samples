#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
        public IActionResult AddRemoveResources()
        {
            List<CalendarRes> calendarCollections = new List<CalendarRes>();
            calendarCollections.Add(new CalendarRes { CalendarName = "My Calendar", CalendarId = 1, CalendarColor = "#c43081" });
            ViewBag.Calendars = calendarCollections;

            ScheduleData data = new ScheduleData();
            List<ScheduleData.ResourceEventsData> holidayData = data.GetHolidayData();
            List<ScheduleData.ResourceEventsData> birthdayData = data.GetBirthdayData();
            List<ScheduleData.ResourceEventsData> companyData = data.GetCompanyData();
            List<ScheduleData.ResourceEventsData> personalData = data.GetPersonalData();
            ViewBag.datasource = holidayData.Concat(birthdayData).Concat(companyData).Concat(personalData);

            string[] resources = new string[] { "Calendars" };
            ViewBag.Resources = resources;

            return View();
        }
        public class CalendarRes
        {
            public string CalendarName { set; get; }
            public int CalendarId { set; get; }
            public string CalendarColor { set; get; }
        }
    }
}