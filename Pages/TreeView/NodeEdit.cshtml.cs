#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeView
{
    public class NodeEditModel : PageModel
    {
        public List<object> TreeData = new List<object>();
        public void OnGet()
        {
            TreeData.Add(new
            {
                id = 1,
                name = "Discover Music",
                hasChild = true,
                expanded = true
            });
            TreeData.Add(new
            {
                id = 2,
                pid = 1,
                name = "Hot Singles",

            });
            TreeData.Add(new
            {
                id = 3,
                pid = 1,
                name = "Rising Artists"
            });

            TreeData.Add(new
            {
                id = 4,
                pid = 1,
                name = "Live Music"
            });
            TreeData.Add(new
            {
                id = 5,
                hasChild = true,
                name = "Sales and Events",

            });
            TreeData.Add(new
            {
                id = 6,
                pid = 5,
                name = "100 Albums - $5 Each",
            });
            TreeData.Add(new
            {
                id = 7,
                pid = 5,
                name = "Hip-Hop and R&B Sale"
            });
            TreeData.Add(new
            {
                id = 8,
                pid = 5,
                name = "CD Deals"
            });
            TreeData.Add(new
            {
                id = 10,
                hasChild = true,
                name = "Categories"
            });
            TreeData.Add(new
            {
                id = 11,
                pid = 10,
                name = "Bestselling Albums",

            });
            TreeData.Add(new
            {
                id = 12,
                pid = 10,
                name = "New Releases"
            });
            TreeData.Add(new
            {
                id = 13,
                pid = 10,
                name = "Bestselling Songs"
            });
            TreeData.Add(new
            {
                id = 14,
                hasChild = true,
                name = "MP3 Albums"
            });
            TreeData.Add(new
            {
                id = 15,
                pid = 14,
                name = "Rock"

            });
            TreeData.Add(new
            {
                id = 16,
                name = "Gospel",
                pid = 14,

            });
            TreeData.Add(new
            {
                id = 17,
                pid = 14,
                name = "Latin Music"

            });
            TreeData.Add(new
            {
                id = 18,
                pid = 14,
                name = "Jazz"

            });
            TreeData.Add(new
            {
                id = 19,
                hasChild = true,
                name = "More in Music"

            });
            TreeData.Add(new
            {
                id = 20,
                pid = 19,
                name = "Music Trade-In"
            });
            TreeData.Add(new
            {
                id = 21,
                name = "Redeem a Gift Card",
                pid = 19
            });
            TreeData.Add(new
            {
                id = 22,
                pid = 19,
                name = "Band T-Shirts"

            });
        }
    }
}
