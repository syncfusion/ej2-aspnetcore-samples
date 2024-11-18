#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
using Microsoft.AspNetCore.Http;
using Syncfusion.EJ2.Spreadsheet;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class SpreadsheetController : Controller
    {
        public IActionResult Chart()
        {
            List<object> data = new List<object>()
            {
                new { Country= "USA", Year2017= "18.00", Year2018= "20.40", Year2019= "21.42", Year2020= "19.48" },
                new { Country= "China", Year2017= "11.00", Year2018= "14.00", Year2019= "14.32", Year2020= "12.23" },
                new { Country= "Japan", Year2017= "4.4", Year2018= "5.10", Year2019= "5.08", Year2020= "4.87" },
                new { Country= "Germany", Year2017= "3.3", Year2018= "4.20", Year2019= "3.84", Year2020= "3.69" },
                new { Country= "India", Year2017= "2.00", Year2018= "2.85", Year2019= "2.87", Year2020= "2.65" },
                new { Country= "UK", Year2017= "2.90", Year2018= "2.94", Year2019= "2.82", Year2020= "2.63" },
                new { Country= "France", Year2017= "2.40", Year2018= "2.93", Year2019= "2.71", Year2020= "2.58" }
            };
            ViewBag.GDPData = data;
            return View();
        }

        public IActionResult ChartOpen(IFormCollection openRequest)
        {
            OpenRequest open = new OpenRequest();
            open.File = openRequest.Files[0];
            return Content(Workbook.Open(open));
        }

        public IActionResult ChartSave(SaveSettings saveSettings)
        {
            return Workbook.Save(saveSettings);
        }
    }
}