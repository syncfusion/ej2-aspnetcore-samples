using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EJ2CoreSampleBrowser.Models
{
    public class BlockEditorApi
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

    }
}