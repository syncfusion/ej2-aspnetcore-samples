#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.Tab;

public class Orientation : PageModel
{
    public List<object> Rome = new List<object>();
    public List<object> Paris = new List<object>();
    public List<object> London = new List<object>();
    public void OnGet()
    {
        Rome.Add(new { Id = "1", Name = "Anne Dodsworth", Role = "Product Manager" });
        Rome.Add(new { Id = "2", Name = "Laura Callahan", Role = "Team Lead" });
        Rome.Add(new { Id = "3", Name = "Andrew Fuller", Role = "Developer" });
        
        Paris.Add(new { Id = "4", Name = "Robert King", Role = "Team Lead" });
        Paris.Add(new { Id = "5", Name = "Michael Suyama", Role = "Developer" });
        Paris.Add(new { Id = "6", Name = "Margaret Peacock", Role = "Developer" });
        
        London.Add(new { Id = "7", Name = "Janet Leverling", Role = "CEO" });
        London.Add(new { Id = "8", Name = "Steven Buchanan", Role = "HR" });
        London.Add(new { Id = "9", Name = "Nancy Davolio", Role = "Product Manager" });
    }
}