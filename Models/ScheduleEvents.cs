#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
                StartTime = new DateTime(CurrentYear, 1, 9, 9, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 9, 11, 0, 0),
                CategoryColor = "#1aaa55"
            });
            appData.Add(new AppointmentData
            {
                Id = 2,
                Subject = "Thule Air Crash Report",
                Location = "Newyork City",
                StartTime = new DateTime(CurrentYear, 1, 10, 12, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 10, 14, 0, 0),
                CategoryColor = "#357cd2"
            });
            appData.Add(new AppointmentData
            {
                Id = 3,
                Subject = "Blue Moon Eclipse",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 1, 11, 9, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 11, 11, 0, 0),
                CategoryColor = "#7fa900"
            });
            appData.Add(new AppointmentData
            {
                Id = 4,
                Subject = "Meteor Showers in 2021",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 1, 12, 13, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 12, 14, 30, 0),
                CategoryColor = "#ea7a57"
            });
            appData.Add(new AppointmentData
            {
                Id = 5,
                Subject = "Milky Way as Melting pot",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 1, 13, 12, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 13, 14, 0, 0),
                CategoryColor = "#00bdae"
            });
            appData.Add(new AppointmentData
            {
                Id = 6,
                Subject = "Mysteries of Bermuda Triangle",
                Location = "Bermuda",
                StartTime = new DateTime(CurrentYear, 1, 13, 9, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 13, 11, 0, 0),
                CategoryColor = "#f57f17"
            });
            appData.Add(new AppointmentData
            {
                Id = 7,
                Subject = "Glaciers and Snowflakes",
                Location = "Himalayas",
                StartTime = new DateTime(CurrentYear, 1, 14, 11, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 14, 12, 30, 0),
                CategoryColor = "#1aaa55"
            });
            appData.Add(new AppointmentData
            {
                Id = 8,
                Subject = "Life on Mars",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 1, 15, 9, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 15, 10, 0, 0),
                CategoryColor = "#357cd2"
            });
            appData.Add(new AppointmentData
            {
                Id = 9,
                Subject = "Alien Civilization",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 1, 17, 11, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 17, 13, 0, 0),
                CategoryColor = "#7fa900"
            });
            appData.Add(new AppointmentData
            {
                Id = 10,
                Subject = "Wildlife Galleries",
                Location = "Africa",
                StartTime = new DateTime(CurrentYear, 1, 19, 11, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 19, 13, 0, 0),
                CategoryColor = "#ea7a57"
            });
            appData.Add(new AppointmentData
            {
                Id = 11,
                Subject = "Best Photography 2021",
                Location = "London",
                StartTime = new DateTime(CurrentYear, 1, 20, 9, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 20, 11, 0, 0),
                CategoryColor = "#00bdae"
            });
            appData.Add(new AppointmentData
            {
                Id = 12,
                Subject = "Smarter Puppies",
                Location = "Sweden",
                StartTime = new DateTime(CurrentYear, 1, 7, 10, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 7, 11, 30, 0),
                CategoryColor = "#f57f17"
            });
            appData.Add(new AppointmentData
            {
                Id = 13,
                Subject = "Myths of Andromeda Galaxy",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 1, 5, 10, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 5, 12, 30, 0),
                CategoryColor = "#1aaa55"
            });
            appData.Add(new AppointmentData
            {
                Id = 14,
                Subject = "Aliens vs Humans",
                Location = "Research Centre of USA",
                StartTime = new DateTime(CurrentYear, 1, 4, 10, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 4, 11, 30, 0),
                CategoryColor = "#357cd2"
            });
            appData.Add(new AppointmentData
            {
                Id = 15,
                Subject = "Facts of Humming Birds",
                Location = "California",
                StartTime = new DateTime(CurrentYear, 1, 18, 9, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 18, 11, 0, 0),
                CategoryColor = "#7fa900"
            });
            appData.Add(new AppointmentData
            {
                Id = 16,
                Subject = "Sky Gazers",
                Location = "Alaska",
                StartTime = new DateTime(CurrentYear, 1, 21, 11, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 21, 13, 0, 0),
                CategoryColor = "#ea7a57"
            });
            appData.Add(new AppointmentData
            {
                Id = 17,
                Subject = "The Cycle of Seasons",
                Location = "Research Centre of USA",
                StartTime = new DateTime(CurrentYear, 1, 10, 5, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 10, 7, 30, 0),
                CategoryColor = "#00bdae"
            });
            appData.Add(new AppointmentData
            {
                Id = 18,
                Subject = "Space Galaxies and Planets",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 1, 10, 17, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 10, 18, 30, 0),
                CategoryColor = "#f57f17"
            });
            appData.Add(new AppointmentData
            {
                Id = 19,
                Subject = "Lifecycle of Bumblebee",
                Location = "San Fransisco",
                StartTime = new DateTime(CurrentYear, 1, 13, 6, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 13, 7, 30, 0),
                CategoryColor = "#7fa900"
            });
            appData.Add(new AppointmentData
            {
                Id = 20,
                Subject = "Alien Civilization",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 1, 13, 16, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 13, 18, 0, 0),
                CategoryColor = "#ea7a57"
            });
            appData.Add(new AppointmentData
            {
                Id = 21,
                Subject = "Alien Civilization",
                Location = "Space Centre USA",
                StartTime = new DateTime(CurrentYear, 1, 9, 14, 0, 0),
                EndTime = new DateTime(CurrentYear, 1, 9, 16, 0, 0),
                CategoryColor = "#ea7a57"
            });
            appData.Add(new AppointmentData
            {
                Id = 22,
                Subject = "The Cycle of Seasons",
                Location = "Research Centre of USA",
                StartTime = new DateTime(CurrentYear, 1, 11, 14, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 11, 16, 0, 0),
                CategoryColor = "#00bdae"
            });
            appData.Add(new AppointmentData
            {
                Id = 23,
                Subject = "Sky Gazers",
                Location = "Greenland",
                StartTime = new DateTime(CurrentYear, 1, 14, 14, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 14, 16, 0, 0),
                CategoryColor = "#ea7a57"
            });
            appData.Add(new AppointmentData
            {
                Id = 24,
                Subject = "Facts of Humming Birds",
                Location = "California",
                StartTime = new DateTime(CurrentYear, 1, 15, 12, 30, 0),
                EndTime = new DateTime(CurrentYear, 1, 15, 14, 30, 0),
                CategoryColor = "#7fa900"
            });
            return appData;
        }
        public List<AppointmentData> GetOverlappingData()
        {
            List<AppointmentData> overlapEventData = new List<AppointmentData>();
            overlapEventData.Add(new AppointmentData
            {
                Id = 1,
                Subject = "Holiday Market",
                Location = "City Square",
                StartTime = new DateTime(CurrentYear, 2, 2, 10, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 2, 12, 0, 0),
                CategoryColor = "#ff0000"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 2,
                Subject = "Christmas Caroling",
                Location = "Town Hall",
                StartTime = new DateTime(CurrentYear, 2, 2, 11, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 2, 13, 0, 0),
                CategoryColor = "#00ff00"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 3,
                Subject = "Gingerbread House Workshop",
                Location = "Community Center",
                StartTime = new DateTime(CurrentYear, 2, 5, 9, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 5, 11, 0, 0),
                CategoryColor = "#0000ff"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 4,
                Subject = "Winter Wonderland",
                Location = "Central Park",
                StartTime = new DateTime(CurrentYear, 2, 5, 10, 30, 0),
                EndTime = new DateTime(CurrentYear, 2, 5, 12, 30, 0),
                CategoryColor = "#ff00ff"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 5,
                Subject = "Santa's Grotto",
                Location = "Shopping Mall",
                StartTime = new DateTime(CurrentYear, 2, 6, 14, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 6, 16, 0, 0),
                CategoryColor = "#00ffff"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 6,
                Subject = "Ice Sculpture Contest",
                Location = "City Center",
                StartTime = new DateTime(CurrentYear, 2, 7, 15, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 7, 17, 0, 0),
                CategoryColor = "#ff8000"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 7,
                Subject = "Hot Cocoa Social",
                Location = "Community Hall",
                StartTime = new DateTime(CurrentYear, 2, 8, 10, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 8, 12, 0, 0),
                CategoryColor = "#8000ff"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 8,
                Subject = "Snowflake Ball",
                Location = "Grand Ballroom",
                StartTime = new DateTime(CurrentYear, 2, 9, 11, 30, 0),
                EndTime = new DateTime(CurrentYear, 2, 9, 13, 30, 0),
                CategoryColor = "#ff0080"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 9,
                Subject = "Reindeer Games",
                Location = "Local Park",
                StartTime = new DateTime(CurrentYear, 2, 10, 9, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 10, 11, 0, 0),
                CategoryColor = "#0080ff"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 10,
                Subject = "Elf Workshop",
                Location = "Toy Store",
                StartTime = new DateTime(CurrentYear, 2, 11, 10, 30, 0),
                EndTime = new DateTime(CurrentYear, 2, 11, 12, 30, 0),
                CategoryColor = "#ff8000"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 11,
                Subject = "Holiday Parade",
                Location = "Main Street",
                StartTime = new DateTime(CurrentYear, 2, 12, 13, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 12, 15, 0, 0),
                CategoryColor = "#800080"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 12,
                Subject = "Christmas Tree Lighting",
                Location = "City Hall",
                StartTime = new DateTime(CurrentYear, 2, 13, 14, 30, 0),
                EndTime = new DateTime(CurrentYear, 2, 13, 16, 30, 0),
                CategoryColor = "#ff00ff"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 13,
                Subject = "Holiday Baking Class",
                Location = "Culinary School",
                StartTime = new DateTime(CurrentYear, 2, 14, 11, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 14, 13, 0, 0),
                CategoryColor = "#00ff80"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 14,
                Subject = "Winter Fair",
                Location = "Fairgrounds",
                StartTime = new DateTime(CurrentYear, 2, 15, 12, 30, 0),
                EndTime = new DateTime(CurrentYear, 2, 15, 14, 30, 0),
                CategoryColor = "#ff0080"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 15,
                Subject = "Parrot Show",
                Location = "Zoo",
                StartTime = new DateTime(CurrentYear, 2, 5, 14, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 5, 15, 0, 0),
                CategoryColor = "#cddc39"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 16,
                Subject = "Seal Show",
                Location = "Aquarium",
                StartTime = new DateTime(CurrentYear, 2, 6, 14, 30, 0),
                EndTime = new DateTime(CurrentYear, 2, 6, 16, 0, 0),
                CategoryColor = "#ff9800"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 17,
                Subject = "Dolphin Show",
                Location = "Marine Park",
                StartTime = new DateTime(CurrentYear, 2, 7, 10, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 7, 11, 0, 0),
                CategoryColor = "#795548"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 18,
                Subject = "Shark Feeding",
                Location = "Aquarium",
                StartTime = new DateTime(CurrentYear, 2, 8, 12, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 8, 13, 0, 0),
                CategoryColor = "#607d8b"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 19,
                Subject = "Otter Show",
                Location = "Zoo",
                StartTime = new DateTime(CurrentYear, 2, 9, 14, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 9, 15, 0, 0),
                CategoryColor = "#e91e63"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 20,
                Subject = "Crocodile Feeding",
                Location = "Reptile House",
                StartTime = new DateTime(CurrentYear, 2, 10, 14, 30, 0),
                EndTime = new DateTime(CurrentYear, 2, 10, 16, 0, 0),
                CategoryColor = "#9e9e9e"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 21,
                Subject = "Panda Playtime",
                Location = "Zoo",
                StartTime = new DateTime(CurrentYear, 2, 11, 10, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 11, 11, 30, 0),
                CategoryColor = "#ff4081"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 22,
                Subject = "Tiger Talk",
                Location = "Big Cat Enclosure",
                StartTime = new DateTime(CurrentYear, 2, 12, 12, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 12, 14, 0, 0),
                CategoryColor = "#8e24aa"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 23,
                Subject = "Holiday Market",
                Location = "Town Square",
                StartTime = new DateTime(CurrentYear, 2, 13, 10, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 13, 12, 0, 0),
                CategoryColor = "#ff0000"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 24,
                Subject = "Christmas Caroling",
                Location = "Community Center",
                StartTime = new DateTime(CurrentYear, 2, 13, 11, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 13, 13, 0, 0),
                CategoryColor = "#00ff00"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 25,
                Subject = "Gingerbread House Workshop",
                Location = "Bakery",
                StartTime = new DateTime(CurrentYear, 2, 16, 9, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 16, 11, 0, 0),
                CategoryColor = "#0000ff"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 26,
                Subject = "Winter Wonderland",
                Location = "Ski Resort",
                StartTime = new DateTime(CurrentYear, 2, 16, 10, 30, 0),
                EndTime = new DateTime(CurrentYear, 2, 16, 12, 30, 0),
                CategoryColor = "#ff00ff"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 27,
                Subject = "Santa's Grotto",
                Location = "Department Store",
                StartTime = new DateTime(CurrentYear, 2, 17, 14, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 17, 16, 0, 0),
                CategoryColor = "#00ffff"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 28,
                Subject = "Ice Sculpture Contest",
                Location = "Town Square",
                StartTime = new DateTime(CurrentYear, 2, 17, 15, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 17, 17, 0, 0),
                CategoryColor = "#ff8000"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 29,
                Subject = "Hot Cocoa Social",
                Location = "Cafe",
                StartTime = new DateTime(CurrentYear, 2, 18, 10, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 18, 12, 0, 0),
                CategoryColor = "#8000ff"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 30,
                Subject = "Snowflake Ball",
                Location = "City Hall",
                StartTime = new DateTime(CurrentYear, 2, 19, 11, 30, 0),
                EndTime = new DateTime(CurrentYear, 2, 19, 13, 30, 0),
                CategoryColor = "#ff0080"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 31,
                Subject = "Reindeer Games",
                Location = "Community Park",
                StartTime = new DateTime(CurrentYear, 2, 20, 9, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 20, 11, 0, 0),
                CategoryColor = "#0080ff"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 32,
                Subject = "Elf Workshop",
                Location = "Community Center",
                StartTime = new DateTime(CurrentYear, 2, 21, 10, 30, 0),
                EndTime = new DateTime(CurrentYear, 2, 21, 12, 30, 0),
                CategoryColor = "#ff8000"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 33,
                Subject = "Holiday Parade",
                Location = "Main Street",
                StartTime = new DateTime(CurrentYear, 2, 22, 13, 0, 0),
                EndTime = new DateTime(CurrentYear, 2, 22, 15, 0, 0),
                CategoryColor = "#800080"
            });
            overlapEventData.Add(new AppointmentData
            {
                Id = 34,
                Subject = "Christmas Tree Lighting",
                Location = "Town Square",
                StartTime = new DateTime(CurrentYear, 2, 22, 14, 30, 0),
                EndTime = new DateTime(CurrentYear, 2, 22, 16, 30, 0),
                CategoryColor = "#ff00ff"
            });
            return overlapEventData;
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
