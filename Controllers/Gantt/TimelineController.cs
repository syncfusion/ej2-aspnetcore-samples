using System.Collections.Generic;
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Gantt
{
    public partial class GanttController : Controller
    {
        public IActionResult Timeline()
        {
            ViewBag.DataSource = GanttData.TimelineData();
            ViewBag.Resources = GanttData.TimelineResources();
            ViewBag.WeekFormat = DayFormat.GetWeekFormat();
            ViewBag.DayFormat = DayFormat.GetDayFormat();
            ViewBag.Units = TimelineUnit.GetUnits();
            return View();
        }

        public class DayFormat
        {
            public string Id { get; set; }
            public string Format { get; set; }


            public static List<DayFormat> GetWeekFormat()
            {
                List<DayFormat> formats = new List<DayFormat>();
                formats.Add(new DayFormat() { Id = "MMM dd, yyyy", Format = "Jan 01, 2019" });
                formats.Add(new DayFormat() { Id = "EEE MMM dd, 'yy", Format = "Mon Jan 01, '19" });
                formats.Add(new DayFormat() { Id = "EEE MMM dd", Format = "Mon Jan 01" });
                return formats;
            }

            public static List<DayFormat> GetDayFormat()
            {
                List<DayFormat> formats = new List<DayFormat>();
                formats.Add(new DayFormat() { Id = "EEE, dd", Format = "Mon, 01" });
                formats.Add(new DayFormat() { Id = "E", Format = "Mon" });
                formats.Add(new DayFormat() { Id = "dd", Format = "01" });
                return formats;
            }
        }

        public class TimelineUnit
        {
            public string Id { get; set; }
            public string Unit { get; set; }
            public static List<TimelineUnit> GetUnits()
            {
                List<TimelineUnit> units = new List<TimelineUnit>();
                units.Add(new TimelineUnit() { Id = "None", Unit = "None" });
                units.Add(new TimelineUnit() { Id = "Year", Unit = "Year" });
                units.Add(new TimelineUnit() { Id = "Month", Unit = "Month" });
                units.Add(new TimelineUnit() { Id = "Week", Unit = "Week" });
                units.Add(new TimelineUnit() { Id = "Day", Unit = "Day" });
                units.Add(new TimelineUnit() { Id = "Hour", Unit = "Hour" });
                return units;
            }
        }
    }
}