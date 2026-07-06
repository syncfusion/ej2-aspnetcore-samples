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
                new ModelItem { Id = "openai", Name = "GPT-4o-mini(Azure)" },
                new ModelItem { Id = "gemini", Name = "Gemini 2.5 Flash" },
                new ModelItem { Id = "deepseek", Name = "DeepSeek-R1" }
            };
        }

        public class ModelItem
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }
}