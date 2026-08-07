using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser.Pages.Schedule
{
    public class SchedulerWithChartModel : PageModel
    {
        public List<DriverData> driversMaster { get; set; }
        public List<SchedulerWithChartEventData> events { get; set; }

        public void OnGet()
        {
            driversMaster = new List<DriverData>()
            {
                new DriverData { driver = "Ben Smith", id = 1, color = "#ea7a57", truck = "Volvo FH16", capacity = "325" },
                new DriverData { driver = "Sarah Johnson", id = 2, color = "#7fa900", truck = "Scania R730", capacity = "310" },
                new DriverData { driver = "Mike Chen", id = 3, color = "#5978ee", truck = "Mercedes Actros", capacity = "290" },
                new DriverData { driver = "Emma Davis", id = 4, color = "#fec200", truck = "MAN TGX", capacity = "280" },
                new DriverData { driver = "Carlos Rodriguez", id = 5, color = "#df5286", truck = "DAF XF", capacity = "300" },
                new DriverData { driver = "Olivia Wilson", id = 6, color = "#00bdae", truck = "Kenworth T680", capacity = "315" },
                new DriverData { driver = "James Taylor", id = 7, color = "#865fcf", truck = "Peterbilt 579", capacity = "305" },
                new DriverData { driver = "Sophia Martinez", id = 8, color = "#1aaa55", truck = "Freightliner Cascadia", capacity = "295" },
                new DriverData { driver = "Daniel Lee", id = 9, color = "#df5286", truck = "Mack Anthem", capacity = "285" },
                new DriverData { driver = "Ava Thompson", id = 10, color = "#710193", truck = "International LT", capacity = "275" }
            };

            events = new List<SchedulerWithChartEventData>()
            {
                new SchedulerWithChartEventData { Id = 1, Subject = "Long haul trip", StartTime = new DateTime(2026,1,14,2,30,0), EndTime = new DateTime(2026,1,14,7,30,0), DriverID = 1 },
                new SchedulerWithChartEventData { Id = 2, Subject = "Delivery to New York", StartTime = new DateTime(2026,1,12,18,30,0), EndTime = new DateTime(2026,1,13,6,30,0), DriverID = 2 },
                new SchedulerWithChartEventData { Id = 3, Subject = "Cross-country route", StartTime = new DateTime(2026,1,13,0,40,0), EndTime = new DateTime(2026,1,13,4,30,0), DriverID = 3 },
                new SchedulerWithChartEventData { Id = 4, Subject = "Refrigerated goods", StartTime = new DateTime(2026,1,13,8,30,0), EndTime = new DateTime(2026,1,13,19,30,0), DriverID = 4 },
                new SchedulerWithChartEventData { Id = 5, Subject = "Container transport", StartTime = new DateTime(2026,1,12,20,30,0), EndTime = new DateTime(2026,1,13,3,30,0), DriverID = 5 },
                new SchedulerWithChartEventData { Id = 6, Subject = "Food products", StartTime = new DateTime(2026,1,12,12,30,0), EndTime = new DateTime(2026,1,13,9,30,0), DriverID = 7 },
                new SchedulerWithChartEventData { Id = 7, Subject = "Medical supplies", StartTime = new DateTime(2026,1,13,1,30,0), EndTime = new DateTime(2026,1,13,7,30,0), DriverID = 9 },
                new SchedulerWithChartEventData { Id = 8, Subject = "Delivery to India", StartTime = new DateTime(2026,1,14,18,30,0), EndTime = new DateTime(2026,1,15,6,30,0), DriverID = 2 },
                new SchedulerWithChartEventData { Id = 9, Subject = "Delivery to UK", StartTime = new DateTime(2026,1,15,8,30,0), EndTime = new DateTime(2026,1,15,19,30,0), DriverID = 4 },
                new SchedulerWithChartEventData { Id = 10, Subject = "Delivery to Germany", StartTime = new DateTime(2026,1,16,8,30,0), EndTime = new DateTime(2026,1,16,19,30,0), DriverID = 4 },
                new SchedulerWithChartEventData { Id = 11, Subject = "Delivery to Japan", StartTime = new DateTime(2026,1,15,12,30,0), EndTime = new DateTime(2026,1,15,19,30,0), DriverID = 7 }
            };
        }
    }

    public class DriverData
    {
        public string driver { get; set; }
        public int id { get; set; }
        public string color { get; set; }
        public string truck { get; set; }
        public string capacity { get; set; }
    }

    public class SchedulerWithChartEventData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DriverID { get; set; }
    }
}
