#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.ListBox;

public class DragAndDropModel : PageModel
{
    public List<object> GroupA { get; set; }
    public List<object> GroupB { get; set; }

    public void OnGet()
    {
        GroupA = new List<object>();
        GroupA.Add(new { Name = "Australia", Code = "AU" });
        GroupA.Add(new { Name = "Bermuda", Code = "BM" });
        GroupA.Add(new { Name = "Canada", Code = "CA" });
        GroupA.Add(new { Name = "Cameroon", Code = "CM" });
        GroupA.Add(new { Name = "Denmark", Code = "DK" });
        GroupA.Add(new { Name = "France", Code = "FR" });
        GroupA.Add(new { Name = "Finland", Code = "FI" });
        GroupA.Add(new { Name = "Germany", Code = "DE" });
        GroupA.Add(new { Name = "Hong Kong", Code = "HK" });

        GroupB = new List<object>();
        GroupB.Add(new { Name = "India", Code = "IN" });
        GroupB.Add(new { Name = "Italy", Code = "IT" });
        GroupB.Add(new { Name = "Japan", Code = "JP" });
        GroupB.Add(new { Name = "Mexico", Code = "MX" });
        GroupB.Add(new { Name = "Norway", Code = "NO" });
        GroupB.Add(new { Name = "Poland", Code = "PL" });
        GroupB.Add(new { Name = "Switzerland", Code = "CH" });
        GroupB.Add(new { Name = "United Kingdom", Code = "GB" });
        GroupB.Add(new { Name = "United States", Code = "US" });  
    }
}