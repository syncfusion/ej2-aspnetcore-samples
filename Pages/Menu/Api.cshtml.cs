#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser_NET8.Pages.Menu;

public class ApiModel : PageModel
{
    public List<object> data { get; set; }
    public MenuFieldSettings menuFields { get; set; }
    public List<object> headerData { get; set; }
    public List<object> ddlData { get; set; }

    public void OnGet()
    {
         data = new List<object>() {
                new {
                    header = "Events",
                    subItems = new List<object>() {
                        new { text= "Conferences" },
                        new { text= "Music" },
                        new { text= "Workshops" }
                    }
                },
                new {
                    header = "Movies",
                    subItems = new List<object>() {
                        new { text= "Now Showing" },
                        new { text= "Coming Soon" }
                    }
                },
                new {
                    header = "Directory",
                    subItems = new List<object>() {
                        new { text= "Media Gallery" },
                        new { text= "Newsletters" }
                    }
                },
                new {
                    header = "Queries",
                    subItems = new List<object>() {
                        new { text= "Our Policy" },
                        new { text= "Site Map"},
                        new { text= "24x7 Support"}
                    }
                },
                new { header= "Services" }
            };
        
            menuFields = new MenuFieldSettings()
            {
                IconCss = "icon",
                Text = new string[] { "header", "text", "value" },
                Children = new string[] { "subItems", "options" }
            };
        
            headerData = new List<object>()
            {
                new { text= "Events" },
                new { text= "Movies"},
                new { text= "Directory" },
                new {text= "Queries" },
                new { text= "Services" }
            };
        
            ddlData = new List<object>()
            {
                new { value = "Horizontal", text = "Horizontal" },
                new { value = "Vertical", text = "Vertical" },
            };
    }
}