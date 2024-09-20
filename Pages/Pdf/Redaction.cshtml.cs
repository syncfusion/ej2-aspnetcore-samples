#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

namespace EJ2CoreSampleBrowser_NET8.Pages.Pdf;

public class Redaction : PageModel
{
    public void OnGet()
    {
        
    }

    public string lab;
    private readonly IWebHostEnvironment _hostingEnvironment;
    public Redaction(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    public ActionResult OnPost(string viewTemplate, string RedactPdf, string Browser, string x, string y,
        string width, string height)
    {
        if (viewTemplate == "View Template")
        {
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = string.Empty;
            dataPath = basePath + @"/PDF/";

            //Read the file
            FileStream file = new FileStream(dataPath + "Redaction.pdf", FileMode.Open, FileAccess.Read,
                FileShare.ReadWrite);

            //Load the template document
            PdfLoadedDocument doc = new PdfLoadedDocument(file);

            //Save the PDF to the MemoryStream
            MemoryStream ms = new MemoryStream();
            doc.Save(ms);

            //If the position is not set to '0' then the PDF will be empty.
            ms.Position = 0;

            //Close the PDF document.
            doc.Close(true);

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
            fileStreamResult.FileDownloadName = "RedactionTemplate.pdf";
            return fileStreamResult;
        }
        else if (RedactPdf == "Redact PDF")
        {
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = string.Empty;
            dataPath = basePath + @"/PDF/";

            //Read the file
            FileStream file = new FileStream(dataPath + "Redaction.pdf", FileMode.Open, FileAccess.Read,
                FileShare.ReadWrite);

            //Load the template document
            PdfLoadedDocument doc = new PdfLoadedDocument(file);

            PdfLoadedPage lpage = doc.Pages[0] as PdfLoadedPage;

            PdfRedaction textRedaction =
                new PdfRedaction(new Syncfusion.Drawing.RectangleF(86.998f, 39.565f, 62.709f, 20.802f),
                    Syncfusion.Drawing.Color.Black);
            //Create PDF redaction for the page to redact text 
            PdfRedaction pathRedaction =
                new PdfRedaction(new Syncfusion.Drawing.RectangleF(83.7744f, 576.066f, 210.0746f, 104.155f),
                    Syncfusion.Drawing.Color.Black);
            //Create PDF redaction for the page to redact text
            PdfRedaction imageRedation =
                new PdfRedaction(new Syncfusion.Drawing.RectangleF(327.848f, 63.97198f, 232.179f, 223.429f),
                    Syncfusion.Drawing.Color.Black);

            lpage.AddRedaction(textRedaction);
            lpage.AddRedaction(pathRedaction);
            lpage.AddRedaction(imageRedation);

            doc.Redact();
            //Save the PDF to the MemoryStream
            MemoryStream ms = new MemoryStream();
            doc.Save(ms);

            //If the position is not set to '0' then the PDF will be empty.
            ms.Position = 0;

            //Close the PDF document.
            doc.Close(true);

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
            fileStreamResult.FileDownloadName = "Redaction.pdf";
            return fileStreamResult;
        }
        else
        {
            if (Request.Form.Files != null && Request.Form.Files.Count != 0 && viewTemplate != "View Template")
            {
                float x1;
                float y1;
                float width1;
                float height1;
                if (x != null && x.Length > 0 && float.TryParse(x.ToString(), out x1) && y != null && y.Length > 0 &&
                    float.TryParse(y.ToString(), out y1) && width != null && width.Length > 0 &&
                    float.TryParse(width.ToString(), out width1) && height != null && height.Length > 0 &&
                    float.TryParse(height.ToString(), out height1))
                {
                    //Load a PDF document
                    PdfLoadedDocument ldoc = new PdfLoadedDocument(Request.Form.Files[0].OpenReadStream());
                    //Get first page from document
                    PdfLoadedPage lpage = ldoc.Pages[0] as PdfLoadedPage;

                    //Create PDF redaction for the page
                    PdfRedaction redaction =
                        new PdfRedaction(new Syncfusion.Drawing.RectangleF(x1, y1, width1, height1),
                            Syncfusion.Drawing.Color.Black);

                    //Adds the redaction to loaded page
                    lpage.AddRedaction(redaction);
                    ldoc.Redact();
                    //Save the PDF to the MemoryStream
                    MemoryStream ms = new MemoryStream();

                    ldoc.Save(ms);

                    //If the position is not set to '0' then the PDF will be empty.
                    ms.Position = 0;

                    ldoc.Close(true);
                    //Download the PDF document in the browser.
                    FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
                    fileStreamResult.FileDownloadName = "Redaction.pdf";
                    return fileStreamResult;
                }
                else
                {
                    lab = "Fill proper redaction bounds to redact";
                }
            }
            else
            {
                lab = "Choose PDF document to redact";
            }
        }

        return null;
        // return View();
    }
}