#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.XlsIO;
using Syncfusion.XlsIORenderer;

namespace EJ2CoreSampleBrowser.Controllers.Excel
{
    public partial class ExcelController : Controller
    {
        public ActionResult CSVToExcel(string button, IFormFile file)
        {
            if (button == null)
                return View();
            string basePath = _hostingEnvironment.WebRootPath;
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            Stream fileStream = null;
            if (file == null)
            {
                fileStream = new FileStream(basePath + @"/XlsIO/CSVToExcelTemplate.csv", FileMode.Open, FileAccess.Read);
            }
            else
            {
                fileStream = file.OpenReadStream();
            }
            fileStream.Position = 0;

            //Loads CSV document
            IWorkbook workbook = application.Workbooks.Open(fileStream, ",");

            //Save workbook
            MemoryStream ms = new MemoryStream();
            workbook.Version = ExcelVersion.Xlsx;
            string ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "Sample.xlsx";
            workbook.SaveAs(ms);
            ms.Position = 0;

            return File(ms, ContentType, fileName);
        }
    }
}