#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Buttons;
namespace EJ2CoreSampleBrowser.Pages.SpeedDial;

public class StylesModel : PageModel
{
    public List<SpeedDialItem> Items = new List<SpeedDialItem>();
    public List<SpeedDialItem> Label = new List<SpeedDialItem>();
    public List<SpeedDialItem> Titles = new List<SpeedDialItem>();
    
    public void OnGet()
    {
        
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
    Items.Add(new SpeedDialItem
            {
                Text = "Save",
                IconCss = "speeddial-icons speeddial-icon-save"
            });
    Titles.Add(new SpeedDialItem
            {
                Title = "Cut",
                IconCss = "speeddial-icons speeddial-icon-cut"
            });
    Titles.Add(new SpeedDialItem
            {
                Title = "Copy",
                IconCss = "speeddial-icons speeddial-icon-copy"
            });
    Titles.Add(new SpeedDialItem
            {
                Title = "Paste",
                IconCss = "speeddial-icons speeddial-icon-paste"
            });
    Titles.Add(new SpeedDialItem
            {
                Title = "Delete",
                IconCss = "speeddial-icons speeddial-icon-delete"
            });
    Titles.Add(new SpeedDialItem
            {
                Title = "Save",
                IconCss = "speeddial-icons speeddial-icon-save"
            });
    Label.Add(new SpeedDialItem
            {
                Text = "Cut",
            });
    Label.Add(new SpeedDialItem
            {
                Text = "Copy",
            });
    Label.Add(new SpeedDialItem
            {
                Text = "Paste",
            });
    Label.Add(new SpeedDialItem
            {
                Text = "Delete",
            });
    Label.Add(new SpeedDialItem
            {
                Text = "Save",
            });
    }
}