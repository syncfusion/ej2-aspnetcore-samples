#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class GroupCustomWorkdays : PageModel
{
    public List<DoctorRes> doctors = new List<DoctorRes>();
    public void OnGet()
    {
        doctors.Add(new DoctorRes { text = "Will Smith", id = 1, color = "#ea7a57", workDays = new List<int> { 1, 2, 4, 5 }, startHour = "08:00", endHour = "15:00" });
        doctors.Add(new DoctorRes { text = "Alice", id = 2, color = "rgb(53, 124, 210)", workDays = new List<int> { 1, 3, 5 }, startHour = "08:00", endHour = "17:00" });
        doctors.Add(new DoctorRes { text = "Robson", id = 3, color = "#7fa900", startHour = "08:00", endHour = "16:00" });
    }
}

public class DoctorRes
{
    public string text { set; get; }
    public int id { set; get; }
    public string color { set; get; }
    public List<int> workDays { set; get; }
    public string startHour { set; get; }
    public string endHour { set; get; }
}