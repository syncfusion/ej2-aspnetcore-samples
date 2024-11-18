#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
using Syncfusion.EJ2.QueryBuilder;
namespace EJ2CoreSampleBrowser.Pages.QueryBuilder;

public class TemplateModel : PageModel
{
    public QueryBuilderRule rule { get; set; }
    public List<object> template { get; set; }
    public List<object> paymentOperator { get; set; }
    public List<object> transactionOperator { get; set; }
    public List<object> amountOperator { get; set; }
    
    public List<object> DataSource { get; set; }
    public void OnGet()
    {
         rule = new QueryBuilderRule()
    {
        Condition = "and",
        Rules = new List<QueryBuilderRule>()
        {
            new QueryBuilderRule { Label="Category", Field="Category", Type="string", Operator="equal", Value = new string[] { "Clothing" } },
            new QueryBuilderRule { Condition="or", Rules = new List<QueryBuilderRule>() {
                new QueryBuilderRule { Label="Transaction Type", Field="TransactionType", Type="boolean", Operator="equal", Value = "Income" },
                new QueryBuilderRule { Label="Payment Mode", Field="PaymentMode", Type="string", Operator="equal", Value = "Cash" }
            } },
            new QueryBuilderRule { Label="Amount", Field="Amount", Type="number", Operator="equal", Value = 10 }
        }
    };

    template = new List<object>()
    {
        new { create = "categoryCreate", destroy = "categoryDestroy", write = "categoryWrite" },
        new { create = "paymentCreate", destroy = "paymentDestroy", write = "paymentWrite" },
        new { create = "transactionCreate", destroy = "transactionDestroy", write = "transactionWrite" },
        new { create = "amountCreate", destroy = "amountDestroy", write = "amountWrite" }
    };

    paymentOperator = new List<object> {
        new { key = "Equal", value = "equal" },
        new { key = "Not Equal", value = "notequal" }
    };

    transactionOperator = new List<object> {
        new { key = "Equal", value = "equal" },
        new { key = "Not Equal", value = "notequal" }
    };

    amountOperator = new List<object> {
        new { key = "Equal", value = "equal" },
        new { key = "Greater than", value = "greaterthan" },
        new { key = "Less than", value = "lessthan" },
        new { key = "Less than or equal", value = "lessthanorequal" },
        new { key = "Greater than or equal", value = "greaterthanorequal" },
        new { key = "Not equal", value = "notequal" }
    };
    DataSource = QueryBuilderData.expenseData;
    }
}