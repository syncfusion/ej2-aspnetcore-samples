using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EJ2CoreSampleBrowser.Models
{
    public class BlockEditorPasteSettings
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
                        new { contentType = "Text", content = "pasteCleanupSettings: {\n deniedTags: ['script', 'iframe'], // Tags to remove\n keepFormat: true, // Keep original formatting\n plainPaste: false // Force plain text paste\n;}" }
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

    }
}