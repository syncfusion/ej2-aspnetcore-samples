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
using Syncfusion.Pdf.Interactive;

namespace EJ2CoreSampleBrowser.Pages.Pdf;

public class NamedDestination : PageModel
{
    public void OnGet()
    {
        
    }
    # region Methods
    public PdfBookmark AddBookmark(PdfDocument document,PdfPage page, string title, PointF point, PdfFont font, PdfBrush brush)
    {
        PdfGraphics graphics = page.Graphics;
        //Add bookmark in PDF document
        PdfBookmark bookmarks = document.Bookmarks.Add(title);

        //Draw the content in the PDF page
        graphics.DrawString(title, font, brush, new PointF(point.X, point.Y));

        //Adding bookmark with named destination
        PdfNamedDestination namedDestination = new PdfNamedDestination(title);
        namedDestination.Destination = new PdfDestination(page, new PointF(point.X, point.Y));
        namedDestination.Destination.Mode = PdfDestinationMode.FitToPage;
        document.NamedDestinationCollection.Add(namedDestination);
        bookmarks.NamedDestination = namedDestination;

        return bookmarks;
    }
    public PdfBookmark AddDocumentSection(PdfDocument document,PdfBookmark bookmark, PdfPage page, string title, PointF point, bool isSubSection, PdfFont font, PdfBrush brush)
    {
        PdfGraphics graphics = page.Graphics;
        //Add bookmark in PDF document
        PdfBookmark bookmarks = bookmark.Add(title);

        //Draw the content in the PDF page
        graphics.DrawString(title, font, brush, new PointF(point.X, point.Y));

        //Adding bookmark with named destination
        PdfNamedDestination namedDestination = new PdfNamedDestination(title);
        namedDestination.Destination = new PdfDestination(page, new PointF(point.X, point.Y));
        if (isSubSection == true)
        {
            namedDestination.Destination.Zoom = 2f;
        }
        else
        {
            namedDestination.Destination.Zoom = 1f;
        }
        document.NamedDestinationCollection.Add(namedDestination);
        bookmarks.NamedDestination = namedDestination;

        return bookmarks;
    }
    #endregion

    [HttpPost]
    public ActionResult OnPost(string InsideBrowser)
    {
        PdfDocument document = new PdfDocument();
        PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f);
        PdfBrush brush = new PdfSolidBrush(Color.Black);

        for (int i = 1; i <= 6; i++)
        {
            PdfPage pages = document.Pages.Add();
            //Add bookmark in PDF document
            PdfBookmark bookmark = AddBookmark(document, pages, "Chapter " + i, new PointF(10, 10), font, brush);
            //Add sections to bookmark
            PdfBookmark section1 = AddDocumentSection(document, bookmark, pages, "Section " + i + ".1",
                new PointF(30, 30), false, font, brush);
            PdfBookmark section2 = AddDocumentSection(document, bookmark, pages, "Section " + i + ".2",
                new PointF(30, 400), false, font, brush);
            //Add subsections to section
            PdfBookmark subsection1 = AddDocumentSection(document, section1, pages, "Paragraph " + i + ".1.1",
                new PointF(50, 50), true, font, brush);
            PdfBookmark subsection2 = AddDocumentSection(document, section1, pages, "Paragraph " + i + ".1.2",
                new PointF(50, 150), true, font, brush);
            PdfBookmark subsection3 = AddDocumentSection(document, section1, pages, "Paragraph " + i + ".1.3",
                new PointF(50, 250), true, font, brush);
            PdfBookmark subsection4 = AddDocumentSection(document, section2, pages, "Paragraph " + i + ".2.1",
                new PointF(50, 420), true, font, brush);
            PdfBookmark subsection5 = AddDocumentSection(document, section2, pages, "Paragraph " + i + ".2.2",
                new PointF(50, 560), true, font, brush);
            PdfBookmark subsection6 = AddDocumentSection(document, section2, pages, "Paragraph " + i + ".2.3",
                new PointF(50, 680), true, font, brush);
        }

        MemoryStream stream = new MemoryStream();

        //Save the PDF document
        document.Save(stream);

        stream.Position = 0;

        //Close the PDF document
        document.Close(true);

        //Download the PDF document in the browser.
        FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
        fileStreamResult.FileDownloadName = "NamedDestination.pdf";
        return fileStreamResult;
    }
}