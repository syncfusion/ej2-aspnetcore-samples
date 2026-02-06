#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.AIAssistView
{
    public class StreamingModel : PageModel
    {
        public List<StreamingToolbarItemModel> Items { get; set; } = new List<StreamingToolbarItemModel>();
        public List<PromptResponseData> PromptResponseData { get; set; }
        public string[] PromptSuggestionData { get; set; }

        public void OnGet()
        {
            PromptResponseData = new PromptResponseData().GetStreamingPromptResponseData();
            PromptSuggestionData = new PromptResponseData().GetStreamingSuggestionData();
            Items.Add(new StreamingToolbarItemModel { align = "Right", iconCss = "e-icons e-refresh" });
        }
    }

    public class StreamingToolbarItemModel
    {
        public string align { get; set; }

        public string iconCss { get; set; }
    }
}
