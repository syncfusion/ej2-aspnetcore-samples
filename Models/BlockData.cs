#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace EJ2CoreSampleBrowser.Models
{
    public class BlockData
    {        
        public List<BlockModel> GetBlockDataAPI()
        {
            return new List<BlockModel>
            {
                new BlockModel
                {
                    id = "heading-block",
                    type = "Heading1",
                    content = new List<ContentModel>
                    {
                        new ContentModel
                        {
                            id = "heading-content",
                            type = "Text",
                            content = "Block Editor API Demo"
                        }
                    }
                },
                new BlockModel
                {
                    id = "intro-block",
                    type = "Paragraph",
                    content = new List<ContentModel>
                    {
                        new ContentModel
                        {
                            id = "intro-content",
                            type = "Text",
                            content = "The Block Editor enables users to create, format, and organize content using various block types."
                        }
                    }
                },
                new BlockModel
                {
                    id = "api-heading",
                    type = "Heading2",
                    content = new List<ContentModel>
                    {
                        new ContentModel
                        {
                            id = "api-heading-content",
                            type = "Text",
                            content = "API Features:"
                        }
                    }
                },
                new BlockModel { id = "api-list-1", type = "BulletList", content = new List<ContentModel> { new ContentModel { id = "api-list-1-content", type = "Text", content = "readOnly - allows to change it as a non-editable state." } } },
                new BlockModel { id = "api-list-2", type = "BulletList", content = new List<ContentModel> { new ContentModel { id = "api-list-2-content", type = "Text", content = "enableDragAndDrop - allows to control drag-and-drop operations within the block editor." } } },
                new BlockModel { id = "api-list-3", type = "BulletList", content = new List<ContentModel> { new ContentModel { id = "api-list-3-content", type = "Text", content = "enableHtmlEncode - Get the encoded string value through value property and source code panel." } } },
                new BlockModel { id = "api-list-4", type = "BulletList", content = new List<ContentModel> { new ContentModel { id = "api-list-4-content", type = "Text", content = "selectAllBlocks - Selects all blocks in the editor." } } },
                new BlockModel { id = "api-list-5", type = "BulletList", content = new List<ContentModel> { new ContentModel { id = "api-list-5-content", type = "Text", content = "focusIn - Focuses the editor." } } },
                new BlockModel { id = "api-list-6", type = "BulletList", content = new List<ContentModel> { new ContentModel { id = "api-list-6-content", type = "Text", content = "focusOut - Removes focus from the editor." } } },
                new BlockModel { id = "api-list-7", type = "BulletList", content = new List<ContentModel> { new ContentModel { id = "api-list-7-content", type = "Text", content = "getBlockCount - Gets total block count." } } },
                new BlockModel { id = "api-list-8", type = "BulletList", content = new List<ContentModel> { new ContentModel { id = "api-list-8-content", type = "Text", content = "getDataAsJson - Retrieves data from the editor as JSON." } } },
                new BlockModel { id = "api-list-9", type = "BulletList", content = new List<ContentModel> { new ContentModel { id = "api-list-9-content", type = "Text", content = "getDataAsHtml - Retrieves data from the editor as HTML." } } },
                new BlockModel
                {
                    id = "try-it-block",
                    type = "Paragraph",
                    content = new List<ContentModel>
                    {
                        new ContentModel
                        {
                            id = "try-it-content",
                            type = "Text",
                            content = "Try it out! Use the property panel on the right to interact with the API.",
                            styles = new StyleSettings
                            {
                                bold = true,
                                bgColor = "#999999"
                            }
                        }
                    }
                }
            };
        }

        public List<BlockModel> GetBlockDataOverview()
        {
            return new List<BlockModel>
            {
                new BlockModel
                {
                    id = "heading-block",
                    type = "Heading1",
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "heading-content", type = "Text", content = "Welcome to the Block Editor Demo!" }
                    }
                },
                new BlockModel
                {
                    id = "intro-block",
                    type = "Paragraph",
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "intro-content", type = "Text", content = "Block Editor is a powerful rich text editor that allows you to create structured content using blocks. Each block can be formatted, moved, or transformed into different types." }
                    }
                },
                new BlockModel
                {
                    id = "styled-paragraph",
                    type = "Paragraph",
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "styled-text-1", type = "Text", content = "Try selecting text to see " },
                        new ContentModel { id = "styled-text-2", type = "Text", content = "formatting options", styles = new StyleSettings { bold = true, italic = true } },
                        new ContentModel { id = "styled-text-3", type = "Text", content = " or type " },
                        new ContentModel { id = "styled-text-4", type = "Text", content = "\"/\"", styles = new StyleSettings { bgColor = "#999999", bold = true } },
                        new ContentModel { id = "styled-text-5", type = "Text", content = " to access the command menu." }
                    }
                },
                new BlockModel
                {
                    id = "block-types-heading",
                    type = "Heading2",
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "block-types-heading-content", type = "Text", content = "Block Types" }
                    }
                },
                new BlockModel
                {
                    id = "quote-block",
                    type = "Quote",
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "quote-content", type = "Text", content = "The Block Editor makes document creation a seamless experience with its intuitive block-based approach.", styles = new StyleSettings { italic = true } }
                    }
                },
                new BlockModel
                {
                    id = "callout-block",
                    type = "Callout",
                    children = new List<BlockModel>
                    {
                        new BlockModel
                        {
                            id = "callout-content",
                            type = "Paragraph",
                            content = new List<ContentModel>
                            {
                                new ContentModel { id = "callout-content-1", type = "Text", content = "Important: Block Editor supports various content types including Text, Link, Code, Mention, and Label.", styles = new StyleSettings { bold = true } }
                            }
                        }
                    }
                },
                new BlockModel
                {
                    id = "list-types-heading",
                    type = "Heading3",
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "list-types-heading-content", type = "Text", content = "List Types" }
                    }
                },
                new BlockModel
                {
                    id = "bullet-list-header",
                    type = "BulletList",
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "bullet-list-header-content", type = "Text", content = "Text blocks: Paragraph, Heading 1-4, Quote, Callout", styles = new StyleSettings { bold = true } }
                    }
                },
                new BlockModel
                {
                    id = "numbered-list",
                    type = "NumberedList",
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "numbered-list-content", type = "Text", content = "Lists: Bullet lists, Numbered lists, Check lists" }
                    }
                },
                new BlockModel
                {
                    id = "check-list",
                    type = "CheckList",
                    isChecked = true,
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "check-list-content", type = "Text", content = "Special blocks: Divider, Toggle, Code block" }
                    }
                },
                new BlockModel
                {
                    id = "divider-block",
                    type = "Divider",
                    content = new List<ContentModel>()
                },
                new BlockModel
                {
                    id = "toggle-block",
                    type = "ToggleParagraph",
                    isExpanded = true,
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "toggle-content", type = "Text", content = "Click me to expand/collapse" }
                    },
                    children = new List<BlockModel>
                    {
                        new BlockModel
                        {
                            id = "toggle-child",
                            type = "Paragraph",
                            content = new List<ContentModel>
                            {
                                new ContentModel { id = "toggle-child-content", type = "Text", content = "This content is inside a toggle block. Toggle blocks are useful for organizing content that can be expanded or collapsed." }
                            }
                        }
                    }
                },
                new BlockModel
                {
                    id = "code-block",
                    type = "Code",
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "code-content", type = "Text", content = "const editor = new BlockEditor();\neditor.appendTo(\"#element\");" }
                    }
                },
                new BlockModel
                {
                    id = "formatting-heading",
                    type = "Heading4",
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "formatting-heading-content", type = "Text", content = "Text Formatting Examples" }
                    }
                },
                new BlockModel
                {
                    id = "formatting-examples",
                    type = "Paragraph",
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "format-bold", type = "Text", content = "Bold ", styles = new StyleSettings { bold = true } },
                        new ContentModel { id = "format-italic", type = "Text", content = "Italic ", styles = new StyleSettings { italic = true } },
                        new ContentModel { id = "format-underline", type = "Text", content = "Underline ", styles = new StyleSettings { underline = true } },
                        new ContentModel { id = "format-strikethrough", type = "Text", content = "Strikethrough ", styles = new StyleSettings { strikethrough = true } },
                        new ContentModel { id = "format-superscript", type = "Text", content = "Superscript ", styles = new StyleSettings { superscript = true } },
                        new ContentModel { id = "format-subscript", type = "Text", content = "Subscript ", styles = new StyleSettings { subscript = true } },
                        new ContentModel { id = "format-uppercase", type = "Text", content = "uppercase ", styles = new StyleSettings { uppercase = true } },
                        new ContentModel { id = "format-lowercase", type = "Text", content = "LOWERCASE", styles = new StyleSettings { lowercase = true } }
                    }
                },
                new BlockModel
                {
                    id = "link-block",
                    type = "Paragraph",
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "link-text", type = "Text", content = "Visit " },
                        new ContentModel { id = "link-content", type = "Link", content = "Syncfusion", linkSettings = new LinkSettings { url = "https://www.syncfusion.com/", openInNewWindow = true } },
                        new ContentModel { id = "link-text-end", type = "Text", content = " for more information." }
                    }
                },
                new BlockModel
                {
                    id = "label-block",
                    type = "Paragraph",
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "label-text", type = "Text", content = "This block contains a " },
                        new ContentModel { id = "progress", type = "Label" },
                        new ContentModel { id = "label-text-end", type = "Text", content = " label." }
                    }
                },
                new BlockModel
                {
                    id = "try-it-block",
                    type = "Paragraph",
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "try-it-content", type = "Text", content = "Try it out! Click anywhere and start typing, or type \"/\" to see available commands.", styles = new StyleSettings { bold = true, bgColor = "#999999" } }
                    }
                }
            };
        }

        public List<BlockModel> GetBlockDataEvents()
        {
            return new List<BlockModel>
            {
                new BlockModel
                {
                    id = "heading-block",
                    type = "Heading1",
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "heading-content", type = "Text", content = "Block Editor Events Demo" }
                    }
                },
                new BlockModel
                {
                    id = "intro-block",
                    type = "Paragraph",
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "intro-content", type = "Text", content = "This sample demonstrates the events triggered by the Block Editor component. Try different actions to see the events in the trace panel." }
                    }
                },
                new BlockModel
                {
                    id = "features-heading",
                    type = "Heading2",
                    content = new List<ContentModel>
                    {
                        new ContentModel { id = "features-heading-content", type = "Text", content = "Notable Features:" }
                    }
                },
                new BlockModel { id = "feature-list-1", type = "BulletList", content = new List<ContentModel> { new ContentModel { id = "feature-list-1-content", type = "Text", content = "Block-based editing with various block types (paragraphs, headings, lists, etc.)" } } },
                new BlockModel { id = "feature-list-2", type = "BulletList", content = new List<ContentModel> { new ContentModel { id = "feature-list-2-content", type = "Text", content = "Slash commands for quick block transformation" } } },
                new BlockModel { id = "feature-list-3", type = "BulletList", content = new List<ContentModel> { new ContentModel { id = "feature-list-3-content", type = "Text", content = "Rich text formatting with inline toolbar" } } },
                new BlockModel { id = "feature-list-4", type = "BulletList", content = new List<ContentModel> { new ContentModel { id = "feature-list-4-content", type = "Text", content = "Hierarchical content organization with nested blocks" } } },
                new BlockModel { id = "feature-list-5", type = "BulletList", content = new List<ContentModel> { new ContentModel { id = "feature-list-5-content", type = "Text", content = "Block manipulation (move, delete, duplicate)" } } },
                new BlockModel { id = "feature-list-6", type = "BulletList", content = new List<ContentModel> { new ContentModel { id = "feature-list-6-content", type = "Text", content = "Keyboard shortcuts for efficient editing" } } },
                new BlockModel { id = "feature-list-7", type = "BulletList", content = new List<ContentModel> { new ContentModel { id = "feature-list-7-content", type = "Text", content = "Drag and drop functionality for blocks" } } },
                new BlockModel
                {
                    id = "try-it-block",
                    type = "Paragraph",
                    content = new List<ContentModel>
                    {
                        new ContentModel
                        {
                            id = "try-it-content",
                            type = "Text",
                            content = "Try different actions like typing, selecting text, adding blocks, or moving blocks to see the events triggered.",
                            styles = new StyleSettings { bold = true, bgColor = "#999999" }
                        }
                    }
                }
            };
        }
    }

    public class BlockModel
    {
        public string id { get; set; }
        public string type { get; set; }
        public bool? isChecked { get; set; }
        public bool? isExpanded { get; set; }
        public List<ContentModel> content { get; set; } = new List<ContentModel>();
        public List<BlockModel> children { get; set; } = new List<BlockModel>();
    }

    public class ContentModel
    {
        public string id { get; set; }
        public String type { get; set; }
        public string content { get; set; }
        public StyleSettings styles { get; set; }
        public LinkSettings linkSettings { get; set; }
    }

    public class StyleSettings
    {
        public bool bold { get; set; }
        public bool italic { get; set; }
        public bool underline { get; set; }
        public bool strikethrough { get; set; }
        public bool superscript { get; set; }
        public bool subscript { get; set; }
        public bool uppercase { get; set; }
        public bool lowercase { get; set; }
        public string bgColor { get; set; }
    }

    public class LinkSettings
    {
        public string url { get; set; }
        public bool openInNewWindow { get; set; }
    }
}
