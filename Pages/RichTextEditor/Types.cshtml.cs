#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.RichTextEditor;

public class Types : PageModel
{
    public List<Data> datasource = new List<Data>();
    public void OnGet()
    {
        datasource.Add(new Data() { text = "Expand", value = 1 });
        datasource.Add(new Data() { text = "MultiRow", value = 2 });
        datasource.Add(new Data() { text = "Scrollable", value = 3 });
    }
}

public class Data
{
    public string text { get; set; }
    public int value { get; set; }
}