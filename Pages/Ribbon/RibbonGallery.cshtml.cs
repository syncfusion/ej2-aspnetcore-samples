#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Ribbon;
using Syncfusion.EJ2.Navigations;
namespace EJ2CoreSampleBrowser.Pages.Ribbon;

public class RibbonGalleryModel : PageModel
{
    public List<MenuItem> pasteOptions { get; set; }
    public List<MenuItem> dictateOptions { get; set; }
    public List<MenuItem> tableOptions { get; set; }
    public List<MenuItem> shapeOptions { get; set; }
    public List<MenuItem> headerOptions { get; set; }
    public List<MenuItem> footerOptions { get; set; }
    public List<MenuItem> pageOptions { get; set; }
    public List<MenuItem> linkOptions { get; set; }
    public List<MenuItem> fileOptions { get; set; }
    public string[] pictureOptions { get; set; }
    
    public void OnGet()
    {
    pasteOptions = new List<MenuItem>() { new MenuItem { Text = "Keep Source Format" }, new MenuItem { Text = "Merge Format" }, new MenuItem { Text = "Keep Text Only" } };
    tableOptions = new List<MenuItem>() { new MenuItem { Text = "Insert Table" }, new MenuItem { Text = "Draw Table" }, new MenuItem { Text = "Convert Table" }, new MenuItem { Text = "Excel SpreadSheet" } };
    dictateOptions = new List<MenuItem>() { new MenuItem { Text = "Chinese" }, new MenuItem { Text = "English" }, new MenuItem { Text = "German" }, new MenuItem { Text = "French" } };
    shapeOptions = new List<MenuItem>() { new MenuItem { Text = "Lines" }, new MenuItem { Text = "Rectangles" }, new MenuItem { Text = "Basic Arrows" }, new MenuItem { Text = "Basic Shapes" }, new MenuItem { Text = "FlowChart" } };
    headerOptions = new List<MenuItem>() { new MenuItem { Text = "Insert Header" }, new MenuItem { Text = "Edit Header" }, new MenuItem { Text = "Remove Header" } };
    footerOptions = new List<MenuItem>() { new MenuItem { Text = "Insert Footer" }, new MenuItem { Text = "Edit Footer" }, new MenuItem { Text = "Remove Footer" } };
    pageOptions = new List<MenuItem>() { new MenuItem { Text = "Insert Top of page" }, new MenuItem { Text = "Insert Bottom of page" }, new MenuItem { Text = "Format Page Number" }, new MenuItem { Text = "Remove Page Number" } };
    linkOptions = new List<MenuItem>() { new MenuItem { Text = "Insert Link", IconCss = "e-icons e-link" }, new MenuItem { Text = "Recent Links", IconCss = "e-icons e-clock" }, new MenuItem { Text = "Bookmarks", IconCss = "e-icons e-bookmark" } };
    pictureOptions = new string[] { "This Device", "Stock Images", "Online Images" };

    fileOptions = new List<MenuItem>() {
        new MenuItem { Text = "New", IconCss = "e-icons e-file-new", Id="new" },
        new MenuItem { Text = "Open", IconCss = "e-icons e-folder-open", Id="Open" },
        new MenuItem { Text = "Rename", IconCss = "e-icons e-rename", Id="rename" },
        new MenuItem { Text = "Save as", IconCss = "e-icons e-save", Id="save",
        Items= new List<MenuItem>() {
                new MenuItem { Text = "Microsoft Word (.docx)", IconCss = "sf-icon-word", Id="word" },
                new MenuItem { Text = "Microsoft Word 97-2003(.doc)", IconCss = "sf-icon-word", Id="word97" },
                new MenuItem { Text = "Download as PDF", IconCss = "e-icons e-export-pdf", Id="pdf" },
            }
        }
    };
    }
}