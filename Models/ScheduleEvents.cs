using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class ScheduleEvents
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
                StartTime = new DateTime(CurrentYear, 1, 10, 9, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 10, 11, 0, 0),
                CategoryColor = "#1aaa55"
            });
            appData.Add(new AppointmentData
            {
                Id = 2,
                Subject = "Thule Air Crash Report",
                Location = "Newyork City",
                StartTime = new DateTime(CurrentYear, 1, 11, 12, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 11, 14, 0, 0),
                CategoryColor = "#357cd2"
            });
            appData.Add(new AppointmentData
            {
                Id = 3,
                Subject = "Blue Moon Eclipse",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 1, 12, 9, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 12, 11, 0, 0),
                CategoryColor = "#7fa900"
            });
            appData.Add(new AppointmentData
            {
                Id = 4,
                Subject = "Meteor Showers in 2021",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 1, 13, 13, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 13, 14, 30, 0),
                CategoryColor = "#ea7a57"
            });
            appData.Add(new AppointmentData
            {
                Id = 5,
                Subject = "Milky Way as Melting pot",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 1, 14, 12, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 14, 14, 0, 0),
                CategoryColor = "#00bdae"
            });
            appData.Add(new AppointmentData
            {
                Id = 6,
                Subject = "Mysteries of Bermuda Triangle",
                Location = "Bermuda",
                StartTime = new DateTime(CurrentYear, 1, 14, 9, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 14, 11, 0, 0),
                CategoryColor = "#f57f17"
            });
            appData.Add(new AppointmentData
            {
                Id = 7,
                Subject = "Glaciers and Snowflakes",
                Location = "Himalayas",
                StartTime = new DateTime(CurrentYear, 1, 15, 11, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 15, 12, 30, 0),
                CategoryColor = "#1aaa55"
            });
            appData.Add(new AppointmentData
            {
                Id = 8,
                Subject = "Life on Mars",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 1, 16, 9, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 16, 10, 0, 0),
                CategoryColor = "#357cd2"
            });
            appData.Add(new AppointmentData
            {
                Id = 9,
                Subject = "Alien Civilization",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 1, 18, 11, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 18, 13, 0, 0),
                CategoryColor = "#7fa900"
            });
            appData.Add(new AppointmentData
            {
                Id = 10,
                Subject = "Wildlife Galleries",
                Location = "Africa",
                StartTime = new DateTime(CurrentYear, 1, 20, 11, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 20, 13, 0, 0),
                CategoryColor = "#ea7a57"
            });
            appData.Add(new AppointmentData
            {
                Id = 11,
                Subject = "Best Photography 2021",
                Location = "London",
                StartTime = new DateTime(CurrentYear, 1, 21, 9, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 21, 11, 0, 0),
                CategoryColor = "#00bdae"
            });
            appData.Add(new AppointmentData
            {
                Id = 12,
                Subject = "Smarter Puppies",
                Location = "Sweden",
                StartTime = new DateTime(CurrentYear, 1, 8, 10, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 8, 11, 30, 0),
                CategoryColor = "#f57f17"
            });
            appData.Add(new AppointmentData
            {
                Id = 13,
                Subject = "Myths of Andromeda Galaxy",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 1, 6, 10, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 6, 12, 30, 0),
                CategoryColor = "#1aaa55"
            });
            appData.Add(new AppointmentData
            {
                Id = 14,
                Subject = "Aliens vs Humans",
                Location = "Research Centre of USA",
                StartTime = new DateTime(CurrentYear, 1, 5, 10, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 5, 11, 30, 0),
                CategoryColor = "#357cd2"
            });
            appData.Add(new AppointmentData
            {
                Id = 15,
                Subject = "Facts of Humming Birds",
                Location = "California",
                StartTime = new DateTime(CurrentYear, 1, 19, 9, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 19, 11, 0, 0),
                CategoryColor = "#7fa900"
            });
            appData.Add(new AppointmentData
            {
                Id = 16,
                Subject = "Sky Gazers",
                Location = "Alaska",
                StartTime = new DateTime(CurrentYear, 1, 22, 11, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 22, 13, 0, 0),
                CategoryColor = "#ea7a57"
            });
            appData.Add(new AppointmentData
            {
                Id = 17,
                Subject = "The Cycle of Seasons",
                Location = "Research Centre of USA",
                StartTime = new DateTime(CurrentYear, 1, 11, 5, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 11, 7, 30, 0),
                CategoryColor = "#00bdae"
            });
            appData.Add(new AppointmentData
            {
                Id = 18,
                Subject = "Space Galaxies and Planets",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 1, 11, 17, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 11, 18, 30, 0),
                CategoryColor = "#f57f17"
            });
            appData.Add(new AppointmentData
            {
                Id = 19,
                Subject = "Lifecycle of Bumblebee",
                Location = "San Fransisco",
                StartTime = new DateTime(CurrentYear, 1, 14, 6, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 14, 7, 30, 0),
                CategoryColor = "#7fa900"
            });
            appData.Add(new AppointmentData
            {
                Id = 20,
                Subject = "Alien Civilization",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 1, 14, 16, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 14, 18, 0, 0),
                CategoryColor = "#ea7a57"
            });
            appData.Add(new AppointmentData
            {
                Id = 21,
                Subject = "Alien Civilization",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 1, 10, 14, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 10, 16, 0, 0),
                CategoryColor = "#ea7a57"
            });
            appData.Add(new AppointmentData
            {
                Id = 22,
                Subject = "The Cycle of Seasons",
                Location = "Research Centre of USA",
                StartTime = new DateTime(CurrentYear, 1, 12, 14, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 12, 16, 0, 0),
                CategoryColor = "#00bdae"
            });
            appData.Add(new AppointmentData
            {
                Id = 23,
                Subject = "Sky Gazers",
                Location = "Greenland",
                StartTime = new DateTime(CurrentYear, 1, 15, 14, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 15, 16, 0, 0),
                CategoryColor = "#ea7a57"
            });
            appData.Add(new AppointmentData
            {
                Id = 24,
                Subject = "Facts of Humming Birds",
                Location = "California",
                StartTime = new DateTime(CurrentYear, 1, 16, 12, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 16, 14, 30, 0),
                CategoryColor = "#7fa900"
            });
            return appData;
        }

        public class AppointmentData
        {
            public int Id { get; set; }
            public string Subject { get; set; }
            public string Location { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string CategoryColor { get; set; }
        }
    }
}
