#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TextArea;

public class TextAreaFor : PageModel
{
    [BindProperty]
    public TextAreaValue Textareas { get; set; }

    public string comment = "";
    public void OnGet()
    {
        Textareas = new TextAreaValue
        {
            comments = comment
        };
    }
    public void OnPost()
    {
        if (Textareas.comments == null)
        {
            ModelState.AddModelError("Textareas.comments", "Value is required");
        }
    }
}
public class TextAreaValue
{
    public string comments { get; set; }
}