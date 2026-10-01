using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.AIAssistView
{
    public class Ai_MentionModel : PageModel
    {
        public List<ToolbarItemModel> Items { get; set; } = new List<ToolbarItemModel>();
        public string[] PromptSuggestionData { get; set; } = Array.Empty<string>();
        public List<object> MentionData { get; set; } = new List<object>();
        public string PromptPlaceholder { get; set; } = string.Empty;
        public string MentionSystemPrompt { get; set; } = string.Empty;
        public Dictionary<string, string> SkillPrompts { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> AgentPrompts { get; set; } = new Dictionary<string, string>();

        public void OnGet()
        {
            PromptSuggestionData = Models.MentionData.GetMentionSuggestions();
            PromptPlaceholder = "Type a prompt and use '/' for commands or '@' for tools...";

            var mentionModel = new Models.MentionData();
            MentionSystemPrompt = mentionModel.MentionSystemPrompt;
            SkillPrompts = Models.MentionData.GetSkillPrompts();
            AgentPrompts = Models.MentionData.GetAgentPrompts();

                    var skillMentionData = new List<object>
                    {
                        new { id = "translate", name = "translate", description = "Translate the response into a requested language.", iconCss = "e-icons e-swap-arrow" },
                        new { id = "help", name = "help", description = "Explain what the assistant can do and how to use it.", iconCss = "e-icons e-circle-info" },
                        new { id = "search", name = "search", description = "Search for relevant and current information.", iconCss = "e-icons e-search" },
                        new { id = "summarize", name = "summarize", description = "Condense the supplied content into the key points.", iconCss = "e-icons e-list-unordered" }
                    };

                    var toolMentionData = new List<object>
                    {
                        new { id = "getweather", name = "getWeather", description = "Get current weather for a city." },
                        new { id = "generatecode", name = "generateCode", description = "Generate code snippets from requirements." },
                        new { id = "websearch", name = "webSearch", description = "Search the web for current information." }
                    };

                    MentionData = new List<object>
                    {
                        new {
                        mentionChar = "@",
                        dataSource = skillMentionData,
                        fields = new { text = "name", value = "id", iconCss = "iconCss" },
                        filterType = "StartsWith",
                        highlight = true
                        },
                        new{
                        mentionChar = "/",
                        dataSource = toolMentionData,
                        showMentionChar = false,
                        fields = new { text = "name", value = "id" }
                        }
                    };

                    Items.Add(new ToolbarItemModel { align = "Right", iconCss = "e-icons e-refresh" });
        }
    }

}