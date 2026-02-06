#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Schedule
{
    public class Clipboard : PageModel
    {
        public List<object> menuItems = new List<object>();

        public void OnGet()
        {
            menuItems.Add(new
            {
                text = "Cut Event",
                iconCss = "e-icons e-cut",
                id = "Cut"
            });
            menuItems.Add(new
            {
                text = "Copy Event",
                iconCss = "e-icons e-copy",
                id = "Copy"
            });
            menuItems.Add(new
            {
                text = "Paste",
                iconCss = "e-icons e-paste",
                id = "Paste"
            });
        }
    }
}
