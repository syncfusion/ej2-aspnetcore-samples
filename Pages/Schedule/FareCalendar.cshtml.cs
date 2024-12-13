#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class FareCalendar : PageModel
{
    public List<AirelineData> airlines = new List<AirelineData>();
    public void OnGet()
    {
        airlines.Add(new AirelineData { Text = "Airways 1", Id = 1 });
        airlines.Add(new AirelineData { Text = "Airways 2", Id = 2 });
        airlines.Add(new AirelineData { Text = "Airways 3", Id = 3 });
    }
}

public class AirelineData
{
    public string Text { set; get; }
    public int Id { set; get; }
}