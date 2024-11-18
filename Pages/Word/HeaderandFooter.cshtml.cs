#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Pages.Word;

public class HeaderandFooter : PageModel
{
    public void OnGet()
    {

    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public HeaderandFooter(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    #region HeaderandFooter

    public ActionResult OnPost(string Group1, string chkFirst, string chkOddEven)
    {
        if (Group1 == null)
            return null;
            // return View();

        // Creating a new document.
        WordDocument doc = new WordDocument();
        // Add a new section to the document.
        IWSection section1 = doc.AddSection();

        if (chkFirst == "FirstPage")
        {
            //Enable different first page.
            section1.PageSetup.DifferentFirstPage = true;
            //Inserting Header Footer to first page.
            InsertFirstPageHeaderFooter(doc, section1);

            if (chkOddEven == "OddAndEvenPages")
            {
                //Enable different odd and even pages.
                section1.PageSetup.DifferentOddAndEvenPages = true;
                //Inserting Header Footer to odd pages.
                InsertOddPageHeaderFooter(doc, section1);
                //Inserting Header Footer to even pages.
                InsertEvenPageHeaderFooter(doc, section1);
            }
            else
            {
                //Inserting Header Footer to remaining pages.
                InsertDefaultPageHeaderFooter(doc, section1);
            }
        }
        else if (chkOddEven == "OddAndEvenPages")
        {
            //Enable different odd and even pages.
            section1.PageSetup.DifferentOddAndEvenPages = true;
            //Inserting Header Footer to odd pages.
            InsertOddPageHeaderFooter(doc, section1);
            //Inserting Header Footer to even pages.
            InsertEvenPageHeaderFooter(doc, section1);
        }
        else
        {
            //Inserting Header Footer to all pages.
            InsertDefaultPageHeaderFooter(doc, section1);
        }

        // Add text to the document body section.
        IWParagraph par;
        par = section1.AddParagraph();

        string basePath = _hostingEnvironment.WebRootPath;
        string dataPath = basePath + @"/Word/WinFAQ.txt";
        //Insert Text into the word Document.
        StreamReader reader = new StreamReader(new FileStream(dataPath, FileMode.Open), System.Text.Encoding.ASCII);
        string text = reader.ReadToEnd();
        par.AppendText(text);
        reader.Dispose();
        reader = null;

        FormatType type = FormatType.Docx;
        string filename = "HeaderAndFooter.docx";
        string contenttype = "application/vnd.ms-word.document.12";

        #region Document SaveOption

        //Save as .doc format
        if (Group1 == "WordDoc")
        {
            type = FormatType.Doc;
            filename = "HeaderAndFooter.doc";
            contenttype = "application/msword";
        }
        //Save as .xml format
        else if (Group1 == "WordML")
        {
            type = FormatType.WordML;
            filename = "HeaderAndFooter.xml";
            contenttype = "application/msword";
        }

        #endregion Document SaveOption

        MemoryStream ms = new MemoryStream();
        doc.Save(ms, type);
        doc.Close();
        ms.Position = 0;
        return File(ms, contenttype, filename);
    }

    #region InsertFirstPageHeaderFooter

    private void InsertFirstPageHeaderFooter(WordDocument doc, IWSection section)
    {
        //Add a new paragraph for header to the document.
        IWParagraph headerPar = new WParagraph(doc);

        //Add a new table to the header.
        IWTable table = section.HeadersFooters.FirstPageHeader.AddTable();
        RowFormat format = new RowFormat();

        //Setting cleared table border style.
        format.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Cleared;

        //Inserting table with a row and two columns.
        table.ResetCells(1, 2, format, 265);

        //Inserting logo image to the table first cell.
        headerPar = table[0, 0].AddParagraph() as WParagraph;
        string basePath = _hostingEnvironment.WebRootPath;
        FileStream imageStream =
            new FileStream(basePath + @"/images/Word/Northwind_logo.png", FileMode.Open, FileAccess.Read);
        headerPar.AppendPicture(imageStream);

        //Set Image size.
        (headerPar.Items[0] as WPicture).Width = 232.5f;
        (headerPar.Items[0] as WPicture).Height = 54.75f;

        //Inserting text to the table second cell.
        headerPar = table[0, 1].AddParagraph() as WParagraph;
        IWTextRange txt =
            headerPar.AppendText(
                "Company Headquarters,\n2501 Aerial Center Parkway,\nSuite 110, Morrisville, NC 27560,\nTEL 1-888-936-8638.");
        txt.CharacterFormat.FontSize = 12;
        txt.CharacterFormat.CharacterSpacing = 1.7f;
        headerPar.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;

        //Add a new paragraph to the header with address text.
        headerPar = new WParagraph(doc);
        headerPar.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
        txt = headerPar.AppendText("\nFirst Page Header");
        txt.CharacterFormat.CharacterSpacing = 1.7f;
        section.HeadersFooters.FirstPageHeader.Paragraphs.Add(headerPar);

        //Add a footer paragraph text to the document.
        WParagraph footerPar = new WParagraph(doc);
        footerPar.ParagraphFormat.Tabs.AddTab(523f, TabJustification.Right, TabLeader.NoLeader);

        //Add text
        footerPar.AppendText("Copyright Northwind Inc. 2001 - 2017");

        //Add page and Number of pages field to the document.
        footerPar.AppendText("\tFirst Page ");
        footerPar.AppendField("Page", FieldType.FieldPage);
        section.HeadersFooters.FirstPageFooter.Paragraphs.Add(footerPar);

        #region Page Number Settings

        section.PageSetup.RestartPageNumbering = true;
        section.PageSetup.PageStartingNumber = 1;
        section.PageSetup.PageNumberStyle = PageNumberStyle.Arabic;

        #endregion Page Number Settings
    }

    #endregion InsertFirstPageHeaderFooter

    #region InsertDefaultPageHeaderFooter

    private void InsertDefaultPageHeaderFooter(WordDocument doc, IWSection section)
    {
        //Add a new paragraph for header to the document.
        IWParagraph headerPar = new WParagraph(doc);

        //Add a new table to the header
        IWTable table = section.HeadersFooters.Header.AddTable();
        RowFormat format = new RowFormat();

        //Setting Single table border style.
        format.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;

        //Inserting table with a row and two columns.
        table.ResetCells(1, 2, format, 265);

        //Inserting logo image to the table first cell.
        headerPar = table[0, 0].AddParagraph() as WParagraph;
        string basePath = _hostingEnvironment.WebRootPath;
        FileStream imageStream =
            new FileStream(basePath + @"/images/Word/Northwind_logo.png", FileMode.Open, FileAccess.Read);
        headerPar.AppendPicture(imageStream);

        //Set Image size.
        (headerPar.Items[0] as WPicture).Width = 232.5f;
        (headerPar.Items[0] as WPicture).Height = 54.75f;

        //Inserting text to the table second cell.
        headerPar = table[0, 1].AddParagraph() as WParagraph;
        IWTextRange txt =
            headerPar.AppendText(
                "Company Headquarters,\n2501 Aerial Center Parkway,\nSuite 110, Morrisville, NC 27560,\nTEL 1-888-936-8638.");
        txt.CharacterFormat.FontSize = 12;
        txt.CharacterFormat.CharacterSpacing = 1.7f;
        headerPar.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;

        //Add a footer paragraph text to the document.
        WParagraph footerPar = new WParagraph(doc);
        footerPar.ParagraphFormat.Tabs.AddTab(523f, TabJustification.Right, TabLeader.NoLeader);

        //Add text.
        footerPar.AppendText("Copyright Northwind Inc. 2001 - 2017");

        //Add page and Number of pages field to the document.
        footerPar.AppendText("\tPage ");
        footerPar.AppendField("Page", FieldType.FieldPage);
        section.HeadersFooters.Footer.Paragraphs.Add(footerPar);

        #region Page Number Settings

        section.PageSetup.RestartPageNumbering = true;
        section.PageSetup.PageStartingNumber = 1;
        section.PageSetup.PageNumberStyle = PageNumberStyle.Arabic;

        #endregion Page Number Settings
    }

    #endregion InsertDefaultPageHeaderFooter

    #region InsertOddPageHeaderFooter

    private void InsertOddPageHeaderFooter(WordDocument doc, IWSection section)
    {
        //Add a new paragraph for header to the document.
        IWParagraph headerPar = new WParagraph(doc);

        //Add a new table to the header.
        IWTable table = section.HeadersFooters.OddHeader.AddTable();
        RowFormat format = new RowFormat();

        //Setting cleared table border style.
        format.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Cleared;

        //Inserting table with a row and two columns.
        table.ResetCells(1, 2, format, 265);

        //Inserting logo image to the table first cell.
        headerPar = table[0, 0].AddParagraph() as WParagraph;
        string basePath = _hostingEnvironment.WebRootPath;
        FileStream imageStream =
            new FileStream(basePath + @"/images/Word/Northwind_logo.png", FileMode.Open, FileAccess.Read);
        headerPar.AppendPicture(imageStream);

        //Set Image size.
        (headerPar.Items[0] as WPicture).Width = 232.5f;
        (headerPar.Items[0] as WPicture).Height = 54.75f;

        //Inserting text to the table second cell.
        headerPar = table[0, 1].AddParagraph() as WParagraph;
        IWTextRange txt =
            headerPar.AppendText(
                "Company Headquarters,\n2501 Aerial Center Parkway,\nSuite 110, Morrisville, NC 27560,\nTEL 1-888-936-8638.");
        txt.CharacterFormat.FontSize = 12;
        txt.CharacterFormat.CharacterSpacing = 1.7f;
        headerPar.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;

        //Add a new paragraph to the header with address text.
        headerPar = new WParagraph(doc);
        headerPar.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
        txt = headerPar.AppendText("\nOdd Page Header");
        txt.CharacterFormat.CharacterSpacing = 1.7f;
        section.HeadersFooters.OddHeader.Paragraphs.Add(headerPar);

        //Add a footer paragraph text to the document.
        WParagraph footerPar = new WParagraph(doc);
        footerPar.ParagraphFormat.Tabs.AddTab(523f, TabJustification.Right, TabLeader.NoLeader);

        //Add text.
        footerPar.AppendText("Copyright Northwind Inc. 2001 - 2017");

        //Add page and Number of pages field to the document.
        footerPar.AppendText("\tPage ");
        footerPar.AppendField("Page", FieldType.FieldPage);
        section.HeadersFooters.OddFooter.Paragraphs.Add(footerPar);

        #region Page Number Settings

        section.PageSetup.RestartPageNumbering = true;
        section.PageSetup.PageStartingNumber = 1;
        section.PageSetup.PageNumberStyle = PageNumberStyle.Arabic;

        #endregion Page Number Settings
    }

    #endregion InsertOddPageHeaderFooter

    #region InsertEvenPageHeaderFooter

    private void InsertEvenPageHeaderFooter(WordDocument doc, IWSection section)
    {
        //Add a new paragraph for header to the document.
        IWParagraph headerPar = new WParagraph(doc);

        //Add a new table to the header
        IWTable table = section.HeadersFooters.EvenHeader.AddTable();
        RowFormat format = new RowFormat();

        //Setting Single table border style.
        format.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;

        //Inserting table with a row and two columns.
        table.ResetCells(1, 2, format, 265);

        //Inserting logo image to the table first cell.
        headerPar = table[0, 0].AddParagraph() as WParagraph;
        string basePath = _hostingEnvironment.WebRootPath;
        FileStream imageStream = new FileStream(basePath + @"/images/Word/Northwind_logo.png", FileMode.Open,
            FileAccess.Read);
        headerPar.AppendPicture(imageStream);

        //Set Image size.
        (headerPar.Items[0] as WPicture).Width = 232.5f;
        (headerPar.Items[0] as WPicture).Height = 54.75f;

        //Inserting text to the table second cell.
        headerPar = table[0, 1].AddParagraph() as WParagraph;
        IWTextRange txt =
            headerPar.AppendText(
                "Company Headquarters,\n2501 Aerial Center Parkway,\nSuite 110, Morrisville, NC 27560,\nTEL 1-888-936-8638.");
        txt.CharacterFormat.FontSize = 12;
        txt.CharacterFormat.CharacterSpacing = 1.7f;
        headerPar.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;

        //Add a new paragraph to the header with address text.
        headerPar = new WParagraph(doc);
        headerPar.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
        txt = headerPar.AppendText("\nEven Page Header");
        txt.CharacterFormat.CharacterSpacing = 1.7f;
        section.HeadersFooters.EvenHeader.Paragraphs.Add(headerPar);

        //Add a footer paragraph text to the document.
        WParagraph footerPar = new WParagraph(doc);
        footerPar.ParagraphFormat.Tabs.AddTab(523f, TabJustification.Right, TabLeader.NoLeader);

        //Add text.
        footerPar.AppendText("Copyright Northwind Inc. 2001 - 2017");

        //Add page and Number of pages field to the document.
        footerPar.AppendText("\tPage ");
        footerPar.AppendField("Page", FieldType.FieldPage);
        footerPar.AppendText(" of ");
        footerPar.AppendField("TotalNumberOfPages", FieldType.FieldNumPages);
        section.HeadersFooters.EvenFooter.Paragraphs.Add(footerPar);

        #region Page Number Settings

        section.PageSetup.RestartPageNumbering = true;
        section.PageSetup.PageStartingNumber = 1;
        section.PageSetup.PageNumberStyle = PageNumberStyle.Arabic;

        #endregion Page Number Settings
    }

    #endregion InsertEvenPageHeaderFooter

    #endregion HeaderandFooter
}