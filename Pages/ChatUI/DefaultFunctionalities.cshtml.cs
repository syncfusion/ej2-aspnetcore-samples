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
    public class DefaultFunctionalitiesModel : PageModel
    {
        public List<ToolbarItemModel> HeaderToolbar1 { get; set; } = new List<ToolbarItemModel>();
        public List<ToolbarItemModel> HeaderToolbar2 { get; set; } = new List<ToolbarItemModel>();
        public List<ChatUIMessage> ChatMessagesData { get; set; }
        public string[] DefaultChatSuggestions { get; set; }

        public void OnGet()
        {   
            ChatMessagesData = new ChatMessagesData().GetUserChatMessages();
            DefaultChatSuggestions = new string[] { "Awesome!", "What kind of painting ?" };
            HeaderToolbar1.Add(new ToolbarItemModel { type= "Input", align = "Right", template = "<button id=\"dduser1Menu\" style=\"border: none; background: none !important;\"></button>" });
            HeaderToolbar2.Add(new ToolbarItemModel { type = "Input", align = "Right", template = "<button id=\"dduser2Menu\" style=\"border: none; background: none !important;\"></button>" });
        }

        public class ToolbarItemModel
        {
            public string type { get; set; }
            public string template { get; set; }
            public string align { get; set; }
        }
    }
}
