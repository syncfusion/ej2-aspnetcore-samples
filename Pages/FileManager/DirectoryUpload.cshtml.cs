#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.FileManager;

public class DirectoryUpload : PageModel
{
    public List<object> items = new List<object>();
    public void OnGet()
    {
        items.Add(new
        {
            text = "Folder",
        });
        items.Add(new
        {
            text = "Files",
        });
    }
}