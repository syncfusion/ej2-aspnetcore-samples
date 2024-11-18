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
using Syncfusion.DocIORenderer;

namespace EJ2CoreSampleBrowser.Pages.Word;

public class TableOfContents : PageModel
{
    public string Message { get; set; }
    public void OnGet()
    {

    }

    public ActionResult OnPost(string Group1, string txtTitle, string StylesOption, string upperLevel, string lowerLevel, string chkPageNumbers, string chkAlign, string chkHyperlink, string chkOutline, string chkTableEntry, string chkUpdateTOC)
    {
        if (Group1 == null)
            return null;
        // return View();
        string filename = "";
        string contenttype = "";
        MemoryStream ms = new MemoryStream();
        WordDocument doc = new WordDocument();
        doc.EnsureMinimal();

        WParagraph para = doc.LastParagraph;
        para.AppendText("Essential DocIO - Table of Contents");
        para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
        para.ApplyStyle(BuiltinStyle.Heading4);

        para = doc.LastSection.AddParagraph() as WParagraph;
        para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
        para.ApplyStyle(BuiltinStyle.Heading4);

        if (chkUpdateTOC != "UpdateTOC")
            para.AppendText("Select TOC and press F9 to update the Table of Contents").CharacterFormat.HighlightColor = Syncfusion.Drawing.Color.Yellow;

        para = doc.LastSection.AddParagraph() as WParagraph;
        string title = txtTitle + "\n";
        para.AppendText(title);
        para.ApplyStyle(BuiltinStyle.Heading4);

        //Insert TOC
        TableOfContent toc = para.AppendTOC(1, 3);

        para.ApplyStyle(BuiltinStyle.Heading4);

        //Apply built-in paragraph formatting
        WSection section = doc.LastSection;

        if (StylesOption == "Default")
        {
            #region Default Styles
            WParagraph newPara = section.AddParagraph() as WParagraph;
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendBreak(BreakType.PageBreak);
            WTextRange text = newPara.AppendText("Document with Default styles") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading1);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading1 of built in style. This sample demonstrates the TOC insertion in a word document. Note that DocIO can only insert TOC field in a word document. It can not refresh or create TOC field. MS Word refreshes the TOC field after insertion. Please update the field or press F9 key to refresh the TOC.");

            section.AddParagraph();
            newPara = section.AddParagraph() as WParagraph;
            text = newPara.AppendText("Section1") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading2);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading2 of built in style. A document can contain any number of sections. Sections are used to apply same formatting for a group of paragraphs. You can insert sections by inserting section breaks.");

