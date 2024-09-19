#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.Toast;

public class Position : PageModel
{
    public List<Positions> position = new List<Positions>();
    public void OnGet()
    {
        position.Add(new Positions { Value = "Top Left" });
        position.Add(new Positions { Value = "Top Right" });
        position.Add(new Positions { Value = "Top Center" });
        position.Add(new Positions { Value = "Top Full Width" });
        position.Add(new Positions { Value = "Bottom Left" });
        position.Add(new Positions { Value = "Bottom Right" });
        position.Add(new Positions { Value = "Bottom Center" });
        position.Add(new Positions { Value = "Bottom Full Width" });
    }
}

public class Positions
{
    public string Value { get; set; }
}