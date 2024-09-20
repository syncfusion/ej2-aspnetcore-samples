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
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser_NET8.Pages.Ribbon;

public class RibbonBackstageModel : PageModel
{
    public List<MenuItem> pasteOptions { get; set; }
    public List<MenuItem> findOptions { get; set; }
    public List<MenuItem> selectOptions { get; set; }
    public List<MenuItem> dictateOptions { get; set; }
    public List<MenuItem> tableOptions { get; set; }
    public List<MenuItem> shapeOptions { get; set; }
    public List<MenuItem> headerOptions { get; set; }
    public List<MenuItem> footerOptions { get; set; }
    public List<MenuItem> pageOptions { get; set; }
    public List<MenuItem> linkOptions { get; set; }
    public List<MenuItem> fileOptions { get; set; }
    public string[] pictureOptions { get; set; }
    public List<string> fontSize { get; set; }
    public List<string> fontStyle { get; set; }
    public List<RibbonGroupButtonItem> groupButtonMultiple { get; set; }
    public List<RibbonGroupButtonItem> groupButtonSingle { get; set; }
    public List<BackstageItem> backstageItems { get; set; }
    public object backButtonSettings { get; set; }
    
    public void OnGet()
    {
    pasteOptions = new List<MenuItem>() { new MenuItem { Text = "Keep Source Format" }, new MenuItem { Text = "Merge Format" }, new MenuItem { Text = "Keep Text Only" } };
    findOptions = new List<MenuItem>() { new MenuItem { Text = "Find", IconCss = "e-icons e-search" }, new MenuItem { Text = "Advanced Find", IconCss = "e-icons e-search" }, new MenuItem { Text = "Go to", IconCss = "e-icons e-arrow-right" } };
    selectOptions = new List<MenuItem>() { new MenuItem { Text = "Select All" }, new MenuItem { Text = "Select Objects" } };
    dictateOptions = new List<MenuItem>() { new MenuItem { Text = "Chinese" }, new MenuItem { Text = "English" }, new MenuItem { Text = "German" }, new MenuItem { Text = "French" } };
    tableOptions = new List<MenuItem>() { new MenuItem { Text = "Insert Table" }, new MenuItem { Text = "Draw Table" }, new MenuItem { Text = "Convert Table" }, new MenuItem { Text = "Excel Spreadsheet" } };
    shapeOptions = new List<MenuItem>() { new MenuItem { Text = "Lines" }, new MenuItem { Text = "Rectangles" }, new MenuItem { Text = "Basic Arrows" }, new MenuItem { Text = "Basic Shapes" }, new MenuItem { Text = "FlowChart" } };
    headerOptions = new List<MenuItem>() { new MenuItem { Text = "Insert Header" }, new MenuItem { Text = "Edit Header" }, new MenuItem { Text = "Remove Header" } };
    footerOptions = new List<MenuItem>() { new MenuItem { Text = "Insert Footer" }, new MenuItem { Text = "Edit Footer" }, new MenuItem { Text = "Remove Footer" } };
    pageOptions = new List<MenuItem>() { new MenuItem { Text = "Insert Top of page" }, new MenuItem { Text = "Insert Bottom of page" }, new MenuItem { Text = "Format Page Number" }, new MenuItem { Text = "Remove Page Number" } };
    linkOptions = new List<MenuItem>() { new MenuItem { Text = "Insert Link", IconCss = "e-icons e-link" }, new MenuItem { Text = "Recent Links", IconCss = "e-icons e-clock" }, new MenuItem { Text = "Bookmarks", IconCss = "e-icons e-bookmark" } };
    pictureOptions = new string[] { "This Device", "Stock Images", "Online Images" };

    fontSize = new List<string>() { "8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", "36", "48", "72", "96" };
    fontStyle = new List<string>() { "Algerian", "Arial", "Calibri", "Cambria", "Cambria Math", "Courier New", "Candara", "Georgia", "Impact", "Segoe Print", "Segoe Script", "Segoe UI", "Symbol", "Times New Roman", "Verdana", "Windings" };
   groupButtonSingle = new List<RibbonGroupButtonItem>() {
      new RibbonGroupButtonItem { IconCss = "e-icons e-align-left", Selected = true, Click="function(){updateContent('Align Left')}" },
      new RibbonGroupButtonItem {IconCss = "e-icons e-align-center", Click="function(){updateContent('Align Center')}" },
      new RibbonGroupButtonItem {IconCss = "e-icons e-align-right", Click="function(){updateContent('Align Right')}" },
      new RibbonGroupButtonItem { IconCss = "e-icons e-justify", Click="function(){updateContent('Justify')}" }
    };
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
    var backstageData = new RibbonData() { };
    backstageItems = new List<BackstageItem>() {
        new BackstageItem { Id = "home", Text = "Home", IconCss = "e-icons e-home", Content = processBackstageContent("home") },
        new BackstageItem { Id = "new", Text = "New", IconCss = "e-icons e-file-new", Content = processBackstageContent("new") },
        new BackstageItem { Id = "open", Text = "Open", IconCss = "e-icons e-folder-open", Content = processBackstageContent("open") },
        new BackstageItem { Separator = true },
        new BackstageItem { Text = "Info", Content = processBackstageContent("info") },
        new BackstageItem { Text = "Save as", Content = processBackstageContent("save") },
        new BackstageItem { Text = "Export", Content = processBackstageContent("export") },
        new BackstageItem { Text = "Print", BackStageItemClick = "backstageClickHandler" },
        new BackstageItem { Text = "Share", Content = processBackstageContent("share") },
        new BackstageItem { Separator = true, IsFooter = true },
        new BackstageItem { Text = "Account", IsFooter = true, Content = processBackstageContent("account") },
        new BackstageItem { Text = "Feedback", IsFooter = true, Content = processBackstageContent("feedback") }
    };
    backButtonSettings = new { text = "Close" };
    string processBackstageContent(string item)
    {
        string homeContentTemplate = "<div class='home-wrapper'>{{newSection}}{{recentSection}}</div>";
        string newSection = "<div class='new-wrapper'><div class='section-title'> New </div><div class='category_container'><div class='doc_category_image'></div> <span class='doc_category_text'> New document </span></div></div>";
        string recentSection = "<div class='block-wrapper'><div class='section-title'> Recent </div>{{recentWrapper}}</div>";
        string recentWrapper = "<div class='section-content'><table><tbody><tr><td> <span class='doc_icon e-icons {{icon}}'></span> </td><td><span style='display: block; font-size: 14px'> {{title}} </span><span style='font-size: 12px'> {{description}} </span></td></tr></tbody></table></div>";
        string blockSection = "<div class='block-wrapper'> <div class='section-title'> {{blockTitle}} </div> {{blockSection}} </div>";
        string content = "";
        string recentDocUpdatedString = "";
        switch (item) {
            case "home": 
                {
                    int documentCount = 0;
                    foreach(var docs in backstageData.RecentDocuments) 
                    {
                        if(documentCount >=3)
                        {
                            break;
                        }
                        recentDocUpdatedString += recentWrapper.Replace("{{icon}}", "e-notes").Replace("{{title}}", docs.FileName).Replace("{{description}}", docs.Location);
                        documentCount++;
                    }
                string updatedRecentSection = recentSection.Replace("{{recentWrapper}}", recentDocUpdatedString);
                content = homeContentTemplate.Replace("{{newSection}}", newSection).Replace("{{recentSection}}", updatedRecentSection);
                break;
            }
            case "new":
            {
                content = newSection;
                break;
            }
            case "open":
            {
                foreach (var doc in backstageData.RecentDocuments)
                {
                    recentDocUpdatedString += recentWrapper.Replace("{{icon}}", "e-notes").Replace("{{title}}", doc.FileName).Replace("{{description}}", doc.Location);
                }
                string updatedRecentSection = recentSection.Replace("{{recentWrapper}}", recentDocUpdatedString);
                content = updatedRecentSection;
                break;
            }
            default:
            {
                foreach (var doc in backstageData.DataOptions[item])
                {
                    recentDocUpdatedString += recentWrapper.Replace("{{icon}}", doc.Icon).Replace("{{title}}", doc.Title).Replace("{{description}}", doc.Description);
                }
                string updatedBlockSection = blockSection.Replace("{{blockSection}}", recentDocUpdatedString).Replace("{{blockTitle}}", char.ToUpper(item[0]) +item.Substring(1));
                content = updatedBlockSection;
                break;
            }
        }
        return content;
    }
    }
}