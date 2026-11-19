using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EJ2CoreSampleBrowser.Pages.Schedule
{
    public class EventBufferModel : PageModel
    {
        public List<OperatingRoomData> RoomData { get; set; }

        public List<SurgeryEventData> Events { get; set; }
        private static List<SurgeryEventData> eventCache;

        public void OnGet()
        {
            RoomData = new List<OperatingRoomData>()
            {
                new OperatingRoomData
                {
                    RoomId = 1,
                    RoomText = "Cardiac Surgery Suite",
                    Specialty = "Cardiology",
                    RoomColor = "#ef4444",
                    Icon = "❤️"
                },

                new OperatingRoomData
                {
                    RoomId = 2,
                    RoomText = "Orthopedic Center",
                    Specialty = "Orthopedics",
                    RoomColor = "#2563eb",
                    Icon = "🦴"
                },

                new OperatingRoomData
                {
                    RoomId = 3,
                    RoomText = "Neuroscience Unit",
                    Specialty = "Neurology",
                    RoomColor = "#8b5cf6",
                    Icon = "🧠"
                },

                new OperatingRoomData
                {
                    RoomId = 4,
                    RoomText = "Pediatric Care Suite",
                    Specialty = "Pediatrics",
                    RoomColor = "#10b981",
                    Icon = "👶"
                },

                new OperatingRoomData
                {
                    RoomId = 5,
                    RoomText = "Emergency Trauma Bay",
                    Specialty = "Emergency",
                    RoomColor = "#f97316",
                    Icon = "🚑"
                },

                new OperatingRoomData
                {
                    RoomId = 6,
                    RoomText = "Diagnostic Imaging Center",
                    Specialty = "Radiology",
                    RoomColor = "#0ea5e9",
                    Icon = "🔬"
                }
            };

            if (eventCache == null)
            {
                eventCache = GenerateAllEvents(
                    new DateTime(2026, 1, 12)
                );
            }

            Events = eventCache;
        }

        private List<SurgeryEventData> GenerateEvents(DateTime date)
        {
            var events = new List<SurgeryEventData>();
            var subjects = new Dictionary<string, string[]>
            {
                { "Cardiology", new[] { "Cardiac Workup", "Heart Valve Assessment", "Stress Test", "ECG Review" } },
                { "Orthopedics", new[] { "Knee Replacement", "Bone Fracture Assessment", "Spinal Workup" } },
                { "Neurology", new[] { "Neurology Workup", "Brain MRI Review" } },
                { "Pediatrics", new[] { "Child Wellness Review", "Immunization Follow-up" } },
                { "Emergency", new[] { "Emergency Care", "Acute Care", "Trauma Care", "Critical Care" } },
                { "Radiology", new[] { "CT Scan Analysis", "MRI Scan Review" } }
            };
            var random = new Random();
            int id = date.Day * 100;

            var startPatterns = new[]
            {
                new { Hour = 9, Minute = 0 },
                new { Hour = 9, Minute = 15 },
                new { Hour = 9, Minute = 30 },
                new { Hour = 9, Minute = 45 }
            };

            var secondPatterns = new[]
            {
                new { Hour = 11, Minute = 0 },
                new { Hour = 11, Minute = 15 },
                new { Hour = 11, Minute = 30 },
                new { Hour = 11, Minute = 45 }
            };

            foreach (var room in RoomData)
            {
                SurgeryEventData CreateEvent(int hour, int minute)
                {
                    int duration = random.Next(2) == 0 ? 75 : 90;

                    int bufferBefore = new[] { 30, 45, 60 }[random.Next(3)];
                    int bufferAfter = new[] { 30, 45, 60 }[random.Next(3)];

                    DateTime startTime = new DateTime(
                        date.Year,
                        date.Month,
                        date.Day,
                        hour,
                        minute,
                        0);

                    var roomSubjects = subjects[room.Specialty];
                    var subject =
                        roomSubjects[random.Next(roomSubjects.Length)];

                    return new SurgeryEventData
                    {
                        Id = id++,
                        Subject = subject,
                        StartTime = startTime,
                        EndTime = startTime.AddMinutes(duration),
                        RoomId = room.RoomId,
                        RequiredSkill = room.Specialty,
                        BufferBefore = bufferBefore,
                        BufferAfter = bufferAfter
                    };
                }

                var first = startPatterns[random.Next(startPatterns.Length)];
                var second = secondPatterns[random.Next(secondPatterns.Length)];

                events.Add(CreateEvent(first.Hour, first.Minute));
                events.Add(CreateEvent(second.Hour, second.Minute));
            }

            return events;
        }
        private List<SurgeryEventData> GenerateAllEvents(DateTime selectedDate)
        {
            return GenerateEvents(selectedDate.AddDays(-1))
                .Concat(GenerateEvents(selectedDate))
                .Concat(GenerateEvents(selectedDate.AddDays(1)))
                .ToList();
        }
    }

    public class OperatingRoomData
    {
        public int RoomId { get; set; }

        public string RoomText { get; set; }

        public string Specialty { get; set; }

        public string RoomColor { get; set; }

        public string Icon { get; set; }
    }

    public class SurgeryEventData
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int RoomId { get; set; }

        public string RequiredSkill { get; set; }

        public int BufferBefore { get; set; }

        public int BufferAfter { get; set; }
    }
}