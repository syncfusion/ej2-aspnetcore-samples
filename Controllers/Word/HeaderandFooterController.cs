#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.IO;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Word
{
    public partial class WordController : Controller
    {
        #region HeaderandFooter
        public ActionResult HeaderandFooter(string Group1)
        {
            if (Group1 == null)
                return View();

            // Creating a new document.
            WordDocument doc = new WordDocument();
            // Add a new section to the document.
            IWSection section1 = doc.AddSection();
            // Set the header/footer setup.
            section1.PageSetup.DifferentFirstPage = true;
            // Inserting Header Footer to first page
            InsertFirstPageHeaderFooter(doc, section1);
            // Inserting Header Footer to all pages
            InsertPageHeaderFooter(doc, section1);

            // Add text to the document body section.
            IWParagraph par;
            par = section1.AddParagraph();

            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = basePath + @"/Word/WinFAQ.txt";
            //Insert Text into the word Document.
            StreamReader reader = new StreamReader(new FileStream(dataPath,FileMode.Open),System.Text.Encoding.ASCII);
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
            // Add a new paragraph for header to the document.
            IWParagraph headerPar = new WParagraph(doc);

            // Add a new table to the header.
            IWTable table = section.HeadersFooters.FirstPageHeader.AddTable();

            RowFormat format = new RowFormat();

            // Setting cleared table border style.
            format.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Cleared;

            // Inserting table with a row and two columns.
            table.ResetCells(1, 2, format, 265);

            // Inserting logo image to the table first cell.
            headerPar = table[0, 0].AddParagraph() as WParagraph;
            string basePath = _hostingEnvironment.WebRootPath;
            FileStream imageStream = new FileStream(basePath + @"/images/Word/Northwind_logo.png", FileMode.Open, FileAccess.Read);
            headerPar.AppendPicture(imageStream);
            //Set Image size
            (headerPar.Items[0] as WPicture).Width = 232.5f;
            (headerPar.Items[0] as WPicture).Height = 54.75f;
            // Inserting text to the table second cell.
            headerPar = table[0, 1].AddParagraph() as WParagraph;
            IWTextRange txt = headerPar.AppendText("Company Headquarters,\n2501 Aerial Center Parkway,\nSuite 110, Morrisville, NC 27560,\nTEL 1-888-936-8638.");
            txt.CharacterFormat.FontSize = 12;
            txt.CharacterFormat.CharacterSpacing = 1.7f;
            headerPar.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
            // Add a new paragraph to the header with address text.
            headerPar = new WParagraph(doc);
            headerPar.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            txt = headerPar.AppendText("\nFirst Page Header");
            txt.CharacterFormat.CharacterSpacing = 1.7f;
            section.HeadersFooters.FirstPageHeader.Paragraphs.Add(headerPar);

            // Add a footer paragraph text to the document.
            WParagraph footerPar = new WParagraph(doc);
            footerPar.ParagraphFormat.Tabs.AddTab(523f, TabJustification.Right, TabLeader.NoLeader);
            // Add text.
            footerPar.AppendText("Copyright Northwind Inc. 2001 - 2017");
            // Add page and Number of pages field to the document.
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

        #region InsertPageHeaderFooter
        private void InsertPageHeaderFooter(WordDocument doc, IWSection section1)
        {
            // Add a new paragraph for header to the document.
            IWParagraph headerPar = new WParagraph(doc);

            // Add a new table to the header
            IWTable table = section1.HeadersFooters.Header.AddTable();

            RowFormat format = new RowFormat();

            // Setting Single table border style.
            format.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;

            // Inserting table with a row and two columns.
            table.ResetCells(1, 2, format, 265);

            // Inserting logo image to the table first cell.
            headerPar = table[0, 0].AddParagraph() as WParagraph;
            string basePath = _hostingEnvironment.WebRootPath;
            FileStream imageStream = new FileStream(basePath + @"/images/Word/Northwind_logo.png", FileMode.Open, FileAccess.Read);
            headerPar.AppendPicture(imageStream);
            //Set Image size.
            (headerPar.Items[0] as WPicture).Width = 232.5f;
            (headerPar.Items[0] as WPicture).Height = 54.75f;
            // Inserting text to the table second cell.
            headerPar = table[0, 1].AddParagraph() as WParagraph;
            IWTextRange txt = headerPar.AppendText("Company Headquarters,\n2501 Aerial Center Parkway,\nSuite 110, Morrisville, NC 27560,\nTEL 1-888-936-8638.");
            txt.CharacterFormat.FontSize = 12;
            txt.CharacterFormat.CharacterSpacing = 1.7f;
            headerPar.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;

            // Add a footer paragraph text to the document.
            WParagraph footerPar = new WParagraph(doc);
            footerPar.ParagraphFormat.Tabs.AddTab(523f, TabJustification.Right, TabLeader.NoLeader);
            // Add text.
            footerPar.AppendText("Copyright Northwind Inc. 2001 - 2017");
            // Add page and Number of pages field to the document.
            footerPar.AppendText("\tPage ");
            IWField ff = footerPar.AppendField("Page", FieldType.FieldPage);

            section1.HeadersFooters.Footer.Paragraphs.Add(footerPar);

            #region Page Number Settings
            section1.PageSetup.RestartPageNumbering = true;
            section1.PageSetup.PageStartingNumber = 1;
            section1.PageSetup.PageNumberStyle = PageNumberStyle.Arabic;
            #endregion Page Number Settings
        }
        #endregion InsertPageHeaderFooter
        #endregion HeaderandFooter
    }
}