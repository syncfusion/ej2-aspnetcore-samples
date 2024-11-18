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
using Syncfusion.Pdf.Graphics;

namespace EJ2CoreSampleBrowser.Pages.Pdf;

public class ImageInsertion : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public ImageInsertion(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    
    public ActionResult OnPost(string Browser)
    {
        string dataPath = _hostingEnvironment.WebRootPath + @"/PDF/";

        // Create a new instance of PdfDocument class.
        PdfDocument document = new PdfDocument();

        // Add a new page to the newly created document.
        PdfPage page = document.Pages.Add();

        PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);

        PdfGraphics g = page.Graphics;

        g.DrawString("JPEG Image", font, PdfBrushes.Blue, new Syncfusion.Drawing.PointF(0, 40));

        //Load JPEG image to stream.
        FileStream  jpgImageStream = new FileStream(dataPath + "Xamarin_JPEG.jpg", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

        //Load the JPEG image
        PdfImage jpgImage = new PdfBitmap(jpgImageStream);

        //Draw the JPEG image
        g.DrawImage(jpgImage,new Syncfusion.Drawing.RectangleF(0,70,515,215));           

        g.DrawString("PNG Image", font, PdfBrushes.Blue, new Syncfusion.Drawing.PointF(0, 355));

        //Load PNG image to stream.
        FileStream pngImageStream = new FileStream(dataPath + "Xamarin_PNG.png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

        //Load the PNG image
        PdfImage pngImage = new PdfBitmap(pngImageStream);

        g.DrawImage(pngImage,new Syncfusion.Drawing.RectangleF(0,365,199,300)); 

        MemoryStream stream = new MemoryStream();

        //Save the PDF document
        document.Save(stream);

        stream.Position = 0;

        //Close the PDF document
        document.Close(true);

        //Download the PDF document in the browser.
        FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
        fileStreamResult.FileDownloadName = "ImageInsertion.pdf";
        return fileStreamResult;
    }
}