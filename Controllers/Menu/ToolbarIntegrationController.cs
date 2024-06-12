#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class MenuController : Controller
    {
        public IActionResult ToolbarIntegration()
        {
            List<ToolbarItem> items = new List<ToolbarItem>()
            {
                new ToolbarItem { Template ="<ul id='menu'></ul>" },
                new ToolbarItem { Template ="<div class='e-input-group'><input class='e-input' type='Text' placeholder='Search' /><span class='e-input-group-icon em-icons e-search'></span></div>", Align=Syncfusion.EJ2.Navigations.ItemAlign.Right },
                new ToolbarItem { Template ="<button id='userDBtn'>Andrew</button>", Align=Syncfusion.EJ2.Navigations.ItemAlign.Right },
                new ToolbarItem { PrefixIcon ="em-icons e-shopping-cart", Align=Syncfusion.EJ2.Navigations.ItemAlign.Right }
            };

            ViewBag.items = items;
            return View();
        }
    }
}
