using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser.Pages.AIAssistView
{
    public class NotionAICloneModel : PageModel
    {
        public string[] NotionSuggestions { get; set; } = [];
        public Dictionary<string, string> ModelIcons { get; set; } = new();
        public Dictionary<int, string> IconMapByIndex { get; set; } = new();
        public object[] ToolbarItems { get; set; } = [];
        public object[] FooterToolbarItems { get; set; } = [];
        public object[] ResponseToolbarItems { get; set; } = [];

        public void OnGet()
        {
            // Reuse data from PromptResponseData
            NotionSuggestions = PromptResponseData.GetNotionSuggestions().ToArray();
            ModelIcons = PromptResponseData.GetModelIcons();
            IconMapByIndex = PromptResponseData.GetIconMapByIndex();
            ToolbarItems =
            [
                new { iconCss = "e-icons e-export", align = "Right", tooltip = "Share Chat" },
                new { iconCss = "e-icons e-history", align = "Right", tooltip = "Chat History", cssClass = "history-icon" },
                new { iconCss = "e-icons e-edit-notes", align = "Right", tooltip = "Start New chat" },
                new { iconCss = "e-icons e-resize", align = "Right", tooltip = "Switch Chat Mode", cssClass = "screen-resizer" },
                new { iconCss = "e-icons e-horizontal-line", align = "Right", tooltip = "Hide Chat" }
            ];
            FooterToolbarItems =
            [
                new { iconCss = "e-icons e-assist-attachment-icon", align = "Left", tooltip = "Attach File" },
                new { iconCss = "e-icons e-settings", align = "Left", tooltip = "Settings", cssClass = "settings-icon" },
                new { iconCss = "e-icons e-edit", align = "Left", tooltip = "Edit access", cssClass = "e-hidden" },
                new { iconCss = "e-icons e-time-zone", align = "Left", tooltip = "Web access", cssClass = "e-hidden" },
                new { align = "Right", text = "Auto", template = "<button id=\"custombtn\">Auto</button>" },
                new { iconCss = "e-icons e-assist-speech-to-text", align = "Right" },
                new { iconCss = "e-icons e-assist-send", align = "Right" }
            ];
            ResponseToolbarItems =
            [
                new { iconCss = "e-icons e-assist-copy" },
                new { iconCss = "e-icons e-assist-like" },
                new { iconCss = "e-icons e-assist-dislike" },
                new { iconCss = "e-icons e-assist-audio" }
            ];
        }
    }

    public class NotionFooterToolbarItem
    {
        public string IconCss { get; set; } = string.Empty;
        public string Align { get; set; } = string.Empty;
        public string Tooltip { get; set; } = string.Empty;
        public string CssClass { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string Template { get; set; } = string.Empty;
        public bool Visible { get; set; } = true;
    }
}
