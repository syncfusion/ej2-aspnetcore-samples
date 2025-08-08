#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
using Syncfusion.EJ2.Navigations;
using Syncfusion.EJ2.InteractiveChat;
using Syncfusion.EJ2.DropDowns;

namespace EJ2CoreSampleBrowser.Pages.ChatUI
{
    public class APIModel : PageModel
    {
        public List<object> TimeStampFormatOptions { get; set; }
        public List<object> TypingUserOptions { get; set; }
        public object DDBListValue = "MM/dd hh:mm a";
        public List<ChatUIMessage> CommunityMessagedata { get; set; }
        public List<ToolbarItemModel> MessageToolbarItems { get; set; }

        public void OnGet()
        {
            MessageToolbarItems = new List<ToolbarItemModel>()
            {
                new ToolbarItemModel { iconCss = "e-icons e-chat-forward", tooltipText = "Forward" },
                new ToolbarItemModel { iconCss = "e-icons e-chat-copy", tooltipText = "Copy" },
                new ToolbarItemModel { iconCss = "e-icons e-chat-reply", tooltipText = "Reply" },
                new ToolbarItemModel { iconCss = "e-icons e-chat-pin", tooltipText = "Pin" },
                new ToolbarItemModel { iconCss = "e-icons e-chat-trash", tooltipText = "Delete" }
            };
            CommunityMessagedata = new ChatMessagesData().GetCommunityMessageData();
            TimeStampFormatOptions = new List<object>
            {
                new { text = "MM/dd hh:mm a", value = "MM/dd hh:mm a" },
                new { text = "dd/MM/yy hh:mm a", value = "dd/MM/yy hh:mm a" },
                new { text = "hh:mm a", value = "hh:mm a" },
                new { text = "MMMM hh:mm a", value = "MMMM hh:mm a" }
            };
            TypingUserOptions = new List<object>
            {
                new { text = "Michale", value = "Michale" },
                new { text = "Laura", value = "Laura" },
                new { text = "Charlie", value = "Charlie" },
                new { text = "Jordan", value = "Jordan"}
            };
        }

        public class ToolbarItemModel
        {
            public string type { get; set; }
            public string template { get; set; }
            public string align { get; set; }
            public string tooltipText { get; set; }
            public string iconCss { get; set; }
        }
    }
}
