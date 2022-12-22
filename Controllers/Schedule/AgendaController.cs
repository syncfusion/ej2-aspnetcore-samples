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

        public IActionResult Agenda()
        {
            ViewBag.appointments = new ScheduleData().GetFifaEventsData();
            ViewBag.data = GetScrollData();
            return View();
        }
        public List<ScrollData> GetScrollData()
        {
            List<ScrollData> view = new List<ScrollData>();
            view.Add(new ScrollData { Name = "False", Value = "false" });
            view.Add(new ScrollData { Name = "True", Value = "true" });
            return view;
        }
    }
    public class ScrollData
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
