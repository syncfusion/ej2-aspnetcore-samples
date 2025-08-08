#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.SpeechToText;
    public class IntegrationModel : PageModel
    {
    public List<ToolbarItemModel> Items { get; set; } = new List<ToolbarItemModel>();

    public void OnGet()
         {
        Items.Add(new ToolbarItemModel { align = "Right", iconCss = "e-icons e-refresh" });
         }
    }
public class ToolbarItemModel
{
    public string align { get; set; }

    public string iconCss { get; set; }
}