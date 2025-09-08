#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Pages.Button;

public class RadioButtonFor : PageModel
{
    [BindProperty]
    public RadioButtonModel model { get; set; }
    public void OnGet()
    {
        model = new RadioButtonModel
        {
            gender = "female"
        };
    }
    public void OnPost()
    {
        if (model.gender != "male")
        {
            ModelState.AddModelError("model.gender", "Male gender is required.");
        }
    }
}
public class RadioButtonModel
{
    public string gender { get; set; }
}