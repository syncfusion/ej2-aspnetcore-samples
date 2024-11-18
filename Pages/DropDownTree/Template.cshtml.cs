#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.DropDownTree;

public class Template : PageModel
{
    public List<object> localData = new List<object>();
    public void OnGet()
    {
        localData.Add(new { id = 1, name = "Steven Buchanan", hasChild = true, expanded = true, image = "10", job = "General Manager", status = "busy" });
        localData.Add(new { id = 2, pid = 1, name = "Laura Callahan", image = "2", job = "Product Manager", hasChild = true, status = "online" });
        localData.Add(new { id = 3, pid = 2, name = "Andrew Fuller", image = "7", job = "Team Lead", hasChild = true, status = "away" });
        localData.Add(new { id = 4, pid = 3, name = "Anne Dodsworth", image = "1", job = "Developer", status = "busy" });
        localData.Add(new { id = 5, pid = 3, name = "Lilly", image = "5", job = "Developer", status = "online" });
        localData.Add(new { id = 6, pid = 1, name = "Nancy Davolio", image = "4", job = "Product Manager", hasChild = true, status = "online" });
        localData.Add(new { id = 7, pid = 6, name = "Michael Suyama", image = "9", job = "Team Lead", hasChild = true, status = "away" });
        localData.Add(new { id = 8, pid = 7, name = "Robert King", image = "8", job = "Developer", status = "busy" });
        localData.Add(new { id = 9, pid = 7, name = "Mary", image = "6", job = "Developer", status = "away" });
        localData.Add(new { id = 10, pid = 1, name = "Janet Leverling", image = "3", job = "HR", status = "online" });
    }
}