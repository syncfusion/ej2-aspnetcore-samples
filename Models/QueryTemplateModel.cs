#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Syncfusion.EJ2.QueryBuilder;
using Syncfusion.EJ2.DropDowns;

namespace EJ2CoreSampleBrowser.Models
{
    public class QueryTemplateModel
    {
        public class ValueModel
        {
        public ActionModel Value { get; set; }
        }
        public class ActionModel
        {
            public string RuleID { get; set; }
            public string Condition { get; set; }
            public List<QueryBuilderColumn> Columns { get; set; }
            public DropDownListFieldSettings Fields { get; set; }
            public QueryBuilderRule Rule {get; set;}
        }
    }
}
