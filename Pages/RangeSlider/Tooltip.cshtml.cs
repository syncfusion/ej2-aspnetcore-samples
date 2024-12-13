#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.RangeSlider;

public class Tooltip : PageModel
{
    public List<object> placement = new List<object>();
    public List<object> showON = new List<object>();
    public void OnGet()
    {
        placement.Add(new { value = "Before", text = "Before" });
        placement.Add(new { value = "After", text = "After" });
        
        showON.Add(new { value = "Auto", text = "Auto" });
        showON.Add(new { value = "Focus", text = "Focus" });
        showON.Add(new { value = "Hover", text = "Hover" });
        showON.Add(new { value = "Always", text = "Always" });
    }
}