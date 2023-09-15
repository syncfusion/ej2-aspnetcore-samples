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

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ComboBoxController : Controller
    {
        public IActionResult VirtualScroll()
        {
            ComboBoxRecord model = new ComboBoxRecord();
            model.RecordList = new ComboBoxRecord().RecordModelList();
            return View(model);
        }
    }
    public class ComboBoxRecord
    {
        public string ID { get; set; }
        public string Text { get; set; }
        public List<ComboBoxRecord> RecordList { set; get; }
        public List<ComboBoxRecord> RecordModelList()
        {
            return Enumerable.Range(1, 150).Select(i => new ComboBoxRecord()
            {
                ID = i.ToString(),
                Text = "Item " + i,
            }).ToList();
        }
    }
}