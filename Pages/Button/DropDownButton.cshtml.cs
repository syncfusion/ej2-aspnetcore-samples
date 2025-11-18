#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Button;

public class DropDownButtonModel : PageModel
{
    public List<object> Items { get; set; }
    public void OnGet()
    {
        Items = new List<object>();
        Items.Add(new
        {
            text = "Dashboard",
            iconCss = "e-ddb-icons e-dashboard"
        });
        Items.Add(new
        {
            text = "Notifications",
            iconCss = "e-ddb-icons e-notifications"
        });
        Items.Add(new
        {
            text = "User Settings",
            iconCss = "e-ddb-icons e-settings"
        });
        Items.Add(new
        {
            text = "Log Out",
            iconCss = "e-ddb-icons e-logout"
        });
    }
}