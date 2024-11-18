#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.ListBox;

public class CheckboxModel : PageModel
{
    public List<object> Data { get; set; }
    public void OnGet()
    {
        Data = new List<object>();
        Data.Add(new { text = "Hennessey Venom", id = "list-01" });
        Data.Add(new { text = "Bugatti Chiron", id = "list-02" });
        Data.Add(new { text = "Bugatti Veyron Super Sport", id = "list-03" });
        Data.Add(new { text = "SSC Ultimate Aero", id = "list-04" });
        Data.Add(new { text = "Koenigsegg CCR", id = "list-05" });
        Data.Add(new { text = "McLaren F1", id = "list-06" });
        Data.Add(new { text = "Aston Martin One- 77", id = "list-07" });
        Data.Add(new { text = "Jaguar XJ220", id = "list-08" });
        Data.Add(new { text = "McLaren P1", id = "list-09" });
        Data.Add(new { text = "Ferrari LaFerrari", id = "list-10" });
    }
}