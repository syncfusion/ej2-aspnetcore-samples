#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser.Models
{
    public class EditorMentionUser {
        public string Name { get; set; }
        public string Initial { get; set; }
        public string Email { get; set; }
        public string Color { get; set; }
        public string BgColor { get; set; }
        public List<EditorMentionUser> GetUserData() 
        {
            List<EditorMentionUser> data = new List<EditorMentionUser>
            {
                new EditorMentionUser { Name = "Selma Rose", Initial = "SR", Email = "selma@gmail.com", Color = "#FAFDFF", BgColor = "#01579B" },
                new EditorMentionUser { Name = "Maria", Initial = "MA", Email = "maria@gmail.com", Color = "#004378", BgColor = "#ADDBFF" },
                new EditorMentionUser { Name = "Russo Kay", Initial = "RK", Email = "russo@gmail.com", Color = "#F9DEDC", BgColor = "#8C1D18" },
                new EditorMentionUser { Name = "Robert", Initial = "RO", Email = "robert@gmail.com", Color = "#FFD6F7", BgColor = "#37003A" },
                new EditorMentionUser { Name = "Camden Kate", Initial = "CK", Email = "camden@gmail.com", Color = "#FFFFFF", BgColor = "#464ECF" },
                new EditorMentionUser { Name = "Garth", Initial = "GA", Email = "garth@gmail.com", Color = "#FFFFFF", BgColor = "#008861" },
                new EditorMentionUser { Name = "Andrew James", Initial = "AJ", Email = "james@gmail.com", Color = "#FFFFFF", BgColor = "#53CA17" },
                new EditorMentionUser { Name = "Olivia", Initial = "OL", Email = "olivia@gmail.com", Color = "#FFFFFF", BgColor = "#8C1D18" },
                new EditorMentionUser { Name = "Sophia", Initial = "SO", Email = "sophia@gmail.com", Color = "#000000", BgColor = "#D0BCFF" },
                new EditorMentionUser { Name = "Margaret", Initial = "MA", Email = "margaret@gmail.com", Color = "#000000", BgColor = "#F2B8B5" },
                new EditorMentionUser { Name = "Ursula Ann", Initial = "UA", Email = "ursula@gmail.com", Color = "#000000", BgColor = "#47ACFB" },
                new EditorMentionUser { Name = "Laura Grace", Initial = "LG", Email = "laura@gmail.com", Color = "#000000", BgColor = "#FFE088" },
                new EditorMentionUser { Name = "Albert", Initial = "AL", Email = "albert@gmail.com", Color = "#FFFFFF", BgColor = "#00335B" },
                new EditorMentionUser { Name = "William", Initial = "WA", Email = "william@gmail.com", Color = "#FFFFFF", BgColor = "#163E02" }
            };

            return data;
        }
    }
}