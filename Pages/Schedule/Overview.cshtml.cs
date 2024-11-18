#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class Overview : PageModel
{
    public List<object> exportItems = new List<object>();
    public List<CalendarRes> calendarCollections = new List<CalendarRes>();
    public List<object> menuItems = new List<object>();
    public List<object> weekDays = new List<object>();
    public List<object> timezoneData = new List<object>();
    public List<object> slotIntervalDataSource = new List<object>();
    public List<object> time = new List<object>();
    public List<object> weekNumbersData = new List<object>();
    public List<object> tooltipData = new List<object>();
    public void OnGet()
    {
        exportItems.Add(new { text = "iCalendar", iconCss = "e-icons e-export" });
        exportItems.Add(new { text = "Excel", iconCss = "e-icons e-export-excel" });

        calendarCollections.Add(new CalendarRes
            { CalendarName = "My Calendar", CalendarId = 1, CalendarColor = "#c43081" });
        calendarCollections.Add(new CalendarRes
            { CalendarName = "Company", CalendarId = 2, CalendarColor = "#ff7f50" });
        calendarCollections.Add(
            new CalendarRes { CalendarName = "Birthday", CalendarId = 3, CalendarColor = "#AF27CD" });
        calendarCollections.Add(new CalendarRes
            { CalendarName = "Holiday", CalendarId = 4, CalendarColor = "#808000" });
        
        menuItems.Add(new { text = "New Event", iconCss = "e-icons e-plus", id = "Add" });
        menuItems.Add(new { text = "New Recurring Event", iconCss = "e-icons e-repeat", id = "AddRecurrence" });
        menuItems.Add(new { text = "Today", iconCss = "e-icons e-timeline-today", id = "Today" });
        menuItems.Add(new { text = "Edit Event", iconCss = "e-icons e-edit", id = "Save" });
        menuItems.Add(new
        {
            text = "Edit Event", id = "EditRecurrenceEvent", iconCss = "e-icons e-edit",
            items = new List<object>()
            {
                new { text = "Edit Occurrence", id = "EditOccurrence" },
                new { text = "Edit Series", id = "EditSeries" }
            }
        });
        menuItems.Add(new { text = "Delete Event", iconCss = "e-icons e-trash", id = "Delete" });
        menuItems.Add(new
        {
            text = "Delete Event", id = "DeleteRecurrenceEvent", iconCss = "e-icons e-trash",
            items = new List<object>()
            {
                new { text = "Delete Occurrence", id = "DeleteOccurrence" },
                new { text = "Delete Series", id = "DeleteSeries" }
            }
        });
        
        weekDays.Add(new { text = "Sunday", value = 0 });
        weekDays.Add(new { text = "Monday", value = 1 });
        weekDays.Add(new { text = "Tuesday", value = 2 });
        weekDays.Add(new { text = "Wednesday", value = 3 });
        weekDays.Add(new { text = "Thursday", value = 4 });
        weekDays.Add(new { text = "Friday", value = 5 });
        weekDays.Add(new { text = "Saturday", value = 6 });
        
        timezoneData.Add(new { text = "UTC -12:00", value = "Etc/GMT+12" });
        timezoneData.Add(new { text = "UTC -11:00", value = "Etc/GMT+11" });
        timezoneData.Add(new { text = "UTC -10:00", value = "Etc/GMT+10" });
        timezoneData.Add(new { text = "UTC -09:00", value = "Etc/GMT+9" });
        timezoneData.Add(new { text = "UTC -08:00", value = "Etc/GMT+8" });
        timezoneData.Add(new { text = "UTC -07:00", value = "Etc/GMT+7" });
        timezoneData.Add(new { text = "UTC -06:00", value = "Etc/GMT+6" });
        timezoneData.Add(new { text = "UTC -05:00", value = "Etc/GMT+5" });
        timezoneData.Add(new { text = "UTC -04:00", value = "Etc/GMT+4" });
        timezoneData.Add(new { text = "UTC -03:00", value = "Etc/GMT+3" });
        timezoneData.Add(new { text = "UTC -02:00", value = "Etc/GMT+2" });
        timezoneData.Add(new { text = "UTC -01:00", value = "Etc/GMT+1" });
        timezoneData.Add(new { text = "UTC +00:00", value = "Etc/GMT" });
        timezoneData.Add(new { text = "UTC +01:00", value = "Etc/GMT-1" });
        timezoneData.Add(new { text = "UTC +02:00", value = "Etc/GMT-2" });
        timezoneData.Add(new { text = "UTC +03:00", value = "Etc/GMT-3" });
        timezoneData.Add(new { text = "UTC +04:00", value = "Etc/GMT-4" });
        timezoneData.Add(new { text = "UTC +05:00", value = "Etc/GMT-5" });
        timezoneData.Add(new { text = "UTC +05:30", value = "Asia/Calcutta" });
        timezoneData.Add(new { text = "UTC +06:00", value = "Etc/GMT-6" });
        timezoneData.Add(new { text = "UTC +07:00", value = "Etc/GMT-7" });
        timezoneData.Add(new { text = "UTC +08:00", value = "Etc/GMT-8" });
        timezoneData.Add(new { text = "UTC +09:00", value = "Etc/GMT-9" });
        timezoneData.Add(new { text = "UTC +10:00", value = "Etc/GMT-10" });
        timezoneData.Add(new { text = "UTC +11:00", value = "Etc/GMT-11" });
        timezoneData.Add(new { text = "UTC +12:00", value = "Etc/GMT-12" });
        timezoneData.Add(new { text = "UTC +13:00", value = "Etc/GMT-13" });
        timezoneData.Add(new { text = "UTC +14:00", value = "Etc/GMT-14" });


        slotIntervalDataSource.Add(new { Name = "1 hour", Value = 60 });
        slotIntervalDataSource.Add(new { Name = "1.5 hours", Value = 90 });
        slotIntervalDataSource.Add(new { Name = "2 hours", Value = 120 });
        slotIntervalDataSource.Add(new { Name = "2.5 hours", Value = 150 });
        slotIntervalDataSource.Add(new { Name = "3 hours", Value = 180 });
        slotIntervalDataSource.Add(new { Name = "3.5 hours", Value = 210 });
        slotIntervalDataSource.Add(new { Name = "4 hours", Value = 240 });
        slotIntervalDataSource.Add(new { Name = "4.5 hours", Value = 270 });
        slotIntervalDataSource.Add(new { Name = "5 hours", Value = 300 });
        slotIntervalDataSource.Add(new { Name = "5.5 hours", Value = 330 });
        slotIntervalDataSource.Add(new { Name = "6 hours", Value = 360 });
        slotIntervalDataSource.Add(new { Name = "6.5 hours", Value = 390 });
        slotIntervalDataSource.Add(new { Name = "7 hours", Value = 420 });
        slotIntervalDataSource.Add(new { Name = "7.5 hours", Value = 450 });
        slotIntervalDataSource.Add(new { Name = "8 hours", Value = 480 });
        slotIntervalDataSource.Add(new { Name = "8.5 hours", Value = 510 });
        slotIntervalDataSource.Add(new { Name = "9 hours", Value = 540 });
        slotIntervalDataSource.Add(new { Name = "9.5 hours", Value = 570 });
        slotIntervalDataSource.Add(new { Name = "10 hours", Value = 600 });
        slotIntervalDataSource.Add(new { Name = "10.5 hours", Value = 630 });
        slotIntervalDataSource.Add(new { Name = "11 hours", Value = 660 });
        slotIntervalDataSource.Add(new { Name = "11.5 hours", Value = 690 });
        slotIntervalDataSource.Add(new { Name = "12 hours", Value = 720 });
        
        time.Add(new { Name = "12 hours", Value = "hh:mm a" });
        time.Add(new { Name = "24 hours", Value = "HH:mm" });
        
        weekNumbersData.Add(new { Name = "Off", Value = "Off" });
        weekNumbersData.Add(new { Name = "First Day Of Year", Value = "FirstDay" });
        weekNumbersData.Add(new { Name = "First Full Week", Value = "FirstFullWeek" });
        weekNumbersData.Add(new { Name = "First Four-Day Week", Value = "FirstFourDayWeek" });
        
        tooltipData.Add(new { Name = "Off", Value = "Off" });
        tooltipData.Add(new { Name = "On", Value = "On" });
    }

    public List<AppointmentData> GenerateEvents()
    {
        List<AppointmentData> EventData = new List<AppointmentData>();
        DateTime YearStart = new DateTime(DateTime.Now.Year, 1, 1);
        DateTime YearEnd = new DateTime(DateTime.Now.Year, 12, 31);
        string[] EventSubjects = new string[]
        {
            "Bering Sea Gold", "Technology", "Maintenance", "Meeting", "Travelling", "Annual Conference",
            "Birthday Celebration", "Farewell Celebration",
            "Wedding Anniversary", "Alaska: The Last Frontier", "Deadliest Catch", "Sports Day", "MoonShiners",
            "Close Encounters", "HighWay Thru Hell",
            "Daily Planet", "Cash Cab", "Basketball Practice", "Rugby Match", "Guitar Class", "Music Lessons",
            "Doctor checkup", "Brazil - Mexico",
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