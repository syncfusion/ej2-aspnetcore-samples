#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Xmp;
using System.IO;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        //
        // GET: /DocumentSettings/

        public ActionResult DocumentSettings()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DocumentSettings(string InsideBrowser)
        {
            //Create a new PDF Document. The pdfDoc object represents the PDF document.
            //This document has one page by default and additional pages have to be added.
            PdfDocument pdfDoc = new PdfDocument();
            PdfPage page = pdfDoc.Pages.Add();

            // Get xmp object.
            XmpMetadata xmp = pdfDoc.DocumentInformation.XmpMetadata;

            // XMP Basic Schema.
            BasicSchema basic = xmp.BasicSchema;
            basic.Advisory.Add("advisory");
            basic.BaseURL = new Uri("http://google.com");
            basic.CreateDate = DateTime.Now;
            basic.CreatorTool = "creator tool";
            basic.Identifier.Add("identifier");
            basic.Label = "label";
            basic.MetadataDate = DateTime.Now;
            basic.ModifyDate = DateTime.Now;
            basic.Nickname = "nickname";
            basic.Rating.Add(-25);

            //Setting various Document properties.
            pdfDoc.DocumentInformation.Title = "Document Properties Information";
            pdfDoc.DocumentInformation.Author = "Syncfusion";
            pdfDoc.DocumentInformation.Keywords = "PDF";
            pdfDoc.DocumentInformation.Subject = "PDF demo";
            pdfDoc.DocumentInformation.Producer = "Syncfusion Software";
            pdfDoc.DocumentInformation.CreationDate = DateTime.Now;

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f);
            PdfFont boldFont = new PdfStandardFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold);
            PdfBrush brush = PdfBrushes.Black;

            PdfGraphics g = page.Graphics;
            PdfStringFormat format = new PdfStringFormat();
            format.LineSpacing = 10f;

            g.DrawString("Press Ctrl+D to see Document Properties", boldFont, brush, 10, 10);
            g.DrawString("Basic Schema Xml:", boldFont, brush, 10, 50);
            g.DrawString(basic.XmlData.ToString(), font, brush, new RectangleF(10, 70, 500, 600), format);

            //Defines and set values for Custom metadata and add them to the Pdf document
            CustomSchema custom = new CustomSchema(xmp, "custom", "http://www.syncfusion.com/");
            custom["Company"] = "Syncfusion";
            custom["Website"] = "http://www.syncfusion.com/";
            custom["Product"] = "Essential PDF";

            //Save the PDF to the MemoryStream
            MemoryStream ms = new MemoryStream();

            pdfDoc.Save(ms);

            //If the position is not set to '0' then the PDF will be empty.
            ms.Position = 0;

            //Close the PDF document.
            pdfDoc.Close(true);

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
            fileStreamResult.FileDownloadName = "DocumentSettings.pdf";
            return fileStreamResult;
        }

    }
}
