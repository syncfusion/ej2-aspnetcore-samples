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
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser_NET8.Pages.AIAssistView
{
    public class AssistantModel : PageModel
    {
        public List<ToolbarItem> Items = new List<ToolbarItem>();
        public List<PromptResponseData> PromptResponseData { get; set; }
        public string[] PromptSuggestionData { get; set; }

        public void OnGet()
        {
            Items.Add(new ToolbarItem { Type = ItemType.Input, Align = ItemAlign.Right, Template = "<button id=\"ddMenu\"></button>" });
            PromptResponseData = new PromptResponseData().GetAssistantPromptResponseData();
            PromptSuggestionData = new PromptResponseData().GetAssistantSuggestionData();
        }
    }
}

