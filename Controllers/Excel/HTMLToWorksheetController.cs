#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Syncfusion.XlsIO;


namespace EJ2CoreSampleBrowser.Controllers.Excel
{
    public partial class ExcelController : Controller
    {
        //
        // GET: /HTMLToWorksheet/

        public ActionResult HTMLToWorksheet(string button,string chkbox)
        {
            string basePath = _hostingEnvironment.WebRootPath;

            if (button == null)
                return View();
            else if (button == "Input Template")
            {
                if (chkbox == null)
                {
                    Stream ms = new FileStream(basePath + @"/XlsIO/HTMLToExcel.html", FileMode.Open, FileAccess.Read);
                    return File(ms, "text/html", "Import-HTML-Table.html");
                }
                else
                {
                    Stream ms = new FileStream(basePath + @"/XlsIO/HTMLwithFormulaToExcel.html", FileMode.Open, FileAccess.Read);
                    return File(ms, "text/html", "Import-HTML-Table-formula.html");
                }
            }
            else
            {
                string filename = "";
                // The instantiation process consists of two steps.
                // Step 1 : Instantiate the spreadsheet creation engine.
                ExcelEngine excelEngine = new ExcelEngine();

                // Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;

                // A workbook is created.
                IWorkbook workbook = application.Workbooks.Create(1);

                // The first worksheet object in the worksheets collection is accessed.
                IWorksheet worksheet = workbook.Worksheets[0];

                if (chkbox == null)
                {
                    Stream file = new FileStream(basePath + @"/XlsIO/HTMLToExcel.html", FileMode.Open, FileAccess.Read);

                    worksheet.ImportHtmlTable(file, 1, 1);
                    filename = "Import-HTML-Table.xlsx";
                }
                else
                {
                    Stream file = new FileStream(basePath + @"/XlsIO/HTMLwithFormulaToExcel.html", FileMode.Open, FileAccess.Read);

                    worksheet.ImportHtmlTable(file, 1, 1, HtmlImportOptions.DetectFormulas);
                    worksheet.Range["E2:F25"].NumberFormat = "_($* #,##0.00_);_($* (#,##0.00)";
                    worksheet.Range["H2:I25"].NumberFormat = "_($* #,##0.00_);_($* (#,##0.00)";
                    filename = "Import-HTML-Table-formula.xlsx";

                }

                

                worksheet.UsedRange.AutofitColumns();
                worksheet.UsedRange.AutofitRows();

                MemoryStream ms = new MemoryStream();
                workbook.SaveAs(ms);
                ms.Position = 0;

                excelEngine.Dispose();

                return File(ms, "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
            }
        }
    }
}