#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
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
        // GET: /ExcelToJSON/

        public ActionResult ExcelToJSON(string button, string checkBox, string ConvertOptions)
        {
            string basePath = _hostingEnvironment.WebRootPath;

            if (button == null)
                return View();
            else if (button == "Input Template")
            {
                Stream ms = new FileStream(basePath + @"/XlsIO/ExcelToJSON.xlsx", FileMode.Open, FileAccess.Read);
                string ContentType = "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                string fileName = "ExcelToJSON.xlsx";
                return File(ms, ContentType, fileName);
            }
            else if(button == "Convert to JSON")
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
            return View();
        }
    }
}