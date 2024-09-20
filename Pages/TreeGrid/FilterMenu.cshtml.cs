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

namespace EJ2CoreSampleBrowser_NET8.Pages.TreeGrid
{
    public class FilterMenuModel : PageModel
    {
        public List<object> DropData { get; set; }
        public List<object> TypeDropData { get; set; }
        
        public void OnGet()
        {
            DropData = new List<object>() {
                new { id= "Parent", mode= "Parent" },
                new { id= "Child", mode= "Child" },
                new { id= "Both", mode= "Both" },
                new { id= "None", mode= "None" },
            };
            TypeDropData = new List<object>() {
                new { id= "Menu", type= "Menu" },
                new { id= "Excel", type= "Excel" },
            };
        }
        
    }
}