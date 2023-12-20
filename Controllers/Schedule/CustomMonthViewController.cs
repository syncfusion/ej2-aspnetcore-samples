#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {
        public IActionResult CustomMonthView()
        {
            ViewBag.appointments = this.generateObject();
            return View();
        }

        private List<CustomMonthData> generateObject()
        {
            DateTime startDate = new DateTime(2021, 12, 19);
            DateTime endDate = new DateTime(2022, 3, 12);
            List<CustomMonthData> dataCollections = new List<CustomMonthData>(360);
            var names = new string[] {
            "Story Time for Kids", "Camping with Turtles", "Wildlife Warriors", "Parrot Talk", "Birds of Prey", "Croco World",
            "Venomous Snake Hunt", "Face Painting & Drawing events", "Pony Rides", "Feed the Giants", "Jungle Treasure Hunt",
            "Endangered Species Program", "Black Cockatoos Playtime", "Walk with Jungle King", "Trained Climbers", "Playtime with Chimpanzees",
            "Meet a small Mammal", "Amazon Fish Feeding", "Elephant Ride"};
            Random random = new Random();
            int id = 1;
            for (DateTime start = startDate; start < endDate;)
            {
                int count = random.Next(1, 5);
                for (int b = 0; b < count; b++)
                {
                    int hour = random.Next(1, 23);
                    int minutes = random.Next(0, 60);
                    int nCount = random.Next(0, names.Length - 1);
                    DateTime eventStart = new DateTime(start.Year, start.Month, start.Day, hour, minutes, 0);
                    DateTime eventEnd = eventStart.AddHours(2.5);

                    DayOfWeek[] weekEnd = new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
                    if ((Array.IndexOf(weekEnd, eventStart.DayOfWeek) > -1) || Array.IndexOf(weekEnd, eventEnd.DayOfWeek) > -1) {
                        continue;
                    }

                    dataCollections.Add(new CustomMonthData
                    {
                        Id = id,
                        Subject = names[nCount],
                        StartTime = eventStart,
                        EndTime = eventEnd,
                        IsAllDay = (id % 10 == 0) ? true : false
                    });
                    id++;
                }
                start = start.AddDays(1);
            }
            return dataCollections;
        }

        internal class CustomMonthData
        {
            public int Id { get; set; }
            public string Subject { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public bool IsAllDay { get; set; }
        }
    }
}

