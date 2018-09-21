using System;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.IO;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        //
        // GET: /PageSettings/       

        public ActionResult PageSettings()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PageSettings(string InsideBrowser)
        {
            // Create a new document class object.
            PdfDocument doc = new PdfDocument();

            PdfSection section;

            PdfPage pdfPage;

            // Create few sections with one page in each.
            for (int i = 0; i < 4; ++i)
            {
                section = doc.Sections.Add();
                //Create page label
                PdfPageLabel label = new PdfPageLabel();

                label.Prefix = "Sec" + i + "-";
                section.PageLabel = label;
                pdfPage = section.Pages.Add();
                section.Pages[0].Graphics.SetTransparency(0.35f);
                section.PageSettings.Transition.PageDuration = 1;
                section.PageSettings.Transition.Duration = 1;
                section.PageSettings.Transition.Style = PdfTransitionStyle.Box;
            }

            //Set page size
            doc.PageSettings.Size = PdfPageSize.A6;

            //Set viewer prefernce.
            doc.ViewerPreferences.HideToolbar = true;
            doc.ViewerPreferences.PageMode = PdfPageMode.FullScreen;

            //Set page orientation
            doc.PageSettings.Orientation = PdfPageOrientation.Landscape;

            //Create a brush
            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);
            brush.Color = new PdfColor(Syncfusion.Drawing.Color.LightGreen);

            //Create a Rectangle
            PdfRectangle rect = new PdfRectangle(0, 0, 1000f, 1000f);
            rect.Brush = brush;
            PdfPen pen = new PdfPen(Syncfusion.Drawing.Color.Black);
            pen.Width = 6f;

            //Get the first page in first section
            pdfPage = doc.Sections[0].Pages[0];

            //Draw the rectangle
            rect.Draw(pdfPage.Graphics);

            //Draw a line
            pdfPage.Graphics.DrawLine(pen, 0, 100, 300, 100);

            // Add margins.
            doc.PageSettings.SetMargins(0f);

            //Get the first page in second section
            pdfPage = doc.Sections[1].Pages[0];
            doc.Sections[1].PageSettings.Rotate = PdfPageRotateAngle.RotateAngle90;
            rect.Draw(pdfPage.Graphics);

            pdfPage.Graphics.DrawLine(pen, 0, 100, 300, 100);

            // Change the angle f the section. This should rotate the previous page.
            doc.Sections[2].PageSettings.Rotate = PdfPageRotateAngle.RotateAngle180;
            pdfPage = doc.Sections[2].Pages[0];
            rect.Draw(pdfPage.Graphics);
            pdfPage.Graphics.DrawLine(pen, 0, 100, 300, 100);

            section = doc.Sections[3];
            section.PageSettings.Orientation = PdfPageOrientation.Portrait;
            pdfPage = section.Pages[0];
            rect.Draw(pdfPage.Graphics);
            pdfPage.Graphics.DrawLine(pen, 0, 100, 300, 100);

            //Set the font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16f);
            PdfSolidBrush fieldBrush = new PdfSolidBrush(Color.Black);

            //Create page number field
            PdfPageNumberField pageNumber = new PdfPageNumberField(font, fieldBrush);

            //Create page count field
            PdfPageCountField count = new PdfPageCountField(font, fieldBrush);

            //Draw page template
            PdfPageTemplateElement templateElement = new PdfPageTemplateElement(400, 400);
            templateElement.Graphics.DrawString("Page :\tof", font, PdfBrushes.Black, new PointF(260, 200));

            //Draw current page number
            pageNumber.Draw(templateElement.Graphics, new PointF(306, 200));

            //Draw number of pages
            count.Draw(templateElement.Graphics, new PointF(345, 200));
            doc.Template.Stamps.Add(templateElement);
            templateElement.Background = true;

            //Save the PDF to the MemoryStream
            MemoryStream ms = new MemoryStream();

            doc.Save(ms);

            //If the position is not set to '0' then the PDF will be empty.
            ms.Position = 0;

            //Close the PDF document.
            doc.Close(true);

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
            fileStreamResult.FileDownloadName = "PageSettings.pdf";
            return fileStreamResult;
        }

    }
}
