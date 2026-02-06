#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Barcode;

public class Ean8Model : PageModel
{
    public List<ExpandOptions> position { get; set; }
    public List<alignment> align { get; set; }
    
    public void OnGet()
    {
        position = new List<ExpandOptions>();
        position.Add(new ExpandOptions() { text = "Bottom", value = "bottom" });
        position.Add(new ExpandOptions() { text = "Top", value = "top" });
        
        align = new List<alignment>();
        align.Add(new alignment() { text = "Left", value = "left" });
        align.Add(new alignment() { text = "Right", value = "right" });
        align.Add(new alignment() { text = "Center", value = "center" });
    }
}