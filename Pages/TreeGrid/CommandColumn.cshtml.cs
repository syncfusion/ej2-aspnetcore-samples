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
    public class CommandColumnModel : PageModel
    {
        public List<object> Commands { get; set; }
        public Dictionary<string, object> Dict { get; set; }
        

        public void OnGet()
        {
            Commands = new List<object>();
            Commands.Add(new { type = "Edit", buttonOption = new { iconCss = "e-icons e-edit", cssClass = "e-flat" } });
            Commands.Add(new { type = "Delete", buttonOption = new { iconCss = "e-icons e-delete", cssClass = "e-flat" } });
            Commands.Add(new { type = "Save", buttonOption = new { iconCss = "e-icons e-update", cssClass = "e-flat" } });
            Commands.Add(new { type = "Cancel", buttonOption = new { iconCss = "e-icons e-cancel-icon", cssClass = "e-flat" } });

            Dict = new Dictionary<string, object>();
            Dict.Add("number", true);
            Dict.Add("min", 0);

        }
        
    }
}