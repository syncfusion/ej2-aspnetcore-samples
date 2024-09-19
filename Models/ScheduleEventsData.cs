#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public interface IScheduleEvent
    {
        int Id { get; set; }
        string Subject { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        string CategoryColor { get; set; }
        bool IsAllDay { get; set; }
        bool IsReadonly { get; set; }
        bool IsHoliday { get; set; }
        string Location { get; set; }
    }

    public class HolidayData : IScheduleEvent
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CategoryColor { get; set; }
        public bool IsAllDay { get; set; }
        public bool IsReadonly { get; set; }
        public bool IsHoliday { get; set; }
        public string Location { get; set; } = string.Empty;
    }

    public class AppointmentData : IScheduleEvent
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CategoryColor { get; set; }
        public bool IsAllDay { get; set; }
        public bool IsReadonly { get; set; }
        public bool IsHoliday { get; set; }
        public string Location { get; set; }
    }

    public class ScheduleEventsData
    {
        private static DateTime Today = DateTime.Now;
        private int CurrentYear = Today.Year;
        public List<AppointmentData> GetAppointmentData()
        {
            List<AppointmentData> appData = new List<AppointmentData>();
            appData.Add(new AppointmentData
            {
                Id = 1,
                Subject = "Explosion of Betelgeuse Star",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 8, 15, 9, 30, 0),
                EndTime = new DateTime(CurrentYear, 8, 15, 11, 0, 0),
                CategoryColor = null,
                IsReadonly = false,
                IsHoliday = false
            });
            appData.Add(new AppointmentData
            {
                Id = 2,
                Subject = "Thule Air Crash Report",
                Location = "Newyork City",
                StartTime = new DateTime(CurrentYear, 8, 10, 12, 0, 0),
                EndTime = new DateTime(CurrentYear, 8, 10, 14, 0, 0),
                CategoryColor = null,
                IsReadonly = false,
                IsHoliday = false
            });
            appData.Add(new AppointmentData
            {
                Id = 3,
                Subject = "Blue Moon Eclipse",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 8, 11, 9, 30, 0),
                EndTime = new DateTime(CurrentYear, 8, 11, 11, 0, 0),
                CategoryColor = null,
                IsReadonly = false,
                IsHoliday = false
            });
            appData.Add(new AppointmentData
            {
                Id = 4,
                Subject = "Meteor Showers in 2021",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 8, 12, 13, 0, 0),
                EndTime = new DateTime(CurrentYear, 8, 12, 14, 30, 0),
                CategoryColor = null,
                IsReadonly = false,
                IsHoliday = false
            });
            appData.Add(new AppointmentData
            {
                Id = 5,
                Subject = "Milky Way as Melting pot",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 8, 13, 12, 0, 0),
                EndTime = new DateTime(CurrentYear, 8, 13, 14, 0, 0),
                CategoryColor = null,
                IsReadonly = false,
                IsHoliday = false
            });
            appData.Add(new AppointmentData
            {
                Id = 6,
                Subject = "Mysteries of Bermuda Triangle",
                Location = "Bermuda",
                StartTime = new DateTime(CurrentYear, 8, 13, 9, 30, 0),
                EndTime = new DateTime(CurrentYear, 8, 13, 11, 0, 0),
                CategoryColor = null,
                IsReadonly = false,
                IsHoliday = false
            });
            appData.Add(new AppointmentData
            {
                Id = 7,
                Subject = "Glaciers and Snowflakes",
                Location = "Himalayas",
                StartTime = new DateTime(CurrentYear, 8, 14, 11, 0, 0),
                EndTime = new DateTime(CurrentYear, 8, 14, 12, 30, 0),
                CategoryColor = null,
                IsReadonly = false,
                IsHoliday = false
            });
            appData.Add(new AppointmentData
            {
                Id = 8,
                Subject = "Life on Mars",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 8, 15, 9, 0, 0),
                EndTime = new DateTime(CurrentYear, 8, 15, 10, 0, 0),
                CategoryColor = null,
                IsReadonly = false,
                IsHoliday = false
            });
            appData.Add(new AppointmentData
            {
                Id = 9,
                Subject = "Alien Civilization",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 8, 17, 11, 0, 0),
                EndTime = new DateTime(CurrentYear, 8, 17, 13, 0, 0),
                CategoryColor = null,
                IsReadonly = false,
                IsHoliday = false
            });
            appData.Add(new AppointmentData
            {
                Id = 10,
                Subject = "Wildlife Galleries",
                Location = "Africa",
                StartTime = new DateTime(CurrentYear, 8, 19, 11, 0, 0),
                EndTime = new DateTime(CurrentYear, 8, 19, 13, 0, 0),
                CategoryColor = null,
                IsReadonly = false,
                IsHoliday = false
            });
            appData.Add(new AppointmentData
            {
                Id = 11,
                Subject = "Best Photography 2021",
                Location = "London",
                StartTime = new DateTime(CurrentYear, 8, 20, 9, 30, 0),
                EndTime = new DateTime(CurrentYear, 8, 20, 11, 0, 0),
                CategoryColor = null,
                IsReadonly = false,
                IsHoliday = false
            });
            appData.Add(new AppointmentData
            {
                Id = 12,
                Subject = "Smarter Puppies",
                Location = "Sweden",
                StartTime = new DateTime(CurrentYear, 8, 7, 10, 0, 0),
                EndTime = new DateTime(CurrentYear, 8, 7, 11, 30, 0),
                CategoryColor = null,
                IsReadonly = false,
                IsHoliday = false
            });
            appData.Add(new AppointmentData
            {
                Id = 13,
                Subject = "Myths of Andromeda Galaxy",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 8, 5, 10, 30, 0),
                EndTime = new DateTime(CurrentYear, 8, 5, 12, 30, 0),
                CategoryColor = null,
                IsReadonly = false,
                IsHoliday = false
            });
            appData.Add(new AppointmentData
            {
                Id = 14,
                Subject = "Aliens vs Humans",
                Location = "Research Centre of USA",
                StartTime = new DateTime(CurrentYear, 8, 4, 10, 0, 0),
                EndTime = new DateTime(CurrentYear, 8, 4, 11, 30, 0),
                CategoryColor = null,
                IsReadonly = false,
                IsHoliday = false
            });
            appData.Add(new AppointmentData
            {
                Id = 15,
                Subject = "Facts of Humming Birds",
                Location = "California",
                StartTime = new DateTime(CurrentYear, 8, 18, 9, 30, 0),
                EndTime = new DateTime(CurrentYear, 8, 18, 11, 0, 0),
                CategoryColor = null,
                IsReadonly = false,
                IsHoliday = false
            });
            return appData;
        }


    }

    public class HolidayList
    {
        public List<HolidayData> GetHolidayData(int currentYear)
        {
            return new List<HolidayData>
            {
                new HolidayData { Id = 1, Subject = "New Year's Day", StartTime = new DateTime(currentYear, 1, 1, 0, 0, 0), EndTime = new DateTime(currentYear, 1, 1, 23, 59, 0), CategoryColor = "#0b8043", Location = string.Empty, IsAllDay = true, IsReadonly = true, IsHoliday = true },
                new HolidayData { Id = 2, Subject = "Makar Sankranti", StartTime = new DateTime(currentYear, 1, 14, 0, 0, 0), EndTime = new DateTime(currentYear, 1, 14, 23, 59, 0), CategoryColor = "#0b8043", IsAllDay = true, IsReadonly = true, IsHoliday = true },
                new HolidayData { Id = 3, Subject = "Republic Day", StartTime = new DateTime(currentYear, 1, 26, 0, 0, 0), EndTime = new DateTime(currentYear, 1, 26, 23, 59, 0), CategoryColor = "#0b8043", IsAllDay = true, IsReadonly = true, IsHoliday = true },
                new HolidayData { Id = 4, Subject = "Maha Shivaratri", StartTime = new DateTime(currentYear, 3, 8, 0, 0, 0), EndTime = new DateTime(currentYear, 3, 8, 23, 59, 0), CategoryColor = "#0b8043", IsAllDay = true, IsReadonly = true, IsHoliday = true },
                new HolidayData { Id = 5, Subject = "Holi", StartTime = new DateTime(currentYear, 3, 25, 0, 0, 0), EndTime = new DateTime(currentYear, 3, 25, 23, 59, 0), CategoryColor = "#0b8043", IsAllDay = true, IsReadonly = true, IsHoliday = true },
                new HolidayData { Id = 6, Subject = "Good Friday", StartTime = new DateTime(currentYear, 3, 29, 0, 0, 0), EndTime = new DateTime(currentYear, 3, 29, 23, 59, 0), CategoryColor = "#0b8043", IsAllDay = true, IsReadonly = true, IsHoliday = true },
                new HolidayData { Id = 7, Subject = "Eid al-Fitr", StartTime = new DateTime(currentYear, 4, 10, 0, 0, 0), EndTime = new DateTime(currentYear, 4, 10, 23, 59, 0), CategoryColor = "#0b8043", IsAllDay = true, IsReadonly = true, IsHoliday = true },
                new HolidayData { Id = 8, Subject = "Buddha Purnima", StartTime = new DateTime(currentYear, 4, 23, 0, 0, 0), EndTime = new DateTime(currentYear, 4, 23, 23, 59, 0), CategoryColor = "#0b8043", IsAllDay = true, IsReadonly = true, IsHoliday = true },
                new HolidayData { Id = 9, Subject = "Raksha Bandhan", StartTime = new DateTime(currentYear, 8, 19, 0, 0, 0), EndTime = new DateTime(currentYear, 8, 19, 23, 59, 0), CategoryColor = "#0b8043", IsAllDay = true, IsReadonly = true, IsHoliday = true },
                new HolidayData { Id = 10, Subject = "Janmashtami", StartTime = new DateTime(currentYear, 8, 26, 0, 0, 0), EndTime = new DateTime(currentYear, 8, 26, 23, 59, 0), CategoryColor = "#0b8043", IsAllDay = true, IsReadonly = true, IsHoliday = true },
                new HolidayData { Id = 11, Subject = "Independence Day", StartTime = new DateTime(currentYear, 8, 15, 0, 0, 0), EndTime = new DateTime(currentYear, 8, 15, 23, 59, 0), CategoryColor = "#0b8043", IsAllDay = true, IsReadonly = true, IsHoliday = true },
                new HolidayData { Id = 12, Subject = "Ganesh Chaturthi", StartTime = new DateTime(currentYear, 9, 7, 0, 0, 0), EndTime = new DateTime(currentYear, 9, 7, 23, 59, 0), CategoryColor = "#0b8043", IsAllDay = true, IsReadonly = true, IsHoliday = true },
                new HolidayData { Id = 13, Subject = "Gandhi Jayanti", StartTime = new DateTime(currentYear, 10, 2, 0, 0, 0), EndTime = new DateTime(currentYear, 10, 2, 23, 59, 0), CategoryColor = "#0b8043", IsAllDay = true, IsReadonly = true, IsHoliday = true },
                new HolidayData { Id = 14, Subject = "Dussehra", StartTime = new DateTime(currentYear, 10, 13, 0, 0, 0), EndTime = new DateTime(currentYear, 10, 13, 23, 59, 0), CategoryColor = "#0b8043", IsAllDay = true, IsReadonly = true, IsHoliday = true },
                new HolidayData { Id = 15, Subject = "Diwali", StartTime = new DateTime(currentYear, 11, 1, 0, 0, 0), EndTime = new DateTime(currentYear, 11, 1, 23, 59, 0), CategoryColor = "#0b8043", IsAllDay = true, IsReadonly = true, IsHoliday = true },
                new HolidayData { Id = 16, Subject = "Christmas Day", StartTime = new DateTime(currentYear, 12, 25, 0, 0, 0), EndTime = new DateTime(currentYear, 12, 25, 23, 59, 0), CategoryColor = "#0b8043", IsAllDay = true, IsReadonly = true, IsHoliday = true }
            };
        }
    }
}
