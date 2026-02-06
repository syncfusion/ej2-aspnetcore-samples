#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
using Syncfusion.EJ2.InteractiveChat;

namespace EJ2CoreSampleBrowser.Pages.ChatUI
{
    public class AttachmentModel : PageModel
    {
        public List<ToolbarItemModel> HeaderToolbar { get; set; } = new List<ToolbarItemModel>();
        public void OnGet()
        {
            HeaderToolbar.Add(new ToolbarItemModel { iconCss = "e-icons e-refresh", align = "Right", tooltip = "Clear Chat" });
        }

        public class ToolbarItemModel
        {
            public string iconCss { get; set; }
            public string tooltip { get; set; }
            public string align { get; set; }
        }
    }
}
