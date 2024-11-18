#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.Pdf;
using Syncfusion.XlsIO;
using Syncfusion.XlsIORenderer;

namespace EJ2CoreSampleBrowser.Pages.Excel
{
    public class ExcelToPDFUA : PageModel
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ExcelToPDFUA(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        string basePath = string.Empty;
        public ActionResult OnPost(string button, string layoutOptions, IFormFile file)
        {
            if (button == null)
                return null;

            basePath = _hostingEnvironment.WebRootPath;
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.EnablePartialTrustCode = true;
            
            XlsIORenderer renderer = new XlsIORenderer();

            Stream fileStream = null;
            if (file == null)
            {
               fileStream = new FileStream(basePath + @"/XlsIO/ExcelToPdf-UA.xlsx", FileMode.Open, FileAccess.Read);
            }
            else
            {
                fileStream = file.OpenReadStream();
            }
            fileStream.Position = 0;

            //Loads file stream into Word document
            IWorkbook workbook = application.Workbooks.Open(fileStream);

            //Intialize the PdfDocument Class
            PdfDocument pdfDoc = new PdfDocument();

            //Intialize the ExcelToPdfConverterSettings class
            XlsIORendererSettings settings = new XlsIORendererSettings();
            settings.AutoTag = true;

            pdfDoc = renderer.ConvertToPDF(workbook, settings);
            fileStream.Dispose();

            MemoryStream stream = new MemoryStream();
            pdfDoc.Save(stream);
            try
            {
                stream.Position = 0;
                return File(stream, "application/pdf", "ExcelToPDF.pdf");
            }
            catch (Exception)
            { }
            finally
            {

            }
            return null;
        }
    }
}
