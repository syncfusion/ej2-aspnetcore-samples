#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.ChatUI
{
    public class ChatIntegrationModel : PageModel
    {
        public List<MessageData> IntegrationMessagedata { get; set; }
        public List<MessageData> BotMessagedata { get; set; }
        public List<MessageData> WalterMessagedata { get; set; }
        public List<MessageData> LauraMessagedata { get; set; }
        public List<MessageData> TeamsMessagedata { get; set; }
        public List<MessageData> SuyamaMessagedata { get; set; }
        public List<TemplateData> IntegrationListTemplateData { get; set; }
        public List<ToolbarItemModel> HeaderToolbar { get; set; } = new List<ToolbarItemModel>();
        public List<BotDataModel> BotData = new List<BotDataModel>();
        public string[] ChatSuggestions;

        public void OnGet()
        {
            ChatSuggestions = new string[] { "Bedroom", "Kitchen" };
            HeaderToolbar.Add(new ToolbarItemModel { tooltipText = "Audio call", align = "Right", iconCss = "sf-icon-phone-call" });

            BotData = new List<BotDataModel>
            {
                new BotDataModel
                {
                    text = "Bedroom",
                    reply = "For a bedroom, we can create a serene and calm atmosphere with neutral colors and comfortable bedding.",
                    suggestions = new List<string> { "Garden", "Balcony" }
                },
                new BotDataModel
                {
                    text = "Kitchen",
                    reply = "For a kitchen, we can go for a modern, sleek look with stainless steel appliances and minimalist cabinetry. </br> <p>Any other home decor suggestions you'd like to explore ?</p>",
                    suggestions = new List<string> { "Wall art", "Plants" }
                }
            };
            IntegrationListTemplateData = new List<TemplateData>
            {
                new TemplateData
                {
                    id = "01",
                    title = "Albert",
                    imgSrc = "andrew",
                    message = "Okay, I'll try that. Thanks for the help!"
                },
                new TemplateData
                {
                    id = "02",
                    title = "Bot",
                    imgSrc = "bot",
                    message = "Personal decor assistant"
                },
                new TemplateData
                {
                    id = "03",
                    title = "Charlie",
                    imgSrc = "charlie",
                    message = "Great! Let's finalize our plans this weekend."
                },
                new TemplateData
                {
                    id = "04",
                    title = "Laura",
                    imgSrc = "laura",
                    message = "10 AM works for me."
                },
                new TemplateData
                {
                    id = "05",
                    title = "New Dev Team",
                    imgSrc = "calendar",
                    message = "User added"
                },
                new TemplateData
                {
                    id = "06",
                    title = "Reena",
                    imgSrc = "reena",
                    message = "Hi, are you available ?"
                }
            };

            var IntegrationMessageUser1 = new Author { id = "user1", user = "Reena", avatarUrl = "../css/chatui/images/reena.png" };
            var IntegrationMessageUser2 = new Author { id = "user2", user = "Albert", avatarUrl = "../css/chatui/images/andrew.png" };

            IntegrationMessagedata = new List<MessageData>
            {
                new MessageData
                {
                    author = IntegrationMessageUser1,
                    text = "Hey, I'm having trouble with my computer. It keeps freezing."
                },
                new MessageData
                {
                    author = IntegrationMessageUser2,
                    text = "Oh, that's annoying. Have you tried restarting it?"
                },
                new MessageData
                {
                    author = IntegrationMessageUser1,
                    text = "Yeah, I did, but it didn't help."
                },
                new MessageData
                {
                    author = IntegrationMessageUser2,
                    text = "Sometimes, outdated software or malware can cause issues."
                },
                new MessageData
                {
                    author = IntegrationMessageUser1,
                    text = "Okay, I'll try that. Thanks for the help!"
                }
            };

            var BotMessagedataUser = new Author { id = "bot", user = "Bot", avatarUrl = "../css/chatui/images/bot.png" };

            BotMessagedata = new List<MessageData>
            {
                new MessageData
                {
                    author = BotMessagedataUser,
                    text = "Hello Sam, I am a virtual assistant."
                },
                new MessageData
                {
                    author = BotMessagedataUser,
                    text = "Which room are you looking to decorate?"
                }
            };

            var WalterMessageUser1 = new Author { id = "user2", user = "Sam", avatarUrl = "../css/chatui/images/laura.png" };
            var WalterMessageUser2 = new Author { id = "user5", user = "Charlie", avatarUrl = "../css/chatui/images/charlie.png" };

            WalterMessagedata = new List<MessageData>
            {
                new MessageData
                {
                    author = WalterMessageUser1,
                    text = "Hey Charlie, have you thought about where you want to go for our vacation?"
                },
                new MessageData
                {
                    author = WalterMessageUser2,
                    text = "Hi Sam! I was thinking about going to Bali. I've heard the beaches are beautiful and there's so much to do."
                },
                new MessageData
                {
                    author = WalterMessageUser1,
                    text = "Bali sounds amazing! I've always wanted to try surfing. Do you know any good places to stay?"
                },
                new MessageData
                {
                    author = WalterMessageUser2,
                    text = "Yes, I found a few nice resorts and some budget-friendly options too. I'll send you the links."
                },
                new MessageData
                {
                    author = WalterMessageUser1,
                    text = "Great! Let's finalize our plans this weekend."
                }
            };

            var LauraMessageUser1 = new Author { id = "user1", user = "Laura Callahan", avatarUrl = "../css/chatui/images/laura.png" };
            var LauraMessageUser2 = new Author { id = "user3", user = "Sam", avatarUrl = "../css/chatui/images/laura.png" };

            LauraMessagedata = new List<MessageData>
            {
                new MessageData
                {
                    author = LauraMessageUser1,
                    text = "Hey Sam, can we have a quick meeting tomorrow morning to discuss the new project?"
                },
                new MessageData
                {
                    author = LauraMessageUser2,
                    text = "Sure, what time works best for you?"
                },
                new MessageData
                {
                    author = LauraMessageUser1,
                    text = "10 AM?"
                },
                new MessageData
                {
                    author = LauraMessageUser2,
                    text = "10 AM works for me."
                }
            };

            TeamsMessagedata = new List<MessageData>
            {
                new MessageData
                {
                    author = new Author { id = "team", user = "Admin" },
                    text = "Hi, everyone! Welcome to the new web team."
                },
                new MessageData
                {
                    author = new Author { id = "user2", user = "Janet", avatarUrl = "../css/chatui/images/janet.png" },
                    text = "Hi Sir, excited about the new team."
                },
                new MessageData
                {
                    author = new Author { id = "user3", user = "Margaret Peacock" },
                    text = "Good morning! Surprised with the new team message."
                },
                new MessageData
                {
                    author = new Author { id = "user2", user = "Charlie", avatarUrl = "../css/chatui/images/charlie.png" },
                    text = "Hi all, what's the purpose of this new team formation?"
                },
                new MessageData
                {
                    author = new Author { id = "team", user = "Admin" },
                    text = "Charlie, we are planning for a new portal launch, hence grouping all in one place."
                }
            };

            SuyamaMessagedata = new List<MessageData>
            {
                new MessageData
                {
                    author = new Author { id = "user4", user = "Reena" },
                    text = "Hi, are you available?"
                }
            };
        }

        public class MessageData
        {
            public Author author { get; set; }
            public string text { get; set; }
        }

        public class Author
        {
            public string id { get; set; }
            public string user { get; set; }
            public string avatarUrl { get; set; }
        }

        public class TemplateData
        {
            public string id { get; set; }
            public string title { get; set; }
            public string imgSrc { get; set; }
            public string message { get; set; }
        }

        public class ToolbarItemModel
        {
            public string tooltipText { get; set; }
            public string align { get; set; }
            public string iconCss { get; set; }
        }

        public class BotDataModel
        {
            public string text { get; set; }
            public string reply { get; set; }
            public List<string> suggestions { get; set; }
        }
    }
}
