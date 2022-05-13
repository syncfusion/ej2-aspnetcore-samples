#region Copyright Syncfusion Inc. 2001-2022
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Reflection;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Word
{
    public partial class WordController : Controller
    {
        #region BookmarkNavigation
        public ActionResult BookmarkNavigation(string Group1,string Button)
        {
            if (Group1 == null)
                return View();
            if (Button == null)
                return View();
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = basePath + @"/Word/Bookmark_Template.docx";
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            string contenttype1 = "application/vnd.ms-word.document.12";
            if (Button == "View Template")
                return File(fileStream, contenttype1, "Bookmark_Template.docx");

            #region BookmarkNavigation
            // Creating a new document.
            WordDocument document = new WordDocument();
            //Adds section with one empty paragraph to the Word document
            document.EnsureMinimal();
            //Sets the page margins
            document.LastSection.PageSetup.Margins.All = 72f;
            //Appends bookmark to the paragraph
            document.LastParagraph.AppendBookmarkStart("NorthwindDatabase");
            document.LastParagraph.AppendText("Northwind database with normalization concept");
            document.LastParagraph.AppendBookmarkEnd("NorthwindDatabase");
            basePath = _hostingEnvironment.WebRootPath;
            dataPath = basePath + @"/Word/Bookmark_Template.docx";
            string dataPathTemp = basePath + @"/Word/BkmkDocumentPart_Template.docx";
            // Open an existing template document with single section to get Northwind.information            
            WordDocument nwdInformation = new WordDocument();
            fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            nwdInformation.Open(fileStream, FormatType.Doc);
            fileStream.Dispose();
            fileStream = null;
            // Open an existing template document with multiple section to get Northwind data.
            WordDocument templateDocument = new WordDocument();
            fileStream = new FileStream(dataPathTemp, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            templateDocument.Open(fileStream, FormatType.Doc);
            fileStream.Dispose();
            fileStream = null;
            // Creating a bookmark navigator. Which help us to navigate through the 
            // bookmarks in the template document.
            BookmarksNavigator bk = new BookmarksNavigator(templateDocument);
            // Move to the NorthWind bookmark in template document
            bk.MoveToBookmark("NorthWind");
            //Gets the bookmark content as WordDocumentPart
            WordDocumentPart documentPart = bk.GetContent();
            // Creating a bookmark navigator. Which help us to navigate through the 
            // bookmarks in the Northwind information document.
            bk = new BookmarksNavigator(nwdInformation);
            // Move to the information bookmark 
            bk.MoveToBookmark("Information");
            // Get the content of information bookmark.
            TextBodyPart bodyPart = bk.GetBookmarkContent();
            // Creating a bookmark navigator. Which help us to navigate through the 
            // bookmarks in the destination document.
            bk = new BookmarksNavigator(document);
            // Move to the NorthWind database in the destination document
            bk.MoveToBookmark("NorthwindDatabase");
            //Replace the bookmark content using word document parts
            bk.ReplaceContent(documentPart);
            // Move to the Northwind_Information in the destination document
            bk.MoveToBookmark("Northwind_Information");
            // Replacing content of Northwind_Information bookmark.
            bk.ReplaceBookmarkContent(bodyPart);
            #region Bookmark selection for table
            // Creating a bookmark navigator. Which help us to navigate through the 
            // bookmarks in the Northwind information document.
            bk = new BookmarksNavigator(nwdInformation);
            bk.MoveToBookmark("SuppliersTable");
            //Sets the column index where the bookmark starts within the table
            bk.CurrentBookmark.FirstColumn = 1;
            //Sets the column index where the bookmark ends within the table
            bk.CurrentBookmark.LastColumn = 5;
            // Get the content of suppliers table bookmark.
            bodyPart = bk.GetBookmarkContent();
            // Creating a bookmark navigator. Which help us to navigate through the 
            // bookmarks in the destination document.
            bk = new BookmarksNavigator(document);
            bk.MoveToBookmark("Table");
            bk.ReplaceBookmarkContent(bodyPart);
            #endregion
            // Move to the text bookmark
            bk.MoveToBookmark("Text");
            //Deletes the bookmark content
            bk.DeleteBookmarkContent(true);
            // Inserting text inside the bookmark. This will preserve the source formatting
            bk.InsertText("Northwind Database contains the following table:");
            #region tableinsertion
            WTable tbl = new WTable(document);
            tbl.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.None;
            tbl.TableFormat.IsAutoResized = true;
            tbl.ResetCells(8, 2);
            IWParagraph paragraph;
            tbl.Rows[0].IsHeader = true;
            paragraph = tbl[0, 0].AddParagraph();
            paragraph.AppendText("Suppliers");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[0, 1].AddParagraph();
            paragraph.AppendText("1");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[1, 0].AddParagraph();
            paragraph.AppendText("Customers");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[1, 1].AddParagraph();
            paragraph.AppendText("1");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[2, 0].AddParagraph();
            paragraph.AppendText("Employees");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[2, 1].AddParagraph();
            paragraph.AppendText("3");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[3, 0].AddParagraph();
            paragraph.AppendText("Products");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[3, 1].AddParagraph();
            paragraph.AppendText("1");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[4, 0].AddParagraph();
            paragraph.AppendText("Inventory");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[4, 1].AddParagraph();
            paragraph.AppendText("2");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[5, 0].AddParagraph();
            paragraph.AppendText("Shippers");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[5, 1].AddParagraph();
            paragraph.AppendText("1");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[6, 0].AddParagraph();
            paragraph.AppendText("PO Transactions");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[6, 1].AddParagraph();
            paragraph.AppendText("3");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[7, 0].AddParagraph();
            paragraph.AppendText("Sales Transactions");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[7, 1].AddParagraph();
            paragraph.AppendText("7");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            bk.InsertTable(tbl);
            #endregion tableinsertion
            //Move to image bookmark
            bk.MoveToBookmark("Image");
            //Deletes the bookmark content
            bk.DeleteBookmarkContent(true);
            // Inserting image to the bookmark.
            IWPicture pic = bk.InsertParagraphItem(ParagraphItemType.Picture) as WPicture;

            FileStream imageStream = new FileStream(basePath + @"/images/Word/Northwind.png", FileMode.Open, FileAccess.Read);
            pic.LoadImage(imageStream);
            pic.WidthScale = 50f;  // It reduce the image size because it don't fit 
            pic.HeightScale = 75f; // in document page.
            #endregion BookmarkNavigation

            FormatType type = FormatType.Docx;
            string filename = "Bookmark Navigation.docx";
            string contenttype = "application/vnd.ms-word.document.12";
            #region Document SaveOption
            //Save as .doc format
            if (Group1 == "WordDoc")
            {
                type = FormatType.Doc;
                filename = "Bookmark Navigation.doc";
                contenttype = "application/msword";
            }
            //Save as .xml format
            else if (Group1 == "WordML")
            {
                type = FormatType.WordML;
                filename = "Bookmark Navigation.xml";
                contenttype = "application/msword";
            }
            #endregion Document SaveOption
            MemoryStream ms = new MemoryStream();
            document.Save(ms, type);
            document.Close();
            ms.Position = 0;
            return File(ms, contenttype, filename);
        }
        #endregion
    }
}
