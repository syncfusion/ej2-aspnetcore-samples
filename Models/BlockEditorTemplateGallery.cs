using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EJ2CoreSampleBrowser.Models
{
    public class BlockEditorTemplateGallery
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