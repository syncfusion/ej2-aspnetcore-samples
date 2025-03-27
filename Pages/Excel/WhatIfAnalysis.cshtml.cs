#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
    public class WhatIfAnalysis : PageModel
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public WhatIfAnalysis(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public ActionResult OnPost(string button, string chkbox)
        {
            string basePath = _hostingEnvironment.WebRootPath;

            if (button == null)
                return null;
            else if (button == "Input Template")
            {
                Stream ms = new FileStream(basePath + @"/XlsIO/WhatIfAnalysisTemplate.xlsx", FileMode.Open, FileAccess.Read);
                return File(ms, "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "WhatIfAnalysisTemplate.xlsx");
            }
            else
            {
                //Initialize ExcelEngine
                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    //Initialize IApplication and set the default application version
                    IApplication application = excelEngine.Excel;
                    application.DefaultVersion = ExcelVersion.Xlsx;

                    //Load the Excel template into IWorkbook and get the worksheet into IWorksheet
                    FileStream excelStream = new FileStream(basePath + @"/XlsIO/WhatIfAnalysisTemplate.xlsx", FileMode.Open);
                    IWorkbook workbook = application.Workbooks.Open(excelStream);
                    IWorksheet worksheet = workbook.Worksheets[0];

                    //Initailize list objects with different values for scenarios
                    List<object> currentChange_Values = new List<object> { 0.23, 0.8, 1.1, 0.5, 0.35, 0.2, 0.4, 0.37, 1.1, 1, 0.94, 0.75 };
                    List<object> increasedChange_Values = new List<object> { 0.45, 0.56, 0.9, 0.5, 0.58, 0.43, 0.39, 0.89, 1.45, 1.2, 0.99, 0.8 };
                    List<object> decreasedChange_Values = new List<object> { 0.3, 0.2, 0.5, 0.3, 0.5, 0.23, 0.2, 0.3, 0.8, 0.6, 0.87, 0.4 };

                    List<object> currentQuantity_Values = new List<object> { 1500, 3000, 5000, 4000, 500, 4000, 1200, 1500, 750, 750, 1200, 7900 };
                    List<object> increasedQuantity_Values = new List<object> { 1000, 5000, 4500, 3900, 10000, 8900, 8000, 3500, 15000, 5500, 4500, 4200 };
                    List<object> decreasedQuantity_Values = new List<object> { 1000, 2000, 3000, 3000, 300, 4000, 1200, 1000, 550, 650, 800, 6900 };

                    //Add scenarios in the worksheet
                    IScenarios scenarios = worksheet.Scenarios;
                    scenarios.Add("Current % of Change", worksheet.Range["F5:F16"], currentChange_Values);
                    scenarios.Add("Increased % of Change", worksheet.Range["F5:F16"], increasedChange_Values);
                    scenarios.Add("Decreased % of Change", worksheet.Range["F5:F16"], decreasedChange_Values);

                    scenarios.Add("Current Quantity", worksheet.Range["D5:D16"], currentQuantity_Values);
                    scenarios.Add("Increased Quantity", worksheet.Range["D5:D16"], increasedQuantity_Values);
                    scenarios.Add("Decreased Quantity", worksheet.Range["D5:D16"], decreasedQuantity_Values);

                    //Create Summary
                    if (chkbox != null)
                    {
                        worksheet.Scenarios.CreateSummary(worksheet.Range["L7"]);
                    }

                    MemoryStream ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    ms.Position = 0;

                    excelEngine.Dispose();
                    excelStream.Dispose();
                    return File(ms, "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "What-If Analysis.xlsx");
                }
            }
        }
    }
}
