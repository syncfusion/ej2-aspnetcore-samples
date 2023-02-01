#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {
        public IActionResult Overview()
        {
            List<object> exportItems = new List<object>()
            {
                new { text = "iCalendar", iconCss = "e-icons e-export" },
                new { text = "Excel", iconCss = "e-icons e-export-excel" }
            };
            ViewBag.ExportItems = exportItems;

            List<CalendarRes> calendarCollections = new List<CalendarRes>()
            {
                new CalendarRes { CalendarName = "My Calendar", CalendarId = 1, CalendarColor = "#c43081" },
                new CalendarRes { CalendarName = "Company", CalendarId = 2, CalendarColor = "#ff7f50" },
                new CalendarRes { CalendarName = "Birthday", CalendarId = 3, CalendarColor = "#AF27CD" },
                new CalendarRes { CalendarName = "Holiday", CalendarId = 4, CalendarColor = "#808000" }
            };
            ViewBag.Calendars = calendarCollections;

            ViewBag.Resources = new string[] { "Calendars" };

            List<object> menuItems = new List<object>() {
                new { text = "New Event", iconCss = "e-icons e-plus", id = "Add" },
                new { text = "New Recurring Event", iconCss = "e-icons e-repeat", id = "AddRecurrence" },
                new { text = "Today", iconCss = "e-icons e-timeline-today", id = "Today" },
                new { text = "Edit Event", iconCss = "e-icons e-edit", id = "Save" },
                new {
                    text = "Edit Event", id = "EditRecurrenceEvent", iconCss = "e-icons e-edit",
                    items = new List<object>() {
                        new { text = "Edit Occurrence", id = "EditOccurrence"},
                        new { text = "Edit Series", id = "EditSeries" }
                    }
                },
                new { text = "Delete Event", iconCss = "e-icons e-trash", id = "Delete" },
                new {
                    text = "Delete Event", id = "DeleteRecurrenceEvent", iconCss = "e-icons e-trash",
                    items = new List<object>() {
                        new { text = "Delete Occurrence", id = "DeleteOccurrence" },
                        new { text = "Delete Series", id = "DeleteSeries"}
                    }
                }
            };
            ViewBag.MenuItems = menuItems;

            List<object> weekDays = new List<object>()
            {
                new { text = "Sunday", value = 0 },
                new { text = "Monday", value = 1 },
                new { text = "Tuesday", value = 2 },
                new { text = "Wednesday", value = 3 },
                new { text = "Thursday", value = 4 },
                new { text = "Friday", value = 5 },
                new { text = "Saturday", value = 6 }
            };
            ViewBag.WeekDays = weekDays;

            List<object> timezoneData = new List<object>()
            {
                new { text = "UTC -12:00", value = "Etc/GMT+12" },
                new { text = "UTC -11:00", value = "Etc/GMT+11" },
                new { text = "UTC -10:00", value = "Etc/GMT+10" },
                new { text = "UTC -09:00", value = "Etc/GMT+9" },
                new { text = "UTC -08:00", value = "Etc/GMT+8" },
                new { text = "UTC -07:00", value = "Etc/GMT+7" },
                new { text = "UTC -06:00", value = "Etc/GMT+6" },
                new { text = "UTC -05:00", value = "Etc/GMT+5" },
                new { text = "UTC -04:00", value = "Etc/GMT+4" },
                new { text = "UTC -03:00", value = "Etc/GMT+3" },
                new { text = "UTC -02:00", value = "Etc/GMT+2" },
                new { text = "UTC -01:00", value = "Etc/GMT+1" },
                new { text = "UTC +00:00", value = "Etc/GMT" },
                new { text = "UTC +01:00", value = "Etc/GMT-1" },
                new { text = "UTC +02:00", value = "Etc/GMT-2" },
                new { text = "UTC +03:00", value = "Etc/GMT-3" },
                new { text = "UTC +04:00", value = "Etc/GMT-4" },
                new { text = "UTC +05:00", value = "Etc/GMT-5" },
                new { text = "UTC +05:30", value = "Asia/Calcutta" },
                new { text = "UTC +06:00", value = "Etc/GMT-6" },
                new { text = "UTC +07:00", value = "Etc/GMT-7" },
                new { text = "UTC +08:00", value = "Etc/GMT-8" },
                new { text = "UTC +09:00", value = "Etc/GMT-9" },
                new { text = "UTC +10:00", value = "Etc/GMT-10" },
                new { text = "UTC +11:00", value = "Etc/GMT-11" },
                new { text = "UTC +12:00", value = "Etc/GMT-12" },
                new { text = "UTC +13:00", value = "Etc/GMT-13" },
                new { text = "UTC +14:00", value = "Etc/GMT-14" }
            };
            ViewBag.TimezoneData = timezoneData;

            List<object> slotIntervalDataSource = new List<object>() {
                new { Name = "1 hour", Value = 60 },
                new { Name = "1.5 hours", Value = 90 },
                new { Name = "2 hours", Value = 120 },
                new { Name = "2.5 hours", Value = 150 },
                new { Name = "3 hours", Value = 180 },
                new { Name = "3.5 hours", Value = 210 },
                new { Name = "4 hours", Value = 240 },
                new { Name = "4.5 hours", Value = 270 },
                new { Name = "5 hours", Value = 300 },
                new { Name = "5.5 hours", Value = 330 },
                new { Name = "6 hours", Value = 360 },
                new { Name = "6.5 hours", Value = 390 },
                new { Name = "7 hours", Value = 420 },
                new { Name = "7.5 hours", Value = 450 },
                new { Name = "8 hours", Value = 480 },
                new { Name = "8.5 hours", Value = 510 },
                new { Name = "9 hours", Value = 540 },
                new { Name = "9.5 hours", Value = 570 },
                new { Name = "10 hours", Value = 600 },
                new { Name = "10.5 hours", Value = 630 },
                new { Name = "11 hours", Value = 660 },
                new { Name = "11.5 hours", Value = 690 },
                new { Name = "12 hours", Value = 720 }
            };
            ViewBag.SlotIntervalDataSource = slotIntervalDataSource;
            List<object> time = new List<object>();
            time.Add(new { Name = "12 hours", Value = "hh:mm a" });
            time.Add(new { Name = "24 hours", Value = "HH:mm" });
            ViewBag.TimeFormat = time;
            List<object> weekNumbersData = new List<object>();
            weekNumbersData.Add(new { Name = "Off", Value = "Off" });
            weekNumbersData.Add(new { Name = "First Day Of Year", Value = "FirstDay" });
            weekNumbersData.Add(new { Name = "First Full Week", Value = "FirstFullWeek" });
            weekNumbersData.Add(new { Name = "First Four-Day Week", Value = "FirstFourDayWeek" });
            ViewBag.WeekNumber = weekNumbersData;

            ViewBag.Appointments = GenerateEvents();

            return View();
        }

        private List<AppointmentData> GenerateEvents()
        {
            List<AppointmentData> EventData = new List<AppointmentData>();
            DateTime YearStart = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime YearEnd = new DateTime(DateTime.Now.Year, 12, 31);
            string[] EventSubjects = new string[] {
                "Bering Sea Gold", "Technology", "Maintenance", "Meeting", "Travelling", "Annual Conference", "Birthday Celebration", "Farewell Celebration",
                "Wedding Anniversary", "Alaska: The Last Frontier", "Deadliest Catch", "Sports Day", "MoonShiners", "Close Encounters", "HighWay Thru Hell",
                "Daily Planet", "Cash Cab", "Basketball Practice", "Rugby Match", "Guitar Class", "Music Lessons", "Doctor checkup", "Brazil - Mexico",
                "Opening ceremony", "Final presentation"
            };
            DateTime CurrentDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Sunday);
            DateTime Start = new DateTime(CurrentDate.Year, CurrentDate.Month, CurrentDate.Day, 10, 0, 0);
            DateTime End = new DateTime(CurrentDate.Year, CurrentDate.Month, CurrentDate.Day, 11, 30, 0);
            EventData.Add(new AppointmentData()
            {
                Id = 1,
                Subject = EventSubjects[new Random().Next(1, 25)],
                StartTime = Start.ToLocalTime(),
                EndTime = End.ToLocalTime(),
                Location = "",
                Description = "Event Scheduled",
                RecurrenceRule = "FREQ=WEEKLY;BYDAY=MO,TU,WE,TH,FR;INTERVAL=1;COUNT=10;",
                IsAllDay = false,
                IsReadonly = false,
                CalendarId = 1
            });
            for (int a = 0, id = 2; a < 500; a++)
            {
                Random random = new Random();
                int Month = random.Next(1, 12);
                int Date = random.Next(1, 28);
                int Hour = random.Next(1, 24);
                int Minutes = random.Next(1, 60);
                DateTime start = new DateTime(YearStart.Year, Month, Date, Hour, Minutes, 0);
                DateTime end = new DateTime(start.Ticks).AddHours(2);
                DateTime StartDate = new DateTime(start.Ticks);
                DateTime EndDate = new DateTime(end.Ticks);
                AppointmentData eventDatas = new AppointmentData()
                {
                    Id = id,
                    Subject = EventSubjects[random.Next(1, 25)],
                    StartTime = StartDate,
                    EndTime = EndDate,
                    Location = "",
                    Description = "Event Scheduled",
                    IsAllDay = id % 10 == 0,
                    IsReadonly = EndDate < DateTime.Now,
                    CalendarId = (a % 4) + 1
                };
                EventData.Add(eventDatas);
                id++;
            }
            return EventData;
        }
    }

    public class CalendarRes
    {
        public string CalendarName { set; get; }
        public int CalendarId { set; get; }
        public string CalendarColor { set; get; }
    }

    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public bool IsReadonly { get; set; }
        public int CalendarId { get; set; }
        public int? RecurrenceID { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
    }

}
