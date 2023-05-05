#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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

namespace EJ2CoreSampleBrowser.Models
{
    public class BreadcrumbItemModel
    {
        public string Text { get; set; }
        public string IconCss { get; set; }

        public List<BreadcrumbItemModel> Items { get; set; }
    }
}
