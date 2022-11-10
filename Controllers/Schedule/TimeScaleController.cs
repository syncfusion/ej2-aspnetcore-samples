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
        public IActionResult TimeScale()
        {
            ViewBag.datasource = new ScheduleData().GetScheduleData();
            ViewBag.workDays = new int[] { 0, 1, 2, 3, 4, 5 };
            ViewBag.intervals = GetIntervalData();
            ViewBag.slotCounts = GetSlotCounts();
            ViewBag.timeScaleOptions = GetTimeScaleOptions();
            ViewBag.timeScaleTemplateOptions = GetTimeScaleTemplateOptions();
            return View();
        }
        public List<TimeScaleDropDownModel> GetIntervalData()
        {
            List<TimeScaleDropDownModel> intervals = new List<TimeScaleDropDownModel>();
            intervals.Add(new TimeScaleDropDownModel { Text = "30", Value = "30" });
            intervals.Add(new TimeScaleDropDownModel { Text = "60", Value = "60" });
            intervals.Add(new TimeScaleDropDownModel { Text = "90", Value = "90" });
            intervals.Add(new TimeScaleDropDownModel { Text = "120", Value = "120" });
            intervals.Add(new TimeScaleDropDownModel { Text = "150", Value = "150" });
            intervals.Add(new TimeScaleDropDownModel { Text = "180", Value = "180" });
            intervals.Add(new TimeScaleDropDownModel { Text = "240", Value = "240" });
            intervals.Add(new TimeScaleDropDownModel { Text = "300", Value = "300" });
            intervals.Add(new TimeScaleDropDownModel { Text = "720", Value = "720" });
            return intervals;
        }
        public List<TimeScaleDropDownModel> GetSlotCounts()
        {
            List<TimeScaleDropDownModel> slots = new List<TimeScaleDropDownModel>();
            slots.Add(new TimeScaleDropDownModel { Text = "1", Value = "1" });
            slots.Add(new TimeScaleDropDownModel { Text = "2", Value = "2" });
            slots.Add(new TimeScaleDropDownModel { Text = "3", Value = "3" });
            slots.Add(new TimeScaleDropDownModel { Text = "4", Value = "4" });
            slots.Add(new TimeScaleDropDownModel { Text = "5", Value = "5" });
            slots.Add(new TimeScaleDropDownModel { Text = "6", Value = "6" });
            return slots;
        }

        public List<TimeScaleDropDownModel> GetTimeScaleOptions()
        {
            List<TimeScaleDropDownModel> options = new List<TimeScaleDropDownModel>();
            options.Add(new TimeScaleDropDownModel { Text = "Show", Value = "enable" });
            options.Add(new TimeScaleDropDownModel { Text = "Hide", Value = "disable" });
            return options;
        }

        public List<TimeScaleDropDownModel> GetTimeScaleTemplateOptions()
        {
            List<TimeScaleDropDownModel> options = new List<TimeScaleDropDownModel>();
            options.Add(new TimeScaleDropDownModel { Text = "Yes", Value = "yes" });
            options.Add(new TimeScaleDropDownModel { Text = "No", Value = "no" });
            return options;
        }
    }
    public class TimeScaleDropDownModel
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
