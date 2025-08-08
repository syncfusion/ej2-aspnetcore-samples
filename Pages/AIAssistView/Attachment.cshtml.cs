#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
    public class AttachmentModel : PageModel
    {
        public List<ToolbarItemModel> Items { get; set; } = new List<ToolbarItemModel>();
        public List<PromptResponseData> PromptResponseData { get; set; }
        public string[] PromptSuggestionData { get; set; }

        public void OnGet()
        {
            PromptResponseData = new PromptResponseData().GetAllPromptResponseData();
            PromptSuggestionData = new PromptResponseData().GetAllSuggestionData();
            Items.Add(new ToolbarItemModel { align = "Right", iconCss = "e-icons e-refresh" });
        }
    }

    public class AttachmentSettingsModel
    {
        public string saveUrl = string.Empty;

        public string removeUrl = string.Empty;

        public string allowedExtensions = string.Empty;

        public int maxFileSize = 200000;
    }

    public class ToolbarItemModel
    {
        public string align { get; set; }

        public string iconCss { get; set; }
    }
}
