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
        public IActionResult Grid()
        {
            QueryBuilderRule rule = new QueryBuilderRule()
            {
                Condition = "or",
                Rules = new List<QueryBuilderRule>()
                {
                    new QueryBuilderRule { Label="Category", Field="Category", Type="string", Operator="equal", Value = "Laptop" }
                }
            };


            ViewBag.rule = rule;
            ViewBag.dataSource = QueryBuilderData.hardwareData;
            return View();
        }
    }
}