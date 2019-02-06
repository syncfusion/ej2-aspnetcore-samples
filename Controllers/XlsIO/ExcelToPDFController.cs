using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.XlsIORenderer;

namespace EJ2CoreSampleBrowser.Controllers.XlsIO
{
    public partial class XlsIOController : Controller
    {
        public ActionResult ExcelToPDF(string button, string Group1, IFormFile file)
        {
            if (button == null)
                return View();
            
            XlsIORenderer renderer = new XlsIORenderer();

            Stream fileStream = null;
            if (file == null)
            {
                string basePath = _hostingEnvironment.WebRootPath;
                fileStream = new FileStream(basePath + @"/XlsIO/ExcelToPDF.xlsx", FileMode.Open, FileAccess.Read);
            }
            else
            {
                fileStream = file.OpenReadStream();
            }
            fileStream.Position = 0;

            //Intialize the PdfDocument Class
            PdfDocument pdfDoc = new PdfDocument();

            //Intialize the ExcelToPdfConverterSettings class
            XlsIORendererSettings settings = new XlsIORendererSettings();
            settings.IsConvertBlankPage = false;
			
            //Set the Layout Options for the output Pdf page.
            if (Group1 == "NoScaling")
                settings.LayoutOptions = LayoutOptions.NoScaling;
            else if (Group1 == "FitAllRowsOnOnePage")
                settings.LayoutOptions = LayoutOptions.FitAllRowsOnOnePage;
            else if (Group1 == "FitAllColumnsOnOnePage")
                settings.LayoutOptions = LayoutOptions.FitAllColumnsOnOnePage;
            else
                settings.LayoutOptions = LayoutOptions.FitSheetOnOnePage;

            //Assign the output PdfDocument to the TemplateDocument property of ExcelToPdfConverterSettings 
            settings.TemplateDocument = pdfDoc;
            settings.DisplayGridLines = GridLinesDisplayStyle.Invisible;
            //Convert the Excel document to PDf

            pdfDoc = renderer.ConvertToPDF(fileStream, settings);
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
            return View();
        }
    }
}