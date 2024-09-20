#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.Schedule;

public class Agenda : PageModel
{
    public List<ScrollData> view = new List<ScrollData>();
    public void OnGet()
    {
        view.Add(new ScrollData { Name = "False", Value = "false" });
        view.Add(new ScrollData { Name = "True", Value = "true" });
    }
}
public class ScrollData
{
    public string Name { get; set; }
    public string Value { get; set; }
}