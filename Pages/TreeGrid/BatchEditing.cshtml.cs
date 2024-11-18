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
    public class BatchEditingModel : PageModel
    {
        public Dictionary<string, object> Dict { get; set; }
        public void OnGet()
        {
            Dict = new Dictionary<string, object>();
            Dict.Add("number", true);
            Dict.Add("min", 0);
        }
        
    }
}