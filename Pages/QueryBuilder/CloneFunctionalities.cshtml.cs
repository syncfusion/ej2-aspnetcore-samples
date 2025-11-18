#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
using Syncfusion.EJ2.QueryBuilder;
namespace EJ2CoreSampleBrowser.Pages.QueryBuilder;

public class CloneFunctionalitiesModel : PageModel
{
    public QueryBuilderRule rule { get; set; }
    public List<string> values { get; set; }
    public List<EmployeeView> EmployeeData { get; set; }
    
    public void OnGet()
    {
        rule = new QueryBuilderRule()
        {
            Condition = "and",
            Rules = new List<QueryBuilderRule>()
            {
                new QueryBuilderRule { Label="Employee ID", Field="EmployeeID", Type="number", Operator="equal", Value = 1 },
                new QueryBuilderRule { Label="Title", Field="Title", Type="string", Operator="equal", Value = "Sales Manager" },
                new QueryBuilderRule { Condition="or", Rules = new List<QueryBuilderRule>()
                    {
                        new QueryBuilderRule { Label="Country", Field="Country", Type="string", Operator="equal", Value = "USA" }
                    }
                },
                new QueryBuilderRule { Label="FirstName", Field="FirstName", Type="string", Operator="equal", Value = "Nancy" }
            }
        };
        values = new List<string> { "Mr.", "Mrs." };

        EmployeeData = EmployeeView.GetAllRecords();
    }
}