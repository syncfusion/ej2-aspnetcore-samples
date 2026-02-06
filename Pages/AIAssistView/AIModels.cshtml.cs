#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Pages.AIAssistView
{
    public class AIModelsModel : PageModel
    {
        public string[] Suggestions { get; set; }
        public List<ModelItem> Models { get; set; }

        public void OnGet()
        {
            Suggestions = new string[]
            {
                "What are the best tools for organizing tasks?",
                "How can I maintain work-life balance?"
            };

            Models = new List<ModelItem>
            {
                new ModelItem { Id = "gemini", Name = "Gemini 2.5 Flash" },
                new ModelItem { Id = "deepseek", Name = "DeepSeek-R1" },
                new ModelItem { Id = "openai", Name = "GPT-4o-mini(Azure)" }
            };
        }

        public class ModelItem
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }
}