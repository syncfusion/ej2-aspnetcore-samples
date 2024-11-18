#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;

namespace EJ2CoreSampleBrowser.Pages.Pdf;

public class TextFlow : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public TextFlow(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public ActionResult OnPost(string InsideBrowser)
    {
        //Create a new PDF document.
        PdfDocument doc = new PdfDocument();

        //Set compression level
        doc.Compression = PdfCompressionLevel.None;

        //Add a page to the document.
        PdfPage page = doc.Pages.Add();

        string basePath = _hostingEnvironment.WebRootPath;
        string dataPath = string.Empty;
        dataPath = basePath + @"/PDF/";

        //Read the file
        FileStream file = new FileStream(dataPath + "Manual.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

        //Read the text from the text file           
        StreamReader reader = new StreamReader(file, System.Text.Encoding.ASCII);
        string text = reader.ReadToEnd();
        reader.Dispose();

        //Set the font           
        PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);

        //Set the formats for the text
        PdfStringFormat format = new PdfStringFormat();
        format.Alignment = PdfTextAlignment.Justify;
        format.LineAlignment = PdfVerticalAlignment.Top;
        format.ParagraphIndent = 15f;

        //Create a text element 
        PdfTextElement element = new PdfTextElement(text, font);
        element.Brush = new PdfSolidBrush(Color.Black);
        element.StringFormat = format;
        element.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

        //Set the properties to paginate the text.
        PdfLayoutFormat layoutFormat = new PdfLayoutFormat();
        layoutFormat.Break = PdfLayoutBreakType.FitPage;
        layoutFormat.Layout = PdfLayoutType.Paginate;

        RectangleF bounds = new RectangleF(PointF.Empty, page.Graphics.ClientSize);

        //Raise the events to draw the graphic elements for each page.
        element.BeginPageLayout += new BeginPageLayoutEventHandler(BeginPageLayout);
        element.EndPageLayout += new EndPageLayoutEventHandler(EndPageLayout);

        //Draw the text element with the properties and formats set.
        PdfTextLayoutResult result = element.Draw(page, bounds, layoutFormat);

        //Save the PDF to the MemoryStream
        MemoryStream ms = new MemoryStream();
        doc.Save(ms);

        //If the position is not set to '0' then the PDF will be empty.
        ms.Position = 0;

        //Close the PDF document.
        doc.Close(true);

        //Download the PDF document in the browser.
        FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
        fileStreamResult.FileDownloadName = "TextFlow.pdf";
        return fileStreamResult;
    }

    private void BeginPageLayout(object sender, BeginPageLayoutEventArgs e)
    {
        int index = e.Page.Section.Pages.IndexOf(e.Page);
        float offset = 50;
        PdfSolidBrush brush = new PdfSolidBrush(Color.LightBlue);

        if (index % 2 == 0)
        {
            RectangleF bounds = e.Bounds;
            e.Page.Graphics.DrawEllipse(brush, bounds.Width / 2 - offset, bounds.Height / 2 - offset, 2 * offset,
                2 * offset);
        }
        else
        {
            RectangleF bounds = e.Bounds;
            e.Page.Graphics.DrawRectangle(brush, bounds.Width / 2 - offset, bounds.Height / 2 - offset, 2 * offset,
                2 * offset);
        }
    }

    private void EndPageLayout(object sender, EndPageLayoutEventArgs e)
    {
        EndTextPageLayoutEventArgs args = (EndTextPageLayoutEventArgs)e;
        PdfPage page = args.Result.Page;
        PdfPen pen = PdfPens.Black;
        page.Graphics.DrawRectangle(pen, new RectangleF(PointF.Empty, page.Graphics.ClientSize));
    }
}