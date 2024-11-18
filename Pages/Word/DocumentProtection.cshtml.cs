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

    public ActionResult OnPost(string Protection_Type, string Password1, string Group2)
    {
        if (Group2 == null)
            return null;
            // return View();
        WordDocument document;
        ProtectionType protectionType;
        string basePath = _hostingEnvironment.WebRootPath;
        string dataPath = string.Empty;
        //Loads the template document.
        if (Protection_Type == "AllowOnlyFormFields")
        {
            dataPath = basePath + @"/Word/TemplateFormFields.doc";
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            document = new WordDocument(fileStream, FormatType.Doc);
            fileStream.Dispose();
            fileStream = null;
            // Sets the protection type as allow only Form Fields.
            protectionType = ProtectionType.AllowOnlyFormFields;
        }
        else if (Protection_Type == "AllowOnlyComments")
        {
            dataPath = basePath + @"/Word/TemplateComments.doc";
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            document = new WordDocument(fileStream, FormatType.Doc);
            fileStream.Dispose();
            fileStream = null;
            // Sets the protection type as allow only Comments.
            protectionType = ProtectionType.AllowOnlyComments;
        }
        else if (Protection_Type == "AllowOnlyRevisions")
        {
            dataPath = basePath + @"/Word/TemplateRevisions.doc";
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            document = new WordDocument(fileStream, FormatType.Doc);
            fileStream.Dispose();
            fileStream = null;
            // Enables track changes in the document.
            document.TrackChanges = true;
            // Sets the protection type as allow only Revisions.
            protectionType = ProtectionType.AllowOnlyRevisions;
        }
        else
        {
            dataPath = basePath + @"/Word/Essential DocIO.doc";
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            document = new WordDocument(fileStream, FormatType.Doc);
            fileStream.Dispose();
            fileStream = null;
            // Sets the protection type as allow only Reading.
            protectionType = ProtectionType.AllowOnlyReading;
        }

        // Enforces protection of the document.
        if (string.IsNullOrEmpty(Password1))
            document.Protect(protectionType);
        else
            document.Protect(protectionType, Password1);

        FormatType type = FormatType.Docx;
        string filename = "DocumentProtection.docx";
        string contenttype = "application/vnd.ms-word.document.12";

        #region Document SaveOption

        //Save as .doc format
        if (Group2 == "WordDoc")
        {
            type = FormatType.Doc;
            filename = "DocumentProtection.doc";
            contenttype = "application/msword";
        }
        //Save as .xml format
        else if (Group2 == "WordML")
        {
            type = FormatType.WordML;
            filename = "DocumentProtection.xml";
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