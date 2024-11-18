#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Pages.Menu;

public class ToolbarIntegrationModel : PageModel
{
    public List<ToolbarItem> items { get; set; }
    public void OnGet()
    {
        items = new List<ToolbarItem>()
        {
            new ToolbarItem { Template ="<ul id='menu'></ul>" },
            new ToolbarItem { Template ="<div class='e-input-group'><input class='e-input' type='Text' placeholder='Search' /><span class='e-input-group-icon em-icons e-search'></span></div>", Align=Syncfusion.EJ2.Navigations.ItemAlign.Right },
            new ToolbarItem { Template ="<button id='userDBtn'>Andrew</button>", Align=Syncfusion.EJ2.Navigations.ItemAlign.Right },
            new ToolbarItem { PrefixIcon ="em-icons e-shopping-cart", Align=Syncfusion.EJ2.Navigations.ItemAlign.Right }
        };
    }
}