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

namespace EJ2CoreSampleBrowser.Controllers.ListBox
{
    public partial class ListBoxController : Controller
    {
        public IActionResult DualListBox()
        {
            string[] items = new string[] { "moveUp", "moveDown", "moveTo", "moveFrom", "moveAllTo", "moveAllFrom" };
            ViewBag.items = items;

            List<object> groupA = new List<object>();
            groupA.Add(new { Name = "Australia", Code = "AU" });
            groupA.Add(new { Name = "Bermuda", Code = "BM" });
            groupA.Add(new { Name = "Canada", Code = "CA" });
            groupA.Add(new { Name = "Cameroon", Code = "CM" });
            groupA.Add(new { Name = "Denmark", Code = "DK" });
            groupA.Add(new { Name = "France", Code = "FR" });
            groupA.Add(new { Name = "Finland", Code = "FI" });
            groupA.Add(new { Name = "Germany", Code = "DE" });
            groupA.Add(new { Name = "Hong Kong", Code = "HK" });
            ViewBag.groupA = groupA;

            List<object> groupB = new List<object>();
            groupB.Add(new { Name = "India", Code = "IN" });
            groupB.Add(new { Name = "Italy", Code = "IT" });
            groupB.Add(new { Name = "Japan", Code = "JP" });
            groupB.Add(new { Name = "Mexico", Code = "MX" });
            groupB.Add(new { Name = "Norway", Code = "NO" });
            groupB.Add(new { Name = "Poland", Code = "PL" });
            groupB.Add(new { Name = "Switzerland", Code = "CH" });
            groupB.Add(new { Name = "United Kingdom", Code = "GB" });
            groupB.Add(new { Name = "United States", Code = "US" });
            ViewBag.groupB = groupB;
            return View();
        }
    }
}
