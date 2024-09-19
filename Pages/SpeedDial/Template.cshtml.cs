#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Buttons;
namespace EJ2CoreSampleBrowser_NET8.Pages.SpeedDial;

public class TemplateModel : PageModel
{
    public List<SpeedDialItem> Items { get; set; }
    
    public void OnGet()
    {
        Items = new List<SpeedDialItem>();
        Items.Add(new SpeedDialItem
        {
            Text = "Cut",
            IconCss = "speeddial-icons speeddial-icon-cut"
        });
        Items.Add(new SpeedDialItem
        {
            Text = "Copy",
            IconCss = "speeddial-icons speeddial-icon-copy"
        });
        Items.Add(new SpeedDialItem
        {
            Text = "Paste",
            IconCss = "speeddial-icons speeddial-icon-paste"
        });
        Items.Add(new SpeedDialItem
        {
            Text = "Delete",
            IconCss = "speeddial-icons speeddial-icon-delete"
        });
    }
}