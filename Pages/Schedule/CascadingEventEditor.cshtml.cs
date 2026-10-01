using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class CascadingEventEditor : PageModel
{
    public List<object> staffData = new List<object>();
    public List<object> eventsData = new List<object>();

    public void OnGet()
    {
        staffData.Add(new { id = 1, text = "Mike Anderson", color = "#1aaa55", type = "Consultants" });
        staffData.Add(new { id = 2, text = "Kevin Larson", color = "#357cd2", type = "Sales" });
        staffData.Add(new { id = 3, text = "Sarah Johnson", color = "#f57f17", type = "Sales" });
        staffData.Add(new { id = 4, text = "David Miller", color = "#7fa900", type = "Testers" });
        staffData.Add(new { id = 5, text = "Emma Wilson", color = "#df5286", type = "Testers" });

        eventsData.Add(new {
            Id = 1,
            Subject = "Meeting",
            Type = "Meeting",
            StartTime = new DateTime(2026, 5, 11, 9, 0, 0),
            EndTime = new DateTime(2026, 5, 11, 12, 0, 0),
            StaffId = 1,
            FloorId = 1,
            RoomId = 101
        });

        eventsData.Add(new {
            Id = 2,
            Subject = "Appointment",
            Type = "Appointment",
            StartTime = new DateTime(2026, 5, 11, 13, 0, 0),
            EndTime = new DateTime(2026, 5, 11, 14, 0, 0),
            StaffId = 2
        });

        eventsData.Add(new {
            Id = 3,
            Subject = "Internal Review",
            Type = "Internal",
            StartTime = new DateTime(2026, 5, 11, 10, 0, 0),
            EndTime = new DateTime(2026, 5, 11, 11, 0, 0),
            StaffId = 3
        });

        eventsData.Add(new {
            Id = 4,
            Subject = "Planning",
            Type = "Meeting",
            StartTime = new DateTime(2026, 5, 11, 15, 0, 0),
            EndTime = new DateTime(2026, 5, 11, 17, 0, 0),
            StaffId = 4,
            FloorId = 1,
            RoomId = 101
        });

        eventsData.Add(new {
            Id = 5,
            Subject = "Discussion",
            Type = "Meeting",
            StartTime = new DateTime(2026, 5, 11, 11, 0, 0),
            EndTime = new DateTime(2026, 5, 11, 12, 30, 0),
            StaffId = 5,
            FloorId = 2,
            RoomId = 201
        });

        eventsData.Add(new {
            Id = 6,
            Subject = "Morning Sync",
            Type = "Meeting",
            StartTime = new DateTime(2026, 5, 11, 8, 0, 0),
            EndTime = new DateTime(2026, 5, 11, 9, 0, 0),
            StaffId = 1,
            FloorId = 1,
            RoomId = 101
        });

        eventsData.Add(new {
            Id = 7,
            Subject = "Follow-up Call",
            Type = "Appointment",
            StartTime = new DateTime(2026, 5, 11, 12, 0, 0),
            EndTime = new DateTime(2026, 5, 11, 13, 0, 0),
            StaffId = 1
        });

        eventsData.Add(new {
            Id = 8,
            Subject = "Client Discussion",
            Type = "Appointment",
            StartTime = new DateTime(2026, 5, 11, 10, 0, 0),
            EndTime = new DateTime(2026, 5, 11, 11, 0, 0),
            StaffId = 2
        });

        eventsData.Add(new {
            Id = 9,
            Subject = "Demo Presentation",
            Type = "Meeting",
            StartTime = new DateTime(2026, 5, 11, 14, 0, 0),
            EndTime = new DateTime(2026, 5, 11, 15, 0, 0),
            StaffId = 2,
            FloorId = 1,
            RoomId = 102
        });

        eventsData.Add(new {
            Id = 10,
            Subject = "Code Refactoring",
            Type = "Internal",
            StartTime = new DateTime(2026, 5, 11, 8, 30, 0),
            EndTime = new DateTime(2026, 5, 11, 9, 30, 0),
            StaffId = 3
        });

        eventsData.Add(new {
            Id = 11,
            Subject = "System Testing",
            Type = "Internal",
            StartTime = new DateTime(2026, 5, 11, 11, 0, 0),
            EndTime = new DateTime(2026, 5, 11, 12, 0, 0),
            StaffId = 3
        });

        eventsData.Add(new {
            Id = 12,
            Subject = "Project Review",
            Type = "Meeting",
            StartTime = new DateTime(2026, 5, 11, 13, 0, 0),
            EndTime = new DateTime(2026, 5, 11, 14, 0, 0),
            StaffId = 4,
            FloorId = 1,
            RoomId = 101
        });

        eventsData.Add(new {
            Id = 13,
            Subject = "Wrap-up Meeting",
            Type = "Meeting",
            StartTime = new DateTime(2026, 5, 11, 17, 0, 0),
            EndTime = new DateTime(2026, 5, 11, 18, 0, 0),
            StaffId = 4,
            FloorId = 1,
            RoomId = 101
        });

        eventsData.Add(new {
            Id = 14,
            Subject = "Bug Fixing",
            Type = "Internal",
            StartTime = new DateTime(2026, 5, 11, 9, 0, 0),
            EndTime = new DateTime(2026, 5, 11, 10, 30, 0),
            StaffId = 5
        });

        eventsData.Add(new {
            Id = 15,
            Subject = "QA Review",
            Type = "Internal",
            StartTime = new DateTime(2026, 5, 11, 13, 0, 0),
            EndTime = new DateTime(2026, 5, 11, 14, 0, 0),
            StaffId = 5
        });
    }
}