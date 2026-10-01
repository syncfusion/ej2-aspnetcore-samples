using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EJ2CoreSampleBrowser.Models
{
    public class BlockEditorOverview
    {
        public class BlockModel
        {
            public string id { get; set; }
            public string blockType { get; set; }
            public object properties { get; set; }
            public List<object> content { get; set; }
            public List<BlockModel> children { get; set; }
            public int indent { get; set; }
        }
          public List<BlockModel> GetBlockDataOverview()
        {
            return new List<BlockModel>
            {
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 2 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Welcome to the Block Editor Demo!" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Welcome to the " },
                        new { contentType = "Text", content = "Block Editor", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = "! This demo highlights all supported block types and inline formatting options. Each section below explains the purpose of the block and shows how it appears in the editor." }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Paragraph" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Paragraph blocks are used for writing regular text. They are the most common block type and support inline formatting to enhance readability and emphasis." }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Inline Formatting" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Use " },
                        new { contentType = "Text", content = "bold", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = ", " },
                        new { contentType = "Text", content = "italic", properties = new { styles = new { italic = true } } },
                        new { contentType = "Text", content = ", and " },
                        new { contentType = "Text", content = "underline", properties = new { styles = new { underline = true } } },
                        new { contentType = "Text", content = " for emphasis; or " },
                        new { contentType = "Text", content = "strikethrough", properties = new { styles = new { strikethrough = true } } },
                        new { contentType = "Text", content = " to indicate removals or outdated text." }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Math and chemistry: E = mc" },
                        new { contentType = "Text", content = "2", properties = new { styles = new { superscript = true } } },
                        new { contentType = "Text", content = ", H" },
                        new { contentType = "Text", content = "2", properties = new { styles = new { subscript = true } } },
                        new { contentType = "Text", content = "O - with superscript and subscript. Add inline code " },
                        new { contentType = "Text", content = "const x = 10;", properties = new { inlineCode = true }  },
                        new { contentType = "Text", content = " and helpful " },
                        new { contentType = "Link", content = "links", properties = new { url = "https://ej2.syncfusion.com/documentation/block-editor/getting-started" } },
                        new { contentType = "Text", content = " for quick references." }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Transform text to " },
                        new { contentType = "Text", content = "uppercase", properties = new { styles = new { uppercase = true } } },
                        new { contentType = "Text", content = " or " },
                        new { contentType = "Text", content = "LOWERCASE", properties = new { styles = new { lowercase = true } } },
                        new { contentType = "Text", content = ". Add " },
                        new { contentType = "Text", content = "color", properties = new { styles = new { color = "green" } } },
                        new { contentType = "Text", content = " or " },
                        new { contentType = "Text", content = "background highlights", properties = new { styles = new { bgColor = "#FEF3C7", color = "#92400E" } } },
                        new { contentType = "Text", content = " as needed. Mention " },
                        new { contentType = "Mention", properties = new { userId = "user1" } },
                        new { contentType = "Text", content = " and tag with " },
                        new { contentType = "Label", properties = new { labelId = "progress" } },
                        new { contentType = "Text", content = " to add context." }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3, placeholder = "Heading 3" },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Table" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Table blocks organize data in rows and columns for easy comparison or presentation. They support headers and basic styling" }
                    }
                },
                 new BlockModel
                {
                    blockType = "Table",
                    properties = new
                    {
                        columns = new List<object>
                        {
                            new { headerText = "Name" },
                            new { headerText = "Age" },
                            new { headerText = "Gender" },
                            new { headerText = "Occupation" },
                            new { headerText = "Mode of Transport" }
                        },
                        rows = new List<object>
                        {
                            new
                            {
                                cells = new List<object>
                                {
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "Selma Rose" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "30" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "Female" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "Engineer" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "🚴" } } } } }
                                }
                            },
                            new
                            {
                                cells = new List<object>
                                {
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "Robert" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "28" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "Male" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "Graphic Designer" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "🚗" } } } } }
                                }
                            },
                            new
                            {
                                cells = new List<object>
                                {
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "William" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "35" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "Male" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "Teacher" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "🚗" } } } } }
                                }
                            },
                            new
                            {
                                cells = new List<object>
                                {
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "Laura Grace" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "42" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "Female" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "Doctor" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "🚌" } } } } }
                                }
                            },
                            new
                            {
                                cells = new List<object>
                                {
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "Andrew James" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "45" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "Male" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "Lawyer" } } } } },
                                    new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", content = new List<object> { new { contentType = "Text", content = "🚕" } } } } }
                                }
                            }
                        }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Image Block" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Image blocks allow you to insert visuals to support or enhance your content." }
                    }
                },
                new BlockModel
                {
                    blockType = "Image",
                    properties = new { src = "../css/blockeditor/images/overview.png", alt = "Block Editor Image" }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Checklist" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Checklists help track tasks or steps:" }
                    }
                },
                new BlockModel
                {
                    blockType = "Checklist",
                    properties = new { isChecked = true },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Apply inline formatting" }
                    }
                },
                new BlockModel
                {
                    blockType = "Checklist",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Invite reviewer " },
                        new { contentType = "Mention", properties = new { userId = "user2" } }
                    }
                },
                new BlockModel
                {
                    blockType = "Checklist",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Publish guide and share " },
                        new { contentType = "Link", content = "the link", properties = new { url = "https://ej2.syncfusion.com/documentation/block-editor/getting-started" } }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Lists" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Lists organize information clearly:" }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Unordered List", properties = new { styles = new { bold = true } } }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    indent = 1,
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Concise points for quick scanning" }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    indent = 1,
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Great for features or tips" }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    indent = 1,
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Easy to reorder and nest" }
                    }
                },
                new BlockModel
                {
                    blockType = "NumberedList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Ordered List", properties = new { styles = new { bold = true } } }
                    }
                },
                new BlockModel
                {
                    blockType = "NumberedList",
                    indent = 1, 
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Start a new document" }
                    }
                },
                new BlockModel
                {
                    blockType = "NumberedList",
                    indent = 1,
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Add structure with headings" }
                    }
                },
                new BlockModel
                {
                    blockType = "NumberedList",
                    indent = 1,
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Fill in content and review" }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Headings" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Headings help organize content into sections. Use different levels " },
                        new { contentType = "Text", content = "(h1, h2, h3 or h4)", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = " to create a hierarchy:" }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Quote" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Use quote blocks to emphasize important statements or references." }
                    }
                },
                new BlockModel
                {
                    blockType = "Quote",
                    properties = new
                    {
                        children = new List<BlockModel>
                        {
                            new BlockModel
                            {
                                blockType = "Paragraph",
                                content = new List<object>
                                {
                                    new { contentType = "Text", content = "“Quotes are perfect for highlighting key messages or testimonials.”" }
                                }
                            }
                        }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Callout" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Callouts are great for tips, warnings, or notes that need attention." }
                    }
                },
                new BlockModel
                {
                    blockType = "Callout",
                    properties = new
                    {
                        children = new List<object>
                        {
                            new BlockModel
                            {
                                blockType = "Paragraph",
                                content = new List<object>
                                {
                                    new { contentType = "Text", content = "Tip: ", properties = new { styles = new { bold = true } } },
                                    new { contentType = "Text", content = "Use the " },
                                    new { contentType = "Text", content = "/ ", properties = new { inlineCode = true }  },
                                    new { contentType = "Text", content = "command to quickly insert blocks like headings, lists, or code." }
                                }
                            }
                        }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Code Block" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Use code blocks to display syntax-highlighted code snippets for technical documentation or tutorials." }
                    }
                },
                new BlockModel
                {
                    blockType = "Code",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "function greet(name) {\n return `Hello, ${name}!`;\n}" }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Toggle Block" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Toggle blocks are interactive and help manage long or optional content." }
                    }
                },
                new BlockModel
                {
                    id = "toggle-block",
                    blockType = "CollapsibleParagraph",
                    content = new List<object>
                    {
                        new { id = "toggle-title", contentType = "Text", content = "Click to expand", properties = new { styles = new { bold = true } } }
                    },
                    properties = new {
                        isExpanded = false,
                        children = new List<object>
                        {
                            new BlockModel
                            {
                                id = "toggle-child-1",
                                blockType = "Paragraph",
                                content = new List<object>
                                {
                                    new { id = "tc-1", contentType = "Text", content = "This is a toggle block. You can hide or show content as needed. Useful for FAQs or detailed sections." }
                                }
                            }
                        }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Divider" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Dividers are horizontal lines used to separate sections or indicate a break in content." }
                    }
                },
                new BlockModel
                {
                    blockType = "Divider"
                },

                new BlockModel
                {
                    blockType = "Paragraph"
                }
            };
        }
    
        public class UserModel
        {
            public string id { get; set; }
            public string user { get; set; }
            public string avatarUrl { get; set; }
            public string avatarBgColor { get; set; }
            public string statusIconCss { get; set; }
        }
        public List<UserModel> GetUniqueMentionUsers()
        {
            return new List<UserModel>
                {
                    new UserModel
                    {
                        id = "user1",
                        user = "Andrews",
                        avatarUrl = "../css/blockeditor/images/andrew.png",
                    },
                    new UserModel
                    {
                        id = "user2",
                        user = "Charlie",
                        avatarUrl = "../css/blockeditor/images/charlie.png"
                    },
                    new UserModel
                    {
                        id = "user3",
                        user = "Laura",
                        avatarUrl = "../css/blockeditor/images/laura.png",
                    }
                };
        }
    }
}