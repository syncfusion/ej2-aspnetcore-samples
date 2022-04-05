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
using Syncfusion.EJ2.Buttons;

namespace EJ2CoreSampleBrowser.Controllers.Button
{
    public partial class ButtonController : Controller
    {
        public IActionResult DropdownButton()
        {
            List<object> items = new List<object>();
            items.Add(new
            {
                text = "Dashboard",
                iconCss = "e-ddb-icons e-dashboard"
            });
            items.Add(new
            {
                text = "Notifications",
                iconCss = "e-ddb-icons e-notifications"
            });
            items.Add(new
            {
                text = "User Settings",
                iconCss = "e-ddb-icons e-settings"
            });
            items.Add(new
            {
                text = "Log Out",
                iconCss = "e-ddb-icons e-logout"
            });
            ViewBag.items = items;
            return View();
        }
    }
}