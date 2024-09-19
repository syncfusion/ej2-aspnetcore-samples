#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.ColorPicker;

public class ColorPickerFor : PageModel
{
    [BindProperty]
    public ColorPickerModel model { get; set; }

    public string ColorText = "#000080";
    public void OnGet()
    {
        model = new ColorPickerModel
        {
            colorValue = ColorText
        };
    }

    public void OnPost()
    {
        if (model.colorValue == ColorText)
        {
            ModelState.AddModelError("model.colorValue", "Please select color with value other than #000080.");
        }
    }
}
public class ColorPickerModel
{
    public string colorValue { get; set; }
}