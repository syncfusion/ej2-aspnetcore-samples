#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.EJ2.InteractiveChat;

namespace EJ2CoreSampleBrowser.Models
{
    public class ChatMessagesData
    {
        public List<ChatUIMessage> GetUserChatMessages()
        {
            List<ChatUIMessage> UserChatMessages = new List<ChatUIMessage>()
            {
                new ChatUIMessage() {
                    Text = "Hi there! How's it going?",
                    Author = new UserModel()
                    {
                        id = "user1",
                        user = "Albert",
                        avatarUrl = "../css/chatui/images/andrew.png"
                    }
                },
                new ChatUIMessage() { Text = "Hey! I'm doing well, thanks. How about you?", Author = new UserModel()
                    {
                        id = "user2",
                        user = "Reena",
                        avatarUrl = "../css/chatui/images/reena.png"
                    }
                },
                new ChatUIMessage() { Text = "Mostly the usual stuff. I did start a new hobby - painting!", Author = new UserModel()
                    {
                        id = "user1",
                        user = "Albert",
                        avatarUrl = "../css/chatui/images/andrew.png"
                    }
                },
            };
            return UserChatMessages;
        }

        public List<ChatUIMessage> GetCommunityMessageData()
        {
            List<ChatUIMessage> CommunityMessages = new List<ChatUIMessage>()
            {
                new ChatUIMessage() {
                    Text = "Hey Michale, Charlie! Seen the latest posts in the Design Community? Amazing projects!",
                    Author = new UserModel()
                    {
                        id = "admin",
                        user = "Alice"
                    },
                    TimeStamp = new DateTime(2024, 10, 25, 23, 07, 30)
                },
                new ChatUIMessage() {
                    Text = "Hi Alice! Yes, Dana’s new UI design is incredible.",
                    Author = new UserModel()
                    {
                        id = "user1",
                        user = "Michale Suyama"
                    },
                    TimeStamp = new DateTime(2024, 10, 25, 8, 0, 0)
                },
                new ChatUIMessage() {
                    Text = "Hey! I loved Dana’s use of color. Frank’s typography guide was great too.",
                    Author = new UserModel()
                    {
                        id = "user2",
                        user = "Charlie",
                        avatarUrl = "../css/chatui/images/charlie.png",
                        avatarBgColor = "#e6cdde"
                    },
                    TimeStamp = new DateTime(2024, 10, 25, 11, 0, 0)
                },
                new ChatUIMessage() {
                    Text = "Absolutely! Any new community events planned?",
                    Author = new UserModel()
                    {
                        id = "admin",
                        user = "Alice"
                    },
                    TimeStamp = new DateTime(2024, 10, 26, 11, 0, 0)
                },
                new ChatUIMessage() {
                    Text = "We should organize a design challenge.",
                    Author = new UserModel()
                    {
                        id = "user1",
                        user = "Michale Suyama"
                    },
                    TimeStamp = new DateTime(2024, 10, 26, 12, 15, 0)
                },
                new ChatUIMessage() {
                    Text = "I am excited to see the new projects.",
                    Author = new UserModel()
                    {
                        id = "user3",
                        user = "Janet",
                        avatarUrl = "../css/chatui/images/janet.png",
                        avatarBgColor = "#dec287"
                    },
                    TimeStamp = new DateTime(2024, 10, 26, 12, 17, 0)
                },
                new ChatUIMessage() {
                    Text = "Great idea! Let’s discuss it in the next meeting.",
                    Author = new UserModel()
                    {
                        id = "user2",
                        user = "Charlie",
                        avatarUrl = "../css/chatui/images/charlie.png",
                        avatarBgColor = "#e6cdde"
                    },
                    TimeStamp = new DateTime(2024, 10, 26, 12, 30, 0)
                },
                new ChatUIMessage() {
                    Text = "Sounds good! This community is so inspiring.",
                    Author = new UserModel()
                    {
                        id = "admin",
                        user = "Alice"
                    },
                    TimeStamp = DateTime.Now
                },
                new ChatUIMessage() {
                    Text = "Agreed! Excited to see everyone’s ideas.",
                    Author = new UserModel()
                    {
                        id = "user1",
                        user = "Michale Suyama"
                    },
                    TimeStamp = DateTime.Now
                },
                new ChatUIMessage() {
                    Text = "I am looking forward to the design challenge.",
                    Author = new UserModel()
                    {
                        id = "user2",
                        user = "Charlie",
                        avatarUrl = "../css/chatui/images/charlie.png",
                        avatarBgColor = "#e6cdde"
                    },
                    TimeStamp = DateTime.Now
                }
            };

            return CommunityMessages;
        }

        public class UserModel
        {
            public string id { get; set; }
            public string user { get; set; }
            public string avatarUrl { get; set; }
            public string avatarBgColor { get; set; }
        }
    }
}
