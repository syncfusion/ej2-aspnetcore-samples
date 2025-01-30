#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Presentation;
using Syncfusion.PresentationRenderer;
using Syncfusion.Pdf;
using Syncfusion.Office;

namespace EJ2CoreSampleBrowser.Pages.PowerPoint;

public class PPTXToPDF : PageModel
{
    public void OnGet()
    {
        
    }

    public string Message { get; set; }
    private readonly IWebHostEnvironment _hostingEnvironment;

    public PPTXToPDF(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    [HttpPost]
    public ActionResult OnPost(string button, string view)
    {
        if (button == null)
            return null;
            // return View();
        Stream stream = GetPresentation();
        if (stream != null)
        {
            try
            {
                string output = (Request.Form.Files != null && Request.Form.Files.Count != 0)
                    ? Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName)
                    : "PPTXToPDF";
                IPresentation presentation = Presentation.Open(stream);
                stream.Dispose();
                stream = null;

                // Create new instance for PresentationToPdfConverterSettings
                PresentationToPdfConverterSettings settings = new PresentationToPdfConverterSettings();

                //Convert the PowerPoint document to PDF document.
                PdfDocument pdfDocument = PresentationToPdfConverter.Convert(presentation, settings);

                MemoryStream pdfStream = new MemoryStream();

                //Save the converted PDF document to Memory stream.
                pdfDocument.Save(pdfStream);
                pdfStream.Position = 0;

                //Close the PDF document.
                pdfDocument.Close(true);

                //Close the PowerPoint Presentation.
                presentation.Close();

                //Initialize the file stream to download the converted PDF.
                FileStreamResult fileStreamResult = new FileStreamResult(pdfStream, "application/pdf");
                //Set the file name.
                fileStreamResult.FileDownloadName = output + ".pdf";

                return fileStreamResult;
            }
            catch
            {
                Message =
                    string.Format(
                        "The input document could not be processed completely, Could you please email the document to support@syncfusion.com for troubleshooting.");
            }
        }

        return null;
        // return View();
    }
    /// <summary>
    /// Add a custom fallback font collection for IPresentation.
    /// </summary>
    /// <param name="presentation">Represent a presentation to add.</param>
    private void AddFallbackFonts(IPresentation presentation)
    {
        //Add customized fallback font names.

        // Arabic
        presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x0600, 0x06ff, "Arial"));
        // Hebrew
        presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x0590, 0x05ff, "Arial, David"));
        // Hindi
        presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x0900, 0x097F, "Mangal"));
        // Chinese
        presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x4E00, 0x9FFF, "DengXian"));
        // Japanese
        presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x3040, 0x309F, "MS Mincho"));
        // Korean
        presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0xAC00, 0xD7A3, "Malgun Gothic"));
    }
    /// <summary>
    /// This method will returns the Input Presentation document or the Default Template Presentation document as Stream
    /// </summary>
    private Stream GetPresentation()
    {
        if (Request.Form.Files != null && Request.Form.Files.Count != 0)
        {
            // Gets the extension from file.
            string extension = Path.GetExtension(Request.Form.Files[0].FileName).ToLower();

            // Compares extension with supported extensions.
            if (extension == ".pptx")
            {
                MemoryStream stream = new MemoryStream();
                Request.Form.Files[0].CopyTo(stream);
                return stream;
            }
            else
            {
                Message = string.Format("Please choose PowerPoint Presentation document (PPTX) to convert as PDF");
                return null;
            }
        }
        else
        {
            //Opens an existing document from stream
            FileStream fileStreamPath = new FileStream(_hostingEnvironment.WebRootPath + @"/PowerPoint/Template.pptx", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            return fileStreamPath;
        }
    }
}