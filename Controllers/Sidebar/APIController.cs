#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class SidebarController : Controller
    {
        // GET: /<controller>/
        public IActionResult API()
        {
            List<object> dataList = new List<object>();
            dataList.Add(new { Type = "Over", value = "Over" });
            dataList.Add(new { Type = "Push", value = "Push" });
            dataList.Add(new { Type = "Slide", value = "Slide" });
            dataList.Add(new { Type = "Auto", value = "Auto" });
            Dictionary<string, object> HtmlAttribute = new Dictionary<string, object>()
            {   {"class", "default-sidebar" } };
            ViewBag.HtmlAttribute = HtmlAttribute;
            ViewBag.Types = dataList;
            return View();
        }

    }
}
