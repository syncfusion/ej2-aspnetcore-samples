#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class ReorderModel : PageModel
{
    public List<EmployeeView> DataSource { get; set; }
    public List<object> columns { get; set; }
    public List<object> index { get; set; }
    public void OnGet()
    {
        DataSource = EmployeeView.GetAllRecords();
        List<object> dd = new List<object>();
        dd.Add(new { text = "Employee ID", value ="EmployeeID" });
        dd.Add(new { text = "Name", value = "FirstName" });
        dd.Add(new { text = "Title", value = "Title" });
        dd.Add(new { text = "Hire Date", value = "HireDate" });
        columns = dd;
       index = new List<object>();
        index.Add(new { text = "1", value = "0" });
        index.Add(new { text = "2", value = "1" });
        index.Add(new { text = "3", value = "2" });
        index.Add(new { text = "4", value = "3" });
    }
}