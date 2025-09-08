#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.EJ2.BlockEditor;

namespace EJ2CoreSampleBrowser.Models
{
    public class BlockData
    {
        public List<Block> GetBlockDataAPI()
        {
            return new List<Block>
            {
                new Block
                {
                    Id = "heading-block",
                    Type = BlockType.Heading,
                    Props = new { level = 1 },
                    Content = new List<object>
                    {
                        new { id = "heading-content", type = "Text", content = "Block Editor API Demo" }
                    }
                },
                new Block
                {
                    Id = "intro-block",
                    Type = BlockType.Paragraph,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "intro-content",
                            type = "Text",
                            content = "The Block Editor enables users to create, format, and organize content using various block types."
                        }
                    }
                },
                new Block
                {
                    Id = "api-heading",
                    Type = BlockType.Heading,
                    Props = new { level = 2 },
                    Content = new List<object>
                    {
                        new { id = "api-heading-content", type = "Text", content = "API Features:" }
                    }
                },
                new Block
                {
                    Id = "api-list-1",
                    Type = BlockType.BulletList,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "api-list-1-content",
                            type = "Text",
                            content = "readOnly - allows to change it as a non-editable state."
                        }
                    }
                },
                new Block
                {
                    Id = "api-list-2",
                    Type = BlockType.BulletList,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "api-list-2-content",
                            type = "Text",
                            content = "enableDragAndDrop - allows to control drag-and-drop operations within the block editor."
                        }
                    }
                },
                new Block
                {
                    Id = "api-list-3",
                    Type = BlockType.BulletList,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "api-list-3-content",
                            type = "Text",
                            content = "enableHtmlEncode - Get the encoded string value through value property and source code panel."
                        }
                    }
                },
                new Block
                {
                    Id = "api-list-4",
                    Type = BlockType.BulletList,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "api-list-4-content",
                            type = "Text",
                            content = "selectAllBlocks - Selects all blocks in the editor."
                        }
                    }
                },
                new Block
                {
                    Id = "api-list-5",
                    Type = BlockType.BulletList,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "api-list-5-content",
                            type = "Text",
                            content = "focusIn - Focuses the editor."
                        }
                    }
                },
                new Block
                {
                    Id = "api-list-6",
                    Type = BlockType.BulletList,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "api-list-6-content",
                            type = "Text",
                            content = "focusOut - Removes focus from the editor."
                        }
                    }
                },
                new Block
                {
                    Id = "api-list-7",
                    Type = BlockType.BulletList,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "api-list-7-content",
                            type = "Text",
                            content = "getBlockCount - Gets total block count."
                        }
                    }
                },
                new Block
                {
                    Id = "api-list-8",
                    Type = BlockType.BulletList,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "api-list-8-content",
                            type = "Text",
                            content = "getDataAsJson - Retrieves data from the editor as JSON."
                        }
                    }
                },
                new Block
                {
                    Id = "api-list-9",
                    Type = BlockType.BulletList,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "api-list-9-content",
                            type = "Text",
                            content = "getDataAsHtml - Retrieves data from the editor as HTML."
                        }
                    }
                },
                new Block
                {
                    Id = "try-it-block",
                    Type = BlockType.Paragraph,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "try-it-content",
                            type = "Text",
                            content = "Try it out! Use the property panel on the right to interact with the API.",
                            props = new { styles = new { bold = true, bgColor = "#999999" } }
                        }
                    }
                }
            };
        }

        public List<Block> GetBlockDataOverview()
        {
            return new List<Block>
            {
                new Block
                {
                    Id = "heading-block",
                    Type = BlockType.Heading,
                    Props = new { level = 1 },
                    Content = new List<object>
                    {
                        new { id = "heading-content", type = "Text", content = "Welcome to the Block Editor Demo!" }
                    }
                },
                new Block
                {
                    Id = "intro-block",
                    Type = BlockType.Paragraph,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "intro-content",
                            type = "Text",
                            content = "Block Editor is a powerful rich text editor that allows you to create structured content using blocks. Each block can be formatted, moved, or transformed into different types."
                        }
                    }
                },
                new Block
                {
                    Id = "styled-paragraph",
                    Type = BlockType.Paragraph,
                    Content = new List<object>
                    {
                        new { id = "styled-text-1", type = "Text", content = "Try selecting text to see " },
                        new
                        {
                            id = "styled-text-2",
                            type = "Text",
                            content = "formatting options",
                            props = new { styles = new { bold = true, italic = true } }
                        },
                        new { id = "styled-text-3", type = "Text", content = ", or type " },
                        new
                        {
                            id = "styled-text-4",
                            type = "Text",
                            content = "\"/\"",
                            props = new { styles = new { bgColor = "#999999", bold = true } }
                        },
                        new { id = "styled-text-5", type = "Text", content = " to access the command menu." }
                    }
                },
                new Block
                {
                    Id = "block-types-heading",
                    Type = BlockType.Heading,
                    Props = new { level = 2 },
                    Content = new List<object>
                    {
                        new { id = "block-types-heading-content", type = "Text", content = "Block Types" }
                    }
                },
                new Block
                {
                    Id = "quote-block",
                    Type = BlockType.Quote,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "quote-content",
                            type = "Text",
                            content = "The Block Editor makes document creation a seamless experience with its intuitive block-based approach.",
                            props = new { styles = new { italic = true } }
                        }
                    }
                },
                new Block
                {
                    Id = "callout-block",
                    Type = BlockType.Callout,
                    Props = new {
                        Children = new List<object>
                        {
                            new Block
                            {
                                Id = "callout-content",
                                Type = BlockType.Paragraph,
                                Content = new List<object>
                                {
                                    new
                                    {
                                        id = "callout-content-1",
                                        type = "Text",
                                        content = "Important: Block Editor supports various content types including Text, Link, Code, Mention, and Label.",
                                        props = new { styles = new { bold = true } }
                                    }
                                }
                            }
                        }
                    }
                },
                new Block
                {
                    Id = "list-types-heading",
                    Type = BlockType.Heading,
                    Props = new { level = 3 },
                    Content = new List<object>
                    {
                        new { id = "list-types-heading-content", type = "Text", content = "List Types" }
                    }
                },
                new Block
                {
                    Id = "bullet-list-header",
                    Type = BlockType.BulletList,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "bullet-list-header-content",
                            type = "Text",
                            content = "Text blocks: Paragraph, Heading 1-4, Quote, Callout",
                            props = new { styles = new { bold = true } }
                        }
                    }
                },
                new Block
                {
                    Id = "numbered-list",
                    Type = BlockType.NumberedList,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "numbered-list-content",
                            type = "Text",
                            content = "Lists: Bullet lists, Numbered lists, Check lists"
                        }
                    }
                },
                new Block
                {
                    Id = "check-list",
                    Type = BlockType.Checklist,
                    Props = new { isChecked = true },
                    Content = new List<object>
                    {
                        new
                        {
                            id = "check-list-content",
                            type = "Text",
                            content = "Special blocks: Divider, Toggle, Code block"
                        }
                    }
                },
                new Block
                {
                    Id = "divider-block",
                    Type = BlockType.Divider
                },
                new Block
                {
                    Id = "toggle-block",
                    Type = BlockType.CollapsibleParagraph,
                    Content = new List<object>
                    {
                        new { id = "toggle-content", type = "Text", content = "Click me to expand/collapse" }
                    },
                    Props = new {
                        IsExpanded = true,
                        Children = new List<object>
                        {
                            new Block
                            {
                                Id = "toggle-child",
                                Type = BlockType.Paragraph,
                                Content = new List<object>
                                {
                                    new
                                    {
                                        id = "toggle-child-content",
                                        type = "Text",
                                        content = "This content is inside a toggle block. Toggle blocks are useful for organizing content that can be expanded or collapsed."
                                    }
                                }
                            }
                        }
                    }
                },
                new Block
                {
                    Id = "code-block",
                    Type = BlockType.Code,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "code-content",
                            type = "Text",
                            content = "const editor = new BlockEditor();\neditor.appendTo(\"#element\");"
                        }
                    }
                },
                new Block
                {
                    Id = "formatting-heading",
                    Type = BlockType.Heading,
                    Props = new { level = 4 },
                    Content = new List<object>
                    {
                        new { id = "formatting-heading-content", type = "Text", content = "Text Formatting Examples" }
                    }
                },
                new Block
                {
                    Id = "formatting-examples",
                    Type = BlockType.Paragraph,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "format-bold",
                            type = "Text",
                            content = "Bold ",
                            props = new { styles = new { bold = true } }
                        },
                        new
                        {
                            id = "format-italic",
                            type = "Text",
                            content = "Italic ",
                            props = new { styles = new { italic = true } }
                        },
                        new
                        {
                            id = "format-underline",
                            type = "Text",
                            content = "Underline ",
                            props = new { styles = new { underline = true } }
                        },
                        new
                        {
                            id = "format-strikethrough",
                            type = "Text",
                            content = "Strikethrough ",
                            props = new { styles = new { strikethrough = true } }
                        },
                        new
                        {
                            id = "format-superscript",
                            type = "Text",
                            content = "Superscript ",
                            props = new { styles = new { superscript = true } }
                        },
                        new
                        {
                            id = "format-subscript",
                            type = "Text",
                            content = "Subscript ",
                            props = new { styles = new { subscript = true } }
                        },
                        new
                        {
                            id = "format-uppercase",
                            type = "Text",
                            content = "uppercase ",
                            props = new { styles = new { uppercase = true } }
                        },
                        new
                        {
                            id = "format-lowercase",
                            type = "Text",
                            content = "LOWERCASE",
                            props = new { styles = new { lowercase = true } }
                        }
                    }
                },
                new Block
                {
                    Id = "link-block",
                    Type = BlockType.Paragraph,
                    Content = new List<object>
                    {
                        new { id = "link-text", type = "Text", content = "Visit " },
                        new
                        {
                            id = "link-content",
                            type = "Link",
                            content = "Syncfusion",
                            props = new { url = "https://www.syncfusion.com/", openInNewWindow = true }
                        },
                        new { id = "link-text-end", type = "Text", content = " for more information." }
                    }
                },
                new Block
                {
                    Id = "label-block",
                    Type = BlockType.Paragraph,
                    Content = new List<object>
                    {
                        new { id = "label-text", type = "Text", content = "This block contains a " },
                        new { id = "progress-label", type = "Label", props = new { labelId = "progress" } },
                        new { id = "label-text-end", type = "Text", content = " label." }
                    }
                },
                new Block
                {
                    Id = "try-it-block",
                    Type = BlockType.Paragraph,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "try-it-content",
                            type = "Text",
                            content = "Try it out! Click anywhere and start typing, or type \"/\" to see available commands.",
                            props = new { styles = new { bold = true, bgColor = "#999999" } }
                        }
                    }
                }
            };
        }

        public List<Block> GetBlockDataEvents()
        {
            return new List<Block>
            {
                new Block
                {
                    Id = "heading-block",
                    Type = BlockType.Heading,
                    Props = new { level = 1 },
                    Content = new List<object>
                    {
                        new { id = "heading-content", type = "Text", content = "Block Editor Events Demo" }
                    }
                },
                new Block
                {
                    Id = "intro-block",
                    Type = BlockType.Paragraph,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "intro-content",
                            type = "Text",
                            content = "This sample demonstrates the events triggered by the Block Editor component. Try different actions to see the events in the trace panel."
                        }
                    }
                },
                new Block
                {
                    Id = "features-heading",
                    Type = BlockType.Heading,
                    Props = new { level = 2 },
                    Content = new List<object>
                    {
                        new { id = "features-heading-content", type = "Text", content = "Notable Features:" }
                    }
                },
                new Block
                {
                    Id = "feature-list-1",
                    Type = BlockType.BulletList,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "feature-list-1-content",
                            type = "Text",
                            content = "Block-based editing with various block types (paragraphs, headings, lists, etc.)"
                        }
                    }
                },
                new Block
                {
                    Id = "feature-list-2",
                    Type = BlockType.BulletList,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "feature-list-2-content",
                            type = "Text",
                            content = "Slash commands for quick block transformation"
                        }
                    }
                },
                new Block
                {
                    Id = "feature-list-3",
                    Type = BlockType.BulletList,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "feature-list-3-content",
                            type = "Text",
                            content = "Rich text formatting with inline toolbar"
                        }
                    }
                },
                new Block
                {
                    Id = "feature-list-4",
                    Type = BlockType.BulletList,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "feature-list-4-content",
                            type = "Text",
                            content = "Hierarchical content organization with nested blocks"
                        }
                    }
                },
                new Block
                {
                    Id = "feature-list-5",
                    Type = BlockType.BulletList,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "feature-list-5-content",
                            type = "Text",
                            content = "Block manipulation (move, delete, duplicate)"
                        }
                    }
                },
                new Block
                {
                    Id = "feature-list-6",
                    Type = BlockType.BulletList,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "feature-list-6-content",
                            type = "Text",
                            content = "Keyboard shortcuts for efficient editing"
                        }
                    }
                },
                new Block
                {
                    Id = "feature-list-7",
                    Type = BlockType.BulletList,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "feature-list-7-content",
                            type = "Text",
                            content = "Drag and drop functionality for blocks"
                        }
                    }
                },
                new Block
                {
                    Id = "try-it-block",
                    Type = BlockType.Paragraph,
                    Content = new List<object>
                    {
                        new
                        {
                            id = "try-it-content",
                            type = "Text",
                            content = "Try different actions like typing, selecting text, adding blocks, or moving blocks to see the events triggered.",
                            props = new { styles = new { bold = true, bgColor = "#999999" } }
                        }
                    }
                }
            };
        }
    }
}
