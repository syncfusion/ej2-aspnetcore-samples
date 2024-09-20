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

namespace EJ2CoreSampleBrowser_NET8.Pages.Pdf;

public class TiffToPDF : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public TiffToPDF(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public ActionResult OnPost(string viewTemplate, string createPDF)
    {
        string dataPath = _hostingEnvironment.WebRootPath + @"/PDF/";

        //Load TIFF image to stream
        FileStream imageFileStream =
            new FileStream(dataPath + "image.tiff", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

        if (viewTemplate == "View Template")
        {
            return File(imageFileStream, "application/image", "image.tiff");
        }
        else if (createPDF == "Convert to PDF")
        {
            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Set margin to the page
            document.PageSettings.Margins.All = 0;

            //Load Multiframe Tiff image
            PdfTiffImage tiffImage = new PdfTiffImage(imageFileStream);

            //Get the frame count
            int frameCount = tiffImage.FrameCount;

            //Access each frame and draw into the page
            for (int i = 0; i < frameCount; i++)
            {
                //Add new page for each frames
                PdfPage page = document.Pages.Add();

                //Get page graphics
                PdfGraphics graphics = page.Graphics;

                //Set active frame.
                tiffImage.ActiveFrame = i;

                //Draw Tiff image into page
                graphics.DrawImage(tiffImage, 0, 0, page.GetClientSize().Width, page.GetClientSize().Height);

            }

            //Save PDF document
            MemoryStream stream = new MemoryStream();

            document.Save(stream);

            //Close the PDF document
            document.Close(true);

            stream.Position = 0;

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = "TiffToPDF.pdf";
            return fileStreamResult;
        }
        else
            return null;
            // return View();
    }
}