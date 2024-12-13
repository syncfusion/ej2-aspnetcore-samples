#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.QueryBuilder;
namespace EJ2CoreSampleBrowser.Pages.QueryBuilder;
using EJ2CoreSampleBrowser.Models;

public class DefaultFunctionalitiesModel : PageModel
{
    public QueryBuilderRule rule { get; set; }
    public List<string> values { get; set; }
    public List<EmployeeView> EmployeeData { get; set; }
    
    public ButtonModel ImportBtn { get; set; }
    public ButtonModel CancelBtn { get; set; }

    public void OnGet()
    {
        ImportBtn = new ButtonModel() { isPrimary = true, cssClass = "e-flat", content = "Import" };
        CancelBtn = new ButtonModel() { content = "Cancel", cssClass = "e-flat" };
        rule = new QueryBuilderRule()
        {
            Condition = "and",
            Rules = new List<QueryBuilderRule>()
            {
                new QueryBuilderRule { Label="Employee ID", Field="EmployeeID", Type="number", Operator="equal", Value = 1 },
                new QueryBuilderRule { Label="Title", Field="Title", Type="string", Operator="equal", Value = "Sales Manager" }
            }
        };

        values = new List<string> { "Mr.", "Mrs." };

        EmployeeData = EmployeeView.GetAllRecords();
    }
}
public class ButtonModel
{
    public string content { get; set; }
    public bool isPrimary { get; set; }
    public string cssClass { get; set; }

}