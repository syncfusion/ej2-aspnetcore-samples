#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Carousel;

public class API : PageModel
{
    public List<ShowArrow> arrows = new List<ShowArrow>();
    public List<ShowInterval> intervals = new List<ShowInterval>();
    public void OnGet()
    {
        arrows.Add(new ShowArrow { Arrow = "Hidden", Id = "Hidden" });
        arrows.Add(new ShowArrow { Arrow = "Visible", Id = "Visible" });
        arrows.Add(new ShowArrow { Arrow = "On Hover", Id = "VisibleOnHover" });
        
        intervals.Add(new ShowInterval { Interval = "3 Seconds", Id = 3000 });
        intervals.Add(new ShowInterval { Interval = "5 Seconds", Id = 5000 });
        intervals.Add(new ShowInterval { Interval = "7 Seconds", Id = 7000 });
    }
}
public class ShowArrow
{
    public string Arrow { get; set; }
    public string Id { get; set; }
}

public class ShowInterval
{
    public string Interval { get; set; }
    public double Id { get; set; }
}