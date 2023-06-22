#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
using System.IO;
using System.Text;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        //
        // GET: /HeadersandFooters/
        # region Private Members
        private bool m_paginateStart = true;
        RectangleF bounds;
        private RectangleF m_columnBounds;
        # endregion

        public ActionResult HeadersandFooters()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HeadersFooters(string InsideBrowser)
        {
            //Create a PDF document
            PdfDocument doc = new PdfDocument();

            //Add a page
            PdfPage page = doc.Pages.Add();
            RectangleF rect = new RectangleF(0, 0, page.GetClientSize().Width, 50);

            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);
            PdfPen pen = new PdfPen(Color.Black, 1f);

            //Create font
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 11.5f);
            
            PdfFont heading = new PdfStandardFont(PdfFontFamily.Courier, 14,PdfFontStyle.Bold);

            //Adding Header
            this.AddDocumentHeader(doc, "Syncfusion Essential PDF", "Header and Footer Demo");

            //Adding Footer
            this.AddDocumentFooter(doc, "@Copyright 2015");

            //Set formats
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Justify;

            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = string.Empty;
            dataPath = basePath + @"/PDF/";

            //Read the file
            FileStream file = new FileStream(dataPath + "Essential studio.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            StreamReader reader = new StreamReader(file, Encoding.ASCII);

            string text = reader.ReadToEnd();
            reader.Dispose();

            RectangleF column = new RectangleF(0, 20, page.Graphics.ClientSize.Width / 2f - 10f, page.Graphics.ClientSize.Height);
            bounds = column;
            m_columnBounds = column;

            //Create text element to control the text flow
            PdfTextElement element = new PdfTextElement(text, font);
            element.Brush = new PdfSolidBrush(Color.Black);
            element.StringFormat = format;
            PdfLayoutFormat layoutFormat = new PdfLayoutFormat();
            layoutFormat.Break = PdfLayoutBreakType.FitPage;
            layoutFormat.Layout = PdfLayoutType.Paginate;

            //Get the remaining text that flows beyond the boundary.
            PdfTextLayoutResult result = element.Draw(page, bounds, layoutFormat);
           
            file = new FileStream(dataPath + "Essential PDF.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            
            reader = new StreamReader(file, Encoding.ASCII);
            text = reader.ReadToEnd();
            reader.Dispose();

            element = new PdfTextElement(text, font);
            element.Brush = new PdfSolidBrush(Color.Black);
            element.StringFormat = format;

            // Next paragraph flow from last line of the previous paragraph.
            bounds.Y = result.LastLineBounds.Y + 35f;

            //Raise the event when the text flows to next page.
            element.BeginPageLayout += new BeginPageLayoutEventHandler(BeginPageLayout2);

            //Raise the event when the text reaches the end of the page.
            element.EndPageLayout += new EndPageLayoutEventHandler(EndPageLayout2);
            result.Page.Graphics.DrawString("Essential PDF", heading, PdfBrushes.DarkBlue, new PointF(bounds.X, bounds.Y));

            bounds.Y = result.LastLineBounds.Y + 60f;
            result = element.Draw(result.Page, new RectangleF(bounds.X, bounds.Y, bounds.Width, -1), layoutFormat);

            file = new FileStream(dataPath + "Essen PDF.jpg", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            PdfImage image = new PdfBitmap(file);
            bounds.Y = result.LastLineBounds.Y + 20f;
            bounds.X = bounds.Width + 20f;

            result.Page.Graphics.DrawImage(image, new PointF(bounds.X, bounds.Y));
            result.Page.Graphics.DrawString("Essential DocIO", heading, PdfBrushes.DarkBlue, new PointF(bounds.X, bounds.Y + image.Height));
            file = new FileStream(dataPath + "Essential DocIO.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            reader = new StreamReader(file, Encoding.ASCII);
            text = reader.ReadToEnd();
            reader.Dispose();

            element = new PdfTextElement(text, font);
            element.Brush = new PdfSolidBrush(Color.Black);
            element.StringFormat = format;

            bounds.Y = result.LastLineBounds.Y + image.Height + 40;
            bounds.X = bounds.Width + 20f;

            result = element.Draw(result.Page, new RectangleF(bounds.X, bounds.Y, bounds.Width, -1), layoutFormat);
            file = new FileStream(dataPath + "Essen DocIO.jpg", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            image = new PdfBitmap(file);
            bounds.Y = result.LastLineBounds.Y + 20f;
            bounds.X = bounds.Width + 20f;

            result.Page.Graphics.DrawImage(image, new PointF(bounds.X, bounds.Y));

            file = new FileStream(dataPath + "Essential XlsIO.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            reader = new StreamReader(file, Encoding.ASCII);
            text = reader.ReadToEnd();
            reader.Dispose();

            element = new PdfTextElement(text, font);
            element.Brush = new PdfSolidBrush(Color.Black);
            element.StringFormat = format;

            result.Page.Graphics.DrawString("Essential XlsIO", heading, PdfBrushes.DarkBlue, new PointF(bounds.X, bounds.Y + image.Height));

            bounds.Y = result.LastLineBounds.Y + image.Height + 40;
            bounds.X = bounds.Width + 20f;
            result = element.Draw(result.Page, new RectangleF(bounds.X, bounds.Y, bounds.Width, -1), layoutFormat);
            file = new FileStream(dataPath + "Essen XlsIO.jpg", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            image = new PdfBitmap(file);
            bounds.Y = result.LastLineBounds.Y + 20f;
            bounds.X = bounds.Width + 20f;

            result.Page.Graphics.DrawImage(image, new PointF(bounds.X, bounds.Y));

            //Save the PDF to the MemoryStream
            MemoryStream ms = new MemoryStream();
            doc.Save(ms);

            //If the position is not set to '0' then the PDF will be empty.
            ms.Position = 0;

            //Close the PDF document.
            doc.Close(true);

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
            fileStreamResult.FileDownloadName = "HeadersAndFooters.pdf";
            return fileStreamResult;
        }

        private void EndPageLayout2(object sender, EndPageLayoutEventArgs e)
        {
            EndTextPageLayoutEventArgs args = (EndTextPageLayoutEventArgs)e;
            PdfTextLayoutResult tlr = args.Result;
            RectangleF bounds = tlr.Bounds;
            args.NextPage = tlr.Page;
        }

        private void BeginPageLayout2(object sender, BeginPageLayoutEventArgs e)
        {
            RectangleF bounds = e.Bounds;

            // First column.
            if (!m_paginateStart)
            {
                bounds.X = bounds.Width + 20f;
                bounds.Y = 10f;
            }
            else
            {
                // Second column.
                bounds.X = 0f;
                m_paginateStart = false;
            }

            e.Bounds = bounds;
            m_columnBounds = bounds;
        }



        # region Helper Methods
        /// <summary>
        /// Adds header to the document
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        private void AddDocumentHeader(PdfDocument doc, string title, string description)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 50);

            //Create page template
            PdfPageTemplateElement header = new PdfPageTemplateElement(rect);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 24);
            float doubleHeight = font.Height * 2;
            Color activeColor = Color.FromArgb(44, 71, 120);
            SizeF imageSize = new SizeF(110f, 35f);
            //Locating the logo on the right corner of the Drawing Surface
            PointF imageLocation = new PointF(doc.Pages[0].GetClientSize().Width - imageSize.Width - 20, 5);

            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = string.Empty;
            dataPath = basePath + @"/PDF/";

            //Read the file
            FileStream file = new FileStream(dataPath + "logo.png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            PdfImage img = new PdfBitmap(file);

            //Draw the image in the Header.
            header.Graphics.DrawImage(img, imageLocation, imageSize);

            PdfSolidBrush brush = new PdfSolidBrush(activeColor);

            PdfPen pen = new PdfPen(Color.DarkBlue, 3f);
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 16, PdfFontStyle.Bold);

            //Set formattings for the text
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;

            //Draw title
            header.Graphics.DrawString(title, font, brush, new RectangleF(0, 0, header.Width, header.Height), format);
            brush = new PdfSolidBrush(Color.Gray);
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 6, PdfFontStyle.Bold);

            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Left;
            format.LineAlignment = PdfVerticalAlignment.Bottom;

            //Draw description
            header.Graphics.DrawString(description, font, brush, new RectangleF(0, 0, header.Width, header.Height - 8), format);

            //Draw some lines in the header
            pen = new PdfPen(Color.DarkBlue, 0.7f);
            header.Graphics.DrawLine(pen, 0, 0, header.Width, 0);
            pen = new PdfPen(Color.DarkBlue, 2f);
            header.Graphics.DrawLine(pen, 0, 03, header.Width + 3, 03);
            pen = new PdfPen(Color.DarkBlue, 2f);
            header.Graphics.DrawLine(pen, 0, header.Height - 3, header.Width, header.Height - 3);
            header.Graphics.DrawLine(pen, 0, header.Height, header.Width, header.Height);

            //Add header template at the top.
            doc.Template.Top = header;
        }

        /// <summary>
        /// Adds footer to the document
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="footerText"></param>
        private void AddDocumentFooter(PdfDocument doc, string footerText)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 50);

            //Create a page template
            PdfPageTemplateElement footer = new PdfPageTemplateElement(rect);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 8);

            PdfSolidBrush brush = new PdfSolidBrush(Color.Gray);

            PdfPen pen = new PdfPen(Color.DarkBlue, 3f);
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 6, PdfFontStyle.Bold);
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;
            footer.Graphics.DrawString(footerText, font, brush, new RectangleF(0, 18, footer.Width, footer.Height), format);

            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Right;
            format.LineAlignment = PdfVerticalAlignment.Bottom;

            //Create page number field
            PdfPageNumberField pageNumber = new PdfPageNumberField(font, brush);

            //Create page count field
            PdfPageCountField count = new PdfPageCountField(font, brush);

            //Create author field
            PdfDocumentAuthorField authorField = new PdfDocumentAuthorField(font, brush);

            footer.Graphics.DrawString("Page\tof", font, brush, new RectangleF(0, 0, footer.Width - 8, footer.Height - 8), format);
            //Draw current page number
            pageNumber.Draw(footer.Graphics, new PointF(496, 35));

            //Draw number of pages
            count.Draw(footer.Graphics, new PointF(510, 35));

            //Draw number of pages
            authorField.Draw(footer.Graphics, new PointF(320, 35));

            //Add the footer template at the bottom
            doc.Template.Bottom = footer;
        }
        #endregion


    }
}
