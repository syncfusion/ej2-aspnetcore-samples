#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.MultiSelect;

public class ChipCustomization : PageModel
{
    public List<ColorsData> Color = new List<ColorsData>();
    public void OnGet()
    {
        Color.Add( new ColorsData { Color= "Chocolate", Code = "#75523C" });
        Color.Add( new ColorsData { Color= "CadetBlue", Code = "#3B8289" });
        Color.Add( new ColorsData { Color= "DarkOrange", Code = "#FF843D" });
        Color.Add( new ColorsData { Color= "DarkRed", Code = "#CA3832" });
        Color.Add( new ColorsData { Color= "Fuchsia", Code = "#D44FA3" });
        Color.Add( new ColorsData { Color= "HotPink", Code = "#F23F82" });
        Color.Add( new ColorsData { Color= "Indigo", Code = "#2F5D81" });
        Color.Add( new ColorsData { Color= "LimeGreen", Code = "#4CD242" });
        Color.Add( new ColorsData { Color= "OrangeRed", Code = "#FE2A00" });
        Color.Add( new ColorsData { Color = "Tomato", Code = "#FF745C" });
    }
}

public class ColorsData
{
    public string Color { get; set; }
    public string Code { get; set; }
}