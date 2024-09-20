#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EJ2CoreSampleBrowser_NET6.Models
{
    public class FormatData
    {
        public string FormatName { get; set; }
        public string Command { get; set; }
        public string FormatType { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }

        public List<FormatData> FormatList()
        {

            List<FormatData> formats = new List<FormatData>()
            {
                new FormatData{ FormatName= "Text", Command= "P", FormatType= "Basic blocks", Icon= "e-btn-icon e-text e-icons", Description= "Writing with paragraphs"},
                new FormatData{ FormatName= "Quotation", Command= "BlockQuote", FormatType= "Basic blocks", Icon= "e-icons block-view", Description= "Insert a quote or citation"},
                new FormatData { FormatName= "Heading 1", Command= "H1", FormatType= "Basic blocks", Icon= "e-icons h1-view", Description= "Use this for a top level heading" },
                new FormatData { FormatName= "Heading 2", Command= "H2", FormatType= "Basic blocks", Icon= "e-icons h2-view", Description= "Use this for key sections" },
                new FormatData { FormatName= "Heading 3", Command= "H3", FormatType= "Basic blocks", Icon= "e-icons h3-view", Description= "Use this for sub sections and group headings" },
                new FormatData { FormatName= "Heading 4", Command= "H4", FormatType= "Basic blocks", Icon= "e-icons h4-view", Description= "Use this for deep headings" },
                new FormatData { FormatName= "Numbered list", Command= "OL", FormatType= "Basic blocks", Icon= "e-icons e-list-ordered icon", Description= "Create an ordered list" },
                new FormatData { FormatName= "Bulleted list", Command= "UL", FormatType= "Basic blocks", Icon= "e-icons e-list-unordered icon", Description= "Create an unordered list" },
                new FormatData { FormatName= "Table", Command= "CreateTable", FormatType= "Basic blocks", Icon= "e-icons e-table icon", Description= "Insert a table" },
                new FormatData { FormatName= "Emoji picker", Command= "EmojiPicker", FormatType= "Inline", Icon= "e-icons e-emoji", Description= "Use emojis to express ideas and emoticons" },
                new FormatData { FormatName= "Image", Command= "Image", FormatType= "Media", Icon= "e-icons e-image icon", Description= "Add image to your page" },
                new FormatData { FormatName= "Audio", Command= "Audio", FormatType= "Media", Icon= "e-icons e-audio icon", Description= "Add audio to your page" },
                new FormatData { FormatName= "Video", Command= "Video", FormatType= "Media", Icon= "e-icons e-video icon", Description= "Add video to your page"}

            };
            return formats;

        }
    }
}