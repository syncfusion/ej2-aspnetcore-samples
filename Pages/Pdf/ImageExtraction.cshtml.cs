#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Exporting;

namespace EJ2CoreSampleBrowser.Pages.Pdf;

public class ImageExtraction : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public ImageExtraction(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    public IActionResult OnPost(string ViewTemplate, string Extract)
    {
        string basePath = _hostingEnvironment.WebRootPath;
        FileStream fileStreamInput = new FileStream(basePath + @"/PDF/ImageTemplate.pdf", FileMode.Open, FileAccess.Read);
        if (!string.IsNullOrEmpty(ViewTemplate))
        {
            FileStreamResult fileStreamResult = new FileStreamResult(fileStreamInput, "application/pdf");
            fileStreamResult.FileDownloadName = "Template.pdf";
            return fileStreamResult;
        }
        else if (!string.IsNullOrEmpty(Extract))
        {
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStreamInput);
            Stream[] extractedImages = loadedDocument.Pages[0].ExtractImages();
            MemoryStream imageStream = extractedImages[0] as MemoryStream;                
            imageStream.Position = 0;
            FileStreamResult fileStreamResult = new FileStreamResult(imageStream, "image/jpeg");
            fileStreamResult.FileDownloadName = "Sample.jpg";
            return fileStreamResult;
        }

        return null;
        // return View();
    }
}