            section.AddParagraph();
            newPara = section.AddParagraph() as WParagraph;
            text = newPara.AppendText("Paragraph1") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading3);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading3 of built in style. Each section contains any number of paragraphs. A paragraph is a set of statements that gives a meaning for the text.");

            section.AddParagraph();
            newPara = section.AddParagraph() as WParagraph;
            text = newPara.AppendText("Paragraph2") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading3);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading3 of built in style. This demonstrates the paragraphs at the same level and style as that of the previous one. A paragraph can have any number formatting. This can be attained by formatting each text range in the paragraph.");

            section.AddParagraph();
            section = doc.AddSection() as WSection;
            section.BreakCode = SectionBreakCode.NewPage;
            newPara = section.AddParagraph() as WParagraph;
            text = newPara.AppendText("Section2") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading2);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading2 of built in style. A document can contain any number of sections. Sections are used to apply same formatting for a group of paragraphs. You can insert sections by inserting section breaks.");

            section.AddParagraph();
            newPara = section.AddParagraph() as WParagraph;
            text = newPara.AppendText("Paragraph1") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading3);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading3 of built in style. Each section contains any number of paragraphs. A paragraph is a set of statements that gives a meaning for the text.");

            section.AddParagraph();
            newPara = section.AddParagraph() as WParagraph;
            text = newPara.AppendText("Paragraph2") as WTextRange;
            newPara.ApplyStyle(BuiltinStyle.Heading3);
            newPara = section.AddParagraph() as WParagraph;
            newPara.AppendText("This is the heading3 of built in style. This demonstrates the paragraphs at the same level and style as that of the previous one. A paragraph can have any number formatting. This can be attained by formatting each text range in the paragraph.");
            #endregion
        }
        else
        {
            #region Custom styles
            //Custom styles.
            WParagraphStyle pStyle1 = (WParagraphStyle)doc.AddParagraphStyle("MyStyle1");
            WParagraphStyle pStyle2 = (WParagraphStyle)doc.AddParagraphStyle("MyStyle2");
            WParagraphStyle pStyle3 = (WParagraphStyle)doc.AddParagraphStyle("MyStyle3");

            //Set the Heading Styles to false in order to define custom levels to TOC.
            toc.UseHeadingStyles = false;

            //Set the TOC level style which determines; based on which the TOC should be created.
            toc.SetTOCLevelStyle(1, "MyStyle1");
            toc.SetTOCLevelStyle(2, "MyStyle2");
            toc.SetTOCLevelStyle(3, "MyStyle3");
            section = doc.AddSection() as WSection;

            pStyle1.CharacterFormat.FontName = "Cambria";
            pStyle1.CharacterFormat.FontSize = 30f;

            para = section.AddParagraph() as WParagraph;

            WTextRange text = para.AppendText("Document with Custom Styles") as WTextRange;
            para.ParagraphFormat.OutlineLevel = OutlineLevel.Level1;
            para.ApplyStyle("MyStyle1");
            para = doc.LastSection.AddParagraph() as WParagraph;
            para.AppendText("This is the heading1 of built in style. This sample demonstrates the TOC insertion in a word document. Note that DocIO can only insert TOC field in a word document. It can not refresh or create TOC field. MS Word refreshes the TOC field after insertion. Please update the field or press F9 key to refresh the TOC.");

            pStyle2.CharacterFormat.FontName = "Cambria";
            pStyle2.CharacterFormat.FontSize = 20f;

            doc.LastSection.AddParagraph();

            para = doc.LastSection.AddParagraph() as WParagraph;
            text = para.AppendText("Section1") as WTextRange;
            para.ParagraphFormat.OutlineLevel = OutlineLevel.Level2;
            para.ApplyStyle("MyStyle2");
            para = doc.LastSection.AddParagraph() as WParagraph;
            para.AppendText("This is the heading2 of built in style. A document can contain any number of sections. Sections are used to apply same formatting for a group of paragraphs. You can insert sections by inserting section breaks.");

            pStyle3.CharacterFormat.FontName = "Cambria";
            pStyle3.CharacterFormat.FontSize = 14f;

            doc.LastSection.AddParagraph();

            para = doc.LastSection.AddParagraph() as WParagraph;
            text = para.AppendText("Section2") as WTextRange;
            para.ParagraphFormat.OutlineLevel = OutlineLevel.Level3;
            para.ApplyStyle("MyStyle3");
            para = doc.LastSection.AddParagraph() as WParagraph;
            para.AppendText("This is the heading2 of built in style. A document can contain any number of sections. Sections are used to apply same formatting for a group of paragraphs. You can insert sections by inserting section breaks.");
            #endregion
        }
        if (int.Parse(upperLevel) < int.Parse(lowerLevel))
        {
            Message = string.Format("Not a valid heading level range. UpperHeadingLevel must be greater than LowerHeadingLevel.");
            return null;
        }
        else
        {
            toc.IncludePageNumbers = chkPageNumbers == "PageNumbers" ? true : false;
            toc.RightAlignPageNumbers = chkAlign == "Align" ? true : false;
            toc.UseHyperlinks = chkHyperlink == "Hyperlink" ? true : false;
            toc.LowerHeadingLevel = int.Parse(lowerLevel);
            toc.UpperHeadingLevel = int.Parse(upperLevel);

            //Right click text. Select Paragraph option. Set OutlineLevel. Update TOC to see the text added in TOC.
            toc.UseOutlineLevels = chkOutline == "Outline" ? true : false;

            //Select the text that should be marked as Table of contents.
            //Press ALT+SHIFT+O. A dialog box will appear with options to enter the text, select the table identifier and level.
            //Choose the table identifier and level for the test and click �Mark�. Update TOC to see the text added in TOC.
            //Sets the Table Identifier if necessary.
            //toc.TableID = "B";              
            toc.UseTableEntryFields = chkTableEntry == "TableEntry" ? true : false;

            //Updates the table of contents.
            if (chkUpdateTOC == "UpdateTOC")
                doc.UpdateTableOfContents();

            #region Document SaveOption
            //Save as .docx format
            if (Group1 == "WordDocx")
            {
                filename = "Table of Contents.docx";
                contenttype = "application/vnd.ms-word.document.12";
                doc.Save(ms, FormatType.Docx);
            }
            // Save as .doc format
            else if (Group1 == "WordDoc")
            {
                filename = "Table of Contents.doc";
                contenttype = "application/msword";
                doc.Save(ms, FormatType.Doc);
            }
            //Save as .xml format
            else if (Group1 == "WordML")
            {
                filename = "Table of Contents.xml";
                contenttype = "application/msword";
                doc.Save(ms, FormatType.WordML);
            }
            //Save as .pdf format
            else if (Group1 == "Pdf")
            {
                filename = "Table of Contents.pdf";
                contenttype = "application/pdf";
                Syncfusion.DocIORenderer.DocIORenderer renderer = new Syncfusion.DocIORenderer.DocIORenderer();
                Syncfusion.Pdf.PdfDocument pdfDoc = renderer.ConvertToPDF(doc);
                pdfDoc.Save(ms);
                pdfDoc.Close();
            }

            #endregion Document SaveOption

            doc.Close();
            ms.Position = 0;
            return File(ms, contenttype, filename);
        }
    }
}