#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Spreadsheet;

namespace EJ2CoreSampleBrowser_NET6.Controllers.Spreadsheet
{
    public partial class SpreadsheetController : Controller
    {
        public IActionResult Notes()
        {
            List<object> products = new List<object>
            {
                new { ProductName = "Coffee Maker", Category = "Kitchen", Quantity = 43, Price = "399", Total = "=PRODUCT(E4,D4)" },
                new { ProductName = "Apple Pencil", Category = "Electronics", Quantity = 7, Price = "200", Total = "=PRODUCT(E5,D5)" },
                new { ProductName = "Juicer", Category = "Kitchen", Quantity = 12, Price = "100", Total = "=PRODUCT(E6,D6)" },
                new { ProductName = "Toaster", Category = "Kitchen", Quantity = 69, Price = "183", Total = "=PRODUCT(E7,D7)" },
                new { ProductName = "Tea Kettle", Category = "Kitchen", Quantity = 83, Price = "169", Total = "=PRODUCT(E8,D8)" },
                new { ProductName = "Logitech Mouse", Category = "Electronics", Quantity = 16, Price = "250", Total = "=PRODUCT(E9,D9)" },
                new { ProductName = "Skillet", Category = "Kitchen", Quantity = 20, Price = "149", Total = "=PRODUCT(E10,D10)" },
                new { ProductName = "Hamilton Blender", Category = "Appliances", Quantity = 68, Price = "109", Total = "=PRODUCT(E11,D11)" },
                new { ProductName = "Plate set", Category = "Kitchen", Quantity = 59, Price = "168", Total = "=PRODUCT(E12,D12)" }
            };
            ViewBag.notesData = products;
            return View();
        }

        public IActionResult NotesOpen(IFormCollection openRequest)
        {
            OpenRequest open = new OpenRequest();
            open.File = openRequest.Files[0];
            return Content(Workbook.Open(open));
        }

        public IActionResult NotesSave(SaveSettings saveSettings)
        {
            return Workbook.Save(saveSettings);
        }
    }
}
