#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Pages.AIAssistView
{
    public class TemplateModel : PageModel
    {
        public List<ToolbarItem> Items = new List<ToolbarItem>();
        public List<AIAssitCarouselDataBinding> datasrc = new List<AIAssitCarouselDataBinding>();
        public List<PromptResponseData> PromptResponseData { get; set; }
        public string[] PromptSuggestionData { get; set; }
        public void OnGet()
        {
            Items.Add(new ToolbarItem { Type = ItemType.Input, Align = ItemAlign.Right, Template = "<button id=\"ddMenu\"></button>" });
            datasrc.Add(new AIAssitCarouselDataBinding
            {
                ImgPath = "./../css/carousel/images/moscow.jpg",
                Suggestion = "How do I prioritize tasks effectively?"
            });
            datasrc.Add(new AIAssitCarouselDataBinding
            {
                ImgPath = "./../css/carousel/images/san-francisco.jpg",
                Suggestion = "How do I set daily goals in my work day?"
            });
            datasrc.Add(new AIAssitCarouselDataBinding
            {
                ImgPath = "./../css/carousel/images/london.jpg",
                Suggestion = "Steps to publish a e-book with marketing strategy"
            });
            datasrc.Add(new AIAssitCarouselDataBinding
            {
                ImgPath = "./../css/carousel/images/tokyo.jpg",
                Suggestion = "What tools or apps can help me prioritize tasks?"
            });

            PromptResponseData = new PromptResponseData().GetTemplatePromptResponseData();
            PromptSuggestionData = new PromptResponseData().GetAllSuggestionData();
        }
    }

    public class AIAssitCarouselDataBinding
    {
        public string Suggestion { get; set; }
        public string ImgPath { get; set; }
    }
}
