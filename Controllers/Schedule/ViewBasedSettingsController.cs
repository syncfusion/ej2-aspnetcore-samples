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

        public IActionResult ViewBasedSettings()
        {
            ViewBag.appointments = new ScheduleData().GetFifaEventsData();

            List<ResourceFields> Resources = new List<ResourceFields>();
            Resources.Add(new ResourceFields { GroupText = "Group A", GroupId = 1, GroupColor = "#1aaa55" });
            Resources.Add(new ResourceFields { GroupText = "Group B", GroupId = 2, GroupColor = "#357cd2" });

            ViewBag.resourceData = Resources;
            return View();
        }
    }
    public class ResourceFields
    {
        public string GroupText { set; get; }
        public int GroupId { set; get; }
        public string GroupColor { set; get; }
    }
}
