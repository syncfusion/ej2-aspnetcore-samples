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

        public IActionResult Views()
        {
            ViewBag.appointments = new ScheduleData().GetZooEventData();
            ViewBag.data = GetViewData();
            return View();
        }

        public List<ViewData> GetViewData()
        {
            List<ViewData> view = new List<ViewData>();
            view.Add(new ViewData { Name = "Day", Value = "Day" });
            view.Add(new ViewData { Name = "Week", Value = "Week" });
            view.Add(new ViewData { Name = "Work Week", Value = "WorkWeek" });
            view.Add(new ViewData { Name = "Month", Value = "Month" });
            return view;
        }
    }

    public class ViewData
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
