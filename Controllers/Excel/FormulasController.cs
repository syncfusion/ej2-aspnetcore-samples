#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using Syncfusion.XlsIO;
using Syncfusion.Drawing;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace EJ2CoreSampleBrowser.Controllers.Excel
{
    public partial class ExcelController : Controller
    {
        //
        // GET: /Formulas/
        public ActionResult Formulas(string button)
        {
            string basePath = _hostingEnvironment.WebRootPath;
            ViewData["computedValue"] = "";

            //Read Formula
            ViewData["formulaString"] = "";
            if (button == null)
                return View();
            else if (button == "Write Formula")
            {
                //New instance of XlsIO is created.[Equivalent to launching Microsoft Excel with no workbooks open].
                //The instantiation process consists of two steps.

                //Step 1 : Instantiate the spreadsheet creation engine.
                ExcelEngine excelEngine = new ExcelEngine();
                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;

                //A new workbook is created.[Equivalent to creating a new workbook in Microsoft Excel]
                //The new workbook will have 3 worksheets
                IWorkbook workbook = application.Workbooks.Create(3);
                //The first worksheet object in the worksheets collection is accessed.
                IWorksheet sheet = workbook.Worksheets[0];

                #region Insert Array Formula

                sheet.Range["A2"].Text = "Array formulas";
                sheet.Range["B2:E2"].FormulaArray = "{10,20,30,40}";
                sheet.Names.Add("ArrayRange", sheet.Range["B2:E2"]);
                sheet.Range["B3:E3"].FormulaArray = "ArrayRange+100";
                sheet.Range["A2"].CellStyle.Font.Bold = true;
                sheet.Range["A2"].CellStyle.Font.Size = 14;

                #endregion

                #region Excel functions

                sheet.Range["A5"].Text = "Formula";
                sheet.Range["B5"].Text = "Result";

                sheet.Range["A7"].Text = "ABS(ABS(-B3))";
                sheet.Range["B7"].Formula = "ABS(ABS(-B3))";

                sheet.Range["A9"].Text = "SUM(B3,C3)";
                sheet.Range["B9"].Formula = "SUM(B3,C3)";

                sheet.Range["A11"].Text = "MIN({10,20,30;5,15,35;6,16,36})";
                sheet.Range["B11"].Formula = "MIN({10,20,30;5,15,35;6,16,36})";

                sheet.Range["A13"].Text = "LOOKUP(B3,B3:E8)";
                sheet.Range["B13"].Formula = "LOOKUP(B3,B3:E3)";

                sheet.Range["A5:B5"].CellStyle.Font.Bold = true;
                sheet.Range["A5:B5"].CellStyle.Font.Size = 14;

                #endregion

                #region Simple formulas
                sheet.Range["C7"].Number = 10;
                sheet.Range["C9"].Number = 10;
                sheet.Range["A15"].Text = "C7+C9";
                sheet.Range["B15"].Formula = "C7+C9";

                #endregion

                sheet.Range["B1"].Text = "Excel formula support";
                sheet.Range["B1"].CellStyle.Font.Bold = true;
                sheet.Range["B1"].CellStyle.Font.Size = 14;
                sheet.Range["B1:E1"].Merge();
                sheet.Range["A1:A15"].AutofitColumns();

                try
                {

                    workbook.Version = ExcelVersion.Excel97to2003;
                    MemoryStream ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    ms.Position = 0;

                    return File(ms, "Application/vnd.ms-excel", "Formulas.xls");
                }
                catch (Exception)
                {
                }

                // Close the workbook
                workbook.Close();
                excelEngine.Dispose();
                return View();
            }
            else
            {
                //New instance of XlsIO is created.[Equivalent to launching Microsoft Excel with no workbooks open].
                //The instantiation process consists of two steps.

                //Step 1 : Instantiate the spreadsheet creation engine.
                ExcelEngine excelEngine = new ExcelEngine();
                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;

                FileStream inputStream = new FileStream(ResolveApplicationPath("FormulaTemplate.xls"), FileMode.Open, FileAccess.Read);
                IWorkbook workbook = application.Workbooks.Open(inputStream);

                //The first worksheet object in the worksheets collection is accessed.
                IWorksheet sheet = workbook.Worksheets[0];

                //Read computed Formula Value. 
                ViewData["computedValue"] = sheet.Range["C1"].FormulaNumberValue;

                //Read Formula
                ViewData["formulaString"] = sheet.Range["C1"].Formula;

                //Close the workbook.
                workbook.Close();
                excelEngine.Dispose();
            }
            return View();
        }

    }
}
