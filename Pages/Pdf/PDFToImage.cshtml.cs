#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.PdfToImageConverter;

namespace EJ2CoreSampleBrowser.Pages.Pdf;

public class PDFToImage : PageModel
{
    public void OnGet()
    {
        
    }

    public string Message = "";
    public IActionResult OnPost(string button)
    {
        if (button == null)
            return null;
            // return View();
        Stream stream = GetPDFDocument();
        if (stream != null)
        {
            PdfToImageConverter imageConverter = new PdfToImageConverter(stream);
            Stream outputStream = new MemoryStream();
            if (imageConverter.PageCount > 0)
            {
                outputStream = imageConverter.Convert(0, false, false);
                outputStream.Position = 0;
                FileStreamResult fileStreamResult = new FileStreamResult(outputStream, "image/png");
                fileStreamResult.FileDownloadName = "Sample.png";
                return fileStreamResult;
            }
        }

        return null;
        // return View();
    }
    private Stream GetPDFDocument()
    {
        if (Request.Form.Files != null && Request.Form.Files.Count != 0)
        {
            MemoryStream stream = new MemoryStream();
            Request.Form.Files[0].CopyTo(stream);
            return stream;
        }
        else
        {
            return null;
        }
    }
}