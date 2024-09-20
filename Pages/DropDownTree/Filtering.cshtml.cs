#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.DropDownTree;

public class Filtering : PageModel
{
    public List<object> Parent = new List<object>();
    public void OnGet()
    {
        Parent.Add(new { id = 1, name = "Discover Music", hasChild = true, expanded = true });
        Parent.Add(new { id = 2, pid = 1, name = "Hot Singles" });
        Parent.Add(new { id = 3, pid = 1, name = "Rising Artists" });
        Parent.Add(new { id = 4, pid = 1, name = "Live Music" });
        Parent.Add(new { id = 7, name = "Sales and Events", hasChild = true });
        Parent.Add(new { id = 8, pid = 7, name = "100 Albums - $5 Each" });
        Parent.Add(new { id = 9, pid = 7, name = "Hip-Hop and R&B Sale" });
        Parent.Add(new { id = 10, pid = 7, name = "CD Deals" });
        Parent.Add(new { id = 11, name = "Categories", hasChild = true });
        Parent.Add(new { id = 12, pid = 11, name = "Songs" });
        Parent.Add(new { id = 13, pid = 11, name = "Bestselling Albums" });
        Parent.Add(new { id = 14, pid = 11, name = "New Releases" });
        Parent.Add(new { id = 15, pid = 11, name = "Bestselling Songs" });
        Parent.Add(new { id = 16, name = "MP3 Albums", hasChild = true });
        Parent.Add(new { id = 17, pid = 16, name = "Rock" });
        Parent.Add(new { id = 18, pid = 16, name = "Gospel" });
        Parent.Add(new { id = 19, pid = 16, name = "Latin Music" });
        Parent.Add(new { id = 20, pid = 16, name = "Jazz" });
        Parent.Add(new { id = 21, name = "More in Music", hasChild = true });
        Parent.Add(new { id = 22, pid = 21, name = "Music Trade-In" });
        Parent.Add(new { id = 23, pid = 21, name = "Redeem a Gift Card" });
        Parent.Add(new { id = 24, pid = 21, name = "Band T-Shirts" });
        Parent.Add(new { id = 25, name = "Fiction Book Lists", hasChild = true });
        Parent.Add(new { id = 26, pid = 25, name = "To Kill a Mockingbird" });
        Parent.Add(new { id = 27, pid = 25, name = "Pride and Prejudice" });
        Parent.Add(new { id = 28, pid = 25, name = "Harry Potter" });
        Parent.Add(new { id = 29, pid = 25, name = "The Hobbit" });
    }
}