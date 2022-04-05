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
        public IActionResult DragDrop()
        {
            List<object> productTeam1 = new List<object>();
            productTeam1.Add(new
            {
                id = "t1",
                name = "ASP.NET MVC Team",
                hasChild = true,
                expanded = true
            });
            productTeam1.Add(new
            {
                id = "t2",
                pid = "t1",
                name = "Smith",
            });
            productTeam1.Add(new
            {
                id = "t3",
                pid = "t1",
                name = "Johnson"
            });

            productTeam1.Add(new
            {
                id = "t4",
                pid = "t1",
                name = "Anderson",
            });
            productTeam1.Add(new
            {
                id = "t6",
                hasChild = true,
                name = "Windows Team",
                expanded = true

            });
            productTeam1.Add(new
            {
                id = "t7",
                pid="t6",
                name="Clark"
                
            });
            productTeam1.Add(new
            {
                id = "t8",
                pid = "t6",
                name = "Wright"
            });
            productTeam1.Add(new
            {
                id = "t9",
                pid = "t6",
                name = "Lopez",
            });

            ViewBag.dataSource = productTeam1;

            List<object> productTeam2 = new List<object>();
            productTeam2.Add(new
            {
                id = "t10",
                hasChild = true,
                name = "Web Team",
                expanded=true

            });
            productTeam2.Add(new
            {
                id = "t11",
                pid="t10",
                name = "Joshua",
               
            });
            productTeam2.Add(new
            {
                id = "t12",
                pid = "t10",
                name = "Matthew"
            });
            productTeam2.Add(new
            {
                id = "t13",
                pid = "t10",
                name = "David"
            });
            productTeam2.Add(new
            {
                id = "t14",
                hasChild = true,
                name = "Build Team",
                expanded = true
            });
            productTeam2.Add(new
            {
                id = "t15",
                pid = "t14",
                name = "Ryan"
            });
            productTeam2.Add(new
            {
                id = "t16",
                pid="t14",
                name = "Justin",
            });
            productTeam2.Add(new
            {
                id = "t17",
                pid = "t14",
                name = "Robert"
            });

            ViewBag.data = productTeam2;
            return View();
        }
    }
}