#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
using Syncfusion.EJ2.DropDowns;
using Syncfusion.EJ2.Base;

namespace EJ2CoreSampleBrowser.Controllers.QueryBuilder
{
    public partial class QueryBuilderController : Controller
    {
        public IActionResult RuleTemplate()
        {
            QueryBuilderRule rule = new QueryBuilderRule()
            {
                Condition = "and",
                Rules = new List<QueryBuilderRule>()
                {
                    new QueryBuilderRule { Label="First Name", Field="FirstName", Type="string", Operator="equal", Value="Nancy"  },
                    new QueryBuilderRule { Label="Country", Field="Country", Type="string", Operator="equal", Value = "USA" }
                }
            };
            ViewBag.rule = rule;
            return View();
        }
        public IActionResult RuleTemplatePartial([FromBody] CRUDModel<QueryTemplateModel.ActionModel> args)
        {
            List<Object> Items = new List<object>()
            {
                new {field = "USA", label ="USA" },
                new {field = "England", label ="England"},
                new {field = "India", label ="India" },
                new {field = "Spain", label ="Spain" }
            };
            ViewBag.Items = Items;
            return PartialView("_RuleTemplatePartial", args.Value);
        }
    }
}