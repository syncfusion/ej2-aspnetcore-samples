#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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

        public IActionResult WorkDays()
        {
            ViewBag.appointments = new ScheduleData().GetEmployeeEventData();
            ViewBag.workDaysdata = GetWorkDays();
            ViewBag.dayOfWeek = GetDayOfWeek();
            ViewBag.workDays = new int[] { 1, 3, 5 };
            return View();
        }
        public List<DropDownData> GetWorkDays()
        {
            List<DropDownData> workDays = new List<DropDownData>();
            workDays.Add(new DropDownData { Name = "Mon, Wed, Fri", Value = "1,3,5" });
            workDays.Add(new DropDownData { Name = "Mon, Tue, Wed, Thu, Fri", Value = "1,2,3,4,5" });
            workDays.Add(new DropDownData { Name = "Tue, Wed, Thu, Fri", Value = "2,3,4,5" });
            workDays.Add(new DropDownData { Name = "Thu, Fri, Sat, Mon, Tue", Value = "4,5,6,1,2" });
            return workDays;
        }

        public List<DropDownData> GetDayOfWeek()
        {
            List<DropDownData> dayOfWeek = new List<DropDownData>();
            dayOfWeek.Add(new DropDownData { Name = "Sunday", Value = "0" });
            dayOfWeek.Add(new DropDownData { Name = "Monday", Value = "1" });
            dayOfWeek.Add(new DropDownData { Name = "Tuesday", Value = "2" });
            dayOfWeek.Add(new DropDownData { Name = "Wednesday", Value = "3" });
            dayOfWeek.Add(new DropDownData { Name = "Thursday", Value = "4" });
            dayOfWeek.Add(new DropDownData { Name = "Friday", Value = "5" });
            dayOfWeek.Add(new DropDownData { Name = "Saturday", Value = "6" });
            return dayOfWeek;
        }
    }
    public class DropDownData
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
