#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class TimeScale : PageModel
{
    public List<TimeScaleDropDownModel> intervals = new List<TimeScaleDropDownModel>();
    public List<TimeScaleDropDownModel> slots = new List<TimeScaleDropDownModel>();
    public List<TimeScaleDropDownModel> options = new List<TimeScaleDropDownModel>();
    public List<TimeScaleDropDownModel> timescaleoptions = new List<TimeScaleDropDownModel>();
    public void OnGet()
    {
        intervals.Add(new TimeScaleDropDownModel { Text = "30", Value = "30" });
        intervals.Add(new TimeScaleDropDownModel { Text = "60", Value = "60" });
        intervals.Add(new TimeScaleDropDownModel { Text = "90", Value = "90" });
        intervals.Add(new TimeScaleDropDownModel { Text = "120", Value = "120" });
        intervals.Add(new TimeScaleDropDownModel { Text = "150", Value = "150" });
        intervals.Add(new TimeScaleDropDownModel { Text = "180", Value = "180" });
        intervals.Add(new TimeScaleDropDownModel { Text = "240", Value = "240" });
        intervals.Add(new TimeScaleDropDownModel { Text = "300", Value = "300" });
        intervals.Add(new TimeScaleDropDownModel { Text = "720", Value = "720" });
        
        slots.Add(new TimeScaleDropDownModel { Text = "1", Value = "1" });
        slots.Add(new TimeScaleDropDownModel { Text = "2", Value = "2" });
        slots.Add(new TimeScaleDropDownModel { Text = "3", Value = "3" });
        slots.Add(new TimeScaleDropDownModel { Text = "4", Value = "4" });
        slots.Add(new TimeScaleDropDownModel { Text = "5", Value = "5" });
        slots.Add(new TimeScaleDropDownModel { Text = "6", Value = "6" });
        
        options.Add(new TimeScaleDropDownModel { Text = "Show", Value = "enable" });
        options.Add(new TimeScaleDropDownModel { Text = "Hide", Value = "disable" });
        
        timescaleoptions.Add(new TimeScaleDropDownModel { Text = "Yes", Value = "yes" });
        timescaleoptions.Add(new TimeScaleDropDownModel { Text = "No", Value = "no" });
    }
}
public class TimeScaleDropDownModel
{
    public string Text { get; set; }
    public string Value { get; set; }
}