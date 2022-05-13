#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {
        public IActionResult TimelineResources()
        {
            ViewBag.datasource = new ScheduleData().GetRoomData();

            List<RoomData> rooms = new List<RoomData>();
            rooms.Add(new RoomData { name = "Jammy", id = 1, color = "#ea7a57", capacity = 20, type = "Conference" });
            rooms.Add(new RoomData { name = "Tweety", id = 2, color = "#7fa900", capacity = 7, type = "Cabin" });
            rooms.Add(new RoomData { name = "Nestle", id = 3, color = "#5978ee", capacity = 5, type = "Cabin" });
            rooms.Add(new RoomData { name = "Phoenix", id = 4, color = "#fec200", capacity = 15, type = "Conference" });
            rooms.Add(new RoomData { name = "Mission", id = 5, color = "#df5286", capacity = 25, type = "Conference" });
            rooms.Add(new RoomData { name = "Hangout", id = 6, color = "#00bdae", capacity = 10, type = "Cabin" });
            rooms.Add(new RoomData { name = "Rick Roll", id = 7, color = "#865fcf", capacity = 20, type = "Conference" });
            rooms.Add(new RoomData { name = "Rainbow", id = 8, color = "#1aaa55", capacity = 8, type = "Cabin" });
            rooms.Add(new RoomData { name = "Swarm", id = 9, color = "#df5286", capacity = 30, type = "Conference" });
            rooms.Add(new RoomData { name = "Photogenic", id = 10, color = "#710193", capacity = 25, type = "Conference" });
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
            public int capacity { set; get; }
            public string type { set; get; }
        }
    }
}