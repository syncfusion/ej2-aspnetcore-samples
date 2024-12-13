#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
    public class PagingAPIModel : PageModel
    {
        public List<object> DropData { get; set; }
        
        public void OnGet()
        {
            DropData = new List<object>() {
                new { id= "All", mode= "All" },
                new { id= "Root", mode= "Root" }
            };
        }
        
    }
}