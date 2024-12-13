#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Syncfusion.XlsIO;
using Syncfusion.Drawing;


namespace EJ2CoreSampleBrowser.Pages.Excel
{
    public class Slicer : PageModel
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public Slicer(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public ActionResult OnPost(string view, string Columns1, string Columns2)
        {
            string basePath = _hostingEnvironment.WebRootPath;

            if (Columns1 == null)
                return null;

            if (view == "Input Template")
            {
                ExcelEngine excelEngine = new ExcelEngine();
                FileStream inputStream = new FileStream(basePath + @"/XlsIO/TableSlicer.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = excelEngine.Excel.Workbooks.Open(inputStream);

                workbook.Version = ExcelVersion.Xlsx;
                MemoryStream ms = new MemoryStream();
                workbook.SaveAs(ms);
                ms.Position = 0;

                excelEngine.Dispose();

                return File(ms, "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "InputTemplate.xlsx");

            }

            else
            {
                string fileName = "TableSlicer.xlsx";

                //Instantiate the spreadsheet creation engine.
                ExcelEngine excelEngine = new ExcelEngine();
                //Instantiate the excel application object.
                IApplication application = excelEngine.Excel;

                FileStream inputStream = new FileStream(basePath + @"/XlsIO/TableSlicer.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = application.Workbooks.Open(inputStream);
                IWorksheet sheet = workbook.Worksheets[0];

                IListObject table = sheet.ListObjects[0];

                //Get the column id from the given column name
                int colId1 = GetColumnId(Columns1, table);
                int colId2 = GetColumnId(Columns2, table);

                // Add slicer for the table
                sheet.Slicers.Add(table, colId1, 11, 2);
                sheet.Slicers.Add(table, colId2, 11, 4);

                MemoryStream result = new MemoryStream();
                workbook.SaveAs(result);
                result.Position = 0;

                excelEngine.Dispose();

                return File(result, "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);

            }
        }

        private int GetColumnId(String columnName, IListObject table)
        {
            int colId = 0;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (table.Columns[i].Name == columnName)
                {
                    colId = i + 1;
                    break;
                }
            }
            return colId;
        }
    }
}
