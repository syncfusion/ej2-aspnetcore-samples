#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.AIAssistView
{
    public class Ai_Speech_To_TextModel : PageModel
    {
        public List<ToolbarItemModel> Items { get; set; } = new List<ToolbarItemModel>();
        public List<ToolbarItemModel> FooterItems { get; set; } = new List<ToolbarItemModel>();
        public string[] Suggestions { get; set; }

        public void OnGet()
        {
            Items.Add(new ToolbarItemModel { align = "Right", iconCss = "e-icons e-refresh" });
            FooterItems.Add(new ToolbarItemModel { iconCss = "e-icons e-assist-send", align = "Right" });
            FooterItems.Add(new ToolbarItemModel { iconCss = "e-icons e-assist-attachment-icon", align = "Left", tooltip = "Attach File" });
            FooterItems.Add(new ToolbarItemModel { iconCss = "e-icons e-assist-speech-to-text", align = "Left" });
        }
    }
}
