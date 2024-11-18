#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.DropDownList;

public class DropdownListFor : PageModel
{
    [BindProperty]
    public DropdownListValue model { get; set; }
    public string[] dataSource = new string[]
    {
        "American Football", "Badminton", "Basketball", "Cricket", "Football", "Golf", "Hockey", "Rugby", "Snooker",
        "Tennis"
    };
    public void OnGet()
    {
        model = new DropdownListValue
        {
            data = dataSource
        };
    }
    public void OnPost()
    {
        if (model.val == null)
        {
            ModelState.AddModelError("model.val", "Please enter a value");
        }

        model.data = dataSource;
        model.val = model.val;
    }
}

public class DropdownListValue
{
    public string val { get; set; }
    public string[] data { get; set; }
}