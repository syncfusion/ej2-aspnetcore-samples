#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser_NET8.Pages.Schedule;

public class Year : PageModel
{
    public List<EventsData> GenerateEvents()
    {
        List<EventsData> dataCollections = new List<EventsData>(360);
        int count = 250;
        int year = DateTime.Now.Year;
        var colors = new string[]
        {
            "#ff8787", "#9775fa", "#748ffc", "#3bc9db", "#69db7c",
            "#fdd835", "#748ffc", "#9775fa", "#df5286", "#7fa900",
            "#fec200", "#5978ee", "#00bdae", "#ea80fc"
        };
        var names = new string[]
        {
            "Bering Sea Gold", "Technology", "Maintenance", "Meeting", "Travelling", "Annual Conference",
            "Birthday Celebration", "Farewell Celebration", "Wedding Anniversary", "Alaska: The Last Frontier",
            "Deadliest Catch", "Sports Day", "MoonShiners", "Close Encounters", "HighWay Thru Hell", "Daily Planet",
            "Cash Cab", "Basketball Practice", "Rugby Match", "Guitar Class", "Music Lessons", "Doctor checkup",
            "Brazil - Mexico", "Opening ceremony", "Final presentation"
        };
        DateTime startDate = new DateTime(year - 2, 1, 1);
        DateTime endDate = new DateTime(year + 2, 12, 31);
        for (int a = 0, id = 1; a < count; a++)
        {
            Random random = new Random();
            double num = random.NextDouble();
            DateTimeOffset sdate = new DateTimeOffset(startDate).ToUniversalTime();
            long startDateMilliSeconds = sdate.ToUnixTimeMilliseconds();
            DateTimeOffset edate = new DateTimeOffset(endDate).ToUniversalTime();
            long endDateMilliSeconds = edate.ToUnixTimeMilliseconds();
            long Operations = (long)(num * (endDateMilliSeconds - startDateMilliSeconds) + startDateMilliSeconds);
            DateTime start = DateTimeOffset.FromUnixTimeMilliseconds(Operations).UtcDateTime;
            DateTime end = start.AddHours(1);
            int ncount = (int)Math.Floor(Convert.ToDecimal(num * names.Length));
            dataCollections.Add(new EventsData
            {
                Id = id,
                Subject = names[ncount],
                StartTime = start,
                EndTime = end,
                IsAllDay = (id % 10 == 0) ? true : false,
                CategoryColor = colors[random.Next(1, 13)],
                TaskId = (id % 5) + 1
            });
            id++;
        }
        return dataCollections;
    }

    public List<ResourceDataSourceModel> categories = new List<ResourceDataSourceModel>();
    public List<MonthData> months = new List<MonthData>();
    public void OnGet()
    {
        categories.Add(new ResourceDataSourceModel { text = "Nancy", id = 1, groupId = 1, color = "#df5286" });
        categories.Add(new ResourceDataSourceModel { text = "Steven", id = 2, groupId = 1, color = "#7fa900" });
        categories.Add(new ResourceDataSourceModel { text = "Robert", id = 3, groupId = 2, color = "#ea7a57" });
        categories.Add(new ResourceDataSourceModel { text = "Smith", id = 4, groupId = 2, color = "#5978ee" });
        categories.Add(new ResourceDataSourceModel { text = "Michael", id = 5, groupId = 3, color = "#df5286" });
        categories.Add(new ResourceDataSourceModel { text = "Root", id = 6, groupId = 3, color = "#00bdae" });
        
        months.Add(new MonthData() { text = "January", value = 0 });
        months.Add(new MonthData() { text = "February", value = 1 });
        months.Add(new MonthData() { text = "March", value = 2 });
        months.Add(new MonthData() { text = "April", value = 3 });
        months.Add(new MonthData() { text = "May", value = 4 });
        months.Add(new MonthData() { text = "June", value = 5 });
        months.Add(new MonthData() { text = "July", value = 6 });
        months.Add(new MonthData() { text = "August", value = 7 });
        months.Add(new MonthData() { text = "September", value = 8 });
        months.Add(new MonthData() { text = "October", value = 9 });
        months.Add(new MonthData() { text = "November", value = 10 });
        months.Add(new MonthData() { text = "December", value = 11 });
    }
}

public class MonthData
{
    public string text { get; set; }
    public int value { get; set; }
}

public class EventsData
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAllDay { get; set; }
    public string CategoryColor { get; set; }
    public int TaskId { get; set; }
}