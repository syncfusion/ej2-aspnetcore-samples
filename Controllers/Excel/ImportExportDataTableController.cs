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
using Syncfusion.XlsIO.Implementation;
using System.Data;

namespace EJ2CoreSampleBrowser.Controllers.Excel
{
    public partial class ExcelController : Controller
    {
        public static DataTable dataTable = null;

        public ActionResult ImportExportDataTable(string saveOption, string button, string importOption)
        {
            string basePath = _hostingEnvironment.WebRootPath;

            ViewBag.exportButtonState = "disabled=\"disabled\"";

            ///SaveOption Null
            if (saveOption == null || button == null)
            {
                ViewBag.DataSource = null;
                return View();
            }

            //Start Business Object Functions
            if (button == "Input Template")
            {
                Stream ms = new FileStream(basePath + @"/XlsIO/NorthwindDataTemplate.xls", FileMode.Open, FileAccess.Read);
                string ContentType = "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                string fileName = "NorthwindDataTemplate.xls";
                return File(ms, ContentType, fileName);
            }
            else if (button == "Import From Excel")
            {
                //Step 1 : Instantiate the spreadsheet creation engine.
                ExcelEngine excelEngine = new ExcelEngine();
                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;

                Stream sampleFile = new FileStream(basePath + @"/XlsIO/NorthwindDataTemplate.xls", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = application.Workbooks.Open(sampleFile);

                IWorksheet sheet = workbook.Worksheets[0];

                if (importOption == "Skip")
                {
                    sheet.ExportDataTableEvent += Sheet_ExportDataTableEventSkip;
                    ViewBag.importOptionSkip = "value=" + importOption + " checked = \"checked\"";
                }
                else if (importOption == "Replace")
                {
                    sheet.ExportDataTableEvent += Sheet_ExportDataTableEventReplace;
                    ViewBag.importOptionReplace = "value=" + importOption + " checked = \"checked\"";
                }
                else if(importOption == "Stop")
                {
                    sheet.ExportDataTableEvent += Sheet_ExportDataTableEventStop;
                    ViewBag.importOptionStop = "value=" + importOption + " checked = \"checked\"";
                }
                else
                {
                    sheet.ExportDataTableEvent += Sheet_ExportDataTableEventNone;
                    ViewBag.importOptionNone = "value=" + importOption + " checked = \"checked\"";
                }

                dataTable = sheet.ExportDataTable(sheet.UsedRange, ExcelExportDataTableOptions.ColumnNames);

                //Close the workbook.
                workbook.Close();
                excelEngine.Dispose();

                ViewBag.DataSource = dataTable;
                ViewBag.exportButtonState = "";

                return View();
            }
            else
            {
                //New instance of XlsIO is created.[Equivalent to launching Microsoft Excel with no workbooks open].
                //The instantiation process consists of two steps.

                //Instantiate the spreadsheet creation engine.
                ExcelEngine excelEngine = new ExcelEngine();
                IApplication application = excelEngine.Excel;

                if (saveOption == "Xls")
                    application.DefaultVersion = ExcelVersion.Excel97to2003;
                else
                    application.DefaultVersion = ExcelVersion.Excel2016;

                //Open an existing spreadsheet which will be used as a template for generating the new spreadsheet.
                //After opening, the workbook object represents the complete in-memory object model of the template spreadsheet.
                IWorkbook workbook;
                workbook = excelEngine.Excel.Workbooks.Create(1);
                //The first worksheet object in the worksheets collection is accessed.
                IWorksheet sheet = workbook.Worksheets[0];

                //Import data table to worksheet
                sheet.ImportDataTable(dataTable, true, 1, 1, true);

                sheet.UsedRange.AutofitColumns();

                try
                {
                    //Saving the workbook to disk. This spreadsheet is the result of opening and modifying
                    //an existing spreadsheet and then saving the result to a new workbook.
                    string ContentType = null;
                    string fileName = null;
                    if (saveOption == "Xlsx")
                    {
                        workbook.Version = ExcelVersion.Excel2013;
                        ContentType = "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        fileName = "ExportDataTable.xlsx";
                    }
                    else
                    {
                        ContentType = "Application/vnd.ms-excel";
                        fileName = "ExportDataTable.xls";
                    }
                    MemoryStream ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    ms.Position = 0;

                    return File(ms, ContentType, fileName);
                }
                catch (Exception)
                {
                }

                //Close the workbook.
                workbook.Close();
                excelEngine.Dispose();
            }
            return View();
        }
        /// <summary>
        /// Skip Row 
        /// </summary>
        /// <param name="exportDataTableArgs">ExportDataTableEventArgs</param>
        private void Sheet_ExportDataTableEventSkip(ExportDataTableEventArgs exportDataTableArgs)
        {
            if (exportDataTableArgs.ExcelColumnIndex == 4 && exportDataTableArgs.ExcelValue.ToString() == "Owner")
                exportDataTableArgs.ExportDataTableAction = ExportDataTableActions.SkipRow;
        }
        /// <summary>
        /// Replace value 
        /// </summary>
        /// <param name="exportDataTableArgs">ExportDataTableEventArgs</param>
        private void Sheet_ExportDataTableEventReplace(ExportDataTableEventArgs exportDataTableArgs)
        {
            if (exportDataTableArgs.ExcelValue != null && exportDataTableArgs.ExcelValue.ToString() == "México D.F.")
                exportDataTableArgs.DataTableValue = "Mexico";
        }
        /// <summary>
        /// Stop Exporting  
        /// </summary>
        /// <param name="exportDataTableArgs">ExportDataTableEventArgs</param>
        private void Sheet_ExportDataTableEventStop(ExportDataTableEventArgs exportDataTableArgs)
        {
            if (exportDataTableArgs.ExcelValue != null && exportDataTableArgs.ExcelValue.ToString() == "BLONP")
                exportDataTableArgs.ExportDataTableAction = ExportDataTableActions.StopExporting;
        }
        private void Sheet_ExportDataTableEventNone(ExportDataTableEventArgs exportDataTableArgs)
        {
            exportDataTableArgs.ExportDataTableAction = ExportDataTableActions.Default;
        }
    }
}