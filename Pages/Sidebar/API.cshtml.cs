#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.Sidebar;

public class API : PageModel
{
    public Dictionary<string, object> HtmlAttribute = new Dictionary<string, object>()
        {   {"class", "default-sidebar" } };

    public List<object> dataList = new List<object>();
    public void OnGet()
    {
        dataList.Add(new { Type = "Over", value = "Over" });
        dataList.Add(new { Type = "Push", value = "Push" });
        dataList.Add(new { Type = "Slide", value = "Slide" });
        dataList.Add(new { Type = "Auto", value = "Auto" });
    }
}