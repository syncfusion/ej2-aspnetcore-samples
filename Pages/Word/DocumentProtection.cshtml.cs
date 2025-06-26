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

public class DocumentProtection : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public DocumentProtection(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public ActionResult OnPost(string Protection_Type, string Password1, string EditableRangeOption)
    {
        WordDocument document;
        ProtectionType protectionType;
        string basePath = _hostingEnvironment.WebRootPath;
        string dataPath = string.Empty;
        //Loads the template document.
        if (Protection_Type == "AllowOnlyFormFields")
        {
            dataPath = basePath + @"/Word/TemplateFormFields.docx";
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            document = new WordDocument(fileStream, FormatType.Docx);
            fileStream.Dispose();
            fileStream = null;
            // Sets the protection type as allow only Form Fields.
            protectionType = ProtectionType.AllowOnlyFormFields;
        }
        else if (Protection_Type == "AllowOnlyComments")
        {
            dataPath = basePath + @"/Word/TemplateComments.docx";
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            document = new WordDocument(fileStream, FormatType.Docx);
            fileStream.Dispose();
            fileStream = null;
            if (EditableRangeOption == "EditableRange")
                // If the "Make part of the document editable for everyone" checkbox is checked,
                // add editable ranges to allow unrestricted editing in specific sections.
                AddEditableRange(document);
            // Sets the protection type as allow only Comments.
            protectionType = ProtectionType.AllowOnlyComments;
        }
        else if (Protection_Type == "AllowOnlyRevisions")
        {
            dataPath = basePath + @"/Word/TemplateRevisions.docx";
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            document = new WordDocument(fileStream, FormatType.Docx);
            fileStream.Dispose();
            fileStream = null;
            // Enables track changes in the document.
            document.TrackChanges = true;
            // Sets the protection type as allow only Revisions.
            protectionType = ProtectionType.AllowOnlyRevisions;
        }
		else if (Protection_Type == "AllowOnlyReading")
        {
            dataPath = basePath + @"/Word/TemplateReading.docx";
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            document = new WordDocument(fileStream, FormatType.Docx);
            fileStream.Dispose();
            fileStream = null;
            if(EditableRangeOption == "EditableRange")
                // If the "Make part of the document editable for everyone" checkbox is checked,
                // add editable ranges to allow unrestricted editing in specific sections.
                AddEditableRange(document);
            // Set the protection type of the entire document to 'AllowOnlyReading'
            // Only the specified editable ranges will remain editable
            protectionType = ProtectionType.AllowOnlyReading;
        }
        else
        {
            dataPath = basePath + @"/Word/TemplateFormFields.docx";
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            document = new WordDocument(fileStream, FormatType.Docx);
            fileStream.Dispose();
            fileStream = null;
            // Sets the protection type as allow only Form Fields.
            protectionType = ProtectionType.AllowOnlyFormFields;
        }

        // Enforces protection of the document.
        if (string.IsNullOrEmpty(Password1))
            document.Protect(protectionType);
        else
            document.Protect(protectionType, Password1);

        FormatType type = FormatType.Docx;
        string filename = Protection_Type + ".docx";
        string contenttype = "application/vnd.ms-word.document.12";

        MemoryStream ms = new MemoryStream();
        document.Save(ms, type);
        document.Close();
        ms.Position = 0;
        return File(ms, contenttype, filename);
    }
    private void AddEditableRange(WordDocument document)
    {
        // Access the paragraph
        WParagraph paragraph = document.Sections[0].Body.ChildEntities[5] as WParagraph;
        // Create a new editable range start
        EditableRangeStart editableRangeStart = new EditableRangeStart(document);
        // Insert the editable range start at the beginning of the selected paragraph
        paragraph.ChildEntities.Insert(0, editableRangeStart);
        // Set the editor group for the editable range to allow everyone to edit
        editableRangeStart.EditorGroup = EditorType.Everyone;
        // Append an editable range end to close the editable region
        paragraph.AppendEditableRangeEnd();

        // Access the first table in the first section of the document
        WTable table = document.Sections[0].Tables[0] as WTable;
        // Access the paragraph in the third row and third column of the table
        paragraph = table[2, 2].ChildEntities[0] as WParagraph;
        // Create a new editable range start for the table cell paragraph
        editableRangeStart = new EditableRangeStart(document);
        // Insert the editable range start at the beginning of the paragraph
        paragraph.ChildEntities.Insert(0, editableRangeStart);
        // Set the editor group for the editable range to allow everyone to edit
        editableRangeStart.EditorGroup = EditorType.Everyone;
        // Apply editable range to second column only
        editableRangeStart.FirstColumn = 1;
        editableRangeStart.LastColumn = 1;
        // Access the paragraph
        paragraph = table[5, 2].ChildEntities[0] as WParagraph;
        // Append an editable range end to close the editable region
        paragraph.AppendEditableRangeEnd();
    }
}