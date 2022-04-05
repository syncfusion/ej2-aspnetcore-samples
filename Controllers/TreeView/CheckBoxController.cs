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

        public IActionResult CheckBox()
        {
            List<object> treedata = new List<object>();
            treedata.Add(new
            {
                id = 1,
                name = "Australia",
                hasChild = true,
                expanded = true
            });
            treedata.Add(new
            {
                id = 2,
                pid = 1,
                name = "New South Wales",

            });
            treedata.Add(new
            {
                id = 3,
                pid = 1,
                name = "Victoria"
            });

            treedata.Add(new
            {
                id = 4,
                pid = 1,
                name = "South Australia"
            });
            treedata.Add(new
            {
                id = 6,
                pid = 1,
                name = "Western Australia",

            });
            treedata.Add(new
            {
                id = 7,
                name = "Brazil",
                hasChild = true
            });
            treedata.Add(new
            {
                id = 8,
                pid = 7,
                name = "Paraná"
            });
            treedata.Add(new
            {
                id = 9,
                pid = 7,
                name = "Ceará"
            });
            treedata.Add(new
            {
                id = 10,
                pid = 7,
                name = "Acre"
            });
            treedata.Add(new
            {
                id = 11,
                name = "China",
                hasChild = true
            });
            treedata.Add(new
            {
                id = 12,
                pid = 11,
                name = "Guangzhou"
            });
            treedata.Add(new
            {
                id = 13,
                pid = 11,
                name = "Shanghai"
            });
            treedata.Add(new
            {
                id = 14,
                pid = 11,
                name = "Beijing"
            });
            treedata.Add(new
            {
                id = 15,
                pid = 11,
                name = "Shantou"

            });
            treedata.Add(new
            {
                id = 16,
                name = "France",
                hasChild = true

            });
            treedata.Add(new
            {
                id = 17,
                pid = 16,
                name = "Pays de la Loire"

            });
            treedata.Add(new
            {
                id = 18,
                pid = 16,
                name = "Aquitaine"

            });
            treedata.Add(new
            {
                id = 19,
                pid = 16,
                name = "Brittany"

            });
            treedata.Add(new
            {
                id = 20,
                pid = 16,
                name = "Lorraine"
            });
            treedata.Add(new
            {
                id = 21,
                name = "India",
                hasChild = true

            });
            treedata.Add(new
            {
                id = 22,
                pid = 21,
                name = "Assam"

            });
            treedata.Add(new
            {
                id = 23,
                pid = 21,
                name = "Bihar"
            });
            treedata.Add(new
            {
                id = 24,
                pid = 21,
                name = "Tamil Nadu"

            });
            ViewBag.dataSource = treedata;
            return View();
        }
    }
}