#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class VirtualScrolling : PageModel
{
    public List<ResourceData> GenerateResourceData(int start, int end)
    {
        List<ResourceData> resources = new List<ResourceData>(300);
        var colors = new string[] { "#ff8787", "#9775fa", "#748ffc", "#3bc9db", "#69db7c",
            "#fdd835", "#748ffc", "#9775fa", "#df5286", "#7fa900",
            "#fec200", "#5978ee", "#00bdae", "#ea80fc"};
        for (int a = start; a <= end; a++)
        {
            int index = a % colors.Length;
            index = index == 0 ? (colors.Length / a):index;  
            resources.Add(new ResourceData
            {
                Id = a,
                Text = "Resource " + a,
                Color = colors[index]
            });
        }
        return resources;
    }
    public List<EventData> generateStaticEvents(DateTime date, int v1, int v2)
    {
        List<EventData> data = new List<EventData>(3600);
        var id = 1;
        for (var i = 0; i < 300; i++)
        {
            Random random = new Random();
            List<int> listNumbers = new List<int>();
            int[] randomCollection = new int[24];
            int number;
            int max = 30;
            for (int a = 0; a < 12; a++)
            {
                do
                {
                    number = random.Next(max);
                } while (listNumbers.Contains(number));

                listNumbers.Add(number);
                var startDate = date.AddDays(number + (i % 2));
                startDate = startDate.AddMilliseconds((((number % 10) * 10) * (1000 * 60)));
                var endDate = startDate.AddMilliseconds(((1440 + 30) * (1000 * 60)));
                data.Add(new EventData
                {
                    Id = id,
                    Subject = "Event #" + id,
                    StartTime = startDate,
                    EndTime = endDate,
                    IsAllDay = (id % 10 == 0) ? false : true,
                    ResourceId = i + 1
                });
                id++;
            }
        }
        return data;
    }

    public void OnGet()
    {
        
    }
}

public class EventData
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAllDay { get; set; }
    public int ResourceId { get; set; }
}

public class ResourceData
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Color { get; set; }
}