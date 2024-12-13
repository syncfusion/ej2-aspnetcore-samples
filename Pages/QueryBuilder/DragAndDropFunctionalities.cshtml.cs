#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.QueryBuilder;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.QueryBuilder;
public class DragAndDropFunctionalitiesModel : PageModel
{
    public QueryBuilderRule rule { get; set; }
    public List<string> values { get; set; }
    public List<EmployeeView> EmployeeData { get; set; }
    public List<object> items { get; set; }
    public ButtonModel ImportBtn { get; set; }
    public ButtonModel CancelBtn { get; set; }
    public void OnGet()
    {
        values = new List<string> { "Davolio", "Buchanan" };
        ImportBtn = new ButtonModel() { isPrimary = true, cssClass = "e-flat", content = "Import" };
        CancelBtn = new ButtonModel() { content = "Cancel", cssClass = "e-flat" };
        rule = new QueryBuilderRule()
        {
            Condition = "and",
            Rules = new List<QueryBuilderRule>()
            {
                new QueryBuilderRule { Label="First Name", Field="FirstName", Type="string", Operator="startswith", Value="Andre" },
                new QueryBuilderRule { Label="Last Name", Field="LastName", Type="string", Operator="in", Value = new List<string> { "Davolio", "Buchanan" } },
                new QueryBuilderRule { Label="Age", Field="Age", Type="number", Operator="greaterthan", Value=30 },
                new QueryBuilderRule { Condition="or", Rules = new List<QueryBuilderRule>()
                {
                    new QueryBuilderRule { Label="Is Developer", Field="IsDeveloper", Type="boolean", Operator="equal", Value=true },
                    new QueryBuilderRule { Label="Primary Framework", Field="PrimaryFramework", Type="string", Operator="equal", Value="React" }
                }},
                new QueryBuilderRule { Label="Hire Date", Field="HireDate", Type="date", Operator="between", Value=new List<string> { "11/28/2023", "11/30/2023" } }

            }
        };


        EmployeeData = EmployeeView.GetAllRecords();

        items = new List<object>();
        items.Add(new
        {
            text = "Import Inline Sql"
        });
        items.Add(new
        {
            text = "Import Parameter Sql"
        });
        items.Add(new
        {
            text = "Import Named Parameter Sql"
        });

    }
}