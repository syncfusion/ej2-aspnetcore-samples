#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Timeline;

public class APIModel : PageModel
{
    public List<object> OrientationData { get; set; }
    public List<object> AlignData { get; set; }
    public List<object> TravelItenary { get; set; }

    public void OnGet()
    {
        OrientationData = new List<object>();
        OrientationData.Add(new { text = "Vertical", value = "vertical" });
        OrientationData.Add(new { text = "Horizontal", value = "horizontal" });

        AlignData = new List<object>();
        AlignData.Add(new { text = "Before", value = "before" });
        AlignData.Add(new { text = "After", value = "after" });
        AlignData.Add(new { text = "Alternate", value = "alternate" });
        AlignData.Add(new { text = "Alternate reverse", value = "alternatereverse" });

        TravelItenary = new List<object>();
        TravelItenary.Add(new { date = "May 13, 2024", details = "Flight Booking: Reserving airline tickets", icon = "sf-icon-onward" });
        TravelItenary.Add(new { date = "June 20, 2024", details = "Hotel Accommodation= Booking lodging for the trip", icon = "sf-icon-accomodation" });
        TravelItenary.Add(new { date = "July 2, 2024", details = "Excursion Plans= Organized visits to popular attractions", icon = "sf-icon-explore" });
        TravelItenary.Add(new { date = "Aug 14, 2024", details = "Return Journey= Flight Confirmation", icon = "sf-icon-return" });
    }
}