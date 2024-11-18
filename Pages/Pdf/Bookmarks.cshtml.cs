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
using Syncfusion.Pdf.Interactive;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;

namespace EJ2CoreSampleBrowser.Pages.Pdf;

public class Bookmarks : PageModel
{
    public void OnGet()
    {
        
    }

    [HttpPost]
    public ActionResult OnPost(string Browser)
    {
        //Creates a new PDF document.
        PdfDocument document = new PdfDocument();

        //Set the Font
        PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f);

        //Set PdfBrush
        PdfBrush brush = new PdfSolidBrush(Color.Black);

        for (int i = 1; i <= 3; i++)
        {
            PdfPage pages = document.Pages.Add();

            //Add bookmark in PDF document
            PdfBookmark bookmark = AddBookmark1(document, pages, "Chapter " + i, new PointF(10, 10), font);

            bookmark.Color = Color.Red;

            //Add sections to bookmark
            PdfBookmark section1 = AddSection1(bookmark, pages, "Section " + i + ".1", new PointF(30, 30), false, font);
            section1.Color = Color.Green;
            PdfBookmark section2 =
                AddSection1(bookmark, pages, "Section " + i + ".2", new PointF(30, 400), false, font);
            section2.Color = Color.Green;

            //Add subsections to section
            PdfBookmark subsection1 =
                AddSection1(section1, pages, "Paragraph " + i + ".1.1", new PointF(50, 50), true, font);
            subsection1.Color = Color.Blue;
            PdfBookmark subsection2 =
                AddSection1(section1, pages, "Paragraph " + i + ".1.2", new PointF(50, 150), true, font);
            subsection2.Color = Color.Blue;
            PdfBookmark subsection3 =
                AddSection1(section1, pages, "Paragraph " + i + ".1.3", new PointF(50, 250), true, font);
            subsection3.Color = Color.Blue;
            PdfBookmark subsection4 =
                AddSection1(section2, pages, "Paragraph " + i + ".2.1", new PointF(50, 420), true, font);
            subsection4.Color = Color.Blue;
            PdfBookmark subsection5 =
                AddSection1(section2, pages, "Paragraph " + i + ".2.2", new PointF(50, 560), true, font);
            subsection5.Color = Color.Blue;
            PdfBookmark subsection6 =
                AddSection1(section2, pages, "Paragraph " + i + ".2.3", new PointF(50, 680), true, font);
            subsection6.Color = Color.Blue;
        }

        //Save the PDF to the MemoryStream
        MemoryStream ms = new MemoryStream();

        document.Save(ms);

        //If the position is not set to '0' then the PDF will be empty.
        ms.Position = 0;

        document.Close(true);

        //Download the PDF document in the browser.
        FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
        fileStreamResult.FileDownloadName = "Bookmarks.pdf";
        return fileStreamResult;
    }

    # region Methods
    public PdfBookmark AddBookmark1(PdfDocument document,PdfPage page, string title, PointF point, PdfFont font)
    {

        PdfGraphics graphics = page.Graphics;

        //Add bookmark in PDF document
        PdfBookmark bookmarks = document.Bookmarks.Add(title);

        PdfBrush brush = new PdfSolidBrush(Color.Red);

        //Draw the content in the PDF page
        graphics.DrawString(title, font, brush, new PointF(point.X, point.Y));

        bookmarks.Destination = new PdfDestination(page);
        bookmarks.Destination.Location = point;

        return bookmarks;
    }
    public PdfBookmark AddSection1(PdfBookmark bookmark, PdfPage page, string title, PointF point, bool isSubSection, PdfFont font)
    {
        PdfGraphics graphics = page.Graphics;
        //Add bookmark in PDF document
        PdfBookmark bookmarks = bookmark.Add(title);

        PdfBrush brush = new PdfSolidBrush(Color.Green);

        if (bookmark.Title.StartsWith("Section"))
        {
            brush = new PdfSolidBrush(Color.Blue);
        }

        //Draw the content in the PDF page
        graphics.DrawString(title, font, brush, new PointF(point.X, point.Y));

        bookmarks.Destination = new PdfDestination(page);
        bookmarks.Destination.Location = point;

        return bookmarks;
    }
    #endregion
}