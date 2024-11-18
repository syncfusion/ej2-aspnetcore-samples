#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

namespace EJ2CoreSampleBrowser.Pages.Pdf;

public class WatermarkPDF : PageModel
{
    public string Lab { get; set; }
    public string Message { get; set; }
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public WatermarkPDF(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    [HttpPost]
    public ActionResult OnPost(string Browser, string Stamptext, string imageWatermark, float transparency,
        IFormFile file, IFormFile imageFile)
    {
        PdfLoadedDocument ldoc = null;
        Stream fileStream = GetInputDocument(file);

        if ((imageWatermark == " Watermark" && imageFile != null && imageFile.Length > 0) ||
            imageWatermark == null && Stamptext != null)
        {
            ldoc = new PdfLoadedDocument(fileStream);

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 36f);
            foreach (PdfPageBase lPage in ldoc.Pages)
            {
                SizeF pageSize = lPage.Size;
                if (!string.IsNullOrEmpty(Stamptext))
                {
                    var textSize = font.MeasureString(Stamptext);
                    while (textSize.Width > 600)
                    {
                        font = new PdfStandardFont(PdfFontFamily.Helvetica, font.Size - 1);
                        textSize = font.MeasureString(Stamptext);
                    }

                    PdfGraphics graphics = lPage.Graphics;
                    PdfGraphicsState state = graphics.Save();
                    graphics.SetTransparency(transparency);
                    graphics.TranslateTransform(pageSize.Width / 2, pageSize.Height / 2);
                    graphics.RotateTransform(-45);
                    graphics.DrawString(Stamptext, font, PdfBrushes.Red,
                        new RectangleF(-(textSize.Width / 2), -(textSize.Height / 2), pageSize.Width, pageSize.Height));
                    graphics.Restore(state);
                }

                if (imageWatermark == " Watermark")
                {
                    PdfGraphics graphics = lPage.Graphics;
                    graphics.Save();
                    PdfImage image = new PdfTiffImage(imageFile.OpenReadStream());
                    graphics.SetTransparency(transparency);
                    graphics.DrawImage(image, 0, 0, lPage.Graphics.ClientSize.Width, lPage.Graphics.ClientSize.Height);
                    graphics.Restore();
                }
            }
        }
        else
        {
            Lab = "Please select a valid image file or enter text to add a watermark.";
            return null;
            // return View();
        }

        MemoryStream stream = new MemoryStream();

        //Save the PDF document
        ldoc.Save(stream);

        stream.Position = 0;

        //Close the PDF document
        ldoc.Close(true);

        //Download the PDF document in the browser.
        FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
        fileStreamResult.FileDownloadName = "Watermark.pdf";
        fileStream.Dispose();
        return fileStreamResult;
    }
    private Stream GetInputDocument(IFormFile file)
    {

        if (file != null)
        {
            string extension = Path.GetExtension(file.FileName).ToLower();
            // Compares extension with supported extensions.
            if (extension == ".pdf")
            {
                MemoryStream stream = new MemoryStream();
                Request.Form.Files[0].CopyTo(stream);
                return stream;
            }
            else
            {
                Message = string.Format("Please choose a valid PDF document to add watermark");
                return null;
            }
        }
        else
        {
            //Opens an existing document from stream through constructor of `WordDocument` class
            FileStream fileStreamPath = new FileStream(_hostingEnvironment.WebRootPath + @"/PDF/HTTP Succinctly.pdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            return fileStreamPath;
        }
    }
}