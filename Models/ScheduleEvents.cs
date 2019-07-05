using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class ScheduleEvents
    {
        public List<AppointmentData> GetAppointmentData()
        {
            List<AppointmentData> appData = new List<AppointmentData>();
            appData.Add(new AppointmentData
            {
                Id = 1,
                Subject = "Explosion of Betelgeuse Star",
                Location = "Space Centre USA",
                StartTime = new DateTime(2019, 1, 6, 9, 30, 0),
                EndTime = new DateTime(2019, 1, 6, 11, 0, 0),
                CategoryColor = "#1aaa55"
            });
            appData.Add(new AppointmentData
            {
                Id = 2,
                Subject = "Thule Air Crash Report",
                Location = "Newyork City",
                StartTime = new DateTime(2019, 1, 7, 12, 0, 0),
                EndTime = new DateTime(2019, 1, 7, 14, 0, 0),
                CategoryColor = "#357cd2"
            });
            appData.Add(new AppointmentData
            {
                Id = 3,
                Subject = "Blue Moon Eclipse",
                Location = "Space Centre USA",
                StartTime = new DateTime(2019, 1, 8, 9, 30, 0),
                EndTime = new DateTime(2019, 1, 8, 11, 0, 0),
                CategoryColor = "#7fa900"
            });
            appData.Add(new AppointmentData
            {
                Id = 4,
                Subject = "Meteor Showers in 2018",
                Location = "Space Centre USA",
                StartTime = new DateTime(2019, 1, 9, 13, 0, 0),
                EndTime = new DateTime(2019, 1, 9, 14, 30, 0),
                CategoryColor = "#ea7a57"
            });
            appData.Add(new AppointmentData
            {
                Id = 5,
                Subject = "Milky Way as Melting pot",
                Location = "Space Centre USA",
                StartTime = new DateTime(2019, 1, 10, 12, 0, 0),
                EndTime = new DateTime(2019, 1, 10, 14, 0, 0),
                CategoryColor = "#00bdae"
            });
            appData.Add(new AppointmentData
            {
                Id = 6,
                Subject = "Mysteries of Bermuda Triangle",
                Location = "Bermuda",
                StartTime = new DateTime(2019, 1, 10, 9, 30, 0),
                EndTime = new DateTime(2019, 1, 10, 11, 0, 0),
                CategoryColor = "#f57f17"
            });
            appData.Add(new AppointmentData
            {
                Id = 7,
                Subject = "Glaciers and Snowflakes",
                Location = "Himalayas",
                StartTime = new DateTime(2019, 1, 11, 11, 0, 0),
                EndTime = new DateTime(2019, 1, 11, 12, 30, 0),
                CategoryColor = "#1aaa55"
            });
            appData.Add(new AppointmentData
            {
                Id = 8,
                Subject = "Life on Mars",
                Location = "Space Centre USA",
                StartTime = new DateTime(2019, 1, 12, 9, 0, 0),
                EndTime = new DateTime(2019, 1, 12, 10, 0, 0),
                CategoryColor = "#357cd2"
            });
            appData.Add(new AppointmentData
            {
                Id = 9,
                Subject = "Alien Civilization",
                Location = "Space Centre USA",
                StartTime = new DateTime(2019, 1, 14, 11, 0, 0),
                EndTime = new DateTime(2019, 1, 14, 13, 0, 0),
                CategoryColor = "#7fa900"
            });
            appData.Add(new AppointmentData
            {
                Id = 10,
                Subject = "Wildlife Galleries",
                Location = "Africa",
                StartTime = new DateTime(2019, 1, 16, 11, 0, 0),
                EndTime = new DateTime(2019, 1, 16, 13, 0, 0),
                CategoryColor = "#ea7a57"
            });
            appData.Add(new AppointmentData
            {
                Id = 11,
                Subject = "Best Photography 2018",
                Location = "London",
                StartTime = new DateTime(2019, 1, 17, 9, 30, 0),
                EndTime = new DateTime(2019, 1, 17, 11, 0, 0),
                CategoryColor = "#00bdae"
            });
            appData.Add(new AppointmentData
            {
                Id = 12,
                Subject = "Smarter Puppies",
                Location = "Sweden",
                StartTime = new DateTime(2019, 1, 4, 10, 0, 0),
                EndTime = new DateTime(2019, 1, 4, 11, 30, 0),
                CategoryColor = "#f57f17"
            });
            appData.Add(new AppointmentData
            {
                Id = 13,
                Subject = "Myths of Andromeda Galaxy",
                Location = "Space Centre USA",
                StartTime = new DateTime(2019, 1, 2, 10, 30, 0),
                EndTime = new DateTime(2019, 1, 2, 12, 30, 0),
                CategoryColor = "#1aaa55"
            });
            appData.Add(new AppointmentData
            {
                Id = 14,
                Subject = "Aliens vs Humans",
                Location = "Research Centre of USA",
                StartTime = new DateTime(2019, 1, 1, 10, 0, 0),
                EndTime = new DateTime(2019, 1, 1, 11, 30, 0),
                CategoryColor = "#357cd2"
            });
            appData.Add(new AppointmentData
            {
                Id = 15,
                Subject = "Facts of Humming Birds",
                Location = "California",
                StartTime = new DateTime(2019, 1, 15, 9, 30, 0),
                EndTime = new DateTime(2019, 1, 15, 11, 0, 0),
                CategoryColor = "#7fa900"
            });
            appData.Add(new AppointmentData
            {
                Id = 16,
                Subject = "Sky Gazers",
                Location = "Alaska",
                StartTime = new DateTime(2019, 1, 18, 11, 0, 0),
                EndTime = new DateTime(2019, 1, 18, 13, 0, 0),
                CategoryColor = "#ea7a57"
            });
            appData.Add(new AppointmentData
            {
                Id = 17,
                Subject = "The Cycle of Seasons",
                Location = "Research Centre of USA",
                StartTime = new DateTime(2019, 1, 7, 5, 30, 0),
                EndTime = new DateTime(2019, 1, 7, 7, 30, 0),
                CategoryColor = "#00bdae"
            });
            appData.Add(new AppointmentData
            {
                Id = 18,
                Subject = "Space Galaxies and Planets",
                Location = "Space Centre USA",
                StartTime = new DateTime(2019, 1, 7, 17, 0, 0),
                EndTime = new DateTime(2019, 1, 7, 18, 30, 0),
                CategoryColor = "#f57f17"
            });
            appData.Add(new AppointmentData
            {
                Id = 19,
                Subject = "Lifecycle of Bumblebee",
                Location = "San Fransisco",
                StartTime = new DateTime(2019, 1, 10, 6, 0, 0),
                EndTime = new DateTime(2019, 1, 10, 7, 30, 0),
                CategoryColor = "#7fa900"
            });
            appData.Add(new AppointmentData
            {
                Id = 20,
                Subject = "Alien Civilization",
                Location = "Space Centre USA",
                StartTime = new DateTime(2019, 1, 10, 16, 0, 0),
                EndTime = new DateTime(2019, 1, 10, 18, 0, 0),
                CategoryColor = "#ea7a57"
            });
            appData.Add(new AppointmentData
            {
                Id = 21,
                Subject = "Alien Civilization",
                Location = "Space Centre USA",
                StartTime = new DateTime(2019, 1, 6, 14, 0, 0),
                EndTime = new DateTime(2019, 1, 6, 16, 0, 0),
                CategoryColor = "#ea7a57"
            });
            appData.Add(new AppointmentData
            {
                Id = 22,
                Subject = "The Cycle of Seasons",
                Location = "Research Centre of USA",
                StartTime = new DateTime(2019, 1, 8, 14, 30, 0),
                EndTime = new DateTime(2019, 1, 8, 16, 0, 0),
                CategoryColor = "#00bdae"
            });
            appData.Add(new AppointmentData
            {
                Id = 23,
                Subject = "Sky Gazers",
                Location = "Greenland",
                StartTime = new DateTime(2019, 1, 11, 14, 30, 0),
                EndTime = new DateTime(2019, 1, 11, 16, 0, 0),
                CategoryColor = "#ea7a57"
            });
            appData.Add(new AppointmentData
            {
                Id = 24,
                Subject = "Facts of Humming Birds",
                Location = "California",
                StartTime = new DateTime(2019, 1, 12, 12, 30, 0),
                EndTime = new DateTime(2019, 1, 12, 14, 30, 0),
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
