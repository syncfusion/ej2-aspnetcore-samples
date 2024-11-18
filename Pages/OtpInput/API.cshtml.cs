#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.OtpInput;

public class APIModel : PageModel
{
    public List<object> stylingMode { get; set; }
    public List<object> validationStatus { get; set; }
    public void OnGet()
    {
        stylingMode = new List<object>();
        stylingMode.Add(new { text = "Outlined", value = "Outlined" });
        stylingMode.Add(new { text = "Underlined", value = "Underlined" });
        stylingMode.Add(new { text = "Filled", value = "Filled" });

        validationStatus = new List<object>();
        validationStatus.Add(new { text = "None", value = "" });
        validationStatus.Add(new { text = "Success", value = "e-success" });
        validationStatus.Add(new { text = "Warning", value = "e-warning" });
        validationStatus.Add(new { text = "Error", value = "e-error" });
    }
}