#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EJ2CoreSampleBrowser.Models
{
    public class BlockData
    {
        public class BlockModel
        {
            public string id { get; set; }
            public string blockType { get; set; }
            public object properties { get; set; }
            public List<object> content { get; set; }
            public List<BlockModel> children { get; set; }
        }
        public List<BlockModel> GetBlockDataAPI()
        {
            return new List<BlockModel>
            {
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 2 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Why Do We Need APIs for Web UI Components?" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "APIs (Application Programming Interfaces) are critical for modern web UI components because they:" }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Enable Customization: ", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = "Developers can tailor components to match application requirements without altering the core code." }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Improve Maintainability: ", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = "Clear APIs separate logic from presentation, making updates and debugging easier." }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Enhance Integration: ", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = "APIs allow components to interact seamlessly with other parts of the application or external services." }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Boost Productivity: ", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = "Predefined properties, methods, and events reduce development time by providing ready-to-use functionality." }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Usage of properties and methods" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "APIs in UI components typically expose properties and methods" }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 4 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "properties" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "properties define the state or configuration of the component." }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Example Use Cases:", properties = new { styles = new { bold = true } } }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Set the editor's read-only mode." }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Enable or disable persisting component's state between page reloads." }
                    }
                },
                new BlockModel
                {
                    blockType = "Code",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "blockEditor.readOnly = true;\nblockEditor.enablePersistence = true;" }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 4 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Methods" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Methods perform actions on the component dynamically." }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Example Use Cases:", properties = new { styles = new { bold = true } } }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Add or remove blocks programmatically." }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Retrieve JSON data content from the editor." }
                    }
                },
                new BlockModel
                {
                    blockType = "Code",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "const newBlock: BlockModel = {\n  id: 'new-block',\n  type: 'Paragraph',\n  content: [{\n    type: ContentType.Text,\n    content: 'This is a newly added block'\n  }]\n};\neditor.addBlock(newBlock, 'target-block-id');\nconst blockData = editor.getDataAsJson('new-block');" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph"
                }
            };
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
                    properties = new { src = "https://cdn.syncfusion.com/ej2/richtexteditor-resources/RTE-Overview.png", alt = "Block Editor Image" }
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
                    properties = new { indent = 1 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Concise points for quick scanning" }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    properties = new { indent = 1 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Great for features or tips" }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    properties = new { indent = 1 },
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
                    properties = new { indent = 1 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Start a new document" }
                    }
                },
                new BlockModel
                {
                    blockType = "NumberedList",
                    properties = new { indent = 1 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Add structure with headings" }
                    }
                },
                new BlockModel
                {
                    blockType = "NumberedList",
                    properties = new { indent = 1 },
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
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "“Quotes are perfect for highlighting key messages or testimonials.”" }
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

        public List<BlockModel> GetBlockDataEvents()
        {
            return new List<BlockModel>
            {
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 2 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Block Editor Event Handling" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "The Block Editor provides a comprehensive event system that allows developers to track user interactions and customize workflows. Events are essential for implementing real-time updates, analytics, and advanced features." }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Why events matter" }
                    }
                },
                new BlockModel
                {
                    id = "collapsible-why-events",
                    blockType = "CollapsibleParagraph",
                    content = new List<object>
                    {
                        new { id = "collapsible-why-title", contentType = "Text", content = "Events enable you to:", properties = new { styles = new { bold = true } } }
                    },
                    properties = new
                    {
                        isExpanded = true,
                        children = new List<BlockModel>
                        {
                            new BlockModel
                            {
                                id = "bl-why-1",
                                blockType = "BulletList",
                                content = new List<object>
                                {
                                    new { id = "bl-why-1-t", contentType = "Text", content = "Respond to content changes instantly." }
                                }
                            },
                            new BlockModel
                            {
                                id = "bl-why-2",
                                blockType = "BulletList",
                                content = new List<object>
                                {
                                    new { id = "bl-why-2-t", contentType = "Text", content = "Track user focus and engagement." }
                                }
                            },
                            new BlockModel
                            {
                                id = "bl-why-3",
                                blockType = "BulletList",
                                content = new List<object>
                                {
                                    new { id = "bl-why-3-t", contentType = "Text", content = "Monitor block-level actions for better control." }
                                }
                            },
                            new BlockModel
                            {
                                id = "bl-why-4",
                                blockType = "BulletList",
                                content = new List<object>
                                {
                                    new { id = "bl-why-4-t", contentType = "Text", content = "Implement custom behaviors and analytics." }
                                }
                            }
                        }
                    }
                },
                new BlockModel
                {
                    blockType = "Callout",
                    properties = new
                    {
                        children = new List<BlockModel>
                        {
                            new BlockModel
                            {
                                blockType = "Paragraph",
                                content = new List<object>
                                {
                                    new { contentType = "Text", content = "Tip: ", properties = new { styles = new { bold = true, color = "#047857" } } },
                                    new { contentType = "Text", content = "Use events wisely — avoid unnecessary listeners to maintain optimal performance." }
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
                        new { contentType = "Text", content = "Core events" }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "blockChange: ", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = "Detect when blocks are added, removed, transformed or updated." }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "focus: ", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = "Track active blocks when the editor gains focus." }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 4 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Basic usage" }
                    }
                },
                new BlockModel
                {
                    blockType = "Code",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "focus: (args: FocusEventArgs) => { \n// Custom actions when the editor gains focus\n} \nblockChanged: (args: BlockChangedEventArgs) {\n //Custom actions on a block are added, removed, transformed, or updated. \n}\n" }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Event usage in the Block Editor" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Events are commonly used for:" }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Autosave: ", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = "Trigger blockChange to save content periodically." }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Collaboration: ", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = "Sync changes in real-time using blockChange." }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Cases to avoid when binding events" }
                    }
                },
                new BlockModel
                {
                    blockType = "NumberedList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "High-frequency events without throttling: ", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = "Binding heavy logic to blockChange without debouncing can cause performance issues." }
                    }
                },
                new BlockModel
                {
                    blockType = "NumberedList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Duplicate listeners: ", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = "Adding multiple listeners for the same event can lead to memory leaks and unexpected behavior." }
                    }
                },
                new BlockModel
                {
                    blockType = "NumberedList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Unnecessary global listeners: ", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = "Avoid binding events that are not relevant to your workflow." }
                    }
                },
                new BlockModel
                {
                    blockType = "NumberedList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Complex operations inside event callbacks: ", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = "Heavy DOM manipulation or API calls inside frequent events can degrade the user experience." }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Best practices" }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Use debouncing for frequent events like blockChange." }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Remove listeners when they are no longer needed." }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Keep event callbacks lightweight and efficient." }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Combine events for analytics without impacting UX." }
                    }
                },
                new BlockModel
                {
                    blockType = "Quote",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "\"Every interaction tells a story — listen carefully.\"", properties = new { styles = new { italic = true } } }
                    },
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
        public List<BlockModel> GetBlockDataPaste()
        {
            return new List<BlockModel>
            {
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 2 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Smart Paste Cleanup" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Pasting content from external sources often introduces unwanted styles and inconsistent formatting. The Block Editor provides a powerful cleanup mechanism with customization options to maintain consistency and security." }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Features" }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Removes inline styles for cleaner markup." }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Preserves semantic structure like headings and paragraphs." }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Converts rich text into clean blocks for easy editing." }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Extracts links and mentions without clutter." }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Customization options" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "You can configure paste cleanup behavior using the following settings:" }
                    }
                },
                new BlockModel
                {
                    blockType = "Code",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "pasteCleanupSettings: {\n allowedStyles: ['color', 'font-weight'], // Styles to keep\n deniedTags: ['script', 'iframe'], // Tags to remove\n keepFormat: true, // Keep original formatting\n plainPaste: false // Force plain text paste\n;}" }
                    }
                },
                new BlockModel
                {
                    blockType = "Heading",
                    properties = new { level = 3 },
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Events" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Hooks for before and after paste actions:" }
                    }
                },
                new BlockModel
                {
                    blockType = "Code",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "afterPasteCleanup: (args: AfterPasteCleanupEventArgs) => { \n // Process pasted content or update UI \n } \n beforePasteCleanup: (args: BeforePasteCleanupEventArgs) => { \n // Modify content before cleanup if needed \n }" }
                    }
                },
                new BlockModel
                {
                    id = "collapsible-paste-modes",
                    blockType = "CollapsibleParagraph",
                    content = new List<object>
                    {
                        new { id = "collapsible-paste-modes-title", contentType = "Text", content = "Paste modes", properties = new { styles = new { bold = true } } }
                    },
                    properties = new
                    {
                        isExpanded = true,
                        children = new List<BlockModel>
                        {
                            new BlockModel
                            {
                                id = "bl-mode-1",
                                blockType = "BulletList",
                                content = new List<object>
                                {
                                    new { id = "bl-mode-1-t", contentType = "Text", content = "Keep Format: ", properties = new { styles = new { bold = true } } },
                                    new { id = "bl-mode-1-desc", contentType = "Text", content = "Retains allowed styles and structure." }
                                }
                            },
                            new BlockModel
                            {
                                id = "bl-mode-2",
                                blockType = "BulletList",
                                content = new List<object>
                                {
                                    new { id = "bl-mode-2-t", contentType = "Text", content = "Plain Paste: ", properties = new { styles = new { bold = true } } },
                                    new { id = "bl-mode-2-desc", contentType = "Text", content = "Strips all styles and converts to plain text." }
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
                        new { contentType = "Text", content = "Why cleanup matters" }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Clean content improves:" }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Readability: ", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = "No distracting styles." }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Accessibility: ", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = "Proper semantic tags." }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Consistency: ", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = "Uniform styling across platforms." }
                    }
                },
                new BlockModel
                {
                    blockType = "BulletList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Security: ", properties = new { styles = new { bold = true } } },
                        new { contentType = "Text", content = "Prevents malicious scripts or embeds." }
                    }
                },
                new BlockModel
                {
                    blockType = "Callout",
                    properties = new
                    {
                        children = new List<BlockModel>
                        {
                            new BlockModel
                            {
                                blockType = "Paragraph",
                                content = new List<object>
                                {
                                    new { contentType = "Text", content = "Tip: ", properties = new { styles = new { bold = true, color = "#047857" } } },
                                    new { contentType = "Text", content = "Use paste cleanup to remove inline styles while retaining semantic structure." }
                                }
                            },
                            new BlockModel
                            {
                                blockType = "Paragraph",
                                content = new List<object>
                                {
                                    new { contentType = "Text", content = "Clean content is clear content.", properties = new { styles = new { italic = true } } }
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
                        new { contentType = "Text", content = "Workflow" }
                    }
                },
                new BlockModel
                {
                    blockType = "NumberedList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Paste content from external sources." }
                    }
                },
                new BlockModel
                {
                    blockType = "NumberedList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Review the cleaned output." }
                    }
                },
                new BlockModel
                {
                    blockType = "NumberedList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Apply additional formatting if needed." }
                    }
                },
                new BlockModel
                {
                    blockType = "NumberedList",
                    content = new List<object>
                    {
                        new { contentType = "Text", content = "Save and publish." }
                    }
                },
                new BlockModel
                {
                    blockType = "Paragraph",
                }
            };
        }

        public class TemplatePage
        {
            public string Id { get; set; }
            public string Icon { get; set; }
            public string Name { get; set; }
            public string Subtitle { get; set; }
            public List<BlockModel> Blocks { get; set; } = new List<BlockModel>();
            public string path { get; set; }
        }

        // Expose initial blocks for first template
        public List<BlockModel> GetInitialTemplateBlocks()
        {
            var pages = GetTemplatePages();
            return pages.ElementAtOrDefault(1)?.Blocks ?? new List<BlockModel>();
        }

        public string GetTemplatePagesJson()
        {
            var pages = GetTemplatePages();
            var settings = new JsonSerializerSettings
            {
                Converters = new JsonConverter[] { new StringEnumConverter() },
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return JsonConvert.SerializeObject(pages, settings);
        }

        // Build all templates (converted from your MVC sample; moved Indent to properties.indent where relevant)
        public List<TemplatePage> GetTemplatePages()
        {
            return new List<TemplatePage>
            {
                GetBlankPage(),
                GetProjectBrief(),
                GetTeamDecisions(),
                GetProjectPlanning(),
                GetMeetingNotes()
            };
        }

        private TemplatePage GetBlankPage()
        {
            return new TemplatePage
            {
                Id = "Blank_Page",
                Icon = "📃",
                Name = "Blank Page",
                Subtitle = "Start from scratch",
                Blocks = new List<BlockModel>
                {
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    }
                }
            };
        }

        private static TemplatePage GetProjectBrief()
        {
            return new TemplatePage
            {
                Id = "Project_Brief",
                Icon = "📝️",
                Name = "Project Brief",
                Subtitle = "Plan, organize, and track",
                Blocks = new List<BlockModel>
                {
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "💫 Overview" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "Provide project background, core objectives, key stakeholders, and proposed timeline here — include an inspiring quote to set the tone." }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "🎯 Goals" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "List the primary project goals and desired outcomes." }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "NumberedList",
                        properties = new { placeholder = "Add item" }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "🧑‍💻 Team Members" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    // Table for Team Members
                    new BlockModel
                    {
                        blockType = "Table",
                        properties = new
                        {
                            columns = new List<object>
                            {
                                new { headerText = "Name" },
                                new { headerText = "Role" },
                                new { headerText = "Location" },
                                new { headerText = "Core working hours" }
                            },
                            rows = new List<object>
                            {
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Full Name" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Designation" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "City, Country" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Timezone / Hours" } } } }
                                    }
                                },
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Full Name" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Designation" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "City, Country" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Timezone / Hours" } } } }
                                    }
                                },
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Full Name" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Designation" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "City, Country" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Timezone / Hours" } } } }
                                    }
                                }
                            }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "🛠️ Project Deliverables" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    // Table for Project Deliverables
                    new BlockModel
                    {
                        blockType = "Table",
                        properties = new
                        {
                            columns = new List<object>
                            {
                                new { headerText = "Task / Deliverable" },
                                new { headerText = "Assigned to" },
                                new { headerText = "Due date" },
                                new { headerText = "Bucket / Status" }
                            },
                            rows = new List<object>
                            {
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "e.g., Finalize user flows" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "e.g., Lead Designer" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "e.g., 15 Dec" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "e.g., Design" } } } }
                                    }
                                },
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Add deliverable..." } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Owner" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Due date" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Bucket" } } } }
                                    }
                                },
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Add deliverable..." } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Owner" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Due date" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Bucket" } } } }
                                    }
                                }
                            }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "🔗 Relevant Links & Resources" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "BulletList",
                        properties = new { placeholder = "Add item" }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    }
                }
            };
        }

        private static TemplatePage GetTeamDecisions()
        {
            return new TemplatePage
            {
                Id = "Team_Decisions",
                Icon = "🦄",
                Name = "Team Decisions",
                Subtitle = "Ideate and decide",
                Blocks = new List<BlockModel>
                {
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "List relevant stakeholders here." }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "🐘 Question" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "Add question for the group decision here." }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "✨ Background context" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "Provide concise background and why this decision matters now." }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "🧊 Constraints" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "BulletList",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "List known limitations, risks, dependencies, or non-negotiables." }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "BulletList",
                        properties = new { placeholder = "Add item" }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "🤔 Assumptions" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "BulletList",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "List anything we’re assuming to be true (or false) for this decision." }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "BulletList",
                        properties = new { placeholder = "Add item" }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = " 🏓 Compare ideas" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    // Table for Compare ideas
                    new BlockModel
                    {
                        blockType = "Table",
                        properties = new
                        {
                            columns = new List<object>
                            {
                                new { headerText = "Idea" },
                                new { headerText = "Pros" },
                                new { headerText = "Cons" },
                                new { headerText = "Votes" }
                            },
                            rows = new List<object>
                            {
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "e.g., Launch with MVP in 6 weeks" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "e.g., Faster feedback, lower cost" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "e.g., Missing key features" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "0" } } } }
                                    }
                                },
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } }
                                    }
                                }
                            }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "👟 Next Steps" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    // Table for Next Steps
                    new BlockModel
                    {
                        blockType = "Table",
                        properties = new
                        {
                            columns = new List<object>
                            {
                                new { headerText = "Task" },
                                new { headerText = "Assigned to" },
                                new { headerText = "Due date" },
                                new { headerText = "Bucket" }
                            },
                            rows = new List<object>
                            {
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Task description" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Assignee" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Date" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "To do" } } } }
                                    }
                                },
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Task description" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Assignee" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Date" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "To do" } } } }
                                    }
                                }
                            }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "🎉 Final decision" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "Add final decision here." }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    }
                }
            };
        }

        private static TemplatePage GetProjectPlanning()
        {
            return new TemplatePage
            {
                Id = "Project_Planning",
                Icon = "💎",
                Name = "Project Planning",
                Subtitle = "Collaborate",
                Blocks = new List<BlockModel>
                {
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        content = new List<object>
                        {
                            new
                            {
                                contentType = "Label",
                                content = "Progress: In-progress",
                                properties = new { labelId = "progress" }
                            }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "🏆 Roles" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "Table",
                        properties = new
                        {
                            columns = new List<object>
                            {
                                new { headerText = "Roles" },
                                new { headerText = "Assignees" }
                            },
                            rows = new List<object>
                            {
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Designation" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Name" } } } }
                                    }
                                },
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Designation" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Name" } } } }
                                    }
                                }
                            }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "⭐ Background context" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "Briefly explain the business need, user problem, or opportunity this project addresses — include key industry context or triggers." }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "(Add an inspiring or strategic quote here to set the tone.)" }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "☁️ Opportunity statement" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "Clearly state the user/business problem, why it matters now, and the value or impact of solving it." }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "✏️ Assignments" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "Table",
                        properties = new
                        {
                            columns = new List<object>
                            {
                                new { headerText = "Job/feature" },
                                new { headerText = "When customers" },
                                new { headerText = "They should" },
                                new { headerText = "So that" }
                            },
                            rows = new List<object>
                            {
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Feature or task name" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Trigger or user context" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Desired action or behavior" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Business/user value or outcome" } } } }
                                    }
                                },
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } }
                                    }
                                }
                            }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "🥅 Goals" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "Define the measurable outcomes we want to achieve." }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Table",
                        properties = new
                        {
                            columns = new List<object>
                            {
                                new { headerText = "High priority" },
                                new { headerText = "Medium priority" },
                                new { headerText = "Low priority" }
                            },
                            rows = new List<object>
                            {
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "List critical must-achieve outcomes" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "List important but non-urgent outcomes" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "List nice-to-have or future outcomes" } } } }
                                    }
                                },
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } }
                                    }
                                }
                            }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "🚀 Milestones" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "Table",
                        properties = new
                        {
                            columns = new List<object>
                            {
                                new { headerText = "Work area" },
                                new { headerText = "Owner" },
                                new { headerText = "Progress" },
                                new { headerText = "End date" },
                                new { headerText = "Obstacles" }
                            },
                            rows = new List<object>
                            {
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "List major phase or deliverable" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Assign responsible person" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Current status or % complete" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Target completion date" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Note any blockers or risks" } } } }
                                    }
                                },
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } }
                                    }
                                }
                            }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "🌡️ Team temp check" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "Quick pulse: On a scale of 1–5, how confident are you right now with our direction, workload, and collaboration? Plus one thing that’s working well and one thing we should adjust." }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Table",
                        properties = new
                        {
                            columns = new List<object>
                            {
                                new { headerText = "Feelings" },
                                new { headerText = "Reflection" },
                                new { headerText = "Votes" }
                            },
                            rows = new List<object>
                            {
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "How you feel (e.g. Happy Thumbs Up Worried)" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "One sentence on what’s driving that feeling" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "0" } } } }
                                    }
                                },
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph" } } }
                                    }
                                }
                            }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "🔗 Relevant links" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "Add relevant links here." }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    }
                }
            };
        }

        private static TemplatePage GetMeetingNotes()
        {
            return new TemplatePage
            {
                Id = "Meeting_Notes",
                Icon = "✏️",
                Name = "Meeting Notes",
                Subtitle = "Sync and share",
                Blocks = new List<BlockModel>
                {
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "Add meeting date here." }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "📌 Topic" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "Add meeting topic here." }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "👥 Attendees" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    // Table for Attendees
                    new BlockModel
                    {
                        blockType = "Table",
                        properties = new
                        {
                            columns = new List<object>
                            {
                                new { headerText = "Name" },
                                new { headerText = "Role" }
                            },
                            rows = new List<object>
                            {
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Full Name" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Designation" } } } }
                                    }
                                },
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Full Name" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Designation" } } } }
                                    }
                                }
                            }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "📃 Agenda" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "BulletList",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "00:00–00:10 | Quick round of wins & current focus" }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "BulletList",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "00:10–00:40 | Review progress, blockers & next steps" }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "BulletList",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "00:40–00:55 | Open discussion & decisions needed" }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "✏️ Notes" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "Key discussion points, decisions, and action items" }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "BulletList",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "[Add key points discussed]" }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "BulletList",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "Decision: [Record any decisions made]" }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "BulletList",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "Action: [Task] → @owner → due [date]" }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "🎊 Tasks" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    // Table for Tasks
                    new BlockModel
                    {
                        blockType = "Table",
                        properties = new
                        {
                            columns = new List<object>
                            {
                                new { headerText = "Task" },
                                new { headerText = "Assigned to" },
                                new { headerText = "Due date" },
                                new { headerText = "Bucket" }
                            },
                            rows = new List<object>
                            {
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Task description" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Assignee" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Date" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "To do" } } } }
                                    }
                                },
                                new
                                {
                                    cells = new List<object>
                                    {
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Task description" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Assignee" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "Date" } } } },
                                        new { blocks = new List<BlockModel> { new BlockModel { blockType = "Paragraph", properties = new { placeholder = "To do" } } } }
                                    }
                                }
                            }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    },
                    new BlockModel
                    {
                        blockType = "Heading",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "🔗 Relevant links" }
                        },
                        properties = new { level = 4, placeholder = "Heading 4" }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        content = new List<object>
                        {
                            new { contentType = "Text", content = "Add relevant links here." }
                        }
                    },
                    new BlockModel
                    {
                        blockType = "Paragraph",
                        properties = new { placeholder = "Write something or ‘/’ for commands." }
                    }
                }
                    };
                }
    }
}