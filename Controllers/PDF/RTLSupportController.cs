#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using System.IO;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        //
        // GET: /RTLSupport/

        public ActionResult RTLSupport()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RTLSupport(string InsideBrowser)
        {
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = string.Empty;
            dataPath = basePath + @"/PDF/";

            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a page
            PdfPage page = document.Pages.Add();

            //Create font
            FileStream fontFileStream = new FileStream(dataPath + "arial.ttf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            PdfFont font = new PdfTrueTypeFont(fontFileStream, 14);

            //Read the text from text file
            FileStream rtlText = new FileStream(dataPath + "arabic.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader reader = new StreamReader(rtlText, System.Text.Encoding.Unicode);
            string text = reader.ReadToEnd();
            reader.Dispose();

            //Create a brush
            PdfBrush brush = new PdfSolidBrush(new PdfColor(0, 0, 0));
            PdfPen pen = new PdfPen(new PdfColor(0, 0, 0));
            SizeF clipBounds = page.Graphics.ClientSize;
            RectangleF rect = new RectangleF(0, 0, clipBounds.Width, clipBounds.Height);

            //Set the property for RTL text
            PdfStringFormat format = new PdfStringFormat();
            format.TextDirection = PdfTextDirection.RightToLeft;
            format.Alignment = PdfTextAlignment.Right;
            format.ParagraphIndent = 35f;

            //Draw text.
            page.Graphics.DrawString(text, font, brush, rect, format);
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            document.Close();
            stream.Position = 0;
            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = "RTLText.pdf";
            return fileStreamResult;
        }

    }
}
