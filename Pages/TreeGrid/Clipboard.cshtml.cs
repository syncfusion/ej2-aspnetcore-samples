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
    public class ClipboardModel : PageModel
    {
        public List<object> Toolbar { get; set; }
        public List<object> DropData { get; set; }
        public void OnGet()
        {
            Toolbar = new List<object>();
            Toolbar.Add(new { text = "Copy", tooltipText = "Copy", prefixIcon = "e-copy", id = "copy" });
            Toolbar.Add(new { text = "Copy With Header", tooltipText = "Copy With Header", prefixIcon = "e-copy", id = "copyHeader" });

            DropData = new List<object>() {
                new { id= "Parent", mode= "Parent" },
                new { id= "Child", mode= "Child" },
                new { id= "Both", mode= "Both" },
                new { id= "None", mode= "None" },
            };

        }
        
    }
}