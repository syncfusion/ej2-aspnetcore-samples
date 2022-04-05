#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;
using Syncfusion.EJ2.QueryBuilder;

namespace EJ2CoreSampleBrowser.Controllers.QueryBuilder
{
    public partial class QueryBuilderController : Controller
    {
        public IActionResult Template()
        {
            QueryBuilderRule rule = new QueryBuilderRule()
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

            List<object> template = new List<object>()
            {
                new { create = "categoryCreate", destroy = "categoryDestroy", write = "categoryWrite" },
                new { create = "paymentCreate", destroy = "paymentDestroy", write = "paymentWrite" },
                new { create = "transactionCreate", destroy = "transactionDestroy", write = "transactionWrite" },
                new { create = "amountCreate", destroy = "amountDestroy", write = "amountWrite" }
            };

            List<object> paymentOperator = new List<object> {
                new { key = "Equal", value = "equal" },
                new { key = "Not Equal", value = "notequal" }
            };

            List<object> transactionOperator = new List<object> {
                new { key = "Equal", value = "equal" },
                new { key = "Not Equal", value = "notequal" }
            };

            List<object> amountOperator = new List<object> {
                new { key = "Equal", value = "equal" },
                new { key = "Greater than", value = "greaterthan" },
                new { key = "Less than", value = "lessthan" },
                new { key = "Less than or equal", value = "lessthanorequal" },
                new { key = "Greater than or equal", value = "greaterthanorequal" },
                new { key = "Not equal", value = "notequal" }
            };

            ViewBag.rule = rule;
            ViewBag.paymentOperator = paymentOperator;
            ViewBag.transactionOperator = transactionOperator;
            ViewBag.amountOperator = amountOperator;
            ViewBag.template = template;
            ViewBag.dataSource = QueryBuilderData.expenseData;
            return View();
        }
    }
}