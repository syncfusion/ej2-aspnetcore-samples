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

namespace EJ2CoreSampleBrowser.Pages.Excel
{
    public class ExcelToJSON : PageModel
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ExcelToJSON(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public ActionResult OnPost(string button, string checkBox, string ConvertOptions)
        {
            string basePath = _hostingEnvironment.WebRootPath;

            if (button == null)
                return null;
            else if (button == "Input Template")
            {
                Stream ms = new FileStream(basePath + @"/XlsIO/ExcelToJSON.xlsx", FileMode.Open, FileAccess.Read);
                string ContentType = "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                string fileName = "ExcelToJSON.xlsx";
                return File(ms, ContentType, fileName);
            }
            else if (button == "Convert to JSON")
            {
                //Initialize ExcelEngine
                ExcelEngine excelEngine = new ExcelEngine();

                //Initialize Application
                IApplication application = excelEngine.Excel;

                //Open the input template workbook
                FileStream sampleFile = new FileStream(basePath + @"/XlsIO/ExcelToJSON.xlsx", FileMode.Open);
                IWorkbook workbook = application.Workbooks.Open(sampleFile);

                //Accessing first worksheet in the workbook
                IWorksheet worksheet = workbook.Worksheets[0];

                IRange range = worksheet.Range["A2:B10"];

                bool isSchema = (checkBox == "Schema") ? true : false;

                //Save the Excel workbook as JSON file
                MemoryStream stream = new MemoryStream();
                if (ConvertOptions == "Workbook")
                    workbook.SaveAsJson(stream, isSchema);
                else if (ConvertOptions == "Worksheet")
                    workbook.SaveAsJson(stream, worksheet, isSchema);
                else if (ConvertOptions == "Range")
                    workbook.SaveAsJson(stream, range, isSchema);

                //If the position is not set to '0' then the file will be empty.
                stream.Position = 0;

                //Download the converted JSON file in the browser
                FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/json");
                fileStreamResult.FileDownloadName = "ExcelToJSON.json";

                workbook.Close();
                sampleFile.Dispose();

                return fileStreamResult;
            }
            return null;
        }
    }
}
