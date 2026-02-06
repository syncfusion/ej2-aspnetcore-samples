#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Splitter;

public class DetailsView : PageModel
{
    public List<object> data = new List<object>();
    public void OnGet()
    {
        data.Add(new { name = "Margaret", imgUrl = @Url.Content("~/splitter/images/margaret.png"), id = "1" });
        data.Add(new { name = "Laura", imgUrl = @Url.Content("~/splitter/images/laura.png"), id = "2" });
        data.Add(new { name = "Robert", imgUrl = @Url.Content("~/splitter/images/robert.png"), id = "3" });
        data.Add(new { name = "Michale", imgUrl = @Url.Content("~/splitter/images/michale.png"), id = "4" });
        data.Add(new { name = "Albert", imgUrl = @Url.Content("~/splitter/images/albert.png"), id = "5" });
    }
}