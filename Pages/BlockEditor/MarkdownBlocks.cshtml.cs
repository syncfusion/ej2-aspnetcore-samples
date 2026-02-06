#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser.Pages.Diagram;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.BlockEditor;
using Syncfusion.EJ2.Layouts;
using Syncfusion.EJ2.Navigations; // add this

namespace EJ2CoreSampleBrowser_NET9.Pages.BlockEditor
{
    public class MarkdownBlocksModel : PageModel
    {
        public string SidebarHeaderText { get; set; } = "Markdown Templates";
        public List<object> CommandMenuItems { get; set; }
        public string[] InlineToolbarItems { get; set; }

        // Strongly typed Breadcrumb items (required by TagHelper)
        public List<BreadcrumbItem> BreadcrumbItems { get; set; } = new()
        {
            new BreadcrumbItem { Text = "Team" }
        };

        public List<TreeNode> TreeData { get; set; } = new();

        // Serve from wwwroot/blockeditor/mdfiles
        public string InitialMdPath => TeamSessionsMdPath;
        public string TeamSessionsMdPath => "../BlockEditor/mdfiles/Team Sessions.md";

        public void OnGet()
        {
            TreeData = new List<TreeNode>
            {
                new TreeNode
                {
                    id = "Team Sessions",
                    name = "Team Sessions",
                    mdFile = TeamSessionsMdPath,
                    selected = true,
                    expanded = true,
                    children = new List<TreeNode>
                    {
                        new TreeNode { id = "1", name = "Meeting minutes.md",  mdFile = "../BlockEditor/mdfiles/Meeting minutes.md" },
                        new TreeNode { id = "2", name = "Brain storming.md",   mdFile = "../BlockEditor/mdfiles/Brain storming.md" },
                        new TreeNode { id = "3", name = "Retrospective.md",     mdFile = "../BlockEditor/mdfiles/Retrospective.md" }
                    }
                },
            };
            CommandMenuItems = new List<object>
            {
                new
                {
                    id = "bullet-list-command",
                    type = "BulletList",
                    groupBy = "General",
                    label = "Bullet List",
                    tooltip = "Create a bullet list",
                    iconCss = "e-icons e-list-unordered",
                    shortcut = "Ctrl+Shift+8"
                },
                new
                {
                    id = "numbered-list-command",
                    type = "NumberedList",
                    groupBy = "General",
                    label = "Numbered List",
                    tooltip = "Create a numbered list",
                    iconCss = "e-icons e-list-ordered",
                    shortcut = "Ctrl+Shift+9"
                },
                new
                {
                    id = "divider-command",
                    type = "Divider",
                    groupBy = "General",
                    label = "Divider",
                    tooltip = "Add a horizontal line",
                    iconCss = "e-icons e-be-divider",
                    shortcut = "Ctrl+Shift+-"
                },
                new
                {
                    id = "code-command",
                    type = "Code",
                    groupBy = "Insert",
                    label = "Code",
                    tooltip = "Insert a code block",
                    iconCss = "e-icons e-insert-code",
                    shortcut = "Ctrl+Alt+k"
                },
                new
                {
                    id = "table-command",
                    type = "Table",
                    groupBy = "Insert",
                    label = "Table",
                    tooltip = "Insert a table block",
                    iconCss = "e-icons e-table-2",
                    shortcut = "Ctrl+Alt+T"
                },
                new
                {
                    id = "paragraph-command",
                    type = "Paragraph",
                    groupBy = "Text Styles",
                    label = "Paragraph",
                    tooltip = "Add a paragraph",
                    iconCss = "e-icons e-be-paragraph",
                    shortcut = "Ctrl+Alt+P"
                },
                new
                {
                    id = "heading1-command",
                    type = "Heading",
                    groupBy = "Text Styles",
                    label = "Heading 1",
                    tooltip = "Page title or main heading",
                    iconCss = "e-icons e-be-h1",
                    shortcut = "Ctrl+Alt+1"
                },
                new
                {
                    id = "heading2-command",
                    type = "Heading",
                    groupBy = "Text Styles",
                    label = "Heading 2",
                    tooltip = "Section heading",
                    iconCss = "e-icons e-be-h2",
                    shortcut = "Ctrl+Alt+2"
                },
                new
                {
                    id = "heading3-command",
                    type = "Heading",
                    groupBy = "Text Styles",
                    label = "Heading 3",
                    tooltip = "Subsection heading",
                    iconCss = "e-icons e-be-h3",
                    shortcut = "Ctrl+Alt+3"
                },
                new
                {
                    id = "heading4-command",
                    type = "Heading",
                    groupBy = "Text Styles",
                    label = "Heading 4",
                    tooltip = "Smaller heading for nested content",
                    iconCss = "e-icons e-be-h4",
                    shortcut = "Ctrl+Alt+4"
                },
                new
                {
                    id = "quote-command",
                    type = "Quote",
                    groupBy = "Text Styles",
                    label = "Quote",
                    tooltip = "Insert a quote block",
                    iconCss = "e-icons e-blockquote",
                    shortcut = "Ctrl+Alt+Q"
                }
            };

            InlineToolbarItems = new string[] { "Bold", "Italic", "Underline", "StrikeThrough" };
    }


        public class TreeNode
        {
            public string id { get; set; }
            public string name { get; set; }
            public string mdFile { get; set; }
            public bool? selected { get; set; }
            public bool? expanded { get; set; }
            public List<TreeNode>? children { get; set; }
        }
    }
}