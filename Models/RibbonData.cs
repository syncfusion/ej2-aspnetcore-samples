#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Models
{
    public class RibbonData
    {
        public class RecentDocument
        {
            public string FileName { get; set; }
            public string Location { get; set; }
        }

        public class DataOption
        {
            public string Icon { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }

        public List<RecentDocument> RecentDocuments { get; set; }
        public Dictionary<string, List<DataOption>> DataOptions { get; set; }

        public RibbonData()
        {
            RecentDocuments = new List<RecentDocument>
            {
                new RecentDocument
                {
                    FileName = "Classic_layout.docx",
                    Location = "EJ2 >> Components >> Navigations >> Ribbon >> layouts"
                },
                new RecentDocument
                {
                    FileName = "Simplified_layout.docx",
                    Location = "EJ2 >> Components >> Navigations >> Ribbon >> layouts"
                },
                new RecentDocument
                {
                    FileName = "Ribbon_resize.docx",
                    Location = "EJ2 >> Components >> Navigations >> Ribbon >> resize"
                },
                new RecentDocument
                {
                    FileName = "Ribbon_backstage.docx",
                    Location = "EJ2 >> Components >> Navigations >> Ribbon >> backstage"
                },
                new RecentDocument
                {
                    FileName = "Ribbon_overflow.docx",
                    Location = "EJ2 >> Components >> Navigations >> Ribbon >> overflow"
                },
                new RecentDocument
                {
                    FileName = "Custom_items.docx",
                    Location = "EJ2 >> Components >> Navigations >> Ribbon >> items"
                }
            };

            DataOptions = new Dictionary<string, List<DataOption>>
        {
            {
                "info",
                new List<DataOption>
                {
                    new DataOption
                    {
                        Icon = "e-open-link",
                        Title = "Open in Desktop App",
                        Description = "Use the full functionality of Ribbon"
                    },
                    new DataOption
                    {
                        Icon = "e-protect-sheet",
                        Title = "Protect Document",
                        Description = "To prevent accidental changes, this document has been set to open as view-only."
                    },
                    new DataOption
                    {
                        Icon = "e-send-to-back",
                        Title = "Version History",
                        Description = "View previous versions"
                    }
                }
            },
            {
                "save",
                new List<DataOption>
                {
                    new DataOption
                    {
                        Icon = "e-save",
                        Title = "Save as",
                        Description = "Save a copy online"
                    },
                    new DataOption
                    {
                        Icon = "e-rename",
                        Title = "Rename",
                        Description = "Rename this file"
                    },
                    new DataOption
                    {
                        Icon = "e-download",
                        Title = "Download a Copy",
                        Description = "Download a local copy"
                    },
                    new DataOption
                    {
                        Icon = "e-export-pdf",
                        Title = "Download as PDF",
                        Description = "Download a copy as PDF file"
                    },
                    new DataOption
                    {
                        Icon = "e-chevron-down-fill",
                        Title = "Download as ODT",
                        Description = "Download a copy as ODT file"
                    }
                }
            },
            {
                "export",
                new List<DataOption>
                {
                    new DataOption
                    {
                        Icon = "e-transform-right",
                        Title = "Transform to Web Page",
                        Description = "Transform your document into an interactive webpage"
                    },
                    new DataOption
                    {
                        Icon = "e-export",
                        Title = "Export to PowerPoint presentation",
                        Description = "Export your document into a multi-slide presentation"
                    },
                    new DataOption
                    {
                        Icon = "e-protect-workbook",
                        Title = "Send documents to Kindle",
                        Description = "Send documents to your Kindle device to read and annotate the documents"
                    }
                }
            },
            {
                "print",
                new List<DataOption>
                {
                    new DataOption
                    {
                        Icon = "e-print-layout",
                        Title = "Print",
                        Description = "Print this document"
                    }
                }
            },
            {
                "share",
                new List<DataOption>
                {
                    new DataOption
                    {
                        Icon = "e-arrow-right-up",
                        Title = "Share with People",
                        Description = "Invite other people to view or edit this document"
                    },
                    new DataOption
                    {
                        Icon = "e-protect-workbook",
                        Title = "Embed",
                        Description = "Embed this document in your blog or website"
                    }
                }
            },
            {
                "account",
                new List<DataOption>
                {
                    new DataOption
                    {
                        Icon = "e-people",
                        Title = "Account type",
                        Description = "Administrator"
                    },
                    new DataOption
                    {
                        Icon = "e-password",
                        Title = "Password protected",
                        Description = "Yes"
                    },
                    new DataOption
                    {
                        Icon = "e-text-that-contains",
                        Title = "E-mail",
                        Description = "abc@gmail.com"
                    }
                }
            },
            {
                "feedback",
                new List<DataOption>
                {
                    new DataOption
                    {
                        Icon = "e-check",
                        Title = "I Like Something",
                        Description = "It's nice to know when we have made a positive change."
                    },
                    new DataOption
                    {
                        Icon = "e-close",
                        Title = "I Don't Like Something",
                        Description = "If something's not right, we'd like to know so we can fix it."
                    },
                    new DataOption
                    {
                        Icon = "e-comment-add",
                        Title = "I Have a Suggestion",
                        Description = "Do you have an idea for a new feature or an improvement?"
                    }
                }
            }
        };
        }
    }
}
