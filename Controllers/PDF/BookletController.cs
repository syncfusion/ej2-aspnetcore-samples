using System;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using System.IO;
namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        //
        // GET: /Booklet/

        public ActionResult Booklet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Booklet(string PageHeight, string PageWidth, string CheckBoxDoubleSide, string InsideBrowser)
        {
            try
            {
                if (PageWidth == String.Empty || PageHeight == String.Empty)
                {

                    ViewData["Error"] = "Please ensure the width and height for the page to be updated.";
                }
                else
                {
                    string basePath = _hostingEnvironment.WebRootPath;
                    string dataPath = string.Empty;
                    dataPath = basePath + @"/PDF/";

                    //Read the file as stream
                    FileStream file = new FileStream(dataPath + "Essential_Pdf.pdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    
                    //Load a PDF document
                    PdfLoadedDocument ldoc = new PdfLoadedDocument(file);

                    //Create booklet with two sides               
                    PdfDocument pdf = PdfBookletCreator.CreateBooklet(ldoc, new SizeF(float.Parse(PageWidth), float.Parse(PageHeight)), (CheckBoxDoubleSide == "DoubleSide") ? true : false);

                    //Save the PDF to the MemoryStream
                    MemoryStream ms = new MemoryStream();
                    pdf.Save(ms);

                    //If the position is not set to '0' then the PDF will be empty.
                    ms.Position = 0;

                    //Close the PDF document.
                    pdf.Close(true);
                    ldoc.Close(true);

                    //Download the PDF document in the browser.
                    FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
                    fileStreamResult.FileDownloadName = "Booklet.pdf";
                    return fileStreamResult;

                }
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.ToString();
            }
            return View();
        }
    }
}
