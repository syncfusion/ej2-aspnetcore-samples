#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class AdaptiveRows : PageModel
{
    public List<RoomDataSource> rooms = new List<RoomDataSource>();
    public void OnGet()
    {
        rooms.Add(new RoomDataSource { name = "Room A", id = 1, color = "#98AFC7" });
        rooms.Add(new RoomDataSource { name = "Room B", id = 2, color = "#99c68e" });
        rooms.Add(new RoomDataSource { name = "Room C", id = 3, color = "#C2B280" });
        rooms.Add(new RoomDataSource { name = "Room D", id = 4, color = "#3090C7" });
        rooms.Add(new RoomDataSource { name = "Room E", id = 5, color = "#95b9" });
        rooms.Add(new RoomDataSource { name = "Room F", id = 6, color = "#95b9c7" });
        rooms.Add(new RoomDataSource { name = "Room G", id = 7, color = "#deb887" });
        rooms.Add(new RoomDataSource { name = "Room H", id = 8, color = "#3090C7" });
        rooms.Add(new RoomDataSource { name = "Room I", id = 9, color = "#98AFC7" });
        rooms.Add(new RoomDataSource { name = "Room J", id = 10, color = "#778899" });
    }
}
public class RoomDataSource
{
    public int id { set; get; }
    public string name { set; get; }
    public string color { set; get; }
}