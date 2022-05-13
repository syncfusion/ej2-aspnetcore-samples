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

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class BadgeController : Controller
    {
        public IActionResult Listview()
        {
             List<object> data = new List<object>();
            data.Add(new { id = "p_01", text = "Primary", messages = "3 New", badge = "e-badge e-badge-primary", icons = "primary", type = "Primary" });
            data.Add(new { id = "p_02", text = "Social", messages = "27 New", badge = "e-badge e-badge-secondary", icons = "social", type = "Primary" });
            data.Add(new { id = "p_03", text = "Promotions", messages = "7 New", badge = "e-badge e-badge-success", icons = "promotion", type = "Primary" });
            data.Add(new { id = "p_04", text = "Updates", messages = "13 New", badge = "e-badge e-badge-info", icons = "updates", type = "Primary" });
            data.Add(new { id = "p_05", text = "Starred", messages = "", badge = "", icons = "starred", type = "All Labels" });
            data.Add(new { id = "p_06", text = "Important", messages = "2 New", badge = "e-badge e-badge-danger", icons = "important", type = "All Labels" });
            data.Add(new { id = "p_07", text = "Sent", messages = "", badge = "", icons = "sent", type = "All Labels" });
            data.Add(new { id = "p_08", text = "Outbox", messages = "", badge = "", icons = "outbox", type = "All Labels" });
            data.Add(new { id = "p_09", text = "Drafts", messages = "7 New", badge = "e-badge e-badge-warning", icons = "draft", type = "All Labels" });
            ViewBag.dataSource = data;
            return View();
        }
    }
}