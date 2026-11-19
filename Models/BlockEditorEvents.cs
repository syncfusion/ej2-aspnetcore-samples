using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EJ2CoreSampleBrowser.Models
{
    public class BlockEditorEvents
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
        
    }
}