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
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Controllers.ListView
{
    public partial class ListViewController : Controller
    {

        public IActionResult CallHistory()
        {
            List<object> listdata = new List<object>();
            listdata.Add(new { text = "Smith", id = "received-01", icon = "e-custom", type = "received", group = "Received", time = "2 hours ago", category = "Today" });
            listdata.Add(new { text = "Johnson", id = "received-02", icon = "e-custom", type = "received", group = "Received", time = "Yesterday", category = "Yesterday" });
            listdata.Add(new { text = "Williams", id = "missed-01", icon = "e-custom", type = "missed", group = "Missed", time = "4 hours ago", category = "Today" });
            listdata.Add(new { text = "Jones", id = "missed-02", icon = "e-custom", type = "missed", group = "Missed", time = "Yesterday", category = "Yesterday" });
            listdata.Add(new { text = "Brown", id = "received-03", icon = "e-custom", type = "received", group = "Received", time = "Yesterday", category = "Yesterday" });
            listdata.Add(new { text = "Anderson", id = "received-01", icon = "e-custom", type = "received", group = "Received", time = "12 hours ago", category = "Today" });
            listdata.Add(new { text = "Thomas", id = "received-02", icon = "e-custom", type = "received", group = "Received", time = "Yesterday", category = "Yesterday" });
            listdata.Add(new { text = "Jackson", id = "missed-01", icon = "e-custom", type = "missed", group = "Missed", time = "Yesterday", category = "Yesterday" });
            listdata.Add(new { text = "Emily", id = "missed-01", icon = "e-custom", type = "missed", group = "Missed", time = "14 hours ago", category = "Today" });
            listdata.Add(new { text = "White", id = "missed-02", icon = "e-custom", type = "missed", group = "Missed", time = "Yesterday", category = "Yesterday" });
            listdata.Add(new { text = "Jones", id = "missed-02", icon = "e-custom", type = "missed", group = "Missed", time = "18 hours ago", category = "Today" });
            listdata.Add(new { text = "Grace", id = "missed-02", icon = "e-custom", type = "missed", group = "Missed", time = "Yesterday", category = "Yesterday" });
            listdata.Add(new { text = "Brooklyn", id = "missed-02", icon = "e-custom", type = "missed", group = "Missed", time = "Yesterday", category = "Yesterday" });
            listdata.Add(new { text = "Arianna", id = "received-01", icon = "e-custom", type = "received", group = "Received", time = "Yesterday", category = "Yesterday" });
            listdata.Add(new { text = "Katherine", id = "received-02", icon = "e-custom", type = "received", group = "Received", time = "Yesterday", category = "Yesterday" });
            ViewBag.dataSource = listdata;
            ViewBag.headerText1 = new TabHeader  { Text = "All" };
            ViewBag.headerText2 = new TabHeader { Text = "Received" };
            ViewBag.headerText3 = new TabHeader { Text = "Missed" };
            return View();
        }
    }
}