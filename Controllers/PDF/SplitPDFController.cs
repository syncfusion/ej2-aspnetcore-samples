using System;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        //
        // GET: /SplitPDF/

        public ActionResult SplitPDF()
        {
            return View();
        }       

        [HttpPost]
        public ActionResult SplitPDF(string Browser, string pageIndex, IFormFile file)
        {           
            if (file != null && file.Length > 0)
            {
                int splitAtPage = int.Parse(pageIndex.ToString());              

                PdfLoadedDocument ldoc = new PdfLoadedDocument(file.OpenReadStream());

                if (splitAtPage <= ldoc.Pages.Count&&splitAtPage!=0)
                {                    
                    //Create PDF documents.
                    PdfDocument doc1 = new PdfDocument();

                    //Import PDF document into splitAtPage index.                   
                    doc1.ImportPage(ldoc, splitAtPage-1);

                    //Save the PDF to the MemoryStream
                    MemoryStream ms = new MemoryStream();
                    doc1.Save(ms);

                    //If the position is not set to '0' then the PDF will be empty.
                    ms.Position = 0;

                    //Close the PDF document.
                    doc1.Close(true);

                    //Download the PDF document in the browser.
                    FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
                    fileStreamResult.FileDownloadName = "Split.pdf";
                    return fileStreamResult;
                }
                else                 
                {
                    ViewBag.lab = "Invalid Page no";
                }             
            }
            else
            {
                ViewBag.lab = "Choose PDF document to Split";
            }
            return View();
        }       
    }
}
