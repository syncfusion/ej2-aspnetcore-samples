#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.Barcode;

public class qrcodeModel : PageModel
{
    public  List<coorectionLevel> level { get; set; }
    public void OnGet()
    {
        level = new List<coorectionLevel>();
        level.Add(new coorectionLevel() { text = "Low", value = "7" });
        level.Add(new coorectionLevel() { text = "Medium", value = "15" });
        level.Add(new coorectionLevel() { text = "Quartile", value = "25" });
        level.Add(new coorectionLevel() { text = "High", value = "30" });
    }
}