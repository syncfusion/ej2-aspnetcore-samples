#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.MaskedTextBox;

public class CustomMask : PageModel
{
    public CustomCharacters customObj = new CustomCharacters();
    public void OnGet()
    {
        customObj.P = "P,A,a,p";
        customObj.M = "M,m";
    }
}
public class CustomCharacters
{
    public string P { get; set; }
    public string M { get; set; }
}