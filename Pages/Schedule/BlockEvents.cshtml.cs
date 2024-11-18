#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Schedule;

public class BlockEvents : PageModel
{
    public List<EmployeeData> employees = new List<EmployeeData>();
    public void OnGet()
    {
        employees.Add(new EmployeeData { text = "Alice", id = 1, groupId = 1, color = "#bbdc00", designation = "Content writer" });
        employees.Add(new EmployeeData { text = "Nancy", id = 2, groupId = 2, color = "#9e5fff", designation = "Designer" });
        employees.Add(new EmployeeData { text = "Robert", id = 3, groupId = 1, color = "#bbdc00", designation = "Software Engineer" });
        employees.Add(new EmployeeData { text = "Robson", id = 4, groupId = 2, color = "#9e5fff", designation = "Support Engineer" });
        employees.Add(new EmployeeData { text = "Laura", id = 5, groupId = 1, color = "#bbdc00", designation = "Human Resource" });
        employees.Add(new EmployeeData { text = "Margaret", id = 6, groupId = 2, color = "#9e5fff", designation = "Content Analyst" });
    }
}
public class EmployeeData
{
    public string text { set; get; }
    public int id { set; get; }
    public int groupId { set; get; }
    public string color { set; get; }
    public string designation { set; get; }
}