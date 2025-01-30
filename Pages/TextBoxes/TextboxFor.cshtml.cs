#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TextBoxes;

public class TextboxFor : PageModel
{
    [BindProperty]
    public TextBoxValue Textbox { get; set; }

    public string ValueText = "John";
    public void OnGet()
    {
        Textbox = new TextBoxValue
        {
            firstname = ValueText
        };
    }
    public void OnPost()
    {
        if (Textbox.firstname == null)
        {
            ModelState.AddModelError("Textbox.firstname", "Value is required");
        }
    }
}
public class TextBoxValue
{
    public string firstname { get; set; }
}