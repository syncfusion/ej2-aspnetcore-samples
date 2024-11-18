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

public class DocumentSettings : PageModel
{
    public void OnGet()
    {
        
    }

    public ActionResult OnPost(string Group1)
    {
        if (Group1 == null)
            return null;
            // return View();
        //A new document is created.
        WordDocument document = new WordDocument();
        //Adding a section to the document.
        IWSection section = document.AddSection();
        //Adding a paragraph to the section.			
        IWParagraph paragraph = section.AddParagraph();

        #region DocVariable

        string name = "John Smith";
        string address = "Cary, NC";
        //Get the variables in the existing document
        DocVariables dVariable = document.Variables;
        //Add doc variables
        dVariable.Add("Customer Name", name);
        dVariable.Add("Customer Address", address);

        #endregion DocVariable

        #region Document Properties

        //Setting document Properties
        document.BuiltinDocumentProperties.Author = "Essential DocIO";
        document.BuiltinDocumentProperties.ApplicationName = "Essential DocIO";
        document.BuiltinDocumentProperties.Category = "Document Generator";
        document.BuiltinDocumentProperties.Comments = "This document was generated using Essential DocIO";
        document.BuiltinDocumentProperties.Company = "Syncfusion Inc";
        document.BuiltinDocumentProperties.Subject = "Native Word Generator";
        document.BuiltinDocumentProperties.Keywords = "Syncfusion";
        document.BuiltinDocumentProperties.Manager = "Sync Manager";
        document.BuiltinDocumentProperties.Title = "Essential DocIO";

        // Add a custom document Property
        document.CustomDocumentProperties.Add("My_Doc_Date", DateTime.Today);
        document.CustomDocumentProperties.Add("My_Doc", true);
        document.CustomDocumentProperties.Add("My_ID", 1031);
        document.CustomDocumentProperties.Add("My_Comment", "Essential DocIO");
        //Remove a custome property
        document.CustomDocumentProperties.Remove("My_Doc");

        #endregion Document Properties

        IWTextRange text = paragraph.AppendText("");
        text.CharacterFormat.FontName = "Calibri";
        text.CharacterFormat.FontSize = 13;
        text = paragraph.AppendText(
            "This document is created with various Document Properties Summary Information and page settings information \n\n You can view Document Properties through: File -> Properties -> Summary/Custom.");
        text.CharacterFormat.FontName = "Calibri";
        text.CharacterFormat.FontSize = 13;

        #region Page setup

        // Write section properties
        section.PageSetup.PageSize = new Syncfusion.Drawing.SizeF(500, 750);
        section.PageSetup.Orientation = PageOrientation.Landscape;
        section.PageSetup.Margins.Bottom = 100;
        section.PageSetup.Margins.Top = 100;
        section.PageSetup.Margins.Left = 50;
        section.PageSetup.Margins.Right = 50;
        section.PageSetup.PageBordersApplyType = PageBordersApplyType.AllPages;
        section.PageSetup.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.DoubleWave;
        section.PageSetup.Borders.Color = Syncfusion.Drawing.Color.DarkBlue;
        section.PageSetup.VerticalAlignment = PageAlignment.Middle;

        #endregion Page setup

        paragraph = section.AddParagraph();
        text = paragraph.AppendText("");
        text.CharacterFormat.FontName = "Calibri";
        text.CharacterFormat.FontSize = 13;

        text = paragraph.AppendText("\n\n You can view Page setup options through File -> PageSetup.");
        text.CharacterFormat.FontName = "Calibri";
        text.CharacterFormat.FontSize = 13;

        #region Get document variables

        paragraph = document.LastSection.AddParagraph();
        dVariable = document.Variables;
        text = paragraph.AppendText("\n\n Document Variables\n");
        text.CharacterFormat.FontName = "Calibri";
        text.CharacterFormat.FontSize = 13;
        text.CharacterFormat.Bold = true;
        text = paragraph.AppendText("\n" + dVariable.GetNameByIndex(1) + ": " + dVariable.GetValueByIndex(1));
        text.CharacterFormat.FontName = "Calibri";
        text.CharacterFormat.FontSize = 13;
        //Display the current variable count
        text = paragraph.AppendText("\n\nDocument Variables Count: " + dVariable.Count);
        text.CharacterFormat.FontName = "Calibri";
        text.CharacterFormat.FontSize = 13;

        #endregion Get document variables

        FormatType type = FormatType.Docx;
        string filename = "DocumentSettings.docx";
        string contenttype = "application/vnd.ms-word.document.12";

        #region Document SaveOption

        //Save as .doc format
        if (Group1 == "WordDoc")
        {
            type = FormatType.Doc;
            filename = "DocumentSettings.doc";
            contenttype = "application/msword";
        }
        //Save as .xml format
        else if (Group1 == "WordML")
        {
            type = FormatType.WordML;
            filename = "DocumentSettings.xml";
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