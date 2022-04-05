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
using EJ2CoreSampleBrowser.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.ListBox
{
    public partial class ListBoxController : Controller
    {
        // GET: /<controller>/
        public ActionResult Api()
        {

            ViewBag.vegetableData = new Vegetables().VegetablesList();

            List<object> sortOrder = new List<object>();
            sortOrder.Add(new { Text = "None" });
            sortOrder.Add(new { Text = "Ascending" });
            sortOrder.Add(new { Text = "Descending" });
            ViewBag.sortOrder = sortOrder;

            List<object> selectionType = new List<object>();
            selectionType.Add(new { Text = "Single" });
            selectionType.Add(new { Text = "Multiple" });
            ViewBag.selectionType = selectionType;
            return View();
        }
    }
}
