#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Pages
{
    public class EventManagement : PageModel
    {
        public DateTime SelectedDate { get; set; } = new DateTime(2025, 2, 24);
        public List<EventManagementData> Events { get; set; }
        public List<RoomData> Rooms { get; set; }
        public List<Room> RoomsData { get; set; }
        public List<EventManagementData> CloudSecurityEvents { get; set; }
        public List<EventManagementData> AIAutomationEvents { get; set; }
        public List<EventManagementData> AllEvents { get; set; }
        public List<DropDownItem> UnPlannedEventsList { get; set; }

        // TreeView field settings
        public TreeViewFieldsSettings AllEventsFields { get; set; }
        public TreeViewFieldsSettings CloudSecurityEventsFields { get; set; }
        public TreeViewFieldsSettings AIAutomationEventsFields { get; set; }

        public void OnGet()
        {
            Events = EventManagementDataSource.GetEventData();
            Rooms = EventManagementDataSource.GetRooms();
            CloudSecurityEvents = EventManagementDataSource.GetCloudSecurityEventData();
            AIAutomationEvents = EventManagementDataSource.GetAIAutomationEventData();

            AllEvents = CloudSecurityEvents.Concat(AIAutomationEvents).ToList();

            UnPlannedEventsList = new List<DropDownItem>
            {
                new DropDownItem { Id = "0", Name = "All" },
                new DropDownItem { Id = "1", Name = "Cloud Security Essentials" },
                new DropDownItem { Id = "2", Name = "AI for Automation" }
            };

            RoomsData = new List<Room>
            {
                new Room { RoomId = 0, RoomName = "All" },
                new Room { RoomId = 1, RoomName = "Room A" },
                new Room { RoomId = 2, RoomName = "Room B" },
                new Room { RoomId = 3, RoomName = "Room C" },
                new Room { RoomId = 4, RoomName = "Room D" },
            };

            ViewData["PrintExportItems"] = new List<object>
            {
                new { text = "Print", id = "print" },
                new { text = "Export", id = "export" }
            };

            AllEventsFields = new TreeViewFieldsSettings
            {
                DataSource = AllEvents,
                Id = "Id",
                Text = "Subject"
            };
            CloudSecurityEventsFields = new TreeViewFieldsSettings
            {
                DataSource = CloudSecurityEvents,
                Id = "Id",
                Text = "Subject"
            };
            AIAutomationEventsFields = new TreeViewFieldsSettings
            {
                DataSource = CloudSecurityEvents,
                Id = "Id",
                Text = "Subject"
            };

        }
    }
}
