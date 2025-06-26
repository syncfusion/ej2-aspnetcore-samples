#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2;
using Syncfusion.EJ2.Navigations;
namespace EJ2CoreSampleBrowser.Pages.Sidebar;

public class SidebarWithMenu : PageModel
{
    public Dictionary<string, object> HtmlAttribute = new Dictionary<string, object>()
        { { "class", "sidebar-menu" } };

    public List<MenuItem> MainMenuItems = new List<MenuItem>();
    public void OnGet()
    {
        MainMenuItems.Add(new MenuItem
        {
            Text = "Overview", IconCss = "icon-user icon",
            Items = new List<MenuItem>
            {
                new MenuItem { Text = "All Data" },
                new MenuItem { Text = "Category2" },
                new MenuItem { Text = "Category3" }
            }
        });
        MainMenuItems.Add(new MenuItem
        {
            Text = "Notification",
            IconCss = "icon-bell-alt icon",
            Items = new List<MenuItem>
            {
                new MenuItem { Text = "Change Profile" },
                new MenuItem { Text = "Add Name" },
                new MenuItem { Text = "Add Details" }
            }
        });
        MainMenuItems.Add(new MenuItem
        {
            Text = "Info",
            IconCss = "icon-tag icon",
            Items = new List<MenuItem>
            {
                new MenuItem { Text = "Message" },
                new MenuItem { Text = "Facebook" },
                new MenuItem { Text = "Twitter" }
            }
        });
        MainMenuItems.Add(new MenuItem
        {
            Text = "Comments",
            IconCss = "icon-comment-inv-alt2 icon",
            Items = new List<MenuItem>
            {
                new MenuItem { Text = "Category1 " },
                new MenuItem { Text = "Category2" },
                new MenuItem { Text = "Category3" }
            }
        });
        MainMenuItems.Add(new MenuItem
        {
            Text = "Bookmarks",
            IconCss = "icon-bookmark icon",
            Items = new List<MenuItem>
            {
                new MenuItem { Text = "All Comments" },
                new MenuItem { Text = "Add Comments" },
                new MenuItem { Text = "Delete Comments" }
            }
        });
        MainMenuItems.Add(new MenuItem
        {
            Text = "Images",
            IconCss = "icon-picture icon",
            Items = new List<MenuItem>
            {
                new MenuItem { Text = "Add Name" },
                new MenuItem { Text = "Add Mobile Number" }
            }
        });
        MainMenuItems.Add(new MenuItem
        {
            Text = "Users",
            IconCss = "icon-user icon",
            Items = new List<MenuItem>
            {
                new MenuItem { Text = "Mobile User" },
                new MenuItem { Text = "Laptop User" },
                new MenuItem { Text = "Desktop User" }
            }
        });
        MainMenuItems.Add(new MenuItem
        {
            Text = "Settings",
            IconCss = "icon-eye icon",
            Items = new List<MenuItem>
            {
                new MenuItem { Text = "Change Profile" },
                new MenuItem { Text = "Add Name" },
                new MenuItem { Text = "Add Details" }
            }
        });
        MainMenuItems.Add(new MenuItem
        {
            Text = "Info",
            IconCss = "icon-tag icon",
            Items = new List<MenuItem>
            {
                new MenuItem { Text = "Facebook" },
                new MenuItem { Text = "Mobile" }
            }
        });
    }
}