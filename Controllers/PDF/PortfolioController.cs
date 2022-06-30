#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using System.IO;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        //
        // GET: /Portfolio/

        public ActionResult Portfolio()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Portfolio(string InsideBrowser)
        {
            //Stream readFile = new FileStream(ResolveApplicationDataPath(@"..\DocIO\DocToPDF.doc"), FileMode.Open, FileAccess.Read, FileShare.Read);
            // Create a new instance of PdfDocument class.
            PdfDocument document = new PdfDocument();

            //Creating new portfolio
            document.PortfolioInformation = new PdfPortfolioInformation();

            //setting the view mode of the portfolio
            document.PortfolioInformation.ViewMode = PdfPortfolioViewMode.Tile;

            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = string.Empty;
            dataPath = basePath + @"/PDF/";

            //Read the file
            FileStream file = new FileStream(dataPath + "CorporateBrochure.pdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //Creating the attachment
            PdfAttachment pdfFile = new PdfAttachment("CorporateBrochure.pdf",file);
            pdfFile.FileName = "CorporateBrochure.pdf";

            file = new FileStream(dataPath + "Stock.docx", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //Creating the attachement
            PdfAttachment wordfile = new PdfAttachment("Stock.docx",file);
            wordfile.FileName = "Stock.docx";

            file = new FileStream(dataPath + "Chart.xlsx", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //Creating the attachement
            PdfAttachment excelfile = new PdfAttachment("Chart.xlsx",file);
            excelfile.FileName = "Chart.xlsx";

            //Setting the startup document to view
            document.PortfolioInformation.StartupDocument = pdfFile;

            //Adding the attachment into document
            document.Attachments.Add(pdfFile);
            document.Attachments.Add(wordfile);
            document.Attachments.Add(excelfile);

            //Adding new page into the document
            document.Pages.Add();

            //Save the PDF to the MemoryStream
            MemoryStream ms = new MemoryStream();
            document.Save(ms);

            //If the position is not set to '0' then the PDF will be empty.
            ms.Position = 0;

            //Close the PDF document.
            document.Close(true);

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
            fileStreamResult.FileDownloadName = "Portfolio.pdf";
            return fileStreamResult;
        }

    }
}
