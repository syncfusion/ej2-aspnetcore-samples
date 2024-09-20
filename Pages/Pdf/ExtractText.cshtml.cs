#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

namespace EJ2CoreSampleBrowser_NET8.Pages.Pdf;

public class ExtractText : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public ExtractText(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    public string Message { get; set; }
    public IActionResult OnPost(string ViewTemplate, string extractText, string extractTextFromFile,
        int pageNumber, IFormFile inputPdfFile)
    {
        string basePath = _hostingEnvironment.WebRootPath;
        if (!string.IsNullOrEmpty(ViewTemplate))
        {
            FileStream fileStreamInput =
                new FileStream(basePath + @"/PDF/HTTP Succinctly.pdf", FileMode.Open, FileAccess.Read);
            FileStreamResult fileStreamResult = new FileStreamResult(fileStreamInput, "application/pdf");
            fileStreamResult.FileDownloadName = "HTTP Succinctly.pdf";
            return fileStreamResult;
        }
        else if (!string.IsNullOrEmpty(extractText))
        {
            FileStream fileStreamInput =
                new FileStream(basePath + @"/PDF/HTTP Succinctly.pdf", FileMode.Open, FileAccess.Read);
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStreamInput);
            string extractedText = string.Empty;
            for (var i = 0; i < loadedDocument.Pages.Count; i++)
            {
                extractedText += loadedDocument.Pages[i].ExtractText(true);
            }

            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(extractedText);
            MemoryStream stream = new MemoryStream(byteArray);
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/txt");
            fileStreamResult.FileDownloadName = "Sample.txt";
            return fileStreamResult;
        }
        else if (!string.IsNullOrEmpty(extractTextFromFile))
        {
            if (inputPdfFile != null)
            {
                //Load the PDF document.
                PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputPdfFile.OpenReadStream());

                if (pageNumber <= loadedDocument.Pages.Count && pageNumber != 0)
                {
                    //Get the page from the PDF document.
                    PdfPageBase page = loadedDocument.Pages[pageNumber - 1];

                    //Extract text.
                    string extractedText = page.ExtractText(true);
                    byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(extractedText);
                    MemoryStream stream = new MemoryStream(byteArray);

                    //Download the PDF document in the browser.
                    FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/txt");
                    fileStreamResult.FileDownloadName = "Sample.txt";
                    return fileStreamResult;
                }
                else
                {
                    Message =
                        "Please enter a valid page number. The page number must be within the range 1 to " +
                        loadedDocument.Pages.Count;
                    loadedDocument.Close(true);
                    return null;
                    // return View();
                }
            }
            else
            {
                Message = "Please select a PDF document to extract text.";
                return null;
                // return View();
            }
        }

        return null;
        // return View();
    }
}