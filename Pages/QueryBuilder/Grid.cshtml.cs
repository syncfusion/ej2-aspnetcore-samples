#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.QueryBuilder;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.QueryBuilder;

public class GridModel : PageModel
{
    public QueryBuilderRule rule { get; set; }
    public List<object> dataSource { get; set; }
    public void OnGet()
    {
        rule = new QueryBuilderRule()
        {
            Condition = "or",
            Rules = new List<QueryBuilderRule>()
            {
                new QueryBuilderRule { Label="Category", Field="Category", Type="string", Operator="equal", Value = "Laptop" }
            }
        };

        dataSource = QueryBuilderData.hardwareData;
    }
}