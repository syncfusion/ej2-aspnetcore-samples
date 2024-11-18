#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Button;

public class SplitButtonModel : PageModel
{
    public List<object> Items { get; set; }
    public void OnGet()
    {
        Items = new List<object>();
        Items.Add(new
        {
            text = "Paste",
            iconCss = "e-btn-icons e-paste"
        });
        Items.Add(new
        {
            text = "Paste Special",
            iconCss = "e-btn-icons e-paste-special"
        });
        Items.Add(new
        {
            text = "Paste as Formula",
            iconCss = "e-btn-icons e-paste-formula"
        });
        Items.Add(new
        {
            text = "Paste as Hyperlink",
            iconCss = "e-btn-icons e-paste-hyperlink"
        });
    }
}