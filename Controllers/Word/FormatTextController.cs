#region Copyright Syncfusion Inc. 2001-2022
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using System.IO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Word
{
    public partial class WordController : Controller
    {
        string[] products = { "Mango", "Orange", "Grape", "Banana", "Apple", "Green Apple", "Water Melon", "Pine apple", "Guava", "Plums" };
        string[] forms = { "Delicious", "Frequent Item" };
        IWSection section1;
        IWParagraph paragraph = null;
        IWTextRange textRange = null;
        #region FormatText
        public ActionResult FormatText(string Group1)
        {
            if (Group1 == null)
                return View();
            //Random number generator.
            Random r = new Random();

            // List of FontNames.
            string[] fontNames = { "Arial" , "Times New Roman" , "Monotype Corsiva" , " Book Antiqua " ,
                                   "Bitstream Vera Sans" , "Comic Sans MS" , "Microsoft Sans Serif" , "Batang" };

            // Create a new document.
            WordDocument document = new WordDocument();

            // Adding a new section to the document.
            IWSection section = document.AddSection();

            // Adding a new paragraph to the section.
            IWParagraph paragraph = section.AddParagraph();

            paragraph.AppendText("This sample demonstrates various text and paragraph formatting support.");
            section.AddParagraph();
            section.AddParagraph();

            section = document.AddSection();
            section.BreakCode = SectionBreakCode.NoBreak;
            //Adding two columns to the section.
            section.AddColumn(250, 20);
            section.AddColumn(250, 20);

            #region Text Formatting
            //Create a TextRange
            IWTextRange text = null;

            // Writing Text with different Formatting styles.
            for (int i = 8, j = 0, k = 0; i <= 20; i++, j++, k++)
            {
                if (j >= fontNames.Length) j = 0;
                paragraph = section.AddParagraph();
                text = paragraph.AppendText("This is " + "[" + fontNames[j] + "]");
                text.CharacterFormat.FontName = fontNames[j];
                text.CharacterFormat.UnderlineStyle = (UnderlineStyle)k;
                text.CharacterFormat.FontSize = i;
                text.CharacterFormat.TextColor = Syncfusion.Drawing.Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
            }

            // More formatting options.
            section.AddParagraph();
            paragraph.ParagraphFormat.ColumnBreakAfter = true;
            paragraph = section.AddParagraph();
            text = paragraph.AppendText("More formatting Options List...");
            text.CharacterFormat.FontName = fontNames[2];
            text.CharacterFormat.FontSize = 18;

            section.AddParagraph();
            paragraph = section.AddParagraph();
            paragraph.AppendText("AllCaps \n\n").CharacterFormat.AllCaps = true;
            paragraph.AppendText("Bold \n\n").CharacterFormat.Bold = true;
            paragraph.AppendText("DoubleStrike \n\n").CharacterFormat.DoubleStrike = true;
            paragraph.AppendText("Emboss \n\n").CharacterFormat.Emboss = true;
            paragraph.AppendText("Engrave \n\n").CharacterFormat.Engrave = true;
            paragraph.AppendText("Italic \n\n").CharacterFormat.Italic = true;
            paragraph.AppendText("Shadow \n\n").CharacterFormat.Shadow = true;
            paragraph.AppendText("SmallCaps \n\n").CharacterFormat.SmallCaps = true;
            paragraph.AppendText("Strikeout \n\n").CharacterFormat.Strikeout = true;
            paragraph.AppendText("Some Text");
            paragraph.AppendText("SubScript \n\n").CharacterFormat.SubSuperScript = SubSuperScript.SubScript;
            paragraph.AppendText("Some Text");
            paragraph.AppendText("SuperScript \n\n").CharacterFormat.SubSuperScript = SubSuperScript.SuperScript;
            paragraph.AppendText("TextBackgroundColor \n\n").CharacterFormat.TextBackgroundColor = Syncfusion.Drawing.Color.LightBlue;
            #endregion

            #region Paragraph formattings

            section = document.AddSection();
            section.BreakCode = SectionBreakCode.NewPage;
            paragraph = section.AddParagraph();
            paragraph.AppendText("Following paragraphs illustrates various paragraph formattings");

            paragraph = section.AddParagraph();
            paragraph.AppendText("We will use this paragraph to illustrate several Microsoft Word features using Essential DocIO. It will be used to illustrate Space Before, Space After, and Line Spacing. Space Before tells Microsoft Word how much space to leave before the paragraph. Space After tells Microsoft Word how much space to leave after the paragraph. Line Spacing sets the space between lines within a paragraph.It also explains about first line indentation,backcolor and paragraph border.");
            paragraph.ParagraphFormat.BeforeSpacing = 20f;
            paragraph.ParagraphFormat.AfterSpacing = 30f;
            paragraph.ParagraphFormat.BackColor = Syncfusion.Drawing.Color.LightGray;
            paragraph.ParagraphFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
            paragraph.ParagraphFormat.FirstLineIndent = 20f;
            paragraph.ParagraphFormat.LineSpacing = 20f;

            paragraph = section.AddParagraph();
            paragraph.AppendText("This is a sample paragraph. It is used to illustrate alignment. Left-justified text is aligned on the left. Right-justified text is aligned with on the right. Centered text is centered between the left and right margins. You can use Center to center your titles. Justified text is flush on both sides.");
            paragraph.ParagraphFormat.LineSpacing = 20f;
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
            paragraph.ParagraphFormat.LineSpacingRule = LineSpacingRule.Exactly;

            section.AddParagraph();

            //Adding a new paragraph to the section.
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.Keep = true;
            paragraph.AppendText("KEEP TOGETHER").CharacterFormat.Bold = true;
            paragraph.AppendText("This is a sample paragraph. It is used to illustrate Keep together of MsWord. You can control where Microsoft Word positions automatic page breaks (page break: The point at which one page ends and another begins. Microsoft Word inserts an 'automatic' (or soft) page break for you, or you can force a page break at a specific location by inserting a 'manual' (or hard) page break.) by setting pagination options.It keeps the lines in a paragraph together when there is page break").CharacterFormat.FontSize = 12f;
            for (int i = 0; i < 10; i++)
            {
                paragraph.AppendText("Text Body_Text Body_Text Body_Text Body_Text Body_Text Body_Text Body").CharacterFormat.FontSize = 12f;
                paragraph.ParagraphFormat.LineSpacing = 20f;
            }
            paragraph.AppendText("KEEP TOGETHER END").CharacterFormat.Bold = true;
            #endregion

            #region Bullets and Numbering
            // Adding a new section to the document.
            section = document.AddSection();
            // Adding a new paragraph to the document.
            paragraph = section.AddParagraph();
            // Writing text to the current paragraph.
            paragraph.AppendText("This document demonstrates the Bullets and Numbering functionality available in Essential DocIO");

            //Add a new section
            section1 = document.AddSection();
            //Adding two columns to the section.
            section1.Columns.Add(new Column(document));
            section1.Columns.Add(new Column(document));
            //Set the columns to be of equal width.
            section1.MakeColumnsEqual();

            // Set section break code as NoBreak. 
            section1.BreakCode = SectionBreakCode.NoBreak;

            // Set formatting.
            ProductDetailsInBullets();

            // Set Formatting.
            ProductDetailsInNumbers();
            #endregion  Bullets and Numbering

            FormatType type = FormatType.Docx;
            string filename = "FormatText.docx";
            string contenttype = "application/vnd.ms-word.document.12";
            #region Document SaveOption
            //Save as .doc format
            if (Group1 == "WordDoc")
            {
                type = FormatType.Doc;
                filename = "FormatText.doc";
                contenttype = "application/msword";
            }
            //Save as .xml format
            else if (Group1 == "WordML")
            {
                type = FormatType.WordML;
                filename = "FormatText.xml";
                contenttype = "application/msword";
            }
            #endregion Document SaveOption
            MemoryStream ms = new MemoryStream();
            document.Save(ms, type);
            document.Close();
            ms.Position = 0;
            return File(ms, contenttype, filename);
        }
        #region ProductDetailsInBullets
        private void ProductDetailsInBullets()
        {
            // Adding a new paragraph to the document.
            section1.AddParagraph();
            paragraph = section1.AddParagraph();

            // Writing text to the document with formatting.
            textRange = paragraph.AppendText("List of Fruits.");
            paragraph.ListFormat.ApplyDefBulletStyle();
            textRange.CharacterFormat.FontName = "Monotype Corsiva";
            textRange.CharacterFormat.FontSize = 15;

            // Writing Product details to the document with the specified list type.
            section1.AddParagraph();
            foreach (string s in products)
            {
                section1.AddParagraph();
                paragraph = section1.AddParagraph();
                paragraph.AppendText(s);
                paragraph.ListFormat.ContinueListNumbering();
                paragraph.ListFormat.ListLevelNumber = 1;

                section1.AddParagraph();
                foreach (string s1 in forms)
                {
                    if (String.Equals(s, "Plums"))
                    {
                        paragraph = section1.AddParagraph();
                        paragraph.AppendText(s1);
                        paragraph.ListFormat.ContinueListNumbering();
                        paragraph.ListFormat.ListLevelNumber = 2;

                        break;
                    }
                    else
                    {
                        paragraph = section1.AddParagraph();
                        paragraph.AppendText(s1);
                        paragraph.ListFormat.ContinueListNumbering();
                        paragraph.ListFormat.ListLevelNumber = 2;
                    }
                }
            }
        }
        #endregion

        #region ProductDetailsInNumbers
        private void ProductDetailsInNumbers()
        {
            // Adding a new paragraph to the document.
            section1.AddParagraph();
            paragraph = section1.AddParagraph();

            // Writing text to the document with formatting.
            textRange = paragraph.AppendText("List of Fruits.");
            paragraph.ListFormat.ApplyDefNumberedStyle();
            textRange.CharacterFormat.FontName = "Monotype Corsiva";
            textRange.CharacterFormat.FontSize = 15;

            // Writing Product details to the document with the specified list type.
            section1.AddParagraph();
            foreach (string s in products)
            {
                section1.AddParagraph();
                paragraph = section1.AddParagraph();
                paragraph.AppendText(s);
                paragraph.ListFormat.ContinueListNumbering();

                paragraph.ListFormat.ListLevelNumber = 1;
                section1.AddParagraph();
                foreach (string s1 in forms)
                {
                    if (String.Equals(s, "Plums"))
                    {
                        paragraph = section1.AddParagraph();
                        paragraph.AppendText(s1);
                        paragraph.ListFormat.ContinueListNumbering();

                        paragraph.ListFormat.ListLevelNumber = 2;
                        break;
                    }
                    else
                    {
                        paragraph = section1.AddParagraph();
                        paragraph.AppendText(s1);
                        paragraph.ListFormat.ContinueListNumbering();

                        paragraph.ListFormat.ListLevelNumber = 2;
                    }
                }
            }
        }
        #endregion
        #endregion FormatText
    }
}
