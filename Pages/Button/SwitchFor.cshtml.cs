#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser_NET8.Pages.Button;

public class SwitchFor : PageModel
{
    [BindProperty]
    public SwitchModel model { get; set; }
    public void OnGet()
    {
        model = new SwitchModel
        {
            check = true
        };
    }
    public void OnPost()
    {
        if (model.check != true)
        {
            ModelState.AddModelError("model.check", "You need to agree to receive newsletter");
        }
    }
}
public class SwitchModel
{
    public bool check { get; set; }
}