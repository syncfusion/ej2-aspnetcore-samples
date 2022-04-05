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
        #region FootnotesandEndnotes
        public ActionResult FootnotesandEndnotes(string Group1)
        {
            if (Group1 == null)
                return View();
            //A new document is created.            
            WordDocument document = new WordDocument();            
            //Create footnotes at the bottom of the page
            CreateFootNote(document);
            //Create endnotes at the end of the section
            CreateEndNote(document);           
            FormatType type = FormatType.Docx;
            string filename = "FootnotesAndEndnotes.docx";
            string contenttype = "application/vnd.ms-word.document.12";
            #region Document SaveOption
            //Save as .doc format
            if (Group1 == "WordDoc")
            {
                type = FormatType.Doc;
                filename = "FootnotesAndEndnotes.doc";
                contenttype = "application/msword";
            }
            //Save as .xml format
            else if (Group1 == "WordML")
            {
                type = FormatType.WordML;
                filename = "FootnotesAndEndnotes.xml";
                contenttype = "application/msword";
            }
            #endregion Document SaveOption
            MemoryStream ms = new MemoryStream();
            document.Save(ms, type);
            document.Close();
            ms.Position = 0;
            return File(ms, contenttype, filename);
        }
        #region Helper Methods
        #region CreateFootNote
        void CreateFootNote(WordDocument document)
        {
            //Add a new section to the document.
            IWSection section = document.AddSection();

            //Adding a new paragraph to the section.
            IWParagraph paragraph = section.AddParagraph();

            IWTextRange textRange = paragraph.AppendText("\t\t\t\t\tDemo for Footnote");
            textRange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.Black;
            textRange.CharacterFormat.Bold = true;
            textRange.CharacterFormat.FontSize = 20;

            section.AddParagraph();
            section.AddParagraph();
            paragraph = section.AddParagraph();
            WFootnote footnote = new WFootnote(document);
            footnote = paragraph.AppendFootnote(FootnoteType.Footnote);
            footnote.MarkerCharacterFormat.SubSuperScript = SubSuperScript.SuperScript;

            //Insert Text into the paragraph
            paragraph.AppendText("Google").CharacterFormat.Bold = true;
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;

            string basePath = _hostingEnvironment.WebRootPath;
            FileStream imageStream = new FileStream(basePath + @"/images/Word/google.png", FileMode.Open, FileAccess.Read);
            paragraph.AppendPicture(imageStream);
           

            paragraph = footnote.TextBody.AddParagraph();
            paragraph.AppendText(" Google is the most famous search engines in the Word ");

            //Adding a new paragraph to the section.
            paragraph = section.AddParagraph();

            paragraph = section.AddParagraph();
            footnote = paragraph.AppendFootnote(FootnoteType.Footnote);
            footnote.MarkerCharacterFormat.SubSuperScript = SubSuperScript.SuperScript;

            //Insert Text into the paragraph
            paragraph.AppendText("Yahoo").CharacterFormat.Bold = true;
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            imageStream = new FileStream(basePath + @"/images/Word/yahoo.gif", FileMode.Open, FileAccess.Read);
            paragraph.AppendPicture(imageStream);
         
            paragraph = footnote.TextBody.AddParagraph();
            paragraph.AppendText(" Yahoo experience makes it easier to discover the news and information that you care about most. ");

            //Adding a new paragraph to the section.
            paragraph = section.AddParagraph();

            paragraph = section.AddParagraph();
            footnote = paragraph.AppendFootnote(FootnoteType.Footnote);
            footnote.MarkerCharacterFormat.SubSuperScript = SubSuperScript.SuperScript;

            //Insert Text into the paragraph
            paragraph.AppendText("Northwind Traders").CharacterFormat.Bold = true;
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            imageStream = new FileStream(basePath + @"/images/Word/Northwind_logo.png", FileMode.Open, FileAccess.Read);
            paragraph.AppendPicture(imageStream);
            
            paragraph = footnote.TextBody.AddParagraph();
            paragraph.AppendText(" The Northwind sample database (Northwind.mdb) is included with all versions of Access. It provides data you can experiment with and database objects that demonstrate features you might want to implement in your own databases. ");

            //Setting number format for Footnote
            document.FootnoteNumberFormat = FootEndNoteNumberFormat.Arabic;

            //Setting Footnote position
            document.FootnotePosition = FootnotePosition.PrintAtBottomOfPage;
        }
        #endregion

        #region CreateEndNote
        void CreateEndNote(WordDocument document)
        {
            //Add a new section to the document.
            IWSection section = document.AddSection();

            //Adding a new paragraph to the section.
            IWParagraph paragraph = section.AddParagraph();

            IWTextRange textRange = paragraph.AppendText("\t\t\t\t\tDemo for Endnote");
            textRange.CharacterFormat.TextColor = Syncfusion.Drawing.Color.Black;
            textRange.CharacterFormat.Bold = true;
            textRange.CharacterFormat.FontSize = 20;

            section.AddParagraph();
            section.AddParagraph();
            paragraph = section.AddParagraph();
            WFootnote footnote = new WFootnote(document);
            footnote = paragraph.AppendFootnote(FootnoteType.Endnote);
            footnote.MarkerCharacterFormat.SubSuperScript = SubSuperScript.SuperScript;

            //Insert Text into the paragraph
            paragraph.AppendText("Google").CharacterFormat.Bold = true;
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            string basePath = _hostingEnvironment.WebRootPath;
            FileStream imageStream = new FileStream(basePath + @"/images/Word/google.png", FileMode.Open, FileAccess.Read);
            paragraph.AppendPicture(imageStream);
            

            paragraph = footnote.TextBody.AddParagraph();
            paragraph.AppendText(" Google is the most famous search engines in the Word ");

            section = document.AddSection();
            section.BreakCode = SectionBreakCode.NoBreak;
            //Adding a new paragraph to the section.
            paragraph = section.AddParagraph();

            paragraph = section.AddParagraph();
            footnote = paragraph.AppendFootnote(FootnoteType.Endnote);
            footnote.MarkerCharacterFormat.SubSuperScript = SubSuperScript.SuperScript;

            //Insert Text into the paragraph
            paragraph.AppendText("Yahoo").CharacterFormat.Bold = true;
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            imageStream = new FileStream(basePath + @"/images/Word/yahoo.gif", FileMode.Open, FileAccess.Read);
            paragraph.AppendPicture(imageStream);
           
            paragraph = footnote.TextBody.AddParagraph();
            paragraph.AppendText(" Yahoo experience makes it easier to discover the news and information that you care about most. ");

            section = document.AddSection();
            section.BreakCode = SectionBreakCode.NoBreak;
            //Adding a new paragraph to the section.
            paragraph = section.AddParagraph();

            paragraph = section.AddParagraph();
            footnote = paragraph.AppendFootnote(FootnoteType.Endnote);
            footnote.MarkerCharacterFormat.SubSuperScript = SubSuperScript.SuperScript;

            //Insert Text into the paragraph
            paragraph.AppendText("Northwind Traders").CharacterFormat.Bold = true;
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            imageStream = new FileStream(basePath + @"/images/Word/Northwind_logo.png", FileMode.Open, FileAccess.Read);
            paragraph.AppendPicture(imageStream);
            
            paragraph = footnote.TextBody.AddParagraph();
            paragraph.AppendText(" The Northwind sample database (Northwind.mdb) is included with all versions of Access. It provides data you can experiment with and database objects that demonstrate features you might want to implement in your own databases.  ");

            //Set the number format for the Endnote.
            document.EndnoteNumberFormat = Syncfusion.DocIO.FootEndNoteNumberFormat.LowerCaseRoman;
            document.RestartIndexForEndnote = Syncfusion.DocIO.EndnoteRestartIndex.DoNotRestart;
            //Set the Endnote position.
            document.EndnotePosition = Syncfusion.DocIO.EndnotePosition.DisplayEndOfSection;
        }
        #endregion
        #endregion
        #endregion FootnotesandEndnotes
    }
}