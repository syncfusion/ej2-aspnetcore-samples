#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Helpers;
using Microsoft.AspNetCore.Hosting;

namespace EJ2CoreSampleBrowser.Controllers
{
    public class SourceCodeTabController : Controller
    {
        private IWebHostEnvironment _appEnv;
        public SourceCodeTabController(IWebHostEnvironment appEnv)

        {
            _appEnv = appEnv;
        }
        public ActionResult Index(string file)
        {
            return Content(new SourceTabActionResult(file, "false", _appEnv).getContent(_appEnv));
        }

    }
}
