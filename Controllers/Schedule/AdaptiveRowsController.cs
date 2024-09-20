#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Schedule
{
    public partial class ScheduleController : Controller
    {
        public IActionResult AdaptiveRows()
        {
            ViewBag.datasource = new ScheduleData().GetRoomData();

            List<RoomData> rooms = new List<RoomData>();
            rooms.Add(new RoomData { name = "Room A", id = 1, color = "#98AFC7" });
            rooms.Add(new RoomData { name = "Room B", id = 2, color = "#99c68e" });
            rooms.Add(new RoomData { name = "Room C", id = 3, color = "#C2B280" });
            rooms.Add(new RoomData { name = "Room D", id = 4, color = "#3090C7" });
            rooms.Add(new RoomData { name = "Room E", id = 5, color = "#95b9" });
            rooms.Add(new RoomData { name = "Room F", id = 6, color = "#95b9c7" });
            rooms.Add(new RoomData { name = "Room G", id = 7, color = "#deb887" });
            rooms.Add(new RoomData { name = "Room H", id = 8, color = "#3090C7" });
            rooms.Add(new RoomData { name = "Room I", id = 9, color = "#98AFC7" });
            rooms.Add(new RoomData { name = "Room J", id = 10, color = "#778899" });
            ViewBag.RoomDatas = rooms;

            string[] resources = new string[] { "MeetingRoom" };
            ViewBag.ResourceNames = resources;
            return View();
        }

        class RoomData
        {
            public int id { set; get; }
            public string name { set; get; }
            public string color { set; get; }
        }
    }
}