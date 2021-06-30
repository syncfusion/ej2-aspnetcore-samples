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
        // GET: /Layers/

        public ActionResult Layers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Layers(string InsideBrowser)
        {
            //Create a new PDF document
            PdfDocument doc = new PdfDocument();
            doc.PageSettings = new PdfPageSettings(new SizeF(350, 300));

            PdfPage page = doc.Pages.Add();

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16);

            page.Graphics.DrawString("Layers", font, PdfBrushes.DarkBlue, new PointF(150, 10));

            //Add the first layer
            PdfPageLayer layer = page.Layers.Add("Layer1");

            PdfGraphics graphics = layer.Graphics;
            graphics.TranslateTransform(100, 60);

            //Draw Arc 
            PdfPen pen = new PdfPen(Color.Red, 50);
            RectangleF rect = new RectangleF(0, 0, 50, 50);
            graphics.DrawArc(pen, rect, 360, 360);

            pen = new PdfPen(Color.Blue, 30);
            graphics.DrawArc(pen, 0, 0, 50, 50, 360, 360);

            pen = new PdfPen(Color.Yellow, 20);
            graphics.DrawArc(pen, rect, 360, 360);

            pen = new PdfPen(Color.Green, 10);
            graphics.DrawArc(pen, 0, 0, 50, 50, 360, 360);

            //Add another layer on the page
            layer = page.Layers.Add("Layer2");

            graphics = layer.Graphics;
            graphics.TranslateTransform(100, 180);
            graphics.SkewTransform(0, 50);

            //Draw another set of elements
            pen = new PdfPen(Color.Red, 50);
            graphics.DrawArc(pen, rect, 360, 360);
            pen = new PdfPen(Color.Blue, 30);
            graphics.DrawArc(pen, 0, 0, 50, 50, 360, 360);
            pen = new PdfPen(Color.Yellow, 20);
            graphics.DrawArc(pen, rect, 360, 360);
            pen = new PdfPen(Color.Green, 10);
            graphics.DrawArc(pen, 0, 0, 50, 50, 360, 360);

            //Add another layer
            layer = page.Layers.Add("Layer3");
            graphics = layer.Graphics;
            graphics.TranslateTransform(160, 120);

            //Draw another set of elements.
            pen = new PdfPen(Color.Red, 50);
            graphics.DrawArc(pen, rect, -60, 60);
            pen = new PdfPen(Color.Blue, 30);
            graphics.DrawArc(pen, 0, 0, 50, 50, -60, 60);
            pen = new PdfPen(Color.Yellow, 20);
            graphics.DrawArc(pen, rect, -60, 60);
            pen = new PdfPen(Color.Green, 10);
            graphics.DrawArc(pen, 0, 0, 50, 50, -60, 60);

            MemoryStream stream = new MemoryStream();

            //Save the PDF document
            doc.Save(stream);

            stream.Position = 0;

            //Close the PDF document
            doc.Close(true);

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = "Layers.pdf";
            return fileStreamResult;
        }

    }
}
