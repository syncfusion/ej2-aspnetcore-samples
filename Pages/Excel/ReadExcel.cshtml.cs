#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.XlsIO;
using System.Data;
using System.Diagnostics;


namespace EJ2CoreSampleBrowser_NET8.Pages.Excel
{
    public class ReadExcel : PageModel
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private DataTable dataTable;
        public string TimeTaken="";
        public ReadExcel(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult OnPost(string button)
        {
            if (button == null)
                return null;

            string basePath = _hostingEnvironment.WebRootPath;
            //New instance of XlsIO is created.[Equivalent to launching Microsoft Excel with no workbooks open].
            //The instantiation process consists of two steps.
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();

            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            //Get file stream.
            Stream fileStream = new FileStream(basePath + @"/XlsIO/ReadTemplate.xlsx", FileMode.Open, FileAccess.Read);
            fileStream.Position = 0;

            //Open the Workbook using the file stream.
            IWorkbook sourceWorkbook = application.Workbooks.Open(fileStream);
            if (button == "Input Template")
            {
                MemoryStream ms = new MemoryStream();
                sourceWorkbook.Version = ExcelVersion.Xlsx;
                string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                string fileName = "InputTemplate.xlsx";
                sourceWorkbook.SaveAs(ms);
                ms.Position = 0;

                return File(ms, contentType, fileName);
            }
            else
            {
                IWorksheet worksheet = sourceWorkbook.Worksheets[0];
                IRange usedRange = worksheet.UsedRange;
                int firstRow = usedRange.Row;
                int lastRow = usedRange.LastRow;
                int firstColumn = usedRange.Column;
                int lastColumn = usedRange.LastColumn;
                IMigrantRange migrantRange = worksheet.MigrantRange;
                dataTable = new System.Data.DataTable();
                for (int column = firstColumn; column <= lastColumn; column++)
                {
                    dataTable.Columns.Add(worksheet[1, column].Value);
                }
                for (int row = firstRow + 1; row <= lastRow; row++)
                {
                    dataTable.Rows.Add();
                    for (int column = firstColumn; column <= lastColumn; column++)
                    {
                        migrantRange.ResetRowColumn(row, column);
                        dataTable.Rows[row - 2][column - 1] = migrantRange.Value;
                    }
                }
                stopwatch.Stop();
                TimeTaken = "Time Taken: " + stopwatch.ElapsedMilliseconds.ToString() + " ms";
                return null;
            }
        }
    }
}
