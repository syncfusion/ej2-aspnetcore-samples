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
        public IActionResult Resource()
        {
            List<OwnerRes> ownerCollections = new List<OwnerRes>();
            ownerCollections.Add(new OwnerRes { OwnerText= "Margaret", OwnerId= 1, Color= "#ea7a57" });
            ownerCollections.Add(new OwnerRes { OwnerText= "Robert", OwnerId= 2, Color= "#df5286" });
            ownerCollections.Add(new OwnerRes { OwnerText= "Laura", OwnerId= 3, Color= "#865fcf" });
            ViewBag.Owners = ownerCollections;

            ViewBag.datasource = new ScheduleData().GetResourceSampleData();
            return View();
        }
        public class OwnerRes
        {
            public string OwnerText { set; get; }
            public int OwnerId { set; get; }
            public string Color { set; get; }
        }
    }
}