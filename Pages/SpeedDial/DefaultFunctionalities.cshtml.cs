#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Buttons;
namespace EJ2CoreSampleBrowser.Pages.SpeedDial;

public class DefaultFunctionalitiesModel : PageModel
{
    public List<SpeedDialItem> Items { get; set; }
    
    public void OnGet()
    {
        Items = new List<SpeedDialItem>();
        Items.Add(new SpeedDialItem
        {
            Title="Home",
            IconCss = "e-icons e-home"
        });
        Items.Add(new SpeedDialItem
        {
            Title="People",
            IconCss = "e-icons e-people"
        });
        Items.Add(new SpeedDialItem
        {
            Title="Search",
            IconCss = "e-icons e-search"
        });
        Items.Add(new SpeedDialItem
        {
            Title="Message",
            IconCss = "e-icons e-comment-show"
        });
    }
}