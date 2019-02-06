using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
                Rules = new List<QueryBuilderRules>()
                {
                    new QueryBuilderRules { Label="Category", Field="Category", Type="string", Operator="equal", Value = new string[] { "Clothing" } },
                    new QueryBuilderRules { Condition="or", Rules = new List<QueryBuilderRules>() {
                        new QueryBuilderRules { Label="Transaction Type", Field="TransactionType", Type="boolean", Operator="equal", Value = "Income" },
                        new QueryBuilderRules { Label="Payment Mode", Field="PaymentMode", Type="string", Operator="equal", Value = "Cash" }
                    } },
                    new QueryBuilderRules { Label="Amount", Field="Amount", Type="number", Operator="equal", Value = 10 }
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
                new { key = "Not Equal", value = "notequal" },
                new { key = "In", value = "in" },
                new { key = "Not In", value = "notin" }
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
            return View();
        }
    }
}