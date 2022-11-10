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
        public IActionResult GroupByDate()
        {
            ViewBag.datasource = new ScheduleData().GetResourceData();

            List<ResourceDataSourceModel> owners = new List<ResourceDataSourceModel>();
            owners.Add(new ResourceDataSourceModel { text = "Alice", id = 1, color = "#df5286" });
            owners.Add(new ResourceDataSourceModel { text = "Smith", id = 2, color = "#7fa900" });
            ViewBag.Owners = owners;

            string[] resources = new string[] { "Owners" };
            ViewBag.Resources = resources;
            return View();
        }
    }
}
