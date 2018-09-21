using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;
using Syncfusion.EJ2.Schedule;

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