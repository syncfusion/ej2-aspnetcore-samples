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

namespace EJ2CoreSampleBrowser_NET8.Pages.Excel
{
    public class CSVToExcel : PageModel
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public CSVToExcel(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public ActionResult OnPost(string button, IFormFile file)
        {
            if (button == null)
                return null;
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
