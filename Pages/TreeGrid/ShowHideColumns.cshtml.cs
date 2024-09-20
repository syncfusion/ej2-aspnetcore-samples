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
    public class ShowHideColumnsModel : PageModel
    {
        public List<object> Columns { get; set; }

        public void OnGet()
        {
            Columns = new List<Object>() {
                new { value= "TaskId", text= "Task ID" },
                new { value= "StartDate", text= "Start Date" },
                new { value= "Duration", text= "Duration" },
                new { value= "Progress", text= "Progress" }
            };
        }
        
    }
}