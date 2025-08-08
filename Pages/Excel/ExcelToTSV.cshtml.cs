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
    public class ExcelToTSV : PageModel
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ExcelToTSV(IWebHostEnvironment hostingEnvironment)
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
                fileStream = new FileStream(basePath + @"/XlsIO/ExcelToTSVTemplate.xlsx", FileMode.Open, FileAccess.Read);
            }
            else
            {
                fileStream = file.OpenReadStream();
            }
            fileStream.Position = 0;

            //Loads Excel document
            IWorkbook workbook = application.Workbooks.Open(fileStream);

            //Save workbook
            MemoryStream ms = new MemoryStream();
            string contentType = "text/tab-separated-values";
            string fileName = "Sample.tsv";
            workbook.SaveAs(ms, "\t");
            ms.Position = 0;

            return File(ms, contentType, fileName);
        }
    }
}
