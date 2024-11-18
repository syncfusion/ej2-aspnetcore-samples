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
    public class SortingAPIModel : PageModel
    {
        public List<object> Columns { get; set; }
        public List<object> Directions { get; set; }

        public void OnGet()
        {
            Columns = new List<object>() {
                new { id= "TaskId", name= "Task ID" },
                new { id= "TaskName", name= "Task Name" },
                new { id= "Progress", name= "Progress" },
                new { id= "Duration", name= "Duration" }
            };
            Directions = new List<object>() {
                new { id= "Ascending", name= "Ascending" },
                new { id= "Descending", name= "Descending" }
            };
        }
        
    }
}