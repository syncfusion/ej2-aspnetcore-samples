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

namespace EJ2CoreSampleBrowser.Controllers.DropDownTree
{
    public partial class DropDownTreeController : Controller
    {
        public IActionResult Checkbox()
        {
            List<object> Parent = new List<object>();
            Parent.Add(new { id = 1, name = "Australia", hasChild = true, expanded = true });
            Parent.Add(new { id = 2, pid = 1, name = "New South Wales" });
            Parent.Add(new { id = 3, pid = 1, name = "Victoria" });
            Parent.Add(new { id = 4, pid = 1, name = "South Australia" });
            Parent.Add(new { id = 6, pid = 1, name = "Western Australia" });
            Parent.Add(new { id = 7, name = "Brazil", hasChild = true });
            Parent.Add(new { id = 8, pid = 7, name = "Paraná" });
            Parent.Add(new { id = 9, pid = 7, name = "Ceará" });
            Parent.Add(new { id = 10, pid = 7, name = "Acre" });
            Parent.Add(new { id = 11, name = "China", hasChild = true });
            Parent.Add(new { id = 12, pid = 11, name = "Guangzhou" });
            Parent.Add(new { id = 13, pid = 11, name = "Shanghai" });
            Parent.Add(new { id = 14, pid = 11, name = "Beijing" });
            Parent.Add(new { id = 15, pid = 11, name = "Shantou" });
            Parent.Add(new { id = 16, name = "France", hasChild = true });
            Parent.Add(new { id = 17, pid = 16, name = "Pays de la Loire" });
            Parent.Add(new { id = 18, pid = 16, name = "Aquitaine" });
            Parent.Add(new { id = 19, pid = 16, name = "Brittany" });
            Parent.Add(new { id = 20, pid = 16, name = "Lorraine" });
            Parent.Add(new { id = 21, name = "India", hasChild = true });
            Parent.Add(new { id = 22, pid = 21, name = "Assam" });
            Parent.Add(new { id = 23, pid = 21, name = "Bihar" });
            Parent.Add(new { id = 24, pid = 21, name = "Tamil Nadu" });
            Parent.Add(new { id = 25, pid = 21, name = "Punjab" });
            ViewBag.dataSource = Parent;
            return View();
        }
    }
}
