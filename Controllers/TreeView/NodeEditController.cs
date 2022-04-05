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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.TreeView
{
    public partial class TreeViewController : Controller
    {

        public IActionResult NodeEdit()
        {
            List<object> treedata = new List<object>();
            treedata.Add(new
            {
                id = 1,
                name = "Discover Music",
                hasChild = true,
                expanded = true
            });
            treedata.Add(new
            {
                id = 2,
                pid = 1,
                name = "Hot Singles",

            });
            treedata.Add(new
            {
                id = 3,
                pid = 1,
                name = "Rising Artists"
            });

            treedata.Add(new
            {
                id = 4,
                pid = 1,
                name = "Live Music"
            });
            treedata.Add(new
            {
                id = 5,
                hasChild = true,
                name = "Sales and Events",

            });
            treedata.Add(new
            {
                id = 6,
               pid=5,
                name = "100 Albums - $5 Each",
            });
            treedata.Add(new
            {
                id = 7,
                pid = 5,
                name = "Hip-Hop and R&B Sale"
            });
            treedata.Add(new
            {
                id = 8,
                pid = 5,
                name = "CD Deals"
            });
            treedata.Add(new
            {
                id = 10,
                hasChild = true,
                name = "Categories"
            });
            treedata.Add(new
            {
                id = 11,
                pid=10,
                name = "Bestselling Albums",
               
            });
            treedata.Add(new
            {
                id = 12,
                pid = 10,
                name = "New Releases"
            });
            treedata.Add(new
            {
                id = 13,
                pid = 10,
                name = "Bestselling Songs"
            });
            treedata.Add(new
            {
                id = 14,
                hasChild = true,
                name = "MP3 Albums"
            });
            treedata.Add(new
            {
                id = 15,
                pid = 14,
                name = "Rock"

            });
            treedata.Add(new
            {
                id = 16,
                name = "Gospel",
                pid = 14,

            });
            treedata.Add(new
            {
                id = 17,
                pid = 14,
                name = "Latin Music"

            });
            treedata.Add(new
            {
                id = 18,
                pid = 14,
                name = "Jazz"

            });
            treedata.Add(new
            {
                id = 19,
                hasChild = true,
                name = "More in Music"

            });
            treedata.Add(new
            {
                id = 20,
                pid = 19,
                name = "Music Trade-In"
            });
            treedata.Add(new
            {
                id = 21,
                name = "Redeem a Gift Card",
                pid = 19
            });
            treedata.Add(new
            {
                id = 22,
                pid = 19,
                name = "Band T-Shirts"

            });
          

            ViewBag.dataSource = treedata;
            return View();
        }
    }
}