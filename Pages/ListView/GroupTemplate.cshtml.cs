#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.ListView;

public class GroupTemplate : PageModel
{
    public List<object> listdata = new List<object>();
    public void OnGet()
    {
        listdata.Add(new { Name = "WI-FI", content = "Disabled", id = "1", css = "wifi", category = "Wireless & networks", order = "0" });
        listdata.Add(new { Name = "Bluetooth", content = "Disabled", id = "2", css = "bluetooth", category = "Wireless & networks", order = "0" });
        listdata.Add(new { Name = "SIM cards", content = "AT&T", id = "3", css = "sim", category = "Wireless & networks", order = "0" });
        listdata.Add(new { Name = "Display", content = "Adaptive brightness is OFF", id = "4", css = "display", category = "Device", order = "1" });
        listdata.Add(new { Name = "Sound", content = "Ringer volume at 50%", id = "5", css = "sound", category = "Device", order = "1" });
        listdata.Add(new { Name = "Battery", content = "85%", id = "5", css = "battery", category = "Device", order = "1" });
        listdata.Add(new { Name = "Users", content = "Signed in as Albert", id = "6", css = "user", category = "Device", order = "1" });
        listdata.Add(new { Name = "Location", content = "ON / High accuracy", id = "7", css = "location", category = "Personal", order = "2" });
        listdata.Add(new { Name = "Security", id = "8", content = "Screen Lock", css = "security", category = "Personal", order = 2 });
        listdata.Add(new { Name = "Languages & input", content = "English (US)", id = "9", css = "language", category = "Personal", order = "2" });
    }
}