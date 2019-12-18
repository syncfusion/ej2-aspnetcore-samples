using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {
        public IActionResult Year()
        {
            ViewBag.orientation = GetOrientation();
            ViewBag.datasource = this.generateStaticEvents(); 
            return View();
        }

        public List<DropDownData> GetOrientation()
        {
            List<DropDownData> orientation = new List<DropDownData>();
            orientation.Add(new DropDownData { Name = "Horizontal", Value = "Horizontal" });
            orientation.Add(new DropDownData { Name = "Vertical", Value = "Vertical" });
            return orientation;
        }
        
        private List<EventsData> generateStaticEvents()
        {
            List<EventsData> data = new List<EventsData>(300);
            var names = new string[]
            { "Bering Sea Gold", "Technology", "Maintenance", "Meeting", "Travelling", "Annual Conference", "Birthday Celebration",
            "Farewell Celebration", "Wedding Aniversary", "Alaska: The Last Frontier", "Deadest Catch", "Sports Day",
            "MoonShiners", "Close Encounters", "HighWay Thru Hell", "Daily Planet", "Cash Cab", "Basketball Practice",
            "Rugby Match", "Guitar Class", "Music Lessons", "Doctor checkup", "Brazil - Mexico", "Opening ceremony", "Final presentation"
            };
            var colors = new string[] { "#ff8787", "#9775fa", "#748ffc", "#3bc9db", "#69db7c",
           "#fdd835", "#748ffc", "#9775fa", "#df5286", "#7fa900",
           "#fec200", "#5978ee", "#00bdae", "#ea80fc"};
            var id = 1;
            DateTime date = new DateTime(2017, 1, 1);
            Random random = new Random();
            for (var index = 0; index< 3; index++)
            {
                for (var i = 0; i < 12; i++)
                {
                    for(var j = 0; j < 5; j++)
                    {
                        int number = random.Next(28);
                        date = new DateTime(2017 + index, 1 + i, 1);
                        var startDate = date.AddDays(number + (i % 2));
                        startDate = startDate.AddMilliseconds((((number % 10) * 10) * (1000 * 60)));
                        var endDate = startDate.AddMilliseconds(((1440 + 30) * (1000 * 60)));
                        data.Add(new EventsData
                        {
                            Id = id,
                            Subject = names[i % names.Length],
                            StartTime = startDate,
                            EndTime = endDate,
                            IsAllDay = (id % 10 == 0) ? false : true,
                            CategoryColor = colors[i % colors.Length]
                        });
                        id++;
                    }
                }
                
            }
            return data;
        }
    }
    class EventsData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAllDay { get; set; }
        public string CategoryColor { get; set; }
    }     
}
