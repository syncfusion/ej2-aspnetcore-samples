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
    public class ExcelToPDF : PageModel
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ExcelToPDF(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        string basePath = string.Empty;
        public ActionResult OnPost(string button, string checkboxStream, string layoutOptions, IFormFile file)
        {
            if (button == null)
                return null;

            basePath = _hostingEnvironment.WebRootPath;
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.EnablePartialTrustCode = true;
            if (checkboxStream != null)
            {
                application.SubstituteFont += new Syncfusion.XlsIO.Implementation.SubstituteFontEventHandler(SubstituteFont);
            }

            XlsIORenderer renderer = new XlsIORenderer();

            Stream fileStream = null;
            if (file == null)
            {
                if (checkboxStream != null)
                    fileStream = new FileStream(basePath + @"/XlsIO/InvoiceTemplate.xlsx", FileMode.Open, FileAccess.Read);
                else
                    fileStream = new FileStream(basePath + @"/XlsIO/ExcelToPDF.xlsx", FileMode.Open, FileAccess.Read);
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
            settings.IsConvertBlankPage = false;

            //Set the Layout Options for the output Pdf page.
            if (layoutOptions == "No scaling")
                settings.LayoutOptions = LayoutOptions.NoScaling;
            else if (layoutOptions == "Fit all rows on one page")
                settings.LayoutOptions = LayoutOptions.FitAllRowsOnOnePage;
            else if (layoutOptions == "Fit all columns on one page")
                settings.LayoutOptions = LayoutOptions.FitAllColumnsOnOnePage;
            else
                settings.LayoutOptions = LayoutOptions.FitSheetOnOnePage;

            //Assign the output PdfDocument to the TemplateDocument property of ExcelToPdfConverterSettings 
            settings.TemplateDocument = pdfDoc;
            settings.DisplayGridLines = GridLinesDisplayStyle.Invisible;
            //Convert the Excel document to PDf

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

        public void SubstituteFont(object sender, Syncfusion.XlsIO.Implementation.SubstituteFontEventArgs args)
        {
            Stream fileStream = new FileStream(basePath + @"/XlsIO/bahnschrift.ttf", FileMode.Open);
            MemoryStream memoryStream = new MemoryStream();
            fileStream.CopyTo(memoryStream);
            fileStream.Close();
            args.AlternateFontStream = memoryStream;
        }
    }
}
