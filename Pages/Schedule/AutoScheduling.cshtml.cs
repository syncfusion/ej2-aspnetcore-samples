#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
#endregion

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class AutoScheduling : PageModel
{
    public List<AutoStaffResource> ResourceData { get; set; } = new();
    public List<AutoSchedulingGridData> GridData { get; set; } = new();
    public List<AutoSchedulingEvent> EventData { get; set; } = new();

    public void OnGet()
    {
        LoadResources();
        LoadGridData();
        LoadEvents();
    }

    private void LoadResources()
    {
        ResourceData = new List<AutoStaffResource>()
        {
            new AutoStaffResource
            {
                text = "Smith",
                id = 1,
                color = "#df5286",
                group = "Doctor",
                skills = new List<string>{ "Cardiology", "General" }
            },
            new AutoStaffResource
            {
                text = "Lee",
                id = 2,
                color = "#7fa900",
                group = "Doctor",
                skills = new List<string>{ "Pediatrics", "General" }
            },
            new AutoStaffResource
            {
                text = "Patel",
                id = 3,
                color = "#ea7a57",
                group = "Doctor",
                skills = new List<string>{ "Surgery", "General" }
            },
            new AutoStaffResource
            {
                text = "Amy",
                id = 4,
                color = "#007bff",
                group = "Nurse",
                skills = new List<string>{ "ICU", "Ward" }
            },
            new AutoStaffResource
            {
                text = "John",
                id = 5,
                color = "#00bdae",
                group = "Nurse",
                skills = new List<string>{ "ER", "Ward" }
            },
            new AutoStaffResource
            {
                text = "Sara",
                id = 6,
                color = "#f57b42",
                group = "Nurse",
                skills = new List<string>{ "ICU", "ER" }
            }
        };
    }

    private void LoadGridData()
    {
        GridData = new List<AutoSchedulingGridData>()
        {
            new AutoSchedulingGridData
            {
                Id = 101,
                Task = "Cardiology Consultation",
                Duration = "2 Hours",
                RequiredSkill = "Cardiology"
            },
            new AutoSchedulingGridData
            {
                Id = 102,
                Task = "Pediatric Health Assessment",
                Duration = "1 Hour",
                RequiredSkill = "Pediatrics"
            },
            new AutoSchedulingGridData
            {
                Id = 103,
                Task = "Pre-Surgical Evaluation",
                Duration = "3 Hours",
                RequiredSkill = "Surgery"
            },
            new AutoSchedulingGridData
            {
                Id = 104,
                Task = "Critical Care Monitoring",
                Duration = "2 Hours",
                RequiredSkill = "ICU"
            },
            new AutoSchedulingGridData
            {
                Id = 105,
                Task = "Emergency Patient Intake",
                Duration = "1 Hour",
                RequiredSkill = "ER"
            },
            new AutoSchedulingGridData
            {
                Id = 106,
                Task = "Inpatient Care Management",
                Duration = "2 Hours",
                RequiredSkill = "Ward"
            },
            new AutoSchedulingGridData
            {
                Id = 107,
                Task = "General Medical Examination",
                Duration = "1 Hour",
                RequiredSkill = "General"
            },
            new AutoSchedulingGridData
            {
                Id = 108,
                Task = "Emergency Case Assessment",
                Duration = "1 Hour",
                RequiredSkill = "ER"
            }
        };
    }

    private void LoadEvents()
    {
        var today = DateTime.Today;

        EventData = new List<AutoSchedulingEvent>()
        {
            new AutoSchedulingEvent
            {
                Id = 1,
                Subject = "Cardiac Checkup - Mr. Johnson",
                StartTime = new DateTime(today.Year, today.Month, today.Day, 9, 0, 0),
                EndTime = new DateTime(today.Year, today.Month, today.Day, 11, 30, 0),
                IsAllDay = false,
                StaffId = 1,
                RequiredSkill = "Cardiology"
            },
            new AutoSchedulingEvent
            {
                Id = 2,
                Subject = "Consultation - ECG Review",
                StartTime = new DateTime(today.Year, today.Month, today.Day, 12, 0, 0),
                EndTime = new DateTime(today.Year, today.Month, today.Day, 14, 0, 0),
                IsAllDay = false,
                StaffId = 1,
                RequiredSkill = "Cardiology"
            },
            new AutoSchedulingEvent
            {
                Id = 3,
                Subject = "Child Wellness Exam - Emma",
                StartTime = new DateTime(today.Year, today.Month, today.Day, 9, 0, 0),
                EndTime = new DateTime(today.Year, today.Month, today.Day, 11, 0, 0),
                IsAllDay = false,
                StaffId = 2,
                RequiredSkill = "Pediatrics"
            },
            new AutoSchedulingEvent
            {
                Id = 4,
                Subject = "Vaccination Clinic",
                StartTime = new DateTime(today.Year, today.Month, today.Day, 11, 30, 0),
                EndTime = new DateTime(today.Year, today.Month, today.Day, 13, 0, 0),
                IsAllDay = false,
                StaffId = 2,
                RequiredSkill = "General"
            },
            new AutoSchedulingEvent
            {
                Id = 5,
                Subject = "Pre-Op Assessment",
                StartTime = new DateTime(today.Year, today.Month, today.Day, 9, 0, 0),
                EndTime = new DateTime(today.Year, today.Month, today.Day, 10, 30, 0),
                IsAllDay = false,
                StaffId = 3,
                RequiredSkill = "Surgery"
            },
            new AutoSchedulingEvent
            {
                Id = 6,
                Subject = "Surgical Consultation - Mrs. Smith",
                StartTime = new DateTime(today.Year, today.Month, today.Day, 11, 0, 0),
                EndTime = new DateTime(today.Year, today.Month, today.Day, 13, 30, 0),
                IsAllDay = false,
                StaffId = 3,
                RequiredSkill = "Surgery"
            },
            new AutoSchedulingEvent
            {
                Id = 7,
                Subject = "ICU Patient Monitoring",
                StartTime = new DateTime(today.Year, today.Month, today.Day, 9, 30, 0),
                EndTime = new DateTime(today.Year, today.Month, today.Day, 12, 30, 0),
                IsAllDay = false,
                StaffId = 4,
                RequiredSkill = "ICU"
            },
            new AutoSchedulingEvent
            {
                Id = 8,
                Subject = "Vitals Check - ICU Ward",
                StartTime = new DateTime(today.Year, today.Month, today.Day, 13, 0, 0),
                EndTime = new DateTime(today.Year, today.Month, today.Day, 14, 0, 0),
                IsAllDay = false,
                StaffId = 4,
                RequiredSkill = "Ward"
            },
            new AutoSchedulingEvent
            {
                Id = 9,
                Subject = "ER Triage - Patient Intake",
                StartTime = new DateTime(today.Year, today.Month, today.Day, 9, 0, 0),
                EndTime = new DateTime(today.Year, today.Month, today.Day, 11, 0, 0),
                IsAllDay = false,
                StaffId = 5,
                RequiredSkill = "ER"
            },
            new AutoSchedulingEvent
            {
                Id = 10,
                Subject = "Emergency Response Team",
                StartTime = new DateTime(today.Year, today.Month, today.Day, 15, 30, 0),
                EndTime = new DateTime(today.Year, today.Month, today.Day, 17, 0, 0),
                IsAllDay = false,
                StaffId = 5,
                RequiredSkill = "ER"
            },
            new AutoSchedulingEvent
            {
                Id = 11,
                Subject = "ICU Support & Monitoring",
                StartTime = new DateTime(today.Year, today.Month, today.Day, 11, 0, 0),
                EndTime = new DateTime(today.Year, today.Month, today.Day, 13, 0, 0),
                IsAllDay = false,
                StaffId = 6,
                RequiredSkill = "ICU"
            },
            new AutoSchedulingEvent
            {
                Id = 12,
                Subject = "ER Support - Critical Care",
                StartTime = new DateTime(today.Year, today.Month, today.Day, 16, 0, 0),
                EndTime = new DateTime(today.Year, today.Month, today.Day, 17, 30, 0),
                IsAllDay = false,
                StaffId = 6,
                RequiredSkill = "ER"
            }
        };
    }
}


public class AutoStaffResource
{
    public string text { get; set; }
    public int id { get; set; }
    public string color { get; set; }
    public string group { get; set; }
    public List<string> skills { get; set; }
}

public class AutoSchedulingGridData
{
    public int Id { get; set; }
    public string Task { get; set; }
    public string Duration { get; set; }
    public string RequiredSkill { get; set; }
}

public class AutoSchedulingEvent
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAllDay { get; set; }
    public int StaffId { get; set; }
    public string RequiredSkill { get; set; }
}