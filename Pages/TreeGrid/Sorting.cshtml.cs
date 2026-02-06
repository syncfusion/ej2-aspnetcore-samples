#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeGrid
{
    public class SortingModel : PageModel
    {
        public List<object> Columns = new List<object>();

        public void OnGet()
        {
            
            Columns.Add(new { field = "ShipmentCategory", direction = "Ascending" });
            Columns.Add(new { field = "Name", direction = "Descending" });
        }
        
    }
}