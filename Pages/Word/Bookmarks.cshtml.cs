#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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

public class Bookmarks : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public Bookmarks(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public ActionResult OnPost(string Group1)
    {
        if (Group1 == null)
            return null;
            // return View();

        #region BookmarkCreation

        // Creating a new document.
        WordDocument document = new WordDocument();
        // Adding a section to the document.
        IWSection section = document.AddSection();
        // Adding a new paragraph to the section.
        IWParagraph paragraph = section.AddParagraph();
        // Writing text
        paragraph.AppendText("This document demonstrates Essential DocIO's Bookmark functionality.").CharacterFormat
            .FontSize = 14f;
        // Adding paragraph to the section.
        section.AddParagraph();
        paragraph = section.AddParagraph();
        paragraph.AppendText("1. Inserting Bookmark Text").CharacterFormat.FontSize = 12f;

        // Adding paragraph to the section.
        section.AddParagraph();
        paragraph = section.AddParagraph();

        // BookmarkStart.
        paragraph.AppendBookmarkStart("Bookmark");
        // Write bookmark
        paragraph.AppendText("Bookmark Text");
        // BookmarkEnd.
        paragraph.AppendBookmarkEnd("Bookmark");

        // Adding paragraph to the section.
        section.AddParagraph();
        paragraph = section.AddParagraph();
        // Indicating hidden bookmark text start.
        paragraph.AppendBookmarkStart("_HiddenText");
        // Writing bookmark text
        paragraph.AppendText("2. Hidden Bookmark Text").CharacterFormat.Font =
            new Syncfusion.Drawing.Font("Comic Sans MS", 10);
        // Indicating hidden bookmark text end.
        paragraph.AppendBookmarkEnd("_HiddenText");

        section.AddParagraph();
        paragraph = section.AddParagraph();
        paragraph.AppendText("3. Nested Bookmarks").CharacterFormat.FontSize = 12f;

        // Writing nested bookmarks
        section.AddParagraph();
        paragraph = section.AddParagraph();
        paragraph.AppendBookmarkStart("Main");
        paragraph.AppendText(" Main data ");
        paragraph.AppendBookmarkStart("Nested");
        paragraph.AppendText(" Nested data ");
        paragraph.AppendBookmarkStart("NestedNested");
        paragraph.AppendText(" Nested Nested ");
        paragraph.AppendBookmarkEnd("NestedNested");
        paragraph.AppendText(" data Nested ");
        paragraph.AppendBookmarkEnd("Nested");
        paragraph.AppendText(" Data Main ");
        paragraph.AppendBookmarkEnd("Main");

        #endregion BookmarkCreation

        FormatType type = FormatType.Docx;
        string filename = "Bookmarks.docx";
        string contenttype = "application/vnd.ms-word.document.12";

        #region Document SaveOption

        //Save as .doc format
        if (Group1 == "WordDoc")
        {
            type = FormatType.Doc;
            filename = "Bookmarks.doc";
            contenttype = "application/msword";
        }
        else if (Group1 == "WordML")
        {
            type = FormatType.WordML;
            filename = "Bookmarks.xml";
            contenttype = "application/msword";
        }

        #endregion Document SaveOption

        MemoryStream ms = new MemoryStream();
        document.Save(ms, type);
        document.Close();
        ms.Position = 0;
        return File(ms, contenttype, filename);
    }
}