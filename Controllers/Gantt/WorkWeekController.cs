#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Gantt
{
    public partial class GanttController : Controller
    {
        public IActionResult WorkWeek()
        {
            ViewBag.dataSource = GanttData.ProjectNewData();
            ViewBag.workWeek = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            ViewBag.WorkingDays = GetDayOfWeek();
            return View();
        }
        public List<DropDownData> GetDayOfWeek()
        {
            List<DropDownData> dayOfWeek = new List<DropDownData>();
            dayOfWeek.Add(new DropDownData { id = "Sunday", day = "Sunday" });
            dayOfWeek.Add(new DropDownData { id = "Monday", day = "Monday" });
            dayOfWeek.Add(new DropDownData { id = "Tuesday", day = "Tuesday" });
            dayOfWeek.Add(new DropDownData { id = "Wednesday", day = "Wednesday" });
            dayOfWeek.Add(new DropDownData { id = "Thursday", day = "Thursday" });
            dayOfWeek.Add(new DropDownData { id = "Friday", day = "Friday" });
            dayOfWeek.Add(new DropDownData { id = "Saturday", day = "Saturday" });
            return dayOfWeek;
        }
    }
    public class DropDownData
    {
        public string id { get; set; }
        public string day { get; set; }
    }
